using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DoAn_DotNet.Custom;
using DTO;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.Office.Interop.Excel;



namespace DoAn_DotNet.GUI
{
    public partial class frmProduct : Form
    {
        private bool isThem = false;
        GiongBLL bllGiong = new GiongBLL();
        LoaiBLL bllLoai = new LoaiBLL();
        ThuCungBLL bllThuCung = new ThuCungBLL();

        int maGiongDoi;
        public frmProduct()
        {
            InitializeComponent();
        }

        public void frmProduct_Load(object sender, EventArgs e)
        {
            pnTabThongTin.Visible = false;
            loadDanhSachThuCung();
            
        }

        //Load thông báo
        public void Alert(string msg, frmCustomTB.enmType type)
        {
            frmCustomTB frm = new frmCustomTB();
            frm.showAlert(msg, type);
        }

        public void loadDanhSachThuCung()
        {
            guna2ShadowPanel5.Controls.Clear();

            System.Data.DataTable dt = bllThuCung.DanhSach();
            Category[] listitem = new Category[dt.Rows.Count];
            for (int i = 0; i < listitem.Length; i++)
            {
                listitem[i] = new Category();
                listitem[i].MaTC = Convert.ToInt32(dt.Rows[i][0].ToString());
                listitem[i].Dock = DockStyle.Top;
                if (dt.Rows[i][4].ToString() == "NULL")
                {
                    listitem[i].Anh = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\cho.png");
                }
                listitem[i].Anh = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dt.Rows[i][4].ToString() + "");
                listitem[i].TenTC = dt.Rows[i][1].ToString();
                listitem[i].MoTa = dt.Rows[i][3].ToString();
                listitem[i].GiaBan = Convert.ToDecimal(dt.Rows[i][2].ToString());
                if (Convert.ToInt32(dt.Rows[i][10].ToString()) == 1)
                {
                    listitem[i].TrangThai = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\sold.png");
                }
                else
                {
                    listitem[i].TrangThai = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\sell.png");
                }
                guna2ShadowPanel5.Controls.Add(listitem[i]);
                listitem[i].Click += new EventHandler(this.onclick);
            }
        }

        void onclick(object sender, EventArgs e)
        {
            Category cate = (Category)sender;

            //Gọi panel ra
            pnTabThongTin.Visible = true;
            //guna2Transition1.HideSync(guna2ShadowPanel2);
            //guna2Transition1.ShowSync(guna2ShadowPanel2);

            System.Data.DataTable dt = bllThuCung.DanhSachTCTheoMa(cate.MaTC);

            BatTat(false);
            BatTatCustom(true);
            if (dt.Rows[0][4].ToString() == "NULL")
            {
                pic_TC.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\cho.png");
            }
            pic_TC.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dt.Rows[0][4].ToString() + "");
            txtMaTC.Text = dt.Rows[0][0].ToString();
            txtTenTC.Text = dt.Rows[0][1].ToString();
            txtGiaBan.Text = dt.Rows[0][2].ToString();
            txtMoTa.Text = dt.Rows[0][3].ToString();
            txtAnh.Text = dt.Rows[0][4].ToString();
            txtNgayTao.Text = dt.Rows[0][5].ToString();
            txtNgayCapNhat.Text = dt.Rows[0][6].ToString();
            txtNgayBan.Text = dt.Rows[0][7].ToString();
            maGiongDoi = Convert.ToInt32(dt.Rows[0][8].ToString());
            txtMaGiong.Text = dt.Rows[0][8].ToString();
            txtMaLoai.Text = dt.Rows[0][9].ToString();
            txtTrangThai.Text = dt.Rows[0][10].ToString();

