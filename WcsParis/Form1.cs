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


namespace WcsParis
{
    public partial class Form1 : Form
    {
        private Plc oPLC = null;
        private cEntidades.cEnums.ExceptionCode errorcode;
        bool EstadoPLC = false;

        #region CONECTARPLC

        private void cConPLC() 
        {

            try {

                string IP = ConfigurationManager.AppSettings["IpPCL"].ToString();
                Int16 Port = Convert.ToInt16(ConfigurationManager.AppSettings["PortPLC"].ToString());
                Int16 Rack = Convert.ToInt16(ConfigurationManager.AppSettings["RackPLC"].ToString());
                Int16 Slot = Convert.ToInt16(ConfigurationManager.AppSettings["SlotPLC"].ToString());

                oPLC = new Plc(CpuType.S71200, IP, Rack, Slot);

                oPLC.Open();

                EstadoPLC = oPLC.IsConnected;

                if (EstadoPLC)
                {
                    
                }
                else { 
                     
                }
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen; 
        }

        private void txtProceso_TextChanged(object sender, EventArgs e)
        {

        }

               ////ESCRIBE TEXTO

            //int dbnumber = 1;
            //int startadrr = Convert.ToInt32(TxtByte.Text);
            //string input = TxtDatosArreglo.Text;
            //byte[] databytes = Types.String.ToByteArray(input);

            //List<byte> values = new List<byte>();
            //byte medida = (byte)input.Length;
            //byte medidaactual = (byte)input.Length;

            //values.Add(medida);
            //values.Add(medidaactual);
            //values.AddRange(databytes);

            //oPLC.WriteBytes(DataType.DataBlock, dbnumber, startadrr, values.ToArray());


        }



    }

