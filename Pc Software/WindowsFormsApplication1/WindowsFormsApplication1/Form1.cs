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

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00001v000td");
            serialPort1.Write(new byte[] {0x0D, 0x0A},0 ,2);
        } //done

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00002v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00003v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00004v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00005v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done

        private void button6_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00011v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done

        private void button7_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00012v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done

        private void button8_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00013v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done

        private void button9_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00014v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done

        private void button10_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00015v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done

        private void button11_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00021v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done

        private void button12_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00022v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done

        private void button13_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00023v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done

        private void button14_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00024v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done

        private void button15_Click(object sender, EventArgs e)
        {
            serialPort1.Write("d00025v000td");
            serialPort1.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
        } //done  
    }
}
