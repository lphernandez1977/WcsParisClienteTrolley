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
    public partial class FrmEntradas : Form
    {
        MDIFramework FrmPrincipal = new MDIFramework();
        private Plc oPLC = null;

        bool EstadoPLC = false;
        bool tIndice0 = false;

        #region HILOS
        //Thread Hilo = new Thread();
        private static System.Threading.Timer temporizador = null;
        bool stop = true;
        #endregion

        #region ENTIDADES
        public cDispositivos oDirecciones = new cDispositivos();
        public cTagPlc oTagPLC = new cTagPlc();
        private cEnt_Server oServer = new cEnt_Server();
        private cEntidades.cEnums.ExceptionCode errorcode;
        private cRegistroErr oLog = new cRegistroErr();
        private cPing ping = new cPing();
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
                oLog.RegistroLog(ex.Message.ToString());
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
            temporizador = new System.Threading.Timer(tcb, null, 1000, 1000);
        }

        private void OnElapsedTime(Object stateInfo)
        {
            TareasTempo();
        }

        private void OnStop()
        {
            stop = true;
            temporizador.Dispose();
        }
        #endregion

        public FrmEntradas()
        {
            InitializeComponent();
        }

        private void FrmEntradas_Load(object sender, EventArgs e)
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
                LeerEntradas();
            }
            else
            {
                LblEstadoPLC.Visible = true;
                LblEstadoPLC.Text = "Controlador Desconectado";
            }

            //OnStart();
        }

        private void TareasTempo()
        {
            OnStop();
            LeerEntradas();
            OnStart();
        }

        private void LeerEntradas()
        {
            OnStop();
            try
            {
                #region ENTRADAS
                //oTagPLC.bool01 = (bool)oPLC.Read("DB8.DBX0.0");
                //oTagPLC.bool02 = (bool)oPLC.Read("DB8.DBX0.1");
                //oTagPLC.bool03 = (bool)oPLC.Read("DB8.DBX0.2");
                //oTagPLC.bool04 = (bool)oPLC.Read("DB8.DBX0.3");
                //oTagPLC.bool05 = (bool)oPLC.Read("DB8.DBX0.4");
                //oTagPLC.bool06 = (bool)oPLC.Read("DB8.DBX0.5");
                //oTagPLC.bool07 = (bool)oPLC.Read("DB8.DBX0.6");
                //oTagPLC.bool08 = (bool)oPLC.Read("DB8.DBX0.7");
                //oTagPLC.bool09 = (bool)oPLC.Read("DB8.DBX1.0");
                //oTagPLC.bool10 = (bool)oPLC.Read("DB8.DBX1.1");
                //oTagPLC.bool11 = (bool)oPLC.Read("DB8.DBX1.2");
                //oTagPLC.bool12 = (bool)oPLC.Read("DB8.DBX1.3");
                //oTagPLC.bool13 = (bool)oPLC.Read("DB8.DBX1.4");
                //oTagPLC.bool14 = (bool)oPLC.Read("DB8.DBX1.5");
                //oTagPLC.bool15 = (bool)oPLC.Read("DB8.DBX1.6");
                //oTagPLC.bool16 = (bool)oPLC.Read("DB8.DBX1.7");
                //oTagPLC.bool17 = (bool)oPLC.Read("DB8.DBX2.0");
                //oTagPLC.bool18 = (bool)oPLC.Read("DB8.DBX2.1");
                //oTagPLC.bool19 = (bool)oPLC.Read("DB8.DBX2.2");
                //oTagPLC.bool20 = (bool)oPLC.Read("DB8.DBX2.3");
                //oTagPLC.bool21 = (bool)oPLC.Read("DB8.DBX2.4");
                //oTagPLC.bool22 = (bool)oPLC.Read("DB8.DBX2.5");
                //oTagPLC.bool23 = (bool)oPLC.Read("DB8.DBX2.6");
                //oTagPLC.bool24 = (bool)oPLC.Read("DB8.DBX2.7");
                //oTagPLC.bool25 = (bool)oPLC.Read("DB8.DBX3.0");
                //oTagPLC.bool26 = (bool)oPLC.Read("DB8.DBX3.1");
                //oTagPLC.bool27 = (bool)oPLC.Read("DB8.DBX3.2");
                //oTagPLC.bool28 = (bool)oPLC.Read("DB8.DBX3.3");
                //oTagPLC.bool29 = (bool)oPLC.Read("DB8.DBX3.4");
                //oTagPLC.bool30 = (bool)oPLC.Read("DB8.DBX3.5");
                //oTagPLC.bool31 = (bool)oPLC.Read("DB8.DBX3.6");
                //oTagPLC.bool32 = (bool)oPLC.Read("DB8.DBX3.7");
                //oTagPLC.bool33 = (bool)oPLC.Read("DB8.DBX4.0");
                //oTagPLC.bool34 = (bool)oPLC.Read("DB8.DBX4.1");
                //oTagPLC.bool35 = (bool)oPLC.Read("DB8.DBX4.2");
                //oTagPLC.bool36 = (bool)oPLC.Read("DB8.DBX4.3");
                //oTagPLC.bool37 = (bool)oPLC.Read("DB8.DBX4.4");
                //oTagPLC.bool38 = (bool)oPLC.Read("DB8.DBX4.5");
                //oTagPLC.bool39 = (bool)oPLC.Read("DB8.DBX4.6");
                //oTagPLC.bool40 = (bool)oPLC.Read("DB8.DBX4.7");
                //oTagPLC.bool41 = (bool)oPLC.Read("DB8.DBX5.0");
                //oTagPLC.bool42 = (bool)oPLC.Read("DB8.DBX5.1");
                //oTagPLC.bool43 = (bool)oPLC.Read("DB8.DBX5.2");
                //oTagPLC.bool44 = (bool)oPLC.Read("DB8.DBX5.3");
                //oTagPLC.bool45 = (bool)oPLC.Read("DB8.DBX5.4");
                //oTagPLC.bool46 = (bool)oPLC.Read("DB8.DBX5.5");
                //oTagPLC.bool47 = (bool)oPLC.Read("DB8.DBX5.6");
                //oTagPLC.bool48 = (bool)oPLC.Read("DB8.DBX5.7");
                //oTagPLC.bool49 = (bool)oPLC.Read("DB8.DBX6.0");
                //oTagPLC.bool50 = (bool)oPLC.Read("DB8.DBX6.1");
                //oTagPLC.bool51 = (bool)oPLC.Read("DB8.DBX6.2");
                //oTagPLC.bool52 = (bool)oPLC.Read("DB8.DBX6.3");
                //oTagPLC.bool53 = (bool)oPLC.Read("DB8.DBX6.4");
                //oTagPLC.bool54 = (bool)oPLC.Read("DB8.DBX6.5");
                //oTagPLC.bool55 = (bool)oPLC.Read("DB8.DBX6.6");
                //oTagPLC.bool56 = (bool)oPLC.Read("DB8.DBX6.7");
                //oTagPLC.bool57 = (bool)oPLC.Read("DB8.DBX7.0");
                //oTagPLC.bool58 = (bool)oPLC.Read("DB8.DBX7.1");
                //oTagPLC.bool59 = (bool)oPLC.Read("DB8.DBX7.2");
                //oTagPLC.bool60 = (bool)oPLC.Read("DB8.DBX7.3");
                //oTagPLC.bool61 = (bool)oPLC.Read("DB8.DBX7.4");
                //oTagPLC.bool62 = (bool)oPLC.Read("DB8.DBX7.5");

                if (FrmPrincipal.oTagPLC.bool01) { PB1.Visible = true; PB2.Visible = false; } else { PB1.Visible = false; PB2.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool02) { PB3.Visible = true; PB4.Visible = false; } else { PB3.Visible = false; PB4.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool03) { PB5.Visible = true; PB6.Visible = false; } else { PB5.Visible = false; PB6.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool04) { PB7.Visible = true; PB8.Visible = false; } else { PB7.Visible = false; PB8.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool05) { PB9.Visible = true; PB10.Visible = false; } else { PB9.Visible = false; PB10.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool06) { PB11.Visible = true; PB12.Visible = false; } else { PB11.Visible = false; PB12.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool07) { PB13.Visible = true; PB14.Visible = false; } else { PB13.Visible = false; PB14.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool08) { PB15.Visible = true; PB16.Visible = false; } else { PB15.Visible = false; PB16.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool09) { PB17.Visible = true; PB18.Visible = false; } else { PB17.Visible = false; PB18.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool10) { PB19.Visible = true; PB20.Visible = false; } else { PB19.Visible = false; PB20.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool11) { PB21.Visible = true; PB22.Visible = false; } else { PB21.Visible = false; PB22.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool12) { PB23.Visible = true; PB24.Visible = false; } else { PB23.Visible = false; PB24.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool13) { PB25.Visible = true; PB26.Visible = false; } else { PB25.Visible = false; PB26.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool14) { PB27.Visible = true; PB28.Visible = false; } else { PB27.Visible = false; PB28.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool15) { PB29.Visible = true; PB30.Visible = false; } else { PB29.Visible = false; PB30.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool16) { PB31.Visible = true; PB32.Visible = false; } else { PB31.Visible = false; PB32.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool17) { PB33.Visible = true; PB34.Visible = false; } else { PB33.Visible = false; PB34.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool18) { PB35.Visible = true; PB36.Visible = false; } else { PB35.Visible = false; PB36.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool19) { PB37.Visible = true; PB38.Visible = false; } else { PB37.Visible = false; PB38.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool20) { PB39.Visible = true; PB40.Visible = false; } else { PB39.Visible = false; PB40.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool21) { PB41.Visible = true; PB42.Visible = false; } else { PB41.Visible = false; PB42.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool22) { PB43.Visible = true; PB44.Visible = false; } else { PB43.Visible = false; PB44.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool23) { PB45.Visible = true; PB46.Visible = false; } else { PB45.Visible = false; PB46.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool24) { PB47.Visible = true; PB48.Visible = false; } else { PB47.Visible = false; PB48.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool25) { PB49.Visible = true; PB50.Visible = false; } else { PB49.Visible = false; PB50.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool26) { PB51.Visible = true; PB52.Visible = false; } else { PB51.Visible = false; PB52.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool27) { PB53.Visible = true; PB54.Visible = false; } else { PB53.Visible = false; PB54.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool28) { PB55.Visible = true; PB56.Visible = false; } else { PB55.Visible = false; PB56.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool29) { PB57.Visible = true; PB58.Visible = false; } else { PB57.Visible = false; PB58.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool30) { PB59.Visible = true; PB60.Visible = false; } else { PB59.Visible = false; PB60.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool31) { PB61.Visible = true; PB62.Visible = false; } else { PB61.Visible = false; PB62.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool32) { PB63.Visible = true; PB64.Visible = false; } else { PB63.Visible = false; PB64.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool33) { PB65.Visible = true; PB66.Visible = false; } else { PB65.Visible = false; PB66.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool34) { PB67.Visible = true; PB68.Visible = false; } else { PB67.Visible = false; PB68.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool35) { PB69.Visible = true; PB70.Visible = false; } else { PB69.Visible = false; PB70.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool36) { PB71.Visible = true; PB72.Visible = false; } else { PB71.Visible = false; PB72.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool37) { PB73.Visible = true; PB74.Visible = false; } else { PB73.Visible = false; PB74.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool38) { PB75.Visible = true; PB76.Visible = false; } else { PB75.Visible = false; PB76.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool39) { PB77.Visible = true; PB78.Visible = false; } else { PB77.Visible = false; PB78.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool40) { PB79.Visible = true; PB80.Visible = false; } else { PB79.Visible = false; PB80.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool41) { PB81.Visible = true; PB82.Visible = false; } else { PB81.Visible = false; PB82.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool42) { PB83.Visible = true; PB84.Visible = false; } else { PB83.Visible = false; PB84.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool43) { PB85.Visible = true; PB86.Visible = false; } else { PB85.Visible = false; PB86.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool44) { PB87.Visible = true; PB88.Visible = false; } else { PB87.Visible = false; PB88.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool45) { PB89.Visible = true; PB90.Visible = false; } else { PB89.Visible = false; PB90.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool46) { PB91.Visible = true; PB92.Visible = false; } else { PB91.Visible = false; PB92.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool47) { PB93.Visible = true; PB94.Visible = false; } else { PB93.Visible = false; PB94.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool48) { PB95.Visible = true; PB96.Visible = false; } else { PB95.Visible = false; PB96.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool49) { PB97.Visible = true; PB98.Visible = false; } else { PB97.Visible = false; PB98.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool50) { PB99.Visible = true; PB100.Visible = false; } else { PB99.Visible = false; PB100.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool51) { PB101.Visible = true; PB102.Visible = false; } else { PB101.Visible = false; PB102.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool52) { PB103.Visible = true; PB104.Visible = false; } else { PB103.Visible = false; PB104.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool53) { PB105.Visible = true; PB106.Visible = false; } else { PB105.Visible = false; PB106.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool54) { PB107.Visible = true; PB108.Visible = false; } else { PB107.Visible = false; PB108.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool55) { PB109.Visible = true; PB110.Visible = false; } else { PB109.Visible = false; PB110.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool56) { PB111.Visible = true; PB112.Visible = false; } else { PB111.Visible = false; PB112.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool57) { PB113.Visible = true; PB114.Visible = false; } else { PB113.Visible = false; PB114.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool58) { PB115.Visible = true; PB116.Visible = false; } else { PB115.Visible = false; PB116.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool59) { PB117.Visible = true; PB118.Visible = false; } else { PB117.Visible = false; PB118.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool60) { PB119.Visible = true; PB120.Visible = false; } else { PB119.Visible = false; PB120.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool61) { PB121.Visible = true; PB122.Visible = false; } else { PB121.Visible = false; PB122.Visible = true; }
                if (FrmPrincipal.oTagPLC.bool62) { PB123.Visible = true; PB124.Visible = false; } else { PB123.Visible = false; PB124.Visible = true; }


                //if (oTagPLC.bool63) { PB125.Visible = true; PB126.Visible = false; } else { PB125.Visible = false; PB126.Visible = true; }
                //if (oTagPLC.bool64) { PB127.Visible = true; PB128.Visible = false; } else { PB127.Visible = false; PB128.Visible = true; }
                //if (oTagPLC.bool65) { PB129.Visible = true; PB130.Visible = false; } else { PB129.Visible = false; PB130.Visible = true; }
                //if (oTagPLC.bool66) { PB131.Visible = true; PB132.Visible = false; } else { PB131.Visible = false; PB132.Visible = true; }
                //if (oTagPLC.bool67) { PB133.Visible = true; PB134.Visible = false; } else { PB133.Visible = false; PB134.Visible = true; }
                //if (oTagPLC.bool68) { PB135.Visible = true; PB136.Visible = false; } else { PB135.Visible = false; PB136.Visible = true; }
                //if (oTagPLC.bool69) { PB137.Visible = true; PB138.Visible = false; } else { PB137.Visible = false; PB138.Visible = true; }
                //if (oTagPLC.bool70) { PB139.Visible = true; PB140.Visible = false; } else { PB139.Visible = false; PB140.Visible = true; }
                //if (oTagPLC.bool71) { PB141.Visible = true; PB142.Visible = false; } else { PB141.Visible = false; PB142.Visible = true; }
                //if (oTagPLC.bool72) { PB143.Visible = true; PB144.Visible = false; } else { PB143.Visible = false; PB144.Visible = true; }
                //if (oTagPLC.bool73) { PB145.Visible = true; PB146.Visible = false; } else { PB145.Visible = false; PB146.Visible = true; }
                //if (oTagPLC.bool74) { PB147.Visible = true; PB148.Visible = false; } else { PB147.Visible = false; PB148.Visible = true; }
                //if (oTagPLC.bool75) { PB149.Visible = true; PB150.Visible = false; } else { PB149.Visible = false; PB150.Visible = true; }
                //if (oTagPLC.bool76) { PB151.Visible = true; PB152.Visible = false; } else { PB151.Visible = false; PB152.Visible = true; }
                //if (oTagPLC.bool77) { PB153.Visible = true; PB154.Visible = false; } else { PB153.Visible = false; PB154.Visible = true; }
                //if (oTagPLC.bool78) { PB155.Visible = true; PB156.Visible = false; } else { PB155.Visible = false; PB156.Visible = true; }           
                #endregion
            }
            catch (Exception ex)
            {
                oLog.RegistroLog(ex.Message.ToString() + " funcion LeerEntradas");
                MessageBox.Show(ex.Message.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            OnStart();

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //MessageBox.Show(e.TabPageIndex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            if (e.TabPageIndex == 0)
            {
                oTagPLC.string010 = "ENTRADA";
                oTagPLC.string09 = "PLC";
                tIndice0 = true;
            }

            if (e.TabPageIndex == 1)
            {
                oTagPLC.string010 = "ENTRADA";
                oTagPLC.string09 = "MODULO1";
                tIndice0 = false;

            }

            if (e.TabPageIndex == 2)
            {
                oTagPLC.string010 = "ENTRADA";
                oTagPLC.string09 = "MODULO2";
            }

            if (e.TabPageIndex == 3)
            {
                oTagPLC.string010 = "ENTRADA";
                oTagPLC.string09 = "MODULO3";

            }

            if (e.TabPageIndex == 4)
            {
                oTagPLC.string010 = "ENTRADA";
                oTagPLC.string09 = "MODULO4";
                tIndice0 = false;
            }


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

        private void button1_Click(object sender, EventArgs e)
        {
            //byte[] db1Bytes = new byte[3358];
            //ushort db1WordVariable = 1234;
            //S7.Net.Types.Word.ToByteArray(db1WordVariable).CopyTo(db1Bytes, 0);
            //oPLC.WriteBytes(DataType.DataBlock, 1, 0, db1Bytes);

            try
            {
                //oPLC.Write(DataType.Output, 0, 0, true, -1);

                //oPLC.Write("Q0.0", true);
                //string ST = "M0.1";
                //bool testRead = (bool)oPLC.Read(ST);
                //bool db1Bool = (bool)oPLC.Read(oTagPLC.string01);
                //oPLC.Close();


            }
            catch (Exception ex)
            {
                //oPLC.Close();
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}
