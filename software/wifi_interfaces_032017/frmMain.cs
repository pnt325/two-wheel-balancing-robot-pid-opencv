using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;
using ZedGraph;

namespace wifi_interfaces_032017
{

    public partial class frmMain : Form
    {
        string host;
        int port;
        static ASCIIEncoding encoding = new ASCIIEncoding();
        TcpClient client;
        Thread th;
        int keyw, keya, keys, keyd;

        //int TickStart;
        double angle = 10;

        public frmMain()
        {
            CheckForIllegalCrossThreadCalls = false;//Cho phép liên kết dữ liệu từ thread đến form
            InitializeComponent();
        }
        //Thiết lập mặc định khi mở úng dụng
        private void Form1_Load(object sender, EventArgs e)
        {
            txb_address.Text = "192.168.170.102";//set default ip
            txb_port.Text = "8080";//set default port number
            btnRight.Enabled = false;
            btnLeft.Enabled = false;
            btnForward.Enabled = false;
            btnBack.Enabled = false;

            rabOn.Checked = false;
            rabOff.Checked = true;

            //rabOn.Enabled = false;
            //rabOff.Enabled = false;

            lblFBSpeedMin.Text = trbFBSpeed.Minimum.ToString();
            lblFBSpeedMax.Text = trbFBSpeed.Maximum.ToString();

            lblLRSpeedMin.Text = trbLRSpeed.Minimum.ToString();
            lblLRSpeedMax.Text = trbLRSpeed.Maximum.ToString();

            //grbConfigure.Enabled = false;
            trbFBSpeed.Value = 80;
            trbLRSpeed.Value = 30;

            txbFBSpeed.Text = trbFBSpeed.Value.ToString();
            txbLRSpeed.Text = trbLRSpeed.Value.ToString();

            chbEnable.Checked = true;

            chbGraph.Checked = false;

            //hiden button using graph
            chbGraph.Hide();

        }

        //Cập nhật địa chỉ ip
        private void txb_address_TextChanged(object sender, EventArgs e)
        {
            host = txb_address.Text;
        }

        //Cập nhật port
        private void txb_port_TextChanged(object sender, EventArgs e)
        {
            try
            {
                port = Convert.ToInt16(txb_port.Text);
            }
            catch
            {
                return;
            }
        }
           
        // Nút kết nối với raspberry py thông qua wifi
        private void btn_connect_Click(object sender, EventArgs e)
        {
            //txb_address.Enabled = false;
            //txb_port.Enabled = false;

            TcpClient client_temp = new TcpClient();
            Thread th_connect = new Thread(client_connect);
            th_connect.IsBackground = true;
            th_connect.Start(client_temp);
        }

        public void setting_default()
        {
            rabOff.Checked = true;
            chbEnable.Checked = true;
            trbFBSpeed.Value = 80;
            trbLRSpeed.Value = 60;
        }

        public void client_connect(object obj)
        {
            if (btn_connect.Text == "Connect")
            {
                try
                {
                    btn_connect.Text = "Connecting...";
                    btn_connect.Enabled = false;

                    TcpClient client_connect = obj as TcpClient;
                    client_connect.Connect(IPAddress.Parse(host), port);
                    client = client_connect;

                    Thread th_receive = new Thread(nhandulieu);
                    th = th_receive;
                    th.IsBackground = true;
                    th.Start();

                    grbConfigure.Enabled = true;

                    btnForward.Enabled = true;
                    btnBack.Enabled = true;
                    btnLeft.Enabled = true;
                    btnRight.Enabled = true;

                    rabOn.Enabled = true;
                    rabOff.Enabled = true;
                    console("<Laptop># Connection successed to Rasperry");

                    btn_connect.Text = "Disconnect";
                    btn_connect.Enabled = true;


                    //Thread th_dis = new Thread(displayVideo);
                    //th_dis.IsBackground = true;
                    //th_dis.Start();

                }
                catch
                {
                    console("<Laptop># Connection failed to Raspberry");
                    btn_connect.Enabled = true;
                    btn_connect.Text = "Connect";
                    grbConfigure.Enabled = false;
                    btnForward.Enabled = false;
                    btnBack.Enabled = false;
                    btnLeft.Enabled = false;
                    btnRight.Enabled = false;
                }
            }
            else
            {
                client.Close();
                th.Abort();
                console("<Laptop># Disconnect to Raspberry");
                btn_connect.Text = "Connect";
                grbConfigure.Enabled = false;
                rabOff.Checked = true;

            }
        }

