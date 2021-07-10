using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using S7.Net;
using System.Configuration;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;

namespace WcsParis
{
    public partial class FrmProbarCaidas : Form
    {
        private Plc oPLC = null;
        private cEntidades.cEnums.ExceptionCode errorcode;
        bool EstadoPLC = false;
        private cPing ping = new cPing();
        bool stop = true;
        private cRegistroErr oLog = new cRegistroErr();
        public cTagPlc oTagPLC = new cTagPlc();
        private static System.Threading.Timer temporizador3 = null;

        #region ENTIDADES
        public cDispositivos oDirecciones = new cDispositivos();
        private cEnt_Server oServer = new cEnt_Server();
        #endregion

        #region CONECTARPLC
        private void Direcciones()
        {
            oDirecciones.IpPLC = ConfigurationManager.AppSettings["IpPCL"].ToString();
            oDirecciones.PortPLC = Convert.ToInt16(ConfigurationManager.AppSettings["PortPLC"].ToString());
            oDirecciones.RackPLC = Convert.ToInt16(ConfigurationManager.AppSettings["RackPLC"].ToString());
            oDirecciones.SlotPLC = Convert.ToInt16(ConfigurationManager.AppSettings["SlotPLC"].ToString());
            oDirecciones.NumDb = Convert.ToInt16(ConfigurationManager.AppSettings["NumDb"].ToString());
        }