            pic_QRCode.Image = null;
            if (File.Exists(System.Windows.Forms.Application.StartupPath + "\\img\\" + dt.Rows[0][0].ToString() + ""))
            {
                pic_QRCode.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dt.Rows[0][0].ToString() + "");
            }
            

            //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("vi-vn");
            //decimal value = decimal.Parse(txtGiaBan.Text, System.Globalization.NumberStyles.AllowThousands);
            //txtGiaBan.Text = String.Format(culture, "{0:C0}", value);
        }


        public void BatTat(bool tt)
        {
            btnThemAnh.Enabled = tt;
            btnLuu.Enabled = tt;
            btnHuy.Enabled = tt;
            btnXoa.Enabled = !tt;
            btnSua.Enabled = !tt;
            txtTenTC.Enabled = tt;
            txtGiaBan.Enabled = tt;
            txtMoTa.Enabled = tt;
            txtNgayTao.Enabled = tt;
            txtNgayCapNhat.Enabled = tt;

            dtpNgayTao.Visible = tt;
            dtpNgayCN.Visible = tt;

            txtMaGiong.Enabled = tt;
            txtMaLoai.Enabled = tt;
            cboMaGiong.Visible = tt;
            cboMaLoai.Visible = tt;

            dtpNgayCN.Enabled = !tt;
            dtpNgayTao.Enabled = !tt;

            txtTrangThai.Enabled = tt;
        }
        public void BatTatCustom(bool tt)
        {
            txtNgayTao.Visible = tt;
            txtNgayCapNhat.Visible = tt;

            txtMaGiong.Visible = tt;
            txtMaLoai.Visible = tt;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            BatTatCustom(false);
            isThem = false;

            dtpNgayTao.Value = Convert.ToDateTime(txtNgayTao.Text);

            cboMaLoai.DataSource = bllLoai.LoadCboLoai(Convert.ToInt32(txtMaLoai.Text));
            cboMaLoai.ValueMember = "MaLoai";
            cboMaLoai.DisplayMember = "TenLoai";

            cboMaGiong.DataSource = bllGiong.DanhSach(Convert.ToInt32(txtMaGiong.Text));
            cboMaGiong.ValueMember = "MaGiong";
            cboMaGiong.DisplayMember = "TenGiong";
        }

        private void cboMaLoai_DropDownClosed(object sender, EventArgs e)
        {
            cboMaGiong.DataSource = bllGiong.LoadCboGiong(Convert.ToInt32(cboMaLoai.SelectedValue.ToString()));
            cboMaGiong.ValueMember = "MaGiong";
            cboMaGiong.DisplayMember = "TenGiong";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenTC.Text.Trim() == "")
                this.Alert("Vui lòng nhập tên thú cưng", frmCustomTB.enmType.Error);
            else if (txtGiaBan.Text.Trim() == "")
                this.Alert("Vui lòng nhập giá bán", frmCustomTB.enmType.Error);
            else if (txtAnh.Text.Trim() == "")
                this.Alert("Vui lòng chọn ảnh", frmCustomTB.enmType.Error);
            else if (cboMaLoai.Text.Trim() == "")
                this.Alert("Vui lòng chọn loài", frmCustomTB.enmType.Error);
            else if (cboMaGiong.Text.Trim() == "")
                this.Alert("Vui lòng chọn giống", frmCustomTB.enmType.Error);
            else if (txtMoTa.Text.Trim() == "")
                this.Alert("Vui lòng nhập mô tả", frmCustomTB.enmType.Error);
            else if (MessageBox.Show("Bạn có muốn lưu " + txtTenTC.Text + " không?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ThuCungDTO info = new ThuCungDTO();
                string url = txtAnh.Text;
                
                info.TenTC = txtTenTC.Text;
                info.GiaBan = Convert.ToDecimal(txtGiaBan.Text);
                info.MoTa = txtMoTa.Text;
                info.Anh = url;
                info.CreateDate = dtpNgayTao.Value;
                info.NgayCapNhat = dtpNgayCN.Value;
                info.MaLoai = Convert.ToInt32(cboMaLoai.SelectedValue);
                info.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue);
                info.TrangThai = 0;
                
                if (isThem)
                {
                    //InsertThuCungLinq
                    if (bllThuCung.ThemLinq(info.TenTC, info.GiaBan, info.MoTa, info.Anh, info.CreateDate, info.NgayCapNhat, info.MaGiong, info.MaLoai, info.TrangThai) == true)
                    {
                        int ma = Convert.ToInt32(bllThuCung.DanhSachTCTheoMa().Rows[0][0].ToString());
                        //Thêm qrcode()
                        QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                        var mydata = QG.CreateQrCode(ma.ToString(), QRCoder.QRCodeGenerator.ECCLevel.H);
                        var code = new QRCoder.QRCode(mydata);
                        Bitmap qrcode = code.GetGraphic(50);

                        luuAnhQRCODE(qrcode, ma.ToString());

                        this.Alert("Thêm thú cưng thành công", frmCustomTB.enmType.Success);
                        luuHinhAnh(url);
                    }
                    else
                    {
                        this.Alert("Thêm thú cưng thất bại", frmCustomTB.enmType.Error);
                    }
                    //txtGiaBan.DataBindings[0].FormattingEnabled = true;
                    
                }
                else
                {
                    info.MaTC = Convert.ToInt32(txtMaTC.Text);

                    if (bllThuCung.UpdateLinq(info.MaTC, info.TenTC, info.GiaBan, info.MoTa, info.Anh, info.CreateDate, info.NgayCapNhat, info.MaGiong, info.MaLoai, info.TrangThai) == true)
                    {
                        if (bllThuCung.CapNhatGiongSoLuongTon(maGiongDoi) && bllThuCung.CapNhatGiongSoLuongTon(info.MaGiong))
                        {
                            this.Alert("Cập nhật số lượng thành công", frmCustomTB.enmType.Success);
                        }
                        else
                        {
                            this.Alert("Cập nhật số lượng thất bại", frmCustomTB.enmType.Error);
                        }
                        this.Alert("Cập nhật thú cưng thành công", frmCustomTB.enmType.Success);
                        luuHinhAnh(url);
                    }
                    else
                    {
                        this.Alert("Cập nhật thú cưng thất bại", frmCustomTB.enmType.Error);
                    }
                    //txtGiaBan.DataBindings[0].FormattingEnabled = true;
                    
                }
                // Tải lại lưới
                frmProduct_Load(sender, e);
            }
        }

        public void luuAnhQRCODE(Bitmap hinh, string tenFile)
        {
            bool kt = File.Exists(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile);
            if (kt == false)
                hinh.Save(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile, ImageFormat.Jpeg);
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            nhapHinhAnh();
        }

        public void anhDefault(string tenFile)
        {
            pic_TC.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile);
            txtAnh.Text = tenFile;
        }

        public void luuHinhAnh(string tenFile)
        {
            bool kt = File.Exists(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile);
            if (kt == false)
                pic_TC.Image.Save(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile, ImageFormat.Png);
        }
        public void nhapHinhAnh()
        {
            //BMP, GIF, JPEG, EXIF, PNG và TIFF, ICO...
            openFileDialog1.Filter = "All Image (*.jpg)|*.jpg|All Image (*.png)|*.png|All Image (*.gif)|*.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pic_TC.Image = Image.FromFile(openFileDialog1.FileName.ToString());

                string[] name = openFileDialog1.FileName.Split('\\');
                string tenFile = name[name.Length - 1].ToString().Trim();

                txtAnh.Text = tenFile;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTat(false);
            BatTatCustom(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isThem = true;

            BatTat(true);
            BatTatCustom(false);

            pic_TC.Image = null;
            pic_QRCode.Image = null;
            txtMaTC.Text = "";
            txtTenTC.Text = "";
            txtGiaBan.Text = "";
            txtAnh.Text = "";
            txtNgayBan.Text = "";
            txtTrangThai.Text = "0";
            txtMoTa.Text = "";

            dtpNgayCN.Value = DateTime.Now;
            dtpNgayTao.Value = DateTime.Now;

            cboMaLoai.DataSource = bllLoai.DanhSach();
            cboMaLoai.ValueMember = "MaLoai";
            cboMaLoai.DisplayMember = "TenLoai";

            pnTabThongTin.Visible = true;


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá thú cưng " + txtTenTC.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (bllThuCung.XoaLinq(Convert.ToInt32(txtMaTC.Text)) == true)
                {
                    this.Alert("Xoá thú cưng thành công", frmCustomTB.enmType.Success);
                    // Tải lại lưới
                    frmProduct_Load(sender, e);
                }
                else
                {
                    this.Alert("Xoá thú cưng thất bại", frmCustomTB.enmType.Error);
                }
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                this.Alert("Vui lòng nhập số", frmCustomTB.enmType.Error);
            }
        }

        private void txtTimKiem_IconLeftClick(object sender, EventArgs e)
        {
            guna2ShadowPanel5.Controls.Clear();

            System.Data.DataTable dt = bllThuCung.DanhSachTCTheoMaTen(txtTimKiem.Text);
            Category[] listitem = new Category[dt.Rows.Count];
            for (int i = 0; i < listitem.Length; i++)
            {
                listitem[i] = new Category();
                listitem[i].MaTC = Convert.ToInt32(dt.Rows[i][0].ToString());
                listitem[i].Dock = DockStyle.Top;
                listitem[i].Anh = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dt.Rows[i][4].ToString() + "");
                listitem[i].TenTC = dt.Rows[i][1].ToString();
                listitem[i].MoTa = dt.Rows[i][3].ToString();
                listitem[i].GiaBan = Convert.ToDecimal(dt.Rows[i][2].ToString());
                if (Convert.ToInt32(dt.Rows[i][10].ToString()) == 1)
                {
                    listitem[i].TrangThai = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\sold.png");
                }
                else
                {
                    listitem[i].TrangThai = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\sell.png");
                }
                guna2ShadowPanel5.Controls.Add(listitem[i]);
                listitem[i].Click += new EventHandler(this.onclick);
            }
        }

        private void btnDongTab_Click(object sender, EventArgs e)
        {
            pnTabThongTin.Visible = false;
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaBan.Text == "" || txtGiaBan.Text == "0") return;
            decimal number;
            number = decimal.Parse(txtGiaBan.Text, System.Globalization.NumberStyles.Currency);
            txtGiaBan.Text = number.ToString("#,#");
            txtGiaBan.SelectionStart = txtGiaBan.Text.Length;
        }
    }

}