        //Thread nhận dữ liệu từ Server (Raspberry py)
        public void nhandulieu()
        {
            Stream stream = client.GetStream();
            while (true)
            {
                try
                {
                    byte[] data = new byte[10240];
                    byte[] data_temp = new byte[10240];
                    stream.Read(data, 0, 10240);
                    if (data != data_temp)
                    {
                        string str = encoding.GetString(data);
                        string[] chuoi = str.Split('@');

                        if (chuoi[0] == "mesg")
                        {
                            //string[] mesg = chuoi[1].Split('?');
                            console("<Raspberry># " + chuoi[1]);
                        }
                        else if (chuoi[0] == "angle")
                        {
                            double.TryParse(chuoi[1], out angle);//convert string to doubel value
                            //lblangle.Text = angle.ToString();
                        }
                        else
                        {
                            //rev_image = data;
                            if (chbGraph.Checked == false)
                            {
                                Thread th_dis = new Thread(displayVideo);
                                th_dis.IsBackground = true;
                                th_dis.Start(data);
                            }
                        }
                    }
                    else
                    {
                        stream.Close();
                        client.Close();
                        btn_connect.Text = "Connect";
                        console("<Laptop># Disconnect to Raspberry");
                        break;
                    }
                }
                catch
                {
                    console("<Laptop># Disconnect to Raspberry");
                    btn_connect.Text = "Connect";
                    grbConfigure.Enabled = false;
                    stream.Close();
                    client.Close();
                    break;
                }
            }
        }

        //Hiển thị nội dung nhận được lên form
        //public void displayVideo(object obj)
        public void displayVideo(object obj)
        {
            try
            {
                byte[] _hinh = obj as byte[];
                MemoryStream ms = new MemoryStream(_hinh);
                pic_image.Image = Image.FromStream(ms);
            }
            catch
            {
            }
        }

        //
        private void txb_send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//Key enter
            {
                if (txb_send.Text == "clc")
                {
                    txb_console.Text = "";
                    txb_send.Text = "";
                }
                else
                {
                    send(txb_send.Text);
                    txb_send.Text = "";
                }
            }
        }