        private void cConPLC()
        {
            try
            {
                oPLC = new Plc(CpuType.S71200, oDirecciones.IpPLC, oDirecciones.RackPLC, oDirecciones.SlotPLC);

                oPLC.Open();

                EstadoPLC = oPLC.IsConnected;

                if (EstadoPLC)
                {

                }
                else
                {
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        #region LOGICA
        private cLogica.cServer lServer = new cLogica.cServer();
        private LGN_ListadoSensores _LGN_ListadoSensores = new LGN_ListadoSensores();
        #endregion

        #region Temporizador

        private void OnStart()
        {
            stop = false;
            TimerCallback tcb = new TimerCallback(OnElapsedTime);
            temporizador3 = new System.Threading.Timer(tcb, null, 1000, 1000);
        }

        private void OnElapsedTime(Object stateInfo)
        {
            Tarea();
        }

        private void OnStop()
        {
            stop = true;
            temporizador3.Dispose();
        }
        #endregion

        public FrmProbarCaidas()
        {
            InitializeComponent();
        }

        private void FrmProbarCaidas_Load(object sender, EventArgs e)
        {
            this.Show();

            CheckForIllegalCrossThreadCalls = false;
            Direcciones();

            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;

            if (ping.PingServidores(oDirecciones.IpPLC))
            {
                cConPLC();
                LeerPlc();
            }

            if (oTagPLC.Divertores == false)
            {
                RadioAUT.Checked = true;
                RadioMan.Checked = false;
            }
            else
            {
                RadioAUT.Checked = false;
                RadioMan.Checked = true;
            }

            this.Show();
            //OnStart();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                MDIFramework FrmPrincipal = new MDIFramework();
                //oPLC.Close();
                //OnStop();
                this.Close();
            }

        }

        #region LECTURA DIVERTORES
        private void LeerPlc()
        {
         
            try
            {
                oTagPLC.Divertores = (bool)oPLC.Read("DB3.DBX11.3");

                //oTagPLC.bool73 = (bool)oPLC.Read("DB8.DBX9.0");
                //oTagPLC.bool74 = (bool)oPLC.Read("DB8.DBX9.1");

                //oTagPLC.bool75 = (bool)oPLC.Read("DB8.DBX9.2");
                //oTagPLC.bool76 = (bool)oPLC.Read("DB8.DBX9.3");
                
                //oTagPLC.bool77 = (bool)oPLC.Read("DB8.DBX9.4");
                //oTagPLC.bool78 = (bool)oPLC.Read("DB8.DBX9.5");
                
                //oTagPLC.bool79 = (bool)oPLC.Read("DB8.DBX9.6");
                //oTagPLC.bool80 = (bool)oPLC.Read("DB8.DBX9.7");
                
                //oTagPLC.bool81 = (bool)oPLC.Read("DB8.DBX10.0");
                //oTagPLC.bool82 = (bool)oPLC.Read("DB8.DBX10.1");
                
                //oTagPLC.bool83 = (bool)oPLC.Read("DB8.DBX10.2");
                //oTagPLC.bool84 = (bool)oPLC.Read("DB8.DBX10.3");
                
                //oTagPLC.bool85 = (bool)oPLC.Read("DB8.DBX10.4");
                //oTagPLC.bool86 = (bool)oPLC.Read("DB8.DBX10.5");
                
                //oTagPLC.bool87 = (bool)oPLC.Read("DB8.DBX10.6");
                //oTagPLC.bool88 = (bool)oPLC.Read("DB8.DBX10.7");
                
                //oTagPLC.bool89 = (bool)oPLC.Read("DB8.DBX11.0");
                //oTagPLC.bool90 = (bool)oPLC.Read("DB8.DBX11.1");
                
                //oTagPLC.bool91 = (bool)oPLC.Read("DB8.DBX11.2");
                //oTagPLC.bool92 = (bool)oPLC.Read("DB8.DBX11.3");
                
                //oTagPLC.bool93 = (bool)oPLC.Read("DB8.DBX11.4");
                //oTagPLC.bool94 = (bool)oPLC.Read("DB8.DBX11.5");
                
                //oTagPLC.bool95 = (bool)oPLC.Read("DB8.DBX11.6");
                //oTagPLC.bool96 = (bool)oPLC.Read("DB8.DBX11.7");
                
                //oTagPLC.bool97 = (bool)oPLC.Read("DB8.DBX12.0");
                //oTagPLC.bool98 = (bool)oPLC.Read("DB8.DBX12.1");
                
                //oTagPLC.bool99 = (bool)oPLC.Read("DB8.DBX12.2");
                //oTagPLC.bool100 = (bool)oPLC.Read("DB8.DBX12.3");
                
                //oTagPLC.bool101 = (bool)oPLC.Read("DB8.DBX12.4");
                //oTagPLC.bool102 = (bool)oPLC.Read("DB8.DBX12.5");
                
                //oTagPLC.bool103 = (bool)oPLC.Read("DB8.DBX12.6");
                //oTagPLC.bool104 = (bool)oPLC.Read("DB8.DBX12.7");
                
                //oTagPLC.bool105 = (bool)oPLC.Read("DB8.DBX13.0");
                //oTagPLC.bool106 = (bool)oPLC.Read("DB8.DBX13.1");
                
                //oTagPLC.bool107 = (bool)oPLC.Read("DB8.DBX13.2");
                //oTagPLC.bool108 = (bool)oPLC.Read("DB8.DBX13.3");
                
                //oTagPLC.bool109 = (bool)oPLC.Read("DB8.DBX13.4");
                //oTagPLC.bool110 = (bool)oPLC.Read("DB8.DBX13.5");
                
                //oTagPLC.bool111 = (bool)oPLC.Read("DB8.DBX13.6");
                //oTagPLC.bool112 = (bool)oPLC.Read("DB8.DBX13.7");
                
                //oTagPLC.bool113 = (bool)oPLC.Read("DB8.DBX14.0");
                //oTagPLC.bool114 = (bool)oPLC.Read("DB8.DBX14.1");
                
                //oTagPLC.bool115 = (bool)oPLC.Read("DB8.DBX14.2");
                //oTagPLC.bool116 = (bool)oPLC.Read("DB8.DBX14.3");
                
                //oTagPLC.bool117 = (bool)oPLC.Read("DB8.DBX14.4");
                //oTagPLC.bool118 = (bool)oPLC.Read("DB8.DBX14.5");

                //oTagPLC = new cTagPlc();           
            }
            catch (Exception ex)
            {
                oLog.RegistroLog(ex.Message.ToString() + " funcion Leer Divertores");
                MessageBox.Show(ex.Message.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

        }

        private void EscribirPlc()
        {
            //byte[] db1Bytes = new byte[3358];
            //ushort db1WordVariable = 1234;
            //S7.Net.Types.Word.ToByteArray(db1WordVariable).CopyTo(db1Bytes, 0);
            //oPLC.WriteBytes(DataType.DataBlock, 1, 0, db1Bytes);                             
        }

        private void LimpiarTag()
        {
            //int NumberOfDB = 1;
            //byte[] db1Bytes = new byte[28];
            //oPLC.WriteBytes(DataType.DataBlock, NumberOfDB, 0, db1Bytes);        
        }
        #endregion

        private void Tarea() 
        {
            OnStop();

            LeerPlc();

            OnStart();
        }

        private void RadioAUT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea bloquear el controlador ?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                RadioAUT.Checked = true;
                RadioMan.Checked = false;

                oPLC.Write("DB3.DBX11.3", false);

                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                
            }
            else
            {
                RadioAUT.Checked = false;
                RadioMan.Checked = true;
            }
        }

        private void RadioMan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea modificar el controlador ?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                RadioAUT.Checked = false;
                RadioMan.Checked = true;

                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
                groupBox5.Enabled = true;

                oPLC.Write("DB3.DBX11.3", true);
        
            }
            else
            {
                RadioAUT.Checked = true;
                RadioMan.Checked = false;
            }
        }

