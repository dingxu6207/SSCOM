using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Collections;

namespace SSCOM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.btnSendData.Enabled = false;
            this.SetCode.Enabled = false;
            this.SetIP.Enabled = false;
            this.WifiConnect.Enabled = false;

        }

        public static string strPortName = "";
        public static string strBaudRate = "";
        public static string strDataBits = "";
        public static string strStopBits = "";

        SerialPort sp = new SerialPort();
        private void btnSetSP_Click(object sender, EventArgs e)
        {
            sp.Close();
            ComSet dlg = new ComSet();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                sp.PortName = strPortName;
                sp.BaudRate = int.Parse(strBaudRate);
                sp.DataBits = int.Parse(strDataBits);
                sp.StopBits = (StopBits)int.Parse(strStopBits);
                sp.ReadTimeout = 500;  
            }
        }

        private void btnSwitchSP_Click(object sender, EventArgs e)
        {
            if (btnSwitchSP.Text == "打开串口")
            {
               
                if (strPortName != "" && strBaudRate != "" && strDataBits != "" && strStopBits != "")
                {
                    try
                    {
                        if (sp.IsOpen)
                        {
                            sp.Close();
                            sp.Open(); //打开串口  
                            timer2.Enabled = true;
                        }
                        else
                        {
                            sp.Open();//打开串口  
                            timer2.Enabled = true;
                        }
                        btnSwitchSP.Text = "关闭串口";
                        btnSetSP.Enabled = false;
                       
                    }
                    catch
                    {

                    }
                    this.btnSendData.Enabled = true;
                    this.SetCode.Enabled = true;
                    this.SetIP.Enabled = true;
                    this.WifiConnect.Enabled = true;
                }
                else
                {
                    MessageBox.Show("请先设置串口！", "RS232串口通信");                  
                }
            }
            else
            {
                this.btnSendData.Enabled = false;
                this.SetCode.Enabled = false;
                this.SetIP.Enabled = false;
                this.WifiConnect.Enabled = false;
                timer2.Enabled = false;
                btnSetSP.Enabled = true;
                btnSwitchSP.Text = "打开串口";
                sp.Close();
            }
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            string wifiname = ":FA" + txtSend.Text + "#";
            if (sp.IsOpen)
            {
                try
                {
                    sp.Encoding = System.Text.Encoding.GetEncoding("GB2312");//GB2312即信息交换用汉字编码字符集
                    sp.Write(wifiname);
                }
                catch (Exception ex)//若应用程序出现调试问题
                {
                    MessageBox.Show("错误：" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请先打开串口！");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            sp.Encoding = System.Text.Encoding.GetEncoding("GB2312");//GB2312即信息交换用汉字编码字符集
            string str = sp.ReadExisting();
            string str4 = str.Replace("\r", "\r\n");
            textBox1.AppendText(str4);
            textBox1.ScrollToCaret();
        }

        private void btnReceiveData_Click(object sender, EventArgs e)
        {
            sp.Encoding = System.Text.Encoding.GetEncoding("GB2312");//GB2312即信息交换用汉字编码字符集
            if (sp.IsOpen)
            {
                timer2.Enabled = true;
            }
            else
            {
                MessageBox.Show("请先打开串口！");
            }
        }

        private void SetCode_Click(object sender, EventArgs e)
        {
            string wificode = ":FC" + textCode.Text + "#";
            if (sp.IsOpen)
            {
                try
                {
                    sp.Encoding = System.Text.Encoding.GetEncoding("GB2312");//GB2312即信息交换用汉字编码字符集
                    sp.Write(wificode);
                }
                catch (Exception ex)//若应用程序出现调试问题
                {
                    MessageBox.Show("错误：" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请先打开串口！");
            }
        }

        private void SetIP_Click(object sender, EventArgs e)
        {
            string serverIp = ":FW" + textip.Text + "#";
            if (sp.IsOpen)
            {
                try
                {
                    sp.Encoding = System.Text.Encoding.GetEncoding("GB2312");//GB2312即信息交换用汉字编码字符集
                    sp.Write(serverIp);
                }
                catch (Exception ex)//若应用程序出现调试问题
                {
                    MessageBox.Show("错误：" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请先打开串口！");
            }
        }

        private void WifiConnect_Click(object sender, EventArgs e)
        {
            string WifiCon = ":FY#";
            if (sp.IsOpen)
            {
                try
                {
                    sp.Encoding = System.Text.Encoding.GetEncoding("GB2312");//GB2312即信息交换用汉字编码字符集
                    sp.Write(WifiCon);
                }
                catch (Exception ex)//若应用程序出现调试问题
                {
                    MessageBox.Show("错误：" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请先打开串口！");
            } 
        }



    }
}
