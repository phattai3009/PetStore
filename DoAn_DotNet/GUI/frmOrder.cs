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
using System.Globalization;


namespace DoAn_DotNet.GUI
{
    public partial class frmOrder : Form
    {
        private int isThaoTac;
        DonHangBLL bllDH = new DonHangBLL();
        ChiTietDonHangBLL bllCTDH = new ChiTietDonHangBLL();
        ThuCungBLL bllTC = new ThuCungBLL();
        DoiTraBLL bllDT = new DoiTraBLL();
        System.Data.DataTable dt;
        System.Data.DataTable dt2;

        int maNV = NhanVienBLL.frmDonHangmaNV;

        int maDH;
        int maThuCung;
        public frmOrder()
        {
            InitializeComponent();

        }


        private void frmDoiTra_Load(object sender, EventArgs e)
        {
            pnTab.Visible = false;
            cboThuCung.DataSource = bllTC.DanhSachTrangThai();
            cboThuCung.ValueMember = "MaTC";
            cboThuCung.DisplayMember = "TenTC";

            loadDH();
            batTat(false);

        }

        //Load thông báo
        public void Alert(string msg, frmCustomTB.enmType type)
        {
            frmCustomTB frm = new frmCustomTB();
            frm.showAlert(msg, type);
        }

        void loadDH()
        {
            pnDSDonHang.Controls.Clear();
            System.Data.DataTable dt = bllDH.DonHang();
            Order[] listitem = new Order[dt.Rows.Count];
            for (int i = 0; i < listitem.Length; i++)
            {
                listitem[i] = new Order();
                listitem[i].Pic_DH = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\box.png");
                listitem[i].MaDH = Convert.ToInt32(dt.Rows[i][0].ToString());
                listitem[i].TongTien = Convert.ToDecimal(dt.Rows[i][8].ToString());
                listitem[i].Dock = DockStyle.Top;
                if (dt.Rows[i][9].ToString() == "3")
                {
                    listitem[i].Pic_trangThai = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\cancel.png");
                }
                else if (dt.Rows[i][9].ToString() == "2")
                {
                    listitem[i].Pic_trangThai = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\delete.png");
                }
                else if (dt.Rows[i][9].ToString() == "1")
                {
                    listitem[i].Pic_trangThai = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\checked.png");
                }
                else
                {
                    listitem[i].Pic_trangThai = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\no-money.png");
                }
                pnDSDonHang.Controls.Add(listitem[i]);
                listitem[i].Click += new EventHandler(this.onclick);

            }
        }

        private void txtTimKiem_IconLeftClick(object sender, EventArgs e)
        {
            pnDSDonHang.Controls.Clear();
            System.Data.DataTable dt = bllDH.DonHang_SoDT(txtTimKiem.Text);
            Order[] listitem = new Order[dt.Rows.Count];
            for (int i = 0; i < listitem.Length; i++)
            {
                listitem[i] = new Order();
                listitem[i].Pic_DH = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\box.png");
                listitem[i].MaDH = Convert.ToInt32(dt.Rows[i][0].ToString());
                listitem[i].TongTien = Convert.ToDecimal(dt.Rows[i][8].ToString());
                listitem[i].Dock = DockStyle.Top;
                if (dt.Rows[i][9].ToString() == "3")
                {
                    listitem[i].Pic_trangThai = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\cancel.png");
                }
                else if (dt.Rows[i][9].ToString() == "2")
                {
                    listitem[i].Pic_trangThai = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\delete.png");
                }
                else if (dt.Rows[i][9].ToString() == "1")
                {
                    listitem[i].Pic_trangThai = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\checked.png");
                }
                else
                {
                    listitem[i].Pic_trangThai = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\no-money.png");
                }
                pnDSDonHang.Controls.Add(listitem[i]);
                listitem[i].Click += new EventHandler(this.onclick);

            }
        }

        void onclick(object sender, EventArgs e)
        {
            Order order = (Order)sender;
            guna2DataGridView1.Rows.Clear();
            dt =  bllCTDH.DanhSachCT_TC(order.MaDH.ToString());
            dt2 = bllDH.DonHang(order.MaDH);

            //lay thuoc tinh o tren 
            
            lblNgayThanhToan.Text = dt2.Rows[0][2].ToString();
            DateTime ngay = Convert.ToDateTime(dt2.Rows[0][2].ToString()).AddDays(15);
            lblNgayGiao.Text =ngay.ToString();

            maDH = order.MaDH;
            lblMaDH.Text = "Mã Đơn Hàng: "+ order.MaDH.ToString();
            lblNguoiNhan.Text = dt2.Rows[0][4].ToString();
            lblEmail.Text = dt2.Rows[0][5].ToString();
            lblPhone.Text = dt2.Rows[0][6].ToString();
            lblAddress.Text = dt2.Rows[0][7].ToString();

            txtMaKH.Text = dt2.Rows[0][3].ToString();
            txtNguoiNhan.Text = dt2.Rows[0][4].ToString();
            txtEmail.Text = dt2.Rows[0][5].ToString();
            txtPhone.Text = dt2.Rows[0][6].ToString();
            txtAddress.Text = dt2.Rows[0][7].ToString();

            txtTongTien.Text = dt2.Rows[0][8].ToString();

            decimal number;
            number = decimal.Parse(txtTongTien.Text, System.Globalization.NumberStyles.Currency);
            txtTongTien.Text = number.ToString("c0");



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string maTC = dt.Rows[i][0].ToString();
                Image anh = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dt.Rows[i][1].ToString() + "");
                string tenTC = dt.Rows[i][2].ToString();
                string giaBan = dt.Rows[i][3].ToString();

