using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace TEST_ETHERNET
{
    public partial class Form1 : Form
    {
        bool push1 = false;
        bool push2 = false;
        bool push3 = false;
        bool push4 = false;
        //System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            msg("Client Started");

            //clientSocket.Connect("192.168.0.120", 80);

            label1.Text = "Client Socket Program - Server Connected ...";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //NetworkStream serverStream = clientSocket.GetStream();

            //byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox2.Text + "$");

            //serverStream.Write(outStream, 0, outStream.Length);

            //serverStream.Flush();



            //byte[] inStream = new byte[10025];  //10025

            //serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);

            //string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            //msg(returndata);

            //textBox2.Text = "";

            //textBox2.Focus();
        }

        public void msg(string mesg)
        {
            textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + mesg;
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            textBox2.Clear();
            try
            {
                WebRequest request = WebRequest.Create("http://192.168.0.120/leds.cgi?led=1&led=2&led=3");
                using (WebResponse response = await request.GetResponseAsync())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            textBox2.Text += reader.ReadToEnd() + Environment.NewLine;
                            response.Close();
                            //Console.WriteLine(reader.ReadToEnd());
                        }

                    }
                }

            }
            catch(WebException)
            {;}

        }

        private void button3_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://192.168.0.120/ledaction.cgi");
            request.Method = "POST";
            string sName = "ledtoggle=1";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(sName);
            request.ContentType = "/index.shtml";
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
        }

        private async void button4_ClickAsync(object sender, EventArgs e)
        {
            textBox2.Clear();
            if (!push1)
            {
                try
                {
                    WebRequest request = WebRequest.Create("http://192.168.0.120/leds.cgi?led=on1");
                    using (WebResponse response = await request.GetResponseAsync())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                textBox2.Text += reader.ReadToEnd() + Environment.NewLine;
                                webBrowser1.DocumentText = textBox2.Text;
                                //webBrowser1.DocumentText = reader.ReadToEnd() + Environment.NewLine;
                                response.Close();
                                //Console.WriteLine(reader.ReadToEnd());
                            }

                        }
                    }

                }
                catch (WebException)
                {;}
                push1 = true;
            }
            else
            {
                try
                {
                    WebRequest request = WebRequest.Create("http://192.168.0.120/leds.cgi?led=off1");
                    using (WebResponse response = await request.GetResponseAsync())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                textBox2.Text += reader.ReadToEnd() + Environment.NewLine;
                                response.Close();
                                //Console.WriteLine(reader.ReadToEnd());
                            }

                        }
                    }

                }
                catch (WebException)
                {;}
                push1 = false;
            }

        }

        private async void button5_ClickAsync(object sender, EventArgs e)
        {
            textBox2.Clear();
            if (!push2)
            {
                try
                {
                    WebRequest request = WebRequest.Create("http://192.168.0.120/leds.cgi?led=on2");
                    using (WebResponse response = await request.GetResponseAsync())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                textBox2.Text += reader.ReadToEnd() + Environment.NewLine;
                                response.Close();
                                //Console.WriteLine(reader.ReadToEnd());
                            }

                        }
                    }

                }
                catch (WebException)
                {; }
                push2 = true;
            }
            else
            {
                try
                {
                    WebRequest request = WebRequest.Create("http://192.168.0.120/leds.cgi?led=off2");
                    using (WebResponse response = await request.GetResponseAsync())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                textBox2.Text += reader.ReadToEnd() + Environment.NewLine;
                                response.Close();
                                //Console.WriteLine(reader.ReadToEnd());
                            }

                        }
                    }

                }
                catch (WebException)
                {; }
                push2 = false;
            }
        }

        private async void button6_ClickAsync(object sender, EventArgs e)
        {
            textBox2.Clear();
            if (!push3)
            {
                try
                {
                    WebRequest request = WebRequest.Create("http://192.168.0.120/leds.cgi?led=on3");
                    using (WebResponse response = await request.GetResponseAsync())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                textBox2.Text += reader.ReadToEnd() + Environment.NewLine;
                                response.Close();
                                //Console.WriteLine(reader.ReadToEnd());
                            }

                        }
                    }

                }
                catch (WebException)
                {; }
                push3 = true;
            }
            else
            {
                try
                {
                    WebRequest request = WebRequest.Create("http://192.168.0.120/leds.cgi?led=off3");
                    using (WebResponse response = await request.GetResponseAsync())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                textBox2.Text += reader.ReadToEnd() + Environment.NewLine;
                                response.Close();
                                //Console.WriteLine(reader.ReadToEnd());
                            }

                        }
                    }

                }
                catch (WebException)
                {; }
                push3 = false;
            }
        }

        private async void button7_ClickAsync(object sender, EventArgs e)
        {
            textBox2.Clear();
            if (!push4)
            {
                try
                {
                    WebRequest request = WebRequest.Create("http://192.168.0.120/leds.cgi?led=on4");
                    using (WebResponse response = await request.GetResponseAsync())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                textBox2.Text += reader.ReadToEnd() + Environment.NewLine;
                                response.Close();
                                //Console.WriteLine(reader.ReadToEnd());
                            }

                        }
                    }

                }
                catch (WebException)
                {; }
                push4 = true;
            }
            else
            {
                try
                {
                    WebRequest request = WebRequest.Create("http://192.168.0.120/leds.cgi?led=off4");
                    using (WebResponse response = await request.GetResponseAsync())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                textBox2.Text += reader.ReadToEnd() + Environment.NewLine;
                                response.Close();
                                //Console.WriteLine(reader.ReadToEnd());
                            }

                        }
                    }

                }
                catch (WebException)
                {; }
                push4 = false;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