        private void BtnL1D1_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX11.1", true);
            oPLC.Write("DB3.DBX11.1", false);

            oPLC.Write("DB3.DBX11.2", false);
            
        }

        private void BtnL1D2_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.5", false);
            oPLC.Write("DB3.DBX5.6", true);
            oPLC.Write("DB3.DBX5.5", true);
            oPLC.Write("DB3.DBX5.6", true); 
        }

        private void button22_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.7", true);
            oPLC.Write("DB3.DBX5.8", false);
            oPLC.Write("DB3.DBX5.7", false);
            oPLC.Write("DB3.DBX5.8", false);
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.7", false);
            oPLC.Write("DB3.DBX5.8", true);
            oPLC.Write("DB3.DBX5.7", true);
            oPLC.Write("DB3.DBX5.8", true);
        }

        private void BtnL3D1_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.9", true);
            oPLC.Write("DB3.DBX5.10", false);

            oPLC.Write("DB3.DBX5.9", false);
            oPLC.Write("DB3.DBX5.10", false); 
        }

        private void BtnL3D2_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.9", false);
            oPLC.Write("DB3.DBX5.10", true);

            oPLC.Write("DB3.DBX5.9", true);
            oPLC.Write("DB3.DBX5.10", true); 
        }

        private void button14_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.11", true);
            oPLC.Write("DB3.DBX5.12", false);

            oPLC.Write("DB3.DBX5.11", false);
            oPLC.Write("DB3.DBX5.12", false); 
        }

        private void button13_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.11", false);
            oPLC.Write("DB3.DBX5.12", true);

            oPLC.Write("DB3.DBX5.11", true);
            oPLC.Write("DB3.DBX5.12", true); 
        }

        private void button16_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.13", true);
            oPLC.Write("DB3.DBX5.14", false);

            oPLC.Write("DB3.DBX5.13", false);
            oPLC.Write("DB3.DBX5.14", false); 
        }

        private void button20_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.15", true);
            oPLC.Write("DB3.DBX5.16", false);

            oPLC.Write("DB3.DBX5.15", false);
            oPLC.Write("DB3.DBX5.16", false); 
        }

        private void button15_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.13", false);
            oPLC.Write("DB3.DBX5.14", true);

            oPLC.Write("DB3.DBX5.13", true);
            oPLC.Write("DB3.DBX5.14", true); 
        }

        private void button19_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.15", false);
            oPLC.Write("DB3.DBX5.16", true);

            oPLC.Write("DB3.DBX5.15", false);
            oPLC.Write("DB3.DBX5.16", false); 
        }

        private void button18_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.16", true);
            oPLC.Write("DB3.DBX5.17", false);

            oPLC.Write("DB3.DBX5.16", false);
            oPLC.Write("DB3.DBX5.17", false); 
        }

        private void button17_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.16", false);
            oPLC.Write("DB3.DBX5.17", true);

            oPLC.Write("DB3.DBX5.16", true);
            oPLC.Write("DB3.DBX5.17", true); 
        }

        private void button24_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.18", true);
            oPLC.Write("DB3.DBX5.19", false);

            oPLC.Write("DB3.DBX5.18", false);
            oPLC.Write("DB3.DBX5.19", false); 
        }

        private void button23_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.18", false);
            oPLC.Write("DB3.DBX5.19", true);

            oPLC.Write("DB3.DBX5.18", true);
            oPLC.Write("DB3.DBX5.19", true); 
        }

        private void button26_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.20", true);
            oPLC.Write("DB3.DBX5.21", false);

            oPLC.Write("DB3.DBX5.20", false);
            oPLC.Write("DB3.DBX5.21", false); 
        }

        private void button25_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.20", false);
            oPLC.Write("DB3.DBX5.21", true);

            oPLC.Write("DB3.DBX5.20", true);
            oPLC.Write("DB3.DBX5.21", true); 
        }

        private void button28_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.22", true);
            oPLC.Write("DB3.DBX5.23", false);

            oPLC.Write("DB3.DBX5.22", false);
            oPLC.Write("DB3.DBX5.23", false); 
        }

        private void button27_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.22", false);
            oPLC.Write("DB3.DBX5.23", true);

            oPLC.Write("DB3.DBX5.22", true);
            oPLC.Write("DB3.DBX5.23", true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.24", true);
            oPLC.Write("DB3.DBX5.25", false);

            oPLC.Write("DB3.DBX5.24", false);
            oPLC.Write("DB3.DBX5.25", false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.24", false);
            oPLC.Write("DB3.DBX5.25", true);

            oPLC.Write("DB3.DBX5.24", true);
            oPLC.Write("DB3.DBX5.25", true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.26", true);
            oPLC.Write("DB3.DBX5.27", false);

            oPLC.Write("DB3.DBX5.26", false);
            oPLC.Write("DB3.DBX5.27", false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.26", false);
            oPLC.Write("DB3.DBX5.27", true);

            oPLC.Write("DB3.DBX5.26", true);
            oPLC.Write("DB3.DBX5.27", true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.28", true);
            oPLC.Write("DB3.DBX5.29", false);

            oPLC.Write("DB3.DBX5.28", false);
            oPLC.Write("DB3.DBX5.29", false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.28", false);
            oPLC.Write("DB3.DBX5.29", true);

            oPLC.Write("DB3.DBX5.28", true);
            oPLC.Write("DB3.DBX5.29", true);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.30", true);
            oPLC.Write("DB3.DBX5.31", false);

            oPLC.Write("DB3.DBX5.30", false);
            oPLC.Write("DB3.DBX5.31", false);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.30", false);
            oPLC.Write("DB3.DBX5.31", true);

            oPLC.Write("DB3.DBX5.30", true);
            oPLC.Write("DB3.DBX5.31", true);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX9.1", true);
            oPLC.Write("DB3.DBX9.1", false);

            oPLC.Write("DB3.DBX9.1", true);
            oPLC.Write("DB3.DBX9.1", false);

        
        }

        private void button31_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.32", false);
            oPLC.Write("DB3.DBX5.33", true);

            oPLC.Write("DB3.DBX5.32", true);
            oPLC.Write("DB3.DBX5.33", true);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.34", true);
            oPLC.Write("DB3.DBX5.35", false);

            oPLC.Write("DB3.DBX5.34", false);
            oPLC.Write("DB3.DBX5.35", false);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.34", false);
            oPLC.Write("DB3.DBX5.35", true);

            oPLC.Write("DB3.DBX5.34", true);
            oPLC.Write("DB3.DBX5.35", true);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.36", true);
            oPLC.Write("DB3.DBX5.37", false);

            oPLC.Write("DB3.DBX5.36", true);
            oPLC.Write("DB3.DBX5.37", true);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.36", false);
            oPLC.Write("DB3.DBX5.37", true);

            oPLC.Write("DB3.DBX5.36", true);
            oPLC.Write("DB3.DBX5.37", true);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.38", true);
            oPLC.Write("DB3.DBX5.39", false);

            oPLC.Write("DB3.DBX5.38", false);
            oPLC.Write("DB3.DBX5.39", false);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.38", false);
            oPLC.Write("DB3.DBX5.39", true);

            oPLC.Write("DB3.DBX5.38", true);
            oPLC.Write("DB3.DBX5.39", true);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.40", true);
            oPLC.Write("DB3.DBX5.41", false);

            oPLC.Write("DB3.DBX5.40", false);
            oPLC.Write("DB3.DBX5.41", false);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.40", false);
            oPLC.Write("DB3.DBX5.41", true);

            oPLC.Write("DB3.DBX5.40", true);
            oPLC.Write("DB3.DBX5.41", true);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.42", true);
            oPLC.Write("DB3.DBX5.43", false);

            oPLC.Write("DB3.DBX5.42", false);
            oPLC.Write("DB3.DBX5.43", false);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.42", false);
            oPLC.Write("DB3.DBX5.43", true);

            oPLC.Write("DB3.DBX5.42", true);
            oPLC.Write("DB3.DBX5.43", true);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX10.5", true);
            oPLC.Write("DB3.DBX10.5", false);

            oPLC.Write("DB3.DBX10.6", true);
            oPLC.Write("DB3.DBX10.6", false);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.44", false);
            oPLC.Write("DB3.DBX5.45", true);

            oPLC.Write("DB3.DBX5.44", true);
            oPLC.Write("DB3.DBX5.45", true);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.46", true);
            oPLC.Write("DB3.DBX5.47", false);

            oPLC.Write("DB3.DBX5.46", false);
            oPLC.Write("DB3.DBX5.47", false);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX5.46", false);
            oPLC.Write("DB3.DBX5.47", true);

            oPLC.Write("DB3.DBX5.46", true);
            oPLC.Write("DB3.DBX5.47", true);
        }

        private void button9_Click(object sender, EventArgs e)
        {

            oPLC.Write("DB3.DBX11.1", true);
            oPLC.Write("DB3.DBX11.1", false);
                        
            oPLC.Write("DB3.DBX11.2", false);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX11.1", false);

            oPLC.Write("DB3.DBX11.2", true);
            oPLC.Write("DB3.DBX11.2", false);
           
        }

        private void button49_Click(object sender, EventArgs e)
        {
            oPLC.Write("DB3.DBX11.3", false);
        }

        private void RadioMan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button45_Click(object sender, EventArgs e)
        {

        }
        


    }

}
