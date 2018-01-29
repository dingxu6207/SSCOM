using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace SSCOM
{
    public partial class ComSet : Form
    {
        public ComSet()
        {
            InitializeComponent();
        }

        private void ComSet_Load(object sender, EventArgs e)
        {
            //串口
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cmbPort.Items.Add(port);
            }
            cmbPort.SelectedIndex = 0;


            //波特率
            cmbBaudRate.Items.Add("110");
            cmbBaudRate.Items.Add("300");
            cmbBaudRate.Items.Add("1200");
            cmbBaudRate.Items.Add("2400");
            cmbBaudRate.Items.Add("4800");
            cmbBaudRate.Items.Add("9600");
            cmbBaudRate.Items.Add("19200");
            cmbBaudRate.Items.Add("38400");
            cmbBaudRate.Items.Add("57600");
            cmbBaudRate.Items.Add("115200");
            cmbBaudRate.Items.Add("230400");
            cmbBaudRate.Items.Add("460800");
            cmbBaudRate.Items.Add("921600");
            cmbBaudRate.SelectedIndex = 9;

            //数据位
            cmbDataBits.Items.Add("8");
            cmbDataBits.Items.Add("7");
            cmbDataBits.Items.Add("6");
            cmbDataBits.SelectedIndex = 0;

            //停止位
            cmbStopBit.Items.Add("1");
            cmbStopBit.SelectedIndex = 0;

            //校验位
            cmbParity.Items.Add("无");
            cmbParity.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.strPortName = cmbPort.Text;
            Form1.strBaudRate = cmbBaudRate.Text;
            Form1.strDataBits = cmbDataBits.Text;
            Form1.strStopBits = cmbStopBit.Text;
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
