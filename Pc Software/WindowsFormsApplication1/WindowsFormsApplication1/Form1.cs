using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            comboBox1.DataSource = ports;
            this.KeyPreview = true;
        } //done    

        private void button16_Click(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            comboBox1.DataSource = ports;
        } //done

        private void button17_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                Connect(comboBox1.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Please select a port first");
            }    
        } //done

        private void serial_check()
        {
            MessageBox.Show("Please open Serial Connection");
        } //done

        private void Connect(string portName)
        {
            serialPort1 = new SerialPort(portName);
            if (!serialPort1.IsOpen)
            {
                serialPort1.BaudRate = 57600;
                serialPort1.Open();
                Form1.ActiveForm.Text = (String.Format("Connected to '{0}'", comboBox1.SelectedItem));
            }
        }// done

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }// done


        private void btn_n1ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00001v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n2ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00002v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n3ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00003v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n4ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00004v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n5ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00005v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n11ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00011v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n12ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00012v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n13ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00013v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n14ident_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00014v000ta");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        }

        private void btn_n15ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00015v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n21ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00021v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n22ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00022v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n23ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00023v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n24ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00024v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n25ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00025v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        // NODE 01

        private void btn_n1dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00001v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n1dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00001v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n1aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00001v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n1aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00001v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n1aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00001v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n1aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00001v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        // NODE 02

        private void btn_n2dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00002v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n2dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00002v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n2aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00002v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n2aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00002v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n2aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00002v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n2aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00002v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        // NODE 03

        private void btn_n3dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00003v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n3dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00003v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n3aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00003v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n3aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00003v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n3aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00003v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n3aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00003v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        // NODE 4

        private void btn_n4dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00004v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n4dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00004v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n4aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00004v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n4aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00004v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n4aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00004v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n4aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00004v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        // NODE 05

        private void btn_n5dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00005v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n5dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00005v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n5aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00005v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n5aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00005v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n5aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00005v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n5aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00005v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
            }
        }

        private void btn_n11dd1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n11dd1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n11aa1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n11aa1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n11aa2h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n11aa2l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n12dd1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n12dd1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n12aa1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n12aa1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n12aa2h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n12aa2l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n13dd1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n13dd1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n13aa1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n13aa1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n13aa2h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n13aa2l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n14dd1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n14dd1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n14aa1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n14aa1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n14aa2h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n14aa2l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n15dd1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n15dd1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n15aa1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n15aa1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n15aa2h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n15aa2l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n21dd1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n21dd1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n21aa1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n21aa1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n21aa2h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n21aa2l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n22dd1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n22dd1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n22aa1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n22aa1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n22aa2h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n22aa2l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n23dd1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n23dd1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n23aa1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n23aa1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n23aa2h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n23aa2l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n24dd1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n24dd1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n24aa1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n24aa1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n24aa2h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n24aa2l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n25dd1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n25dd1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n25aa1h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n25aa1l_Click(object sender, EventArgs e)
        {

        }

        private void btn_n25aa2h_Click(object sender, EventArgs e)
        {

        }

        private void btn_n25aa2l_Click(object sender, EventArgs e)
        {

        }
    }
}