        //Gửi dữ liệu qua TCP/IP
        void send(string str)
        {
            if (btn_connect.Text == "Disconnect")
            {
                Stream stream = client.GetStream();
                try
                {
                    byte[] data = new byte[1024];
                    data = encoding.GetBytes(str);
                    stream.Write(data, 0, data.Length);
                }
                catch
                {
                    console("<Laptop># Disconnect to Raspberry");
                    th.Abort();
                    btn_connect.Text = "Connect";
                    grbConfigure.Enabled = false;
                    client.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please connect to Raspberry\r\nbefore send something");
                return;
            }
        }

        //Sự kiện tắt form thực hiện các thao tắc dóng form
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                client.Close();
                th.Abort();
            }
            catch
            {
                return;
            }
        }
        //<summary>
        //nút nhấn gửi chuỗi điều khiển
        //</summary>
        //<param name="sender"></param>
        //<param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            send(txb_send.Text);
            txb_send.Text = "";
        }

        //Hiển thị nội dung lên text box
        public void console(string s)
        {
            try
            {
                txb_console.AppendText(s);
                txb_console.AppendText(Environment.NewLine);
            }
            catch
            {
                MessageBox.Show("Have no connect to Server");
            }
        }
        /// <summary>
        /// Phím nhấn điều khiển robot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// //Nhấn phím
        private void txb_console_KeyDown(object sender, KeyEventArgs e)
        {
            if (btn_connect.Text == "Disconnect")
            {
                if (e.KeyValue == 87)//Key "W"
                {
                    if (keyw != 1)
                    {
                        send("ct@forward");
                        btnForward.Enabled = false;
                        keyw = 1;
                    }
                }
                if (e.KeyValue == 83)//Key "S"
                {
                    if (keys != 1)
                    {
                        send("ct@back");
                        btnBack.Enabled = false;
                        keys = 1;
                    }
                }
                if (e.KeyValue == 65)//Key "A"
                {
                    if (keya != 1)
                    {
                        send("ct@left");
                        btnLeft.Enabled = false;
                        keya = 1;
                    }
                }
                if (e.KeyValue == 68)//Key "D"
                {
                    if (keyd != 1)
                    {
                        send("ct@right");
                        btnRight.Enabled = false;
                        keyd = 1;
                    }
                }
            }
        }
        //Nhả phím
        private void txb_console_KeyUp(object sender, KeyEventArgs e)
        {
            if (btn_connect.Text == "Disconnect")
            {
                if (e.KeyValue == 87)//Key "W"
                {
                    send("ct@gostop");
                    btnForward.Enabled = true;
                    keyw = 0;
                }
                if (e.KeyValue == 83)//Key "S"
                {
                    send("ct@gostop");
                    btnBack.Enabled = true;
                    keys = 0;
                }
                if (e.KeyValue == 65)//Key "A"
                {
                    send("ct@turnstop");
                    btnLeft.Enabled = true;
                    keya = 0;
                }
                if (e.KeyValue == 68)//Key "D"
                {
                    send("ct@turnstop");
                    btnRight.Enabled = true;
                    keyd = 0;
                }
            }
        }
        /// <summary>
        /// Phím điều hướng điều khiển robot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForward_MouseDown(object sender, MouseEventArgs e)
        {
            send("ct@forward");
        }

        private void btnForward_MouseUp(object sender, MouseEventArgs e)
        {
            send("ct@gostop");
        }

        private void btnBack_MouseDown(object sender, MouseEventArgs e)
        {
            send("ct@back");
        }

        private void btnBack_MouseUp(object sender, MouseEventArgs e)
        {
            send("ct@gostop");
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            send("ct@left");
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            send("ct@turnstop");
        }

        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            send("ct@right");
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            send("ct@turnstop");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_connect.Text == "Disconnect")
            {
                if (rabOn.Checked == true)
                {
                    send("dt@detecton");
                }
            }
        }

        private void rabOff_CheckedChanged(object sender, EventArgs e)
        {
            if (btn_connect.Text == "Disconnect")
            {
                if (rabOff.Checked == true)
                {
                    send("dt@detectoff");
                }
            }
        }

        private void trbSpeed_Scroll(object sender, EventArgs e)
        {
            txbFBSpeed.Text = trbFBSpeed.Value.ToString();
        }

        private void txbSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//Key Enter
            {
                if ((Convert.ToInt16(txbFBSpeed.Text) <= trbFBSpeed.Maximum) && (Convert.ToInt16(txbFBSpeed.Text) >= trbFBSpeed.Minimum))
                {
                    trbFBSpeed.Value = Convert.ToInt16(txbFBSpeed.Text);
                    send("setgo@"+txbFBSpeed.Text);
                }
                else
                {
                    MessageBox.Show("Please type value from " + trbFBSpeed.Minimum.ToString() + " to "+ trbFBSpeed.Maximum.ToString());
                    txbFBSpeed.Text = "";
                }
            }
        }
        /// <summary>
        /// Hiển thị giá trị thanh kéo lên trên text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trbSpeed_MouseUp(object sender, MouseEventArgs e)
        {
            send("setgo@" + trbFBSpeed.Value.ToString());
        }

        private void trbLRSpeed_Scroll(object sender, EventArgs e)
        {
            txbLRSpeed.Text = trbLRSpeed.Value.ToString();
        }
        /// <summary>
        /// Chọn giá trị tốc độ điều khiển cho robot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbLRSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//Key Enter
            {
                if ((Convert.ToInt16(txbLRSpeed.Text) <= trbLRSpeed.Maximum) && (Convert.ToInt16(txbLRSpeed.Text) >= trbLRSpeed.Minimum))
                {
                    trbLRSpeed.Value = Convert.ToInt16(txbLRSpeed.Text);
                    send("setturn@" + txbLRSpeed.Text);
                }
                else
                {
                    MessageBox.Show("Please type value from " + trbLRSpeed.Minimum.ToString() + " to " + trbLRSpeed.Maximum.ToString());
                    txbLRSpeed.Text = "";
                }
            }
        }

        private void trbLRSpeed_MouseUp(object sender, MouseEventArgs e)
        {
            send("setturn@" + trbLRSpeed.Value.ToString());
        }

        private void chbEnable_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(chbEnable.Checked.ToString());
            if (btn_connect.Text == "Disconnect")
            {
                string text_send = chbEnable.Checked.ToString();
                send("setenable@" + text_send);
            }
        }
        
        //chuong trinh con ve do thi.
        public void drawing(double _angle, ZedGraphControl _graph, int _tickstart)
        {
            if (_graph.GraphPane.CurveList.Count <= 0)
                return;
            
            LineItem curve1 = _graph.GraphPane.CurveList[0] as LineItem;
            if(curve1 == null) 
                return;

            IPointListEdit list1 = curve1.Points as IPointListEdit;
            if (list1 == null)
                return;

            double time1 = (Environment.TickCount - _tickstart) / 1000.0;
            list1.Add(time1, _angle);

            //Auto scale x axis
            Scale xScale1 = _graph.GraphPane.XAxis.Scale;
            if (time1 > xScale1.Max - xScale1.MajorStep)
            {
                xScale1.Max = time1 + xScale1.MajorStep;
                xScale1.Min = xScale1.Max - 10;//Auto scale x axis in limit time
            }

            _graph.AxisChange();
            _graph.Invalidate();
        }

        //Chuyên đỏi dữ liệu byte thành hình ảnh
        public Image byteToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream();
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