                decimal number1;
                number1 = decimal.Parse(giaBan, System.Globalization.NumberStyles.Currency);
                giaBan = number1.ToString("c0");


                guna2DataGridView1.Rows.Add(maTC, anh, tenTC, giaBan);

            }

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1);
            if (validClick)
            {
                System.Data.DataTable dt3 = bllCTDH.DanhSach(maDH);

                if (isThaoTac == 2)
                {
                    txtGiaBan.Visible = true;
                    cboThuCung.Visible = true;
                    txtTen.Enabled = false;
                }
                pnTab.Visible = true;
                batTat(false);
                maThuCung = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtTen.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string anh = bllCTDH.DanhSachCT_TC(maDH.ToString()).Rows[e.RowIndex][1].ToString();
                pic_TC.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + anh + "");

            }
        }

        void load(int maTC)
        {
            string anh = bllTC.DanhSachTCTheoMa(maTC).Rows[0][4].ToString();
            pic_TC.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + anh + "");
        }

        void batTat(bool tt)
        {
            cboThuCung.Enabled = tt;
            txtTen.Visible = !tt;
            cboThuCung.Visible = tt;

            txtLyDo.Enabled = tt;
            txtTinhTrangTC.Enabled = tt;

            btnLuu.Enabled = tt;

            btnDoiTC.Enabled = !tt;
            btnTra.Enabled = !tt;
            btnSua.Enabled = !tt;

            btnHuy.Enabled = tt;
        }

        private void btnDongTab_Click(object sender, EventArgs e)
        {
            pnTab.Visible = false;
            batTat(false);
            pnDSDonHang.Enabled = true;
            guna2DataGridView1.Enabled = true;
        }

        private void btnDoiTC_Click(object sender, EventArgs e)
        {
            isThaoTac = 1;
            cboThuCung.SelectedValue = maThuCung;
            txtTen.Visible = false;
            batTat(true);

            pnDSDonHang.Enabled = false;
            guna2DataGridView1.Enabled = false;

        }

        private void cboThuCung_DropDownClosed(object sender, EventArgs e)
        {
            txtGiaBan.Text = bllTC.LayGiaBanTC(Convert.ToInt32(cboThuCung.SelectedValue));

            if (txtGiaBan.Text == "" || txtGiaBan.Text == "0") return;
            decimal number;
            number = decimal.Parse(txtGiaBan.Text, System.Globalization.NumberStyles.Currency);
            txtGiaBan.Text = number.ToString("#,#");
            txtGiaBan.SelectionStart = txtGiaBan.Text.Length;

            load(Convert.ToInt32(cboThuCung.SelectedValue));
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            isThaoTac = 2;
            batTat(true);
            cboThuCung.Visible = false;
            txtTen.Enabled = true;
            txtGiaBan.Visible = false;

            pnDSDonHang.Enabled = false;
            guna2DataGridView1.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isThaoTac = 3;
            batTat(true);
            cboThuCung.SelectedValue = maThuCung;
            txtLyDo.Enabled = false;
            txtTinhTrangTC.Enabled = false;

            pnDSDonHang.Enabled = false;
            guna2DataGridView1.Enabled = false;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThaoTac == 1)
            {
                TimeSpan tg = DateTime.Now - Convert.ToDateTime(bllDH.DonHang(maDH).Rows[0][2].ToString());
                int tongngay = tg.Days;
                if (bllDT.KiemTraMaDHBiDoi(maDH).Rows.Count > 0)
                {
                    this.Alert("Đơn hàng đã được đổi", frmCustomTB.enmType.Error);
                }
                else if (bllDT.KiemTraMaDHTraHang(maDH).Rows.Count > 0)
                {
                    this.Alert("Đơn hàng đã được trả hàng", frmCustomTB.enmType.Error);
                }
                else if (tongngay > 15)
                {
                    this.Alert("Đơn hàng đã quá ngày đổi", frmCustomTB.enmType.Error);
                }
                else if (bllCTDH.KiemTraMaTCLinq(Convert.ToInt32(cboThuCung.SelectedValue.ToString())).Count > 0)
                {
                    this.Alert("Thú cưng đã bán", frmCustomTB.enmType.Error);
                }
                else
                {
                    if (txtLyDo.Text.Trim() == "")
                        this.Alert("Vui lòng nhập lý do", frmCustomTB.enmType.Error);
                    else if (txtTinhTrangTC.Text.Trim() == "")
                        this.Alert("Vui lòng nhập tình trạng thú cưng", frmCustomTB.enmType.Error);
                    else
                    {
                        DateTime ngay = DateTime.Now;
                        DoiTraDTO info = new DoiTraDTO();
                        info.MaDH = maDH;
                        info.MaNV = maNV;
                        info.NgayDoi = ngay;
                        info.LyDo = txtLyDo.Text;
                        info.TinhTrangThuCung = txtTinhTrangTC.Text;
                        if (bllDT.Them(info))
                        {
                            ThuCungDTO tc = new ThuCungDTO();
                            tc.TrangThai = 0;
                            tc.MaTC = Convert.ToInt32(cboThuCung.SelectedValue.ToString());

                            ChiTietDonHangDTO ctdh = new ChiTietDonHangDTO();
                            ctdh.MaTC = tc.MaTC;
                            
                            if (bllTC.SuaTrangThai(tc, maThuCung) && bllTC.SuaTrangThai(tc, tc.MaTC) && bllCTDH.SuaMaTC(ctdh, maThuCung))
                            {
                                this.Alert("Đổi thú cưng thành công!", frmCustomTB.enmType.Success);
                                loadDH();
                            }
                        }
                        else
                        {
                            this.Alert("Đổi thú cưng thất bại!", frmCustomTB.enmType.Error);
                        }
                    }       
                }
            }
            else if (isThaoTac == 2)
            {
                TimeSpan tg = DateTime.Now - Convert.ToDateTime(bllDH.DonHang(maDH).Rows[0][2].ToString());
                int tongngay = tg.Days;
                if (bllDT.KiemTraMaDHBiDoi(maDH).Rows.Count > 0)
                {
                    this.Alert("Đơn hàng đã được đổi", frmCustomTB.enmType.Error);
                }
                else if (bllDT.KiemTraMaDHTraHang(maDH).Rows.Count > 0)
                {
                    this.Alert("Đơn hàng đã được trả hàng", frmCustomTB.enmType.Error);
                }
                else if (tongngay > 15)
                {
                    this.Alert("Đơn hàng đã quá ngày đổi", frmCustomTB.enmType.Error);
                }
                else
                {
                    if (txtLyDo.Text.Trim() == "")
                        this.Alert("Vui lòng nhập lý do", frmCustomTB.enmType.Error);
                    else if (txtTinhTrangTC.Text.Trim() == "")
                        this.Alert("Vui lòng nhập tình trạng thú cưng", frmCustomTB.enmType.Error);
                    else
                    {
                        DateTime ngay = DateTime.Now;
                        DoiTraDTO info = new DoiTraDTO();
                        info.MaDH = maDH;
                        info.MaNV = maNV;
                        info.NgayDoi = ngay;
                        info.LyDo = txtLyDo.Text;
                        info.TinhTrangThuCung = txtTinhTrangTC.Text;
                        if (bllDT.Them(info))
                        {
                            DonHangDTO dh = new DonHangDTO();
                            dh.TrangThai = 3;
                            if (bllDH.Sua(dh,maDH))
                            {
                                this.Alert("Trả thú cưng thành công", frmCustomTB.enmType.Success);
                                loadDH();
                            }
                        }
                        else
                        {
                            this.Alert("Trả thú cưng thất bại!", frmCustomTB.enmType.Error);
                        }
                    }
                }
            }
            else if (isThaoTac == 3)
            {
                if (bllCTDH.KiemTraMaTCLinq(Convert.ToInt32(cboThuCung.SelectedValue.ToString())).Count > 0)
                {
                    this.Alert("Thú cưng đã bán", frmCustomTB.enmType.Error);
                }
                else
                {
                    ThuCungDTO tc = new ThuCungDTO();
                    tc.TrangThai = 0;
                    tc.MaTC = Convert.ToInt32(cboThuCung.SelectedValue.ToString());

                    ChiTietDonHangDTO ctdh = new ChiTietDonHangDTO();
                    ctdh.MaTC = tc.MaTC;

                    if (bllTC.SuaTrangThai(tc, maThuCung) && bllTC.SuaTrangThai(tc, tc.MaTC) && bllCTDH.SuaMaTC(ctdh, maThuCung))
                    {
                        this.Alert("Sửa thú cưng thành công", frmCustomTB.enmType.Success);
                        loadDH();
                    }
                    else
                    {
                        this.Alert("Sửa thú cưng thất bại", frmCustomTB.enmType.Success);
                    }
                }
            }
            pnDSDonHang.Enabled = true;
            guna2DataGridView1.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (isThaoTac == 2)
            {
                txtGiaBan.Visible = true;
                cboThuCung.Visible = true;
                txtTen.Enabled = false;
            }
            batTat(false);
            pnDSDonHang.Enabled = true;
            guna2DataGridView1.Enabled = true;
        }
    }
}
