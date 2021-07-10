using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;


namespace WcsParis
{
    public class cMD5
    {

        public static string Encriptar(string texto)
        {
            try
            {

                string key = "qualityinfosolutions"; //llave para encriptar datos

                byte[] keyArray;

                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

                //Se utilizan las clases de encriptación MD5

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                //Algoritmo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();

                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

                tdes.Clear();

                //se regresa el resultado en forma de una cadena
                texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);

            }
            catch (Exception)
            {

            }
            return texto;
        }

        public static string Desencriptar(string textoEncriptado)
        {
            try
            {
                string key = "qualityinfosolutions";
                byte[] keyArray;
                byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

                //algoritmo MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

                tdes.Clear();
                textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);

            }
            catch (Exception)
            {

            }
            return textoEncriptado;
        }



    }
}

//Imports System.IO
//Imports System.Text
//Imports System.Security.Cryptography
//Public Class MD5
//    Private des As New TripleDESCryptoServiceProvider 'Algorithmo TripleDES
//    Private hashmd5 As New MD5CryptoServiceProvider 'objeto md5
//    Private myKey As String = "MyKey2012" 'Clave secreta(puede alterarse)

//    Public Function Desencriptar(ByVal texto As String) As String
//        If Trim(texto) = "" Then
//            Desencriptar = ""
//        Else
//            des.Key = hashmd5.ComputeHash((New UnicodeEncoding).GetBytes(myKey))
//            des.Mode = CipherMode.ECB
//            Dim desencrypta As ICryptoTransform = des.CreateDecryptor()
//            Dim buff() As Byte = Convert.FromBase64String(texto)
//            Desencriptar = UnicodeEncoding.ASCII.GetString(desencrypta.TransformFinalBlock(buff, 0, buff.Length))
//        End If
//        Return Desencriptar
//    End Function

//    Public Function Encriptar(ByVal texto As String) As String
//        If Trim(texto) = "" Then
//            Encriptar = ""
//        Else
//            des.Key = hashmd5.ComputeHash((New UnicodeEncoding).GetBytes(myKey))
//            des.Mode = CipherMode.ECB
//            Dim encrypt As ICryptoTransform = des.CreateEncryptor()
//            Dim buff() As Byte = UnicodeEncoding.ASCII.GetBytes(texto)
//            Encriptar = Convert.ToBase64String(encrypt.TransformFinalBlock(buff, 0, buff.Length))
//        End If
//        Return Encriptar
//    End Function