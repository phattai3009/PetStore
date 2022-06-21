using AForge.Video;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using BLL;
using static DoAn_DotNet.GUI.frmSell;

namespace DoAn_DotNet.GUI
{
    public partial class frmCode : Form
    {
        DonHangBLL bllDonHang = new DonHangBLL();
        public layMaTCQR send;
        public frmCode()
        {
            InitializeComponent();
        }

        public frmCode(layMaTCQR sender)
        {
            InitializeComponent();
            this.send = sender;
        }


        frmSell sell = new frmSell();
        MJPEGStream stream;

        //Load thông báo
        public void Alert(string msg, frmCustomTB.enmType type)
        {
            frmCustomTB frm = new frmCustomTB();
            frm.showAlert(msg, type);
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (btn_Connect.Text == "Connect")
            {
                stream = new MJPEGStream(txt_url_DroidCam.Text);
                stream.NewFrame += stream_NewFrame;
                stream.Start();
                timer1.Enabled = true;
                timer1.Start();
                btn_Connect.Text = "Disconnect";
            }
            else
            {
                btn_Connect.Text = "Connect";
                timer1.Stop();
                stream.Stop();
            }

        }
        public void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            pic_cam.Image = bmp;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap img = (Bitmap)pic_cam.Image;
            if (img != null)
            {
                ZXing.BarcodeReader Reader = new ZXing.BarcodeReader();
                Result result = Reader.Decode(img);
                try
                {
                    string decoded = result.ToString().Trim();
                    string maTCQR = "";
                    bool kt = true;
                    if (maTCQR.Trim() == "")
                    {
                        maTCQR = decoded;
                        if (this.send(maTCQR) == false)
                        {
                            timer1.Stop();
                            stream.Stop();
                            img.Dispose();
                            this.Close();
                            kt = false;
                            this.Alert("Thú cưng đã có trong giỏ hàng", frmCustomTB.enmType.Error);
                        }
                        timer1.Stop();
                        stream.Stop();
                        if (kt == true)
                        {
                            this.Alert("Thú cưng đã được thêm vào giỏ hàng", frmCustomTB.enmType.Success);
                        }
                    }
                    img.Dispose();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "");
                }
            }
        }

    }
}
