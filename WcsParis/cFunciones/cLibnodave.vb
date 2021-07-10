Imports System
Imports Microsoft.VisualBasic
'Imports DLL_Entidades
'Imports DLL_Negocio

' Part of Libnodave, a free communication libray for Siemens S7 200/300/400
'  
' (C) Thomas Hergenhahn (thomas.hergenhahn@web.de) 2005
'
' Libnodave is free software; you can redistribute it and/or modify
' it under the terms of the GNU Library General Public License as published by
' the Free Software Foundation; either version 2, or (at your option)
' any later version.
'
' Libnodave is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU Library General Public License
' along with Libnodave; see the file COPYING.  If not, write to
' the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA.  
'

Public Class Libnodave_WinAC
    Public daveSerie As libnodave.daveOSserialType
    Public daveInter As libnodave.daveInterface
    Public daveConex As libnodave.daveConnection
    Public res As Integer
    Public buf(1000) As Byte
    Public Conectado As Boolean = False
    Public Mensaje As String
    Public Respuesta As Integer


    Public Function Conectar(ByVal Puerto As Integer, _
                             ByVal IP As String, _
                             ByVal Rack As Integer, _
                             ByVal Slot As Integer) As Boolean
        'Public Function Conectar(ByVal eConfig As ENT_Configuracion) As Boolean
        If Conectado Then
            Mensaje = "Conexión abortada, ya existe una conexión."
            Conectar = False
            Exit Function
        End If

        Mensaje = "Abriendo una conexión de Red..."

        Try
            daveSerie.rfd = libnodave.openSocket(Puerto, IP)
            daveSerie.wfd = daveSerie.rfd

            If daveSerie.rfd > 0 Then
                Mensaje = "Conexión OK, creando interface..."

                daveInter = New libnodave.daveInterface(daveSerie, "", _
                                                        0, _
                                                        libnodave.daveProtoISOTCP, _
                                                        libnodave.daveSpeed187k)
                'Make this longer if you have a very long response time
                daveInter.setTimeout(1000)
                res = daveInter.initAdapter

                Mensaje = "Inicialización del adaptador OK, creando conexión..."
                daveConex = New libnodave.daveConnection(daveInter, 0, Rack, Slot)
                res = daveConex.connectPLC()

                If res = 0 Then       ' init Adapter is ok
                    daveConex = New libnodave.daveConnection(daveInter, 0, Rack, Slot)  ' rack amd slot don't matter in case of MPI
                    Mensaje = "Conexión correcta, lista para operar."                                        
                End If

                Conectado = True
                Respuesta = 1
                Return True
            Else
                Mensaje = "Error de conexión " & libnodave.daveStrerror(Respuesta)
                Respuesta = 0
                Conectado = False
                Return False
            End If
        Catch ex As Exception
            cFichero.FicheroLog(ex.Message.ToString)
            Mensaje = "Error de conexión " & libnodave.daveStrerror(Respuesta)
            Return False
        End Try
       
    End Function

    Public Function Desconectar() As Boolean
        If Conectado Then
            daveConex.disconnectPLC()
            libnodave.closeSocket(daveSerie.rfd)
            Conectado = False
            Mensaje = "Conexión terminada."
            Desconectar = True
        Else
            Mensaje = "No existe conexión activa."
            Desconectar = False
        End If
    End Function

    Public Function LeerDatosPLC(ByVal NumDB As Integer,
                              ByVal Dir As Integer, _
                              ByVal NumBytes As Integer, _
                              ByRef oEntidadesPLC As ENT_Plc)

        Dim TipoDatos As New cTiposDeDatos

        If Conectado Then
            res = daveConex.readBytes(libnodave.daveFlags, 0, 10, 16, buf)
            If res = 0 Then
                TipoDatos.Texto1 = Str(daveConex.getS32)
            End If

            res = daveConex.readBytes(libnodave.daveInputs, 0, 96, 2, buf)
            If res = 0 Then
                TipoDatos.Texto2 = Str(daveConex.getU16)  'WORD 2 bytes
            End If

            res = daveConex.readBytes(libnodave.daveFlags, 68, 8, 4, buf)
            If res = 0 Then
                TipoDatos.Texto3 = Str(daveConex.getU32)  'DB68.DBW8 DWORD 4 bytes
            End If
        End If

        Return TipoDatos

    End Function

    Public Function EscribirDatosPLC()
        Dim x1 As Double = 12345.9
        Dim x2 As Integer = 123456
        Dim x3 As Short = 1234
        Dim x4 As Byte = 34

        If Conectado Then
            'write 4 bytes s7 float to MD4
            buf = BitConverter.GetBytes(libnodave.daveToPLCfloat(x1))
            res = daveConex.writeBytes(libnodave.daveFlags, 0, 4, 4, buf)

            'write 4 bytes s7 DWORD or DINT to MD12
            buf = BitConverter.GetBytes(libnodave.daveSwapIed_32(x2))
            res = daveConex.writeBytes(libnodave.daveFlags, 0, 12, 4, buf)

            'write 2 bytes s7 WORD or INT to MW568
            buf = BitConverter.GetBytes(libnodave.daveSwapIed_16(x3))
            res = daveConex.writeBytes(libnodave.daveFlags, 0, 568, 2, buf)

            'write byte to MB80
            buf(0) = x4
            res = daveConex.writeBytes(libnodave.daveFlags, 0, 80, 1, buf)

            'write 2 bytes s7 WORD or INT to DB34.DBW2
            buf = BitConverter.GetBytes(libnodave.daveSwapIed_16(x3))
            res = daveConex.writeBytes(libnodave.daveFlags, 34, 2, 2, buf)
        Else
            Mensaje = "No connection with PLC!"
        End If



    End Function

    Public Function EscribirBitPLC()
        Dim Adr As Integer
        Dim Par As Boolean = True

        Dim InputNum As Integer = 20 'input I20.3
        Dim BitNum As Integer = 3

        If Par Then
            buf(0) = 255 'write 1
        Else
            buf(0) = 0 'write 0
        End If
        If Conectado Then
            Adr = InputNum * 8 + BitNum

            'write Input I20.3
            res = daveConex.writeBits(libnodave.daveInputs, 0, Adr, 1, buf)

            'write Merke M20.3
            res = daveConex.writeBits(libnodave.daveFlags, 0, Adr, 1, buf)

            'write output Q20.3
            res = daveConex.writeBits(libnodave.daveOutputs, 0, Adr, 1, buf)
        Else
            Mensaje = "No connection with PLC!"
        End If
    End Function

    Public Function LeerBytePLC()
        Dim a As Byte
        If Conectado Then
            res = daveConex.readBytes(libnodave.daveInputs, 0, 0, 1, buf)
            If res = 0 Then
                a = daveConex.getU8

                If IsBitSet(a, 0) Then
                    'Panel1.BackColor = Color.Lime
                Else
                    'Panel1.BackColor = Color.DarkGreen
                End If

                If IsBitSet(a, 1) Then
                    'Panel2.BackColor = Color.Lime
                Else
                    'Panel2.BackColor = Color.DarkGreen
                End If
            Else
                Mensaje = "Read data. " + libnodave.daveStrerror(res)
            End If
        End If
    End Function

    Public Function IsBitSet(ByVal InByte As Byte, ByVal Bit As Byte) As Boolean
        'Is a n'th bit in InByte 1 of not?
        IsBitSet = ((InByte And (2 ^ Bit)) > 0)
    End Function

    '************************************
    '************************************funciones originales
    '************************************
    'Public Function LeerBytesDB(ByVal NumDB As Integer, _
    '                            ByVal Dir As Integer, _
    '                            ByVal NumBytes As Integer) As Boolean

    '    Dim Respuesta As Integer
    '    'Respuesta = daveConex.readBits(libnodave.daveDB, NumDB, Dir, NumBytes, BufferLectura)
    '    Respuesta = daveConex.readBytes(libnodave.daveDB, NumDB, Dir, NumBytes, BufferLectura)

    '    If Respuesta = 0 Then
    '        Mensaje = "Leídos " & NumBytes & " bytes a partir de la dirección " & _
    '                  Dir & " en el DB " & NumDB
    '        LeerBytesDB = True
    '    Else
    '        Mensaje = "Error al leer " & NumBytes & " bytes a partir de la dirección " & _
    '                  Dir & " en el DB " & NumDB
    '        LeerBytesDB = False
    '    End If

    'End Function

    'Public Function EscribirBytesDB(ByVal NumDB As Integer, _
    '                                ByVal Dir As Integer, _
    '                                ByVal NumBytes As Integer) As Boolean
    '    Dim Respuesta As Integer

    '    'Respuesta = daveConex.writeBits(libnodave.daveDB, NumDB, Dir, NumBytes, BufferEscritura)
    '    Respuesta = daveConex.writeBytes(libnodave.daveDB, NumDB, Dir, NumBytes, BufferEscritura)

    '    Respuesta = daveConex.writeBytes(libnodave.


    '    If Respuesta = 0 Then
    '        Mensaje = "Escritos " & NumBytes & " bytes a partir de la dirección " & _
    '                  Dir & " en el DB " & NumDB
    '        EscribirBytesDB = True
    '    Else
    '        Mensaje = "Error al escribir " & NumBytes & " bytes a partir de la dirección " & _
    '                  Dir & " en el DB " & NumDB
    '        EscribirBytesDB = False
    '    End If

    'End Function

End Class

