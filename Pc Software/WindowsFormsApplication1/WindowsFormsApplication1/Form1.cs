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
        private String rx_data; // incoming data
        private String str1; // substring of rx_data
        private String str2; // substring of rx_data
        private String str3; // substring of rx_data
        private int status_address;
        private int start1;
        private int start2;
        private int start3;
        private int end1;
        private int end2;
        private int end3;

        private bool node01_alive = false;
        private bool node02_alive = false;
        private bool node03_alive = false;
        private bool node04_alive = false;
        private bool node05_alive = false;

        private bool node011_alive = false;
        private bool node012_alive = false;
        private bool node013_alive = false;
        private bool node014_alive = false;
        private bool node015_alive = false;

        private bool node021_alive = false;
        private bool node022_alive = false;
        private bool node023_alive = false;
        private bool node024_alive = false;
        private bool node025_alive = false;


        public Form1()
        {
            InitializeComponent();
            textBox3.Text = ("0.00v");
            textBox4.Text = ("0.00°c");
            textBox5.Text = ("0.00v");
            textBox6.Text = ("0.00°c");
            textBox7.Text = ("0.00v");
            textBox8.Text = ("0.00°c");
            textBox9.Text = ("0.00v");
            textBox10.Text = ("0.00°c");
            textBox11.Text = ("0.00v");
            textBox12.Text = ("0.00°c");

            textBox15.Text = ("0.00v");
            textBox16.Text = ("0.00°c");
            textBox17.Text = ("0.00v");
            textBox18.Text = ("0.00°c");
            textBox19.Text = ("0.00v");
            textBox20.Text = ("0.00°c");
            textBox21.Text = ("0.00v");
            textBox22.Text = ("0.00°c");
            textBox23.Text = ("0.00v");
            textBox24.Text = ("0.00°c");

            textBox27.Text = ("0.00v");
            textBox28.Text = ("0.00°c");
            textBox29.Text = ("0.00v");
            textBox30.Text = ("0.00°c");
            textBox31.Text = ("0.00v");
            textBox32.Text = ("0.00°c");
            textBox33.Text = ("0.00v");
            textBox34.Text = ("0.00°c");
            textBox35.Text = ("0.00v");
            textBox36.Text = ("0.00°c");

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
                timer2.Enabled = true;
                btn_scan_Click(null, null);
            }
        }// done

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }// done

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (serialPort1.IsOpen == true)
            {
                if (serialPort1.BytesToRead > 0)
                {
                    textBox2.AppendText(DateTime.Now.ToString("HH:mm:ss ") + Environment.NewLine);
                    rx_data = (serialPort1.ReadLine() + Environment.NewLine);
                    textBox2.AppendText(rx_data + Environment.NewLine);

                    if (rx_data.Contains("Node"))
                    {
                        //MessageBox.Show("Found Node");
                        start1 = rx_data.IndexOf("Node") + 5; // locate the start of the address
                        end1 = rx_data.IndexOf(" ");
                        str1 = rx_data.Substring(start1, 3); // save the address into str1
                        status_address = Convert.ToInt32(str1);

                        start2 = rx_data.IndexOf(" ", start1 + 1); // locate the second space in the string
                        end2 = rx_data.IndexOf("C"); // locate the end of the temp reading
                        str2 = rx_data.Substring(start2 + 1, end2 - start2 - 1); // save the temp reading into str2

                        start3 = rx_data.IndexOf(" ", start2 + 1); // locate the third space in the string
                        end3 = rx_data.IndexOf("V"); // locate the end of the voltage reading
                        str3 = rx_data.Substring(start3 + 1, end3 - start3 - 1); // save the voltage reading into str3
                        switch (status_address)
                        {
                            case 01:
                                node01_alive = true;
                                textBox3.Text = (str3 + "v");
                                textBox4.Text = (str2 + "°c");
                                break;

                            case 02:
                                node02_alive = true;
                                textBox5.Text = (str3 + "v");
                                textBox6.Text = (str2 + "°c");
                                break;

                            case 03:
                                node03_alive = true;
                                textBox7.Text = (str3 + "v");
                                textBox8.Text = (str2 + "°c");
                                break;

                            case 04:
                                node04_alive = true;
                                textBox9.Text = (str3 + "v");
                                textBox10.Text = (str2 + "°c");
                                break;

                            case 05:
                                node05_alive = true;
                                textBox11.Text = (str3 + "v");
                                textBox12.Text = (str2 + "°c");
                                break;

                            case 011:
                                node011_alive = true;
                                textBox15.Text = (str3 + "v");
                                textBox16.Text = (str2 + "°c");
                                break;

                            case 012:
                                node012_alive = true;
                                textBox17.Text = (str3 + "v");
                                textBox18.Text = (str2 + "°c");
                                break;

                            case 013:
                                node013_alive = true;
                                textBox19.Text = (str3 + "v");
                                textBox20.Text = (str2 + "°c");
                                break;

                            case 014:
                                node014_alive = true;
                                textBox21.Text = (str3 + "v");
                                textBox22.Text = (str2 + "°c");
                                break;

                            case 015:
                                node015_alive = true;
                                textBox23.Text = (str3 + "v");
                                textBox24.Text = (str2 + "°c");
                                break;

                            case 021:
                                node021_alive = true;
                                textBox27.Text = (str3 + "v");
                                textBox28.Text = (str2 + "°c");
                                break;

                            case 022:
                                node022_alive = true;
                                textBox29.Text = (str3 + "v");
                                textBox30.Text = (str2 + "°c");
                                break;

                            case 023:
                                node023_alive = true;
                                textBox31.Text = (str3 + "v");
                                textBox32.Text = (str2 + "°c");
                                break;

                            case 024:
                                node024_alive = true;
                                textBox33.Text = (str3 + "v");
                                textBox34.Text = (str2 + "°c");
                                break;

                            case 025:
                                node025_alive = true;
                                textBox35.Text = (str3 + "v");
                                textBox36.Text = (str2 + "°c");
                                break;
                        }
                        if (node01_alive == true)
                        {
                            btn_n1dd1h.Enabled = true;
                            btn_n1dd1l.Enabled = true;
                            btn_n1aa1h.Enabled = true;
                            btn_n1aa1l.Enabled = true;
                            btn_n1aa2h.Enabled = true;
                            btn_n1aa2l.Enabled = true;
                            btn_n1ident.Enabled = true;
                        }

                        if (node02_alive == true)
                        {
                            btn_n2dd1h.Enabled = true;
                            btn_n2dd1l.Enabled = true;
                            btn_n2aa1h.Enabled = true;
                            btn_n2aa1l.Enabled = true;
                            btn_n2aa2h.Enabled = true;
                            btn_n2aa2l.Enabled = true;
                            btn_n2ident.Enabled = true;
                        }

                        if (node03_alive == true)
                        {
                            btn_n3dd1h.Enabled = true;
                            btn_n3dd1l.Enabled = true;
                            btn_n3aa1h.Enabled = true;
                            btn_n3aa1l.Enabled = true;
                            btn_n3aa2h.Enabled = true;
                            btn_n3aa2l.Enabled = true;
                            btn_n3ident.Enabled = true;
                        }

                        if (node04_alive == true)
                        {
                            btn_n4dd1h.Enabled = true;
                            btn_n4dd1l.Enabled = true;
                            btn_n4aa1h.Enabled = true;
                            btn_n4aa1l.Enabled = true;
                            btn_n4aa2h.Enabled = true;
                            btn_n4aa2l.Enabled = true;
                            btn_n4ident.Enabled = true;
                        }

                        if (node05_alive == true)
                        {
                            btn_n5dd1h.Enabled = true;
                            btn_n5dd1l.Enabled = true;
                            btn_n5aa1h.Enabled = true;
                            btn_n5aa1l.Enabled = true;
                            btn_n5aa2h.Enabled = true;
                            btn_n5aa2l.Enabled = true;
                            btn_n5ident.Enabled = true;
                        }

                        if (node011_alive == true)
                        {
                            btn_n11dd1h.Enabled = true;
                            btn_n11dd1l.Enabled = true;
                            btn_n11aa1h.Enabled = true;
                            btn_n11aa1l.Enabled = true;
                            btn_n11aa2h.Enabled = true;
                            btn_n11aa2l.Enabled = true;
                            btn_n11ident.Enabled = true;
                        }

                        if (node012_alive == true)
                        {
                            btn_n12dd1h.Enabled = true;
                            btn_n12dd1l.Enabled = true;
                            btn_n12aa1h.Enabled = true;
                            btn_n12aa1l.Enabled = true;
                            btn_n12aa2h.Enabled = true;
                            btn_n12aa2l.Enabled = true;
                            btn_n12ident.Enabled = true;
                        }

                        if (node013_alive == true)
                        {
                            btn_n13dd1h.Enabled = true;
                            btn_n13dd1l.Enabled = true;
                            btn_n13aa1h.Enabled = true;
                            btn_n13aa1l.Enabled = true;
                            btn_n13aa2h.Enabled = true;
                            btn_n13aa2l.Enabled = true;
                            btn_n13ident.Enabled = true;
                        }

                        if (node014_alive == true)
                        {
                            btn_n14dd1h.Enabled = true;
                            btn_n14dd1l.Enabled = true;
                            btn_n14aa1h.Enabled = true;
                            btn_n14aa1l.Enabled = true;
                            btn_n14aa2h.Enabled = true;
                            btn_n14aa2l.Enabled = true;
                            btn_n14ident.Enabled = true;
                        }

                        if (node015_alive == true)
                        {
                            btn_n15dd1h.Enabled = true;
                            btn_n15dd1l.Enabled = true;
                            btn_n15aa1h.Enabled = true;
                            btn_n15aa1l.Enabled = true;
                            btn_n15aa2h.Enabled = true;
                            btn_n15aa2l.Enabled = true;
                            btn_n15ident.Enabled = true;
                        }

                        if (node021_alive == true)
                        {
                            btn_n21dd1h.Enabled = true;
                            btn_n21dd1l.Enabled = true;
                            btn_n21aa1h.Enabled = true;
                            btn_n21aa1l.Enabled = true;
                            btn_n21aa2h.Enabled = true;
                            btn_n21aa2l.Enabled = true;
                            btn_n21ident.Enabled = true;
                        }

                        if (node022_alive == true)
                        {
                            btn_n22dd1h.Enabled = true;
                            btn_n22dd1l.Enabled = true;
                            btn_n22aa1h.Enabled = true;
                            btn_n22aa1l.Enabled = true;
                            btn_n22aa2h.Enabled = true;
                            btn_n22aa2l.Enabled = true;
                            btn_n22ident.Enabled = true;
                        }

                        if (node023_alive == true)
                        {
                            btn_n23dd1h.Enabled = true;
                            btn_n23dd1l.Enabled = true;
                            btn_n23aa1h.Enabled = true;
                            btn_n23aa1l.Enabled = true;
                            btn_n23aa2h.Enabled = true;
                            btn_n23aa2l.Enabled = true;
                            btn_n23ident.Enabled = true;
                        }

                        if (node024_alive == true)
                        {
                            btn_n24dd1h.Enabled = true;
                            btn_n24dd1l.Enabled = true;
                            btn_n24aa1h.Enabled = true;
                            btn_n24aa1l.Enabled = true;
                            btn_n24aa2h.Enabled = true;
                            btn_n24aa2l.Enabled = true;
                            btn_n24ident.Enabled = true;
                        }

                        if (node025_alive == true)
                        {
                            btn_n25dd1h.Enabled = true;
                            btn_n25dd1l.Enabled = true;
                            btn_n25aa1h.Enabled = true;
                            btn_n25aa1l.Enabled = true;
                            btn_n25aa2h.Enabled = true;
                            btn_n25aa2l.Enabled = true;
                            btn_n25ident.Enabled = true;
                        }
                    }
                }
            }
            timer1.Enabled = true;
        }

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
                textBox1.AppendText("Node 01 Identify - d00001v000ta" + Environment.NewLine);
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
                textBox1.AppendText("Node 02 Identify - d00002v000ta" + Environment.NewLine);
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
                textBox1.AppendText("Node 03 Identify - d00003v000ta" + Environment.NewLine);
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
                textBox1.AppendText("Node 04 Identify - d00004v000ta" + Environment.NewLine);
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
                textBox1.AppendText("Node 05 Identify - d00005v000ta" + Environment.NewLine);
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
                textBox1.AppendText("Node 011 Identify - d00011v000ta" + Environment.NewLine);
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
                textBox1.AppendText("Node 012 Identify - d00012v000ta" + Environment.NewLine);
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
                textBox1.AppendText("Node 013 Identify - d00013v000ta" + Environment.NewLine);
            }
        }

        private void btn_n14ident_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00014v000ta");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 014 Identify - d00014v000ta" + Environment.NewLine);
            }
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
                textBox1.AppendText("Node 015 Identify - d00015v000ta" + Environment.NewLine);
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
                textBox1.AppendText("Node 021 Identify - d00021v000ta" + Environment.NewLine);
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
                textBox1.AppendText("Node 022 Identify - d00022v000ta" + Environment.NewLine);
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
                textBox1.AppendText("Node 023 Identify - d00023v000ta" + Environment.NewLine);
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
                textBox1.AppendText("Node 024 Identify - d00024v000ta" + Environment.NewLine);
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
                textBox1.AppendText("Node 025 Identify - d00025v000ta" + Environment.NewLine);
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
                textBox1.AppendText("Node 01 DD1 HIGH - d00001v000tb" + Environment.NewLine);
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
                textBox1.AppendText("Node 01 DD1 LOW - d00001v000tc" + Environment.NewLine);
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
                textBox1.AppendText("Node 01 AA1 HIGH - d00001v000te" + Environment.NewLine);
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
                textBox1.AppendText("Node 01 AA1 LOW - d00001v000tf" + Environment.NewLine);
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
                textBox1.AppendText("Node 01 AA2 HIGH - d00001v000tg" + Environment.NewLine);
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
                textBox1.AppendText("Node 01 AA2 LOW - d00001v000th" + Environment.NewLine);
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
                textBox1.AppendText("Node 02 DD1 HIGH - d00002v000tb" + Environment.NewLine);
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
                textBox1.AppendText("Node 02 DD1 LOW - d00002v000tc" + Environment.NewLine);
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
                textBox1.AppendText("Node 02 AA1 HIGH - d00002v000te" + Environment.NewLine);
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
                textBox1.AppendText("Node 02 AA1 LOW - d00002v000tf" + Environment.NewLine);
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
                textBox1.AppendText("Node 02 AA2 HIGH - d00002v000tg" + Environment.NewLine);
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
                textBox1.AppendText("Node 02 AA2 LOW - d00002v000th" + Environment.NewLine);
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
                textBox1.AppendText("Node 03 DD1 HIGH - d00003v000tb" + Environment.NewLine);
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
                textBox1.AppendText("Node 03 DD1 LOW - d00003v000tc" + Environment.NewLine);
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
                textBox1.AppendText("Node 03 AA1 HIGH - d00003v000te" + Environment.NewLine);
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
                textBox1.AppendText("Node 03 AA1 LOW - d00003v000tf" + Environment.NewLine);
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
                textBox1.AppendText("Node 03 AA2 HIGH - d00003v000tg" + Environment.NewLine);
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
                textBox1.AppendText("Node 03 AA2 LOW -  d00003v000th" + Environment.NewLine);
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
                textBox1.AppendText("Node 04 DD1 HIGH - d00004v000tb" + Environment.NewLine);
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
                textBox1.AppendText("Node 04 DD1 LOW - d00004v000tc" + Environment.NewLine);
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
                textBox1.AppendText("Node 04 AA1 HIGH - d00004v000te" + Environment.NewLine);
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
                textBox1.AppendText("Node 04 AA1 LOW - d00004v000tf" + Environment.NewLine);
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
                textBox1.AppendText("Node 04 AA2 HIGH - d00004v000tg" + Environment.NewLine);
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
                textBox1.AppendText("Node 04 AA2 LOW - d00004v000th" + Environment.NewLine);
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
                textBox1.AppendText("Node 05 DD1 HIGH - d00005v000tb" + Environment.NewLine);
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
                textBox1.AppendText("Node 05 DD1 LOW - d00005v000tc" + Environment.NewLine);
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
                textBox1.AppendText("Node 05 AA1 HIGH - d00005v000te" + Environment.NewLine);
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
                textBox1.AppendText("Node 05 AA1 LOW - d00005v000tf" + Environment.NewLine);
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
                textBox1.AppendText("Node 05 AA2 HIGH - d00005v000tg" + Environment.NewLine);
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
                textBox1.AppendText("Node 05 AA2 LOW - d00005v000th" + Environment.NewLine);
            }
        }

        // NODE 011

        private void btn_n11dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00011v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 011 DD1 HIGH - d00011v000tb" + Environment.NewLine);
            }
        }

        private void btn_n11dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00011v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 011 DD1 LOW - d00011v000tc" + Environment.NewLine);
            }
        }

        private void btn_n11aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00011v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 011 AA1 HIGH - d00011v000te" + Environment.NewLine);
            }
        }

        private void btn_n11aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00011v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 011 AA1 LOW - d00011v000tf" + Environment.NewLine);
            }
        }

        private void btn_n11aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00011v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 011 AA2 HIGH - d00011v000tg" + Environment.NewLine);
            }
        }

        private void btn_n11aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00011v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 011 AA2 LOW - d00011v000th" + Environment.NewLine);
            }
        }

        // NODE 012

        private void btn_n12dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00012v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 012 DD1 HIGH - d00012v000tb" + Environment.NewLine);
            }
        }

        private void btn_n12dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00012v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 012 DD1 LOW - d00012v000tc" + Environment.NewLine);
            }
        }

        private void btn_n12aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00012v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 012 AA1 HIGH - d00012v000te" + Environment.NewLine);
            }
        }

        private void btn_n12aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00012v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 012 AA1 LOW - d00012v000tf" + Environment.NewLine);
            }
        }

        private void btn_n12aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00012v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 012 AA2 HIGH - d00012v000tg" + Environment.NewLine);
            }
        }

        private void btn_n12aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00012v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 012 AA2 LOW - d00012v000th" + Environment.NewLine);
            }
        }

        // NODE 013

        private void btn_n13dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00013v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 013 DD1 HIGH - d00013v000tb" + Environment.NewLine);
            }
        }

        private void btn_n13dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00013v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 013 DD1 LOW - d00013v000tc" + Environment.NewLine);
            }
        }

        private void btn_n13aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00013v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 013 AA1 HIGH - d00013v000te" + Environment.NewLine);
            }
        }

        private void btn_n13aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00013v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 013 AA1 LOW - d00013v000tf" + Environment.NewLine);
            }
        }

        private void btn_n13aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00013v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 013 AA2 HIGH - d00013v000tg" + Environment.NewLine);
            }
        }

        private void btn_n13aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00013v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 013 AA2 LOW - d00013v000th" + Environment.NewLine);
            }
        }

        // NODE 014

        private void btn_n14dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00014v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 014 DD1 HIGH - d00014v000tb" + Environment.NewLine);
            }
        }

        private void btn_n14dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00014v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 014 DD1 LOW - d00014v000tc" + Environment.NewLine);
            }
        }

        private void btn_n14aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00014v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 014 AA1 HIGH - d00014v000te" + Environment.NewLine);
            }
        }

        private void btn_n14aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00014v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 014 AA1 LOW - d00014v000tf" + Environment.NewLine);
            }
        }

        private void btn_n14aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00014v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 014 AA2 HIGH - d00014v000tg" + Environment.NewLine);
            }
        }

        private void btn_n14aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00014v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 014 AA2 LOW - d00014v000th" + Environment.NewLine);
            }
        }

        // NODE 015

        private void btn_n15dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00015v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 015 DD1 HIGH - d00015v000tb" + Environment.NewLine);
            }
        }

        private void btn_n15dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00015v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 015 DD1 LOW - d00015v000tc" + Environment.NewLine);
            }
        }

        private void btn_n15aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00015v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 015 AA1 HIGH - d00015v000te" + Environment.NewLine);
            }
        }

        private void btn_n15aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00015v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 015 AA1 LOW - d00015v000tf" + Environment.NewLine);
            }
        }

        private void btn_n15aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00015v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 015 AA2 HIGH - d00015v000tg" + Environment.NewLine);
            }
        }

        private void btn_n15aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00015v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 015 AA2 LOW - d00015v000th" + Environment.NewLine);
            }
        }

        // NODE 021

        private void btn_n21dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00021v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 021 DD1 HIGH - d00021v000tb" + Environment.NewLine);
            }
        }

        private void btn_n21dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00021v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 021 DD1 LOW - d00021v000tc" + Environment.NewLine);
            }
        }

        private void btn_n21aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00021v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 021 AA1 HIGH - d00021v000te" + Environment.NewLine);
            }
        }

        private void btn_n21aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00021v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 021 AA1 LOW - d00021v000tf" + Environment.NewLine);
            }
        }

        private void btn_n21aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00021v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 021 AA2 HIGH - d00021v000tg" + Environment.NewLine);
            }
        }

        private void btn_n21aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00021v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 021 AA2 LOW - d00021v000th" + Environment.NewLine);
            }
        }

        // NODE 022

        private void btn_n22dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00022v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 022 DD1 HIGH - d00022v000tb" + Environment.NewLine);
            }
        }

        private void btn_n22dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00022v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 022 DD1 LOW - d00022v000tc" + Environment.NewLine);
            }
        }

        private void btn_n22aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00022v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 022 AA1 HIGH - d00022v000te" + Environment.NewLine);
            }
        }

        private void btn_n22aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00022v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 022 AA1 LOW - d00022v000tf" + Environment.NewLine);
            }
        }

        private void btn_n22aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00022v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 022 AA2 HIGH - d00022v000tg" + Environment.NewLine);
            }
        }

        private void btn_n22aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00022v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 022 AA2 LOW - d00022v000th" + Environment.NewLine);
            }
        }

        // NODE 023

        private void btn_n23dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00023v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 023 DD1 HIGH - d00023v000tb" + Environment.NewLine);
            }
        }

        private void btn_n23dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00023v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 023 DD1 LOW - d00023v000tc" + Environment.NewLine);
            }
        }

        private void btn_n23aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00023v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 023 AA1 HIGH - d00023v000te" + Environment.NewLine);
            }
        }

        private void btn_n23aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00023v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 023 AA1 LOW - d00023v000tf" + Environment.NewLine);
            }
        }

        private void btn_n23aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00023v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 023 AA2 HIGH - d00023v000tg" + Environment.NewLine);
            }
        }

        private void btn_n23aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00023v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 023 AA2 LOW - d00023v000th" + Environment.NewLine);
            }
        }

        // NODE 024

        private void btn_n24dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00024v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 024 DD1 HIGH - d00024v000tb" + Environment.NewLine);
            }
        }

        private void btn_n24dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00024v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 024 DD1 LOW - d00024v000tc" + Environment.NewLine);
            }
        }

        private void btn_n24aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00024v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 024 AA1 HIGH - d00024v000te" + Environment.NewLine);
            }
        }

        private void btn_n24aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00024v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 024 AA1 LOW - d00024v000tf" + Environment.NewLine);
            }
        }

        private void btn_n24aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00024v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 024 AA2 HIGH - d00024v000tg" + Environment.NewLine);
            }
        }

        private void btn_n24aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00024v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 024 AA2 LOW- d00024v000th" + Environment.NewLine);
            }
        }

        // NODE 025

        private void btn_n25dd1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00025v000tb");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 025 DD1 HIGH - d00025v000tb" + Environment.NewLine);
            }
        }

        private void btn_n25dd1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00025v000tc");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 025 DD1 LOW - d00025v000tc" + Environment.NewLine);
            }
        }

        private void btn_n25aa1h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00025v000te");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 025 AA1 HIGH - d00025v000te" + Environment.NewLine);
            }
        }

        private void btn_n25aa1l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00025v000tf");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 025 AA1 LOW - d00025v000tf" + Environment.NewLine);
            }
        }

        private void btn_n25aa2h_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00025v000tg");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 025 AA2 HIGH - d00025v000tg" + Environment.NewLine);
            }
        }

        private void btn_n25aa2l_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00025v000th");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Node 025 AA2 LOW - d00025v000th" + Environment.NewLine);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            textBox3.Text = ("0.00v");
            textBox4.Text = ("0.00°c");
            textBox5.Text = ("0.00v");
            textBox6.Text = ("0.00°c");
            textBox7.Text = ("0.00v");
            textBox8.Text = ("0.00°c");
            textBox9.Text = ("0.00v");
            textBox10.Text = ("0.00°c");
            textBox11.Text = ("0.00v");
            textBox12.Text = ("0.00°c");

            textBox15.Text = ("0.00v");
            textBox16.Text = ("0.00°c");
            textBox17.Text = ("0.00v");
            textBox18.Text = ("0.00°c");
            textBox19.Text = ("0.00v");
            textBox20.Text = ("0.00°c");
            textBox21.Text = ("0.00v");
            textBox22.Text = ("0.00°c");
            textBox23.Text = ("0.00v");
            textBox24.Text = ("0.00°c");

            textBox27.Text = ("0.00v");
            textBox28.Text = ("0.00°c");
            textBox29.Text = ("0.00v");
            textBox30.Text = ("0.00°c");
            textBox31.Text = ("0.00v");
            textBox32.Text = ("0.00°c");
            textBox33.Text = ("0.00v");
            textBox34.Text = ("0.00°c");
            textBox35.Text = ("0.00v");
            textBox36.Text = ("0.00°c");

            node01_alive = false;
            node02_alive = false;
            node03_alive = false;
            node04_alive = false;
            node05_alive = false;
            node011_alive = false;
            node012_alive = false;
            node013_alive = false;
            node014_alive = false;
            node015_alive = false;
            node021_alive = false;
            node022_alive = false;
            node023_alive = false;
            node024_alive = false;
            node025_alive = false;

            btn_n1dd1h.Enabled = false;
            btn_n1dd1l.Enabled = false;
            btn_n1aa1h.Enabled = false;
            btn_n1aa1l.Enabled = false;
            btn_n1aa2h.Enabled = false;
            btn_n1aa2l.Enabled = false;
            btn_n1ident.Enabled = false;

            btn_n2dd1h.Enabled = false;
            btn_n2dd1l.Enabled = false;
            btn_n2aa1h.Enabled = false;
            btn_n2aa1l.Enabled = false;
            btn_n2aa2h.Enabled = false;
            btn_n2aa2l.Enabled = false;
            btn_n2ident.Enabled = false;

            btn_n3dd1h.Enabled = false;
            btn_n3dd1l.Enabled = false;
            btn_n3aa1h.Enabled = false;
            btn_n3aa1l.Enabled = false;
            btn_n3aa2h.Enabled = false;
            btn_n3aa2l.Enabled = false;
            btn_n3ident.Enabled = false;

            btn_n4dd1h.Enabled = false;
            btn_n4dd1l.Enabled = false;
            btn_n4aa1h.Enabled = false;
            btn_n4aa1l.Enabled = false;
            btn_n4aa2h.Enabled = false;
            btn_n4aa2l.Enabled = false;
            btn_n4ident.Enabled = false;

            btn_n5dd1h.Enabled = false;
            btn_n5dd1l.Enabled = false;
            btn_n5aa1h.Enabled = false;
            btn_n5aa1l.Enabled = false;
            btn_n5aa2h.Enabled = false;
            btn_n5aa2l.Enabled = false;
            btn_n5ident.Enabled = false;

            btn_n11dd1h.Enabled = false;
            btn_n11dd1l.Enabled = false;
            btn_n11aa1h.Enabled = false;
            btn_n11aa1l.Enabled = false;
            btn_n11aa2h.Enabled = false;
            btn_n11aa2l.Enabled = false;
            btn_n11ident.Enabled = false;

            btn_n12dd1h.Enabled = false;
            btn_n12dd1l.Enabled = false;
            btn_n12aa1h.Enabled = false;
            btn_n12aa1l.Enabled = false;
            btn_n12aa2h.Enabled = false;
            btn_n12aa2l.Enabled = false;
            btn_n12ident.Enabled = false;

            btn_n13dd1h.Enabled = false;
            btn_n13dd1l.Enabled = false;
            btn_n13aa1h.Enabled = false;
            btn_n13aa1l.Enabled = false;
            btn_n13aa2h.Enabled = false;
            btn_n13aa2l.Enabled = false;
            btn_n13ident.Enabled = false;

            btn_n14dd1h.Enabled = false;
            btn_n14dd1l.Enabled = false;
            btn_n14aa1h.Enabled = false;
            btn_n14aa1l.Enabled = false;
            btn_n14aa2h.Enabled = false;
            btn_n14aa2l.Enabled = false;
            btn_n14ident.Enabled = false;

            btn_n15dd1h.Enabled = false;
            btn_n15dd1l.Enabled = false;
            btn_n15aa1h.Enabled = false;
            btn_n15aa1l.Enabled = false;
            btn_n15aa2h.Enabled = false;
            btn_n15aa2l.Enabled = false;
            btn_n15ident.Enabled = false;

            btn_n21dd1h.Enabled = false;
            btn_n21dd1l.Enabled = false;
            btn_n21aa1h.Enabled = false;
            btn_n21aa1l.Enabled = false;
            btn_n21aa2h.Enabled = false;
            btn_n21aa2l.Enabled = false;
            btn_n21ident.Enabled = false;

            btn_n22dd1h.Enabled = false;
            btn_n22dd1l.Enabled = false;
            btn_n22aa1h.Enabled = false;
            btn_n22aa1l.Enabled = false;
            btn_n22aa2h.Enabled = false;
            btn_n22aa2l.Enabled = false;
            btn_n22ident.Enabled = false;

            btn_n23dd1h.Enabled = false;
            btn_n23dd1l.Enabled = false;
            btn_n23aa1h.Enabled = false;
            btn_n23aa1l.Enabled = false;
            btn_n23aa2h.Enabled = false;
            btn_n23aa2l.Enabled = false;
            btn_n23ident.Enabled = false;

            btn_n24dd1h.Enabled = false;
            btn_n24dd1l.Enabled = false;
            btn_n24aa1h.Enabled = false;
            btn_n24aa1l.Enabled = false;
            btn_n24aa2h.Enabled = false;
            btn_n24aa2l.Enabled = false;
            btn_n24ident.Enabled = false;

            btn_n25dd1h.Enabled = false;
            btn_n25dd1l.Enabled = false;
            btn_n25aa1h.Enabled = false;
            btn_n25aa1l.Enabled = false;
            btn_n25aa2h.Enabled = false;
            btn_n25aa2l.Enabled = false;
            btn_n25ident.Enabled = false;

            if (!serialPort1.IsOpen)
            {
                serial_check();
            }
            else
            {
                serialPort1.Write("d00000v000tl");
                serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                textBox1.AppendText("Checking Network Status - d00000v000tl" + Environment.NewLine);
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            btn_scan_Click(null, null);
            timer2.Enabled = true;
        }


    }
}
