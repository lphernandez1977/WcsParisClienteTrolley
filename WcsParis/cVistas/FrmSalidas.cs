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
    public partial class FrmSalidas : Form
    {
        private Plc oPLC = null;
        //private cEntidades.cEnums.ExceptionCode errorcode;
        bool EstadoPLC = false;
        private cPing ping = new cPing();
        bool tIndice0 = false;
        bool tIndice1 = false;
        bool tIndice2 = false;
        bool tIndice3 = false;
        bool tIndice4 = false;
        private static System.Threading.Timer temporizador2 = null;
        bool stop = true;

        #region HILOS
        private static System.Threading.Timer temporizador = null;

        #endregion

        #region ENTIDADES
        public cDispositivos oDirecciones = new cDispositivos();
        public cTagPlc oTagPLC = new cTagPlc();
        private cEnt_Server oServer = new cEnt_Server();
        private cRegistroErr oLog = new cRegistroErr();
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
                    PConectado.Visible = true;
                    PNoConectado.Visible = false;
                    LblEstadoPLC.Visible = true;
                    LblEstadoPLC.Text = "Controlador En Linea";

                }
                else
                {
                    PConectado.Visible = false;
                    PNoConectado.Visible = true;
                    LblEstadoPLC.Visible = true;
                    LblEstadoPLC.Text = "Controlador Desconectado";
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
            TimerCallback tcb1 = new TimerCallback(OnElapsedTime);
            temporizador2 = new System.Threading.Timer(tcb1, null, 1000, 1000);
        }

        private void OnElapsedTime(Object stateInfo)
        {
            TareasTempo();
        }

        private void OnStop()
        {
            stop = true;
            temporizador2.Dispose();
        }
        #endregion

        public FrmSalidas()
        {
            InitializeComponent();
        }

        private void FrmSalidas_Load(object sender, EventArgs e)
        {
            this.Show();

            CheckForIllegalCrossThreadCalls = false;
            Direcciones();

            PNoConectado.Visible = true;
            PConectado.Visible = false;
            LblEstadoPLC.Visible = false;

            if (ping.PingServidores(oDirecciones.IpPLC))
            {
                cConPLC();
                LeerSalidas();
            }
            else
            {
                LblEstadoPLC.Visible = true;
                LblEstadoPLC.Text = "Controlador Desconectado";
            }
           
            OnStart();    
        }

        private void TareasTempo(object objeto)
        {
            //LeerSalidas();
        }

        private void LeerSalidas()
        {
            OnStop();

            try
            {
                #region SALIDAS
                oTagPLC.bool80 = (bool)oPLC.Read("DB8.DBX7.6");
                oTagPLC.bool81 = (bool)oPLC.Read("DB8.DBX7.7");
                oTagPLC.bool82 = (bool)oPLC.Read("DB8.DBX8.0");
                oTagPLC.bool83 = (bool)oPLC.Read("DB6.DBX8.1");
                oTagPLC.bool84 = (bool)oPLC.Read("DB6.DBX8.2");
                oTagPLC.bool85 = (bool)oPLC.Read("DB6.DBX8.3");
                oTagPLC.bool86 = (bool)oPLC.Read("DB6.DBX8.4");
                oTagPLC.bool87 = (bool)oPLC.Read("DB6.DBX8.5");
                oTagPLC.bool88 = (bool)oPLC.Read("DB6.DBX8.6");
                oTagPLC.bool89 = (bool)oPLC.Read("DB6.DBX8.7");
                oTagPLC.bool90 = (bool)oPLC.Read("DB6.DBX9.0");
                oTagPLC.bool91 = (bool)oPLC.Read("DB6.DBX9.1");
                oTagPLC.bool92 = (bool)oPLC.Read("DB6.DBX9.2");
                oTagPLC.bool93 = (bool)oPLC.Read("DB6.DBX9.3");
                oTagPLC.bool94 = (bool)oPLC.Read("DB6.DBX9.4");
                oTagPLC.bool95 = (bool)oPLC.Read("DB6.DBX9.5");
                oTagPLC.bool96 = (bool)oPLC.Read("DB6.DBX9.6");
                oTagPLC.bool97 = (bool)oPLC.Read("DB6.DBX9.7");
                oTagPLC.bool98 = (bool)oPLC.Read("DB6.DBX10.0");
                oTagPLC.bool99 = (bool)oPLC.Read("DB6.DBX10.1");
                oTagPLC.bool100 = (bool)oPLC.Read("DB6.DBX10.2");
                oTagPLC.bool101 = (bool)oPLC.Read("DB6.DBX10.3");
                oTagPLC.bool102 = (bool)oPLC.Read("DB6.DBX10.4");
                oTagPLC.bool103 = (bool)oPLC.Read("DB6.DBX10.5");
                oTagPLC.bool104 = (bool)oPLC.Read("DB6.DBX10.6");
                oTagPLC.bool105 = (bool)oPLC.Read("DB6.DBX10.7");
                oTagPLC.bool106 = (bool)oPLC.Read("DB6.DBX11.0");
                oTagPLC.bool107 = (bool)oPLC.Read("DB6.DBX11.0");
                oTagPLC.bool108 = (bool)oPLC.Read("DB6.DBX11.1");
                oTagPLC.bool109 = (bool)oPLC.Read("DB6.DBX11.2");
                oTagPLC.bool110 = (bool)oPLC.Read("DB6.DBX11.3");
                oTagPLC.bool111 = (bool)oPLC.Read("DB6.DBX11.4");
                oTagPLC.bool112 = (bool)oPLC.Read("DB6.DBX11.5");
                oTagPLC.bool113 = (bool)oPLC.Read("DB6.DBX11.6");
                oTagPLC.bool114 = (bool)oPLC.Read("DB6.DBX11.7");
                oTagPLC.bool115 = (bool)oPLC.Read("DB6.DBX12.0");
                oTagPLC.bool116 = (bool)oPLC.Read("DB6.DBX12.1");
                oTagPLC.bool117 = (bool)oPLC.Read("DB6.DBX12.2");
                oTagPLC.bool118 = (bool)oPLC.Read("DB6.DBX12.3");
                oTagPLC.bool119 = (bool)oPLC.Read("DB6.DBX12.4");
                oTagPLC.bool120 = (bool)oPLC.Read("DB6.DBX12.5");
                oTagPLC.bool121 = (bool)oPLC.Read("DB6.DBX12.6");
                oTagPLC.bool122 = (bool)oPLC.Read("DB6.DBX12.7");
                oTagPLC.bool123 = (bool)oPLC.Read("DB6.DBX13.0");
                oTagPLC.bool124 = (bool)oPLC.Read("DB6.DBX13.1");
                oTagPLC.bool125 = (bool)oPLC.Read("DB6.DBX13.2");
                oTagPLC.bool126 = (bool)oPLC.Read("DB6.DBX13.3");
                oTagPLC.bool127 = (bool)oPLC.Read("DB6.DBX13.4");
                oTagPLC.bool128 = (bool)oPLC.Read("DB6.DBX13.5");
                oTagPLC.bool129 = (bool)oPLC.Read("DB6.DBX13.6");
                oTagPLC.bool130 = (bool)oPLC.Read("DB6.DBX13.7");
                oTagPLC.bool131 = (bool)oPLC.Read("DB6.DBX14.0");
                oTagPLC.bool132 = (bool)oPLC.Read("DB6.DBX14.1");
                oTagPLC.bool133 = (bool)oPLC.Read("DB6.DBX14.2");
                oTagPLC.bool134 = (bool)oPLC.Read("DB6.DBX14.3");
                oTagPLC.bool135 = (bool)oPLC.Read("DB6.DBX14.4");
                oTagPLC.bool136 = (bool)oPLC.Read("DB6.DBX14.5");
                oTagPLC.bool137 = (bool)oPLC.Read("DB6.DBX14.6");
                oTagPLC.bool138 = (bool)oPLC.Read("DB6.DBX14.7");

                if (oTagPLC.bool80) { PB1.Visible = true; PB2.Visible = false; } else { PB1.Visible = false; PB2.Visible = true; }
                if (oTagPLC.bool81) { PB3.Visible = true; PB4.Visible = false; } else { PB3.Visible = false; PB4.Visible = true; }
                if (oTagPLC.bool82) { PB5.Visible = true; PB6.Visible = false; } else { PB5.Visible = false; PB6.Visible = true; }
                if (oTagPLC.bool83) { PB7.Visible = true; PB8.Visible = false; } else { PB7.Visible = false; PB8.Visible = true; }
                if (oTagPLC.bool84) { PB9.Visible = true; PB10.Visible = false; } else { PB9.Visible = false; PB10.Visible = true; }
                if (oTagPLC.bool85) { PB11.Visible = true; PB12.Visible = false; } else { PB11.Visible = false; PB12.Visible = true; }
                if (oTagPLC.bool86) { PB13.Visible = true; PB14.Visible = false; } else { PB13.Visible = false; PB14.Visible = true; }
                if (oTagPLC.bool87) { PB15.Visible = true; PB16.Visible = false; } else { PB15.Visible = false; PB16.Visible = true; }
                if (oTagPLC.bool88) { PB17.Visible = true; PB18.Visible = false; } else { PB17.Visible = false; PB18.Visible = true; }
                if (oTagPLC.bool89) { PB19.Visible = true; PB20.Visible = false; } else { PB19.Visible = false; PB20.Visible = true; }
                if (oTagPLC.bool90) { PB21.Visible = true; PB22.Visible = false; } else { PB21.Visible = false; PB22.Visible = true; }
                if (oTagPLC.bool91) { PB23.Visible = true; PB24.Visible = false; } else { PB23.Visible = false; PB24.Visible = true; }
                if (oTagPLC.bool92) { PB25.Visible = true; PB26.Visible = false; } else { PB25.Visible = false; PB26.Visible = true; }
                if (oTagPLC.bool93) { PB27.Visible = true; PB28.Visible = false; } else { PB27.Visible = false; PB28.Visible = true; }
                if (oTagPLC.bool94) { PB29.Visible = true; PB30.Visible = false; } else { PB29.Visible = false; PB30.Visible = true; }
                if (oTagPLC.bool95) { PB31.Visible = true; PB32.Visible = false; } else { PB31.Visible = false; PB32.Visible = true; }
                if (oTagPLC.bool96) { PB33.Visible = true; PB34.Visible = false; } else { PB33.Visible = false; PB34.Visible = true; }
                if (oTagPLC.bool97) { PB35.Visible = true; PB36.Visible = false; } else { PB35.Visible = false; PB36.Visible = true; }
                if (oTagPLC.bool98) { PB37.Visible = true; PB38.Visible = false; } else { PB37.Visible = false; PB38.Visible = true; }
                if (oTagPLC.bool99) { PB39.Visible = true; PB40.Visible = false; } else { PB39.Visible = false; PB40.Visible = true; }
                if (oTagPLC.bool100) { PB41.Visible = true; PB42.Visible = false; } else { PB41.Visible = false; PB42.Visible = true; }
                if (oTagPLC.bool101) { PB43.Visible = true; PB44.Visible = false; } else { PB43.Visible = false; PB44.Visible = true; }
                if (oTagPLC.bool102) { PB45.Visible = true; PB46.Visible = false; } else { PB45.Visible = false; PB46.Visible = true; }
                if (oTagPLC.bool103) { PB47.Visible = true; PB48.Visible = false; } else { PB47.Visible = false; PB48.Visible = true; }
                if (oTagPLC.bool104) { PB49.Visible = true; PB50.Visible = false; } else { PB49.Visible = false; PB50.Visible = true; }
                if (oTagPLC.bool105) { PB51.Visible = true; PB52.Visible = false; } else { PB51.Visible = false; PB52.Visible = true; }
                if (oTagPLC.bool106) { PB53.Visible = true; PB54.Visible = false; } else { PB53.Visible = false; PB54.Visible = true; }
                if (oTagPLC.bool107) { PB55.Visible = true; PB56.Visible = false; } else { PB55.Visible = false; PB56.Visible = true; }
                if (oTagPLC.bool108) { PB57.Visible = true; PB58.Visible = false; } else { PB57.Visible = false; PB58.Visible = true; }
                if (oTagPLC.bool109) { PB59.Visible = true; PB60.Visible = false; } else { PB59.Visible = false; PB60.Visible = true; }
                if (oTagPLC.bool110) { PB61.Visible = true; PB62.Visible = false; } else { PB61.Visible = false; PB62.Visible = true; }
                if (oTagPLC.bool111) { PB63.Visible = true; PB64.Visible = false; } else { PB63.Visible = false; PB64.Visible = true; }
                if (oTagPLC.bool112) { PB65.Visible = true; PB66.Visible = false; } else { PB65.Visible = false; PB66.Visible = true; }
                if (oTagPLC.bool113) { PB67.Visible = true; PB68.Visible = false; } else { PB67.Visible = false; PB68.Visible = true; }
                if (oTagPLC.bool114) { PB69.Visible = true; PB70.Visible = false; } else { PB69.Visible = false; PB70.Visible = true; }
                if (oTagPLC.bool115) { PB71.Visible = true; PB72.Visible = false; } else { PB71.Visible = false; PB72.Visible = true; }
                if (oTagPLC.bool116) { PB73.Visible = true; PB74.Visible = false; } else { PB73.Visible = false; PB74.Visible = true; }
                if (oTagPLC.bool117) { PB75.Visible = true; PB76.Visible = false; } else { PB75.Visible = false; PB76.Visible = true; }
                if (oTagPLC.bool118) { PB77.Visible = true; PB78.Visible = false; } else { PB77.Visible = false; PB78.Visible = true; }
                if (oTagPLC.bool119) { PB79.Visible = true; PB80.Visible = false; } else { PB79.Visible = false; PB80.Visible = true; }
                if (oTagPLC.bool120) { PB81.Visible = true; PB82.Visible = false; } else { PB81.Visible = false; PB82.Visible = true; }
                if (oTagPLC.bool121) { PB83.Visible = true; PB84.Visible = false; } else { PB83.Visible = false; PB84.Visible = true; }
                if (oTagPLC.bool122) { PB85.Visible = true; PB86.Visible = false; } else { PB85.Visible = false; PB86.Visible = true; }
                if (oTagPLC.bool123) { PB87.Visible = true; PB88.Visible = false; } else { PB87.Visible = false; PB88.Visible = true; }
                if (oTagPLC.bool124) { PB89.Visible = true; PB90.Visible = false; } else { PB89.Visible = false; PB90.Visible = true; }
                if (oTagPLC.bool125) { PB91.Visible = true; PB92.Visible = false; } else { PB91.Visible = false; PB92.Visible = true; }
                if (oTagPLC.bool126) { PB93.Visible = true; PB94.Visible = false; } else { PB93.Visible = false; PB94.Visible = true; }
                if (oTagPLC.bool127) { PB95.Visible = true; PB96.Visible = false; } else { PB95.Visible = false; PB96.Visible = true; }
                if (oTagPLC.bool128) { PB97.Visible = true; PB98.Visible = false; } else { PB97.Visible = false; PB98.Visible = true; }
                if (oTagPLC.bool129) { PB99.Visible = true; PB100.Visible = false; } else { PB99.Visible = false; PB100.Visible = true; }
                if (oTagPLC.bool130) { PB101.Visible = true; PB102.Visible = false; } else { PB101.Visible = false; PB102.Visible = true; }
                if (oTagPLC.bool131) { PB103.Visible = true; PB104.Visible = false; } else { PB103.Visible = false; PB104.Visible = true; }
                if (oTagPLC.bool132) { PB105.Visible = true; PB106.Visible = false; } else { PB105.Visible = false; PB106.Visible = true; }
                if (oTagPLC.bool133) { PB107.Visible = true; PB108.Visible = false; } else { PB107.Visible = false; PB108.Visible = true; }
                if (oTagPLC.bool134) { PB109.Visible = true; PB110.Visible = false; } else { PB109.Visible = false; PB110.Visible = true; }
                if (oTagPLC.bool135) { PB111.Visible = true; PB112.Visible = false; } else { PB111.Visible = false; PB112.Visible = true; }
                if (oTagPLC.bool136) { PB113.Visible = true; PB114.Visible = false; } else { PB113.Visible = false; PB114.Visible = true; }
                if (oTagPLC.bool137) { PB115.Visible = true; PB116.Visible = false; } else { PB115.Visible = false; PB116.Visible = true; }
                if (oTagPLC.bool138) { PB117.Visible = true; PB118.Visible = false; } else { PB117.Visible = false; PB118.Visible = true; }
               
                //if (oTagPLC.bool139) { PB119.Visible = true; PB120.Visible = false; } else { PB119.Visible = false; PB120.Visible = true; }
                //if (oTagPLC.bool140) { PB121.Visible = true; PB122.Visible = false; } else { PB121.Visible = false; PB122.Visible = true; }
                //if (oTagPLC.bool141) { PB123.Visible = true; PB124.Visible = false; } else { PB123.Visible = false; PB124.Visible = true; }
                //if (oTagPLC.bool142) { PB125.Visible = true; PB126.Visible = false; } else { PB125.Visible = false; PB126.Visible = true; }
                //if (oTagPLC.bool143) { PB127.Visible = true; PB128.Visible = false; } else { PB127.Visible = false; PB128.Visible = true; }
                //if (oTagPLC.bool144) { PB129.Visible = true; PB130.Visible = false; } else { PB129.Visible = false; PB130.Visible = true; }
                //if (oTagPLC.bool145) { PB131.Visible = true; PB132.Visible = false; } else { PB131.Visible = false; PB132.Visible = true; }
                //if (oTagPLC.bool146) { PB133.Visible = true; PB134.Visible = false; } else { PB133.Visible = false; PB134.Visible = true; }
                //if (oTagPLC.bool147) { PB135.Visible = true; PB136.Visible = false; } else { PB135.Visible = false; PB136.Visible = true; }
                //if (oTagPLC.bool148) { PB137.Visible = true; PB138.Visible = false; } else { PB137.Visible = false; PB138.Visible = true; }
                //if (oTagPLC.bool149) { PB139.Visible = true; PB140.Visible = false; } else { PB139.Visible = false; PB140.Visible = true; }
                //if (oTagPLC.bool150) { PB141.Visible = true; PB142.Visible = false; } else { PB141.Visible = false; PB142.Visible = true; }
                //if (oTagPLC.bool151) { PB143.Visible = true; PB144.Visible = false; } else { PB143.Visible = false; PB144.Visible = true; }
                //if (oTagPLC.bool152) { PB145.Visible = true; PB146.Visible = false; } else { PB145.Visible = false; PB146.Visible = true; }
                //if (oTagPLC.bool153) { PB147.Visible = true; PB148.Visible = false; } else { PB147.Visible = false; PB148.Visible = true; }
                //if (oTagPLC.bool154) { PB149.Visible = true; PB150.Visible = false; } else { PB149.Visible = false; PB150.Visible = true; }
                //if (oTagPLC.bool155) { PB151.Visible = true; PB152.Visible = false; } else { PB151.Visible = false; PB152.Visible = true; }
                //if (oTagPLC.bool156) { PB153.Visible = true; PB154.Visible = false; } else { PB153.Visible = false; PB154.Visible = true; }
                //if (oTagPLC.bool157) { PB155.Visible = true; PB156.Visible = false; } else { PB155.Visible = false; PB156.Visible = true; }

                #endregion

            }

            catch (Exception ex)
            {
                oLog.RegistroLog(ex.Message.ToString() + " funcion Salidas");
                MessageBox.Show(ex.Message.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            OnStart();
        }          

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //oPLC.Close();
                OnStop();
                this.Close();
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                oTagPLC.string010 = "ENTRADA";
                oTagPLC.string09 = "PLC";
                tIndice0 = true;
                tIndice1 = false;
                tIndice2 = false;
                tIndice3 = false;
                tIndice4 = false;
            }

            if (e.TabPageIndex == 1)
            {
                oTagPLC.string010 = "ENTRADA";
                oTagPLC.string09 = "MODULO1";
                tIndice0 = false;
                tIndice1 = true;
                tIndice2 = false;
                tIndice3 = false;
                tIndice4 = false;
            }

            if (e.TabPageIndex == 2)
            {
                oTagPLC.string010 = "ENTRADA";
                oTagPLC.string09 = "MODULO2";
                tIndice0 = false;
                tIndice1 = false;
                tIndice2 = true;
                tIndice3 = false;
                tIndice4 = false;
            }

            if (e.TabPageIndex == 3)
            {
                oTagPLC.string010 = "ENTRADA";
                oTagPLC.string09 = "MODULO3";
                tIndice0 = false;
                tIndice1 = false;
                tIndice2 = false;
                tIndice3 = true;
                tIndice4 = false;
            }

            if (e.TabPageIndex == 4)
            {
                oTagPLC.string010 = "ENTRADA";
                oTagPLC.string09 = "MODULO4";
                tIndice0 = false;
                tIndice1 = false;
                tIndice2 = false;
                tIndice3 = false;
                tIndice4 = true;
            }
        }

        private void TareasTempo()
        {
            OnStop();
            //LeerSalidas(); 
            OnStart();
        }

          
    }
}
