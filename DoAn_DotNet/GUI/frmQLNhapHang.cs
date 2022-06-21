using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using BLL;
using DTO;
using DoAn_DotNet.Custom;
using System.Globalization;
using System.IO;
using System.Drawing.Imaging;

namespace DoAn_DotNet.GUI
{
    public partial class frmQLNhapHang : Form
    {
        private bool isThem;
        private bool isThemCT;
        PhieuNhapBLL bllPhieuNhap = new PhieuNhapBLL();
        ChiTietPNBLL bllChiTietPN = new ChiTietPNBLL();
        ThuCungBLL bllThuCung = new ThuCungBLL();
        GiongBLL bllGiong = new GiongBLL();
        LoaiBLL bllLoai = new LoaiBLL();
        DonDatMuaBLL bllDonDatMua = new DonDatMuaBLL();
        ChiTietDDMBLL bllCTDDM = new ChiTietDDMBLL();
        System.Data.DataTable dt;
        int maPN;
        int maTCMoi;
        int maTCClick;
        int maLoai;

        int maNV = NhanVienBLL.frmDonHangmaNV;

        public frmQLNhapHang()
        {
            InitializeComponent();
        }

        private void frmQLNhapHang_Load(object sender, EventArgs e)
        {
            pnTab.Visible = false;
            dGVPhieuNhap.DataSource = bllPhieuNhap.PhieuNhap();

            //cboMaGiong.DataSource = bllGiong.DanhSach();
            //cboMaGiong.ValueMember = "MaGiong";
            //cboMaGiong.DisplayMember = "TenGiong";

            cboMaDDM.DataSource = bllDonDatMua.DsDDM();
            cboMaDDM.ValueMember = "MaDDM";
            cboMaDDM.DisplayMember = "MaDDM";

            dtpNgayCN.Value = DateTime.Now;

            //Format tiền cho dataGridView1
            dGVPhieuNhap.Columns["Column5"].DefaultCellStyle.Format = "c0";
            dGVChiTietPN.Columns["Column8"].DefaultCellStyle.Format = "c0";
        }

        //Load thông báo
        public void Alert(string msg, frmCustomTB.enmType type)
        {
            frmCustomTB frm = new frmCustomTB();
            frm.showAlert(msg, type);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            pnTab.Visible = true;
            isThem = true;
            BatTat(true);

            dtpNgayNhap.Enabled = false;
            dtpNgayCN.Enabled = false;

            dtpNgayNhap.Value = DateTime.Now;
            dtpNgayCN.Value = DateTime.Now;

            //txtMaDDM.Visible = false;
            txtMaDDM.Text = "";
            txtTenTC.Text = "";
            txtGiaNhap.Text = "";
            txtNoiDung.Text = "";

            dt = new System.Data.DataTable();
            dGVChiTietPN.DataSource = null;

            dGVPhieuNhap.Enabled = false;
            dGVChiTietPN.Enabled = false;

            if (bllThuCung.DanhSach().Rows.Count > 0)
            {
                maTCMoi = Convert.ToInt32(bllThuCung.DanhSachTCTheoMa().Rows[0][0].ToString());
            }
            else
            {
                maTCMoi = 1;
            }
            
        }
        public void BatTat(bool tt)
        {
            txtTenTC.Enabled = tt;
            txtGiaNhap.Enabled = tt;
            txtNoiDung.Enabled = tt;
            btnThemChiTiet.Enabled = tt;

            cboMaDDM.Visible = tt;
            txtMaDDM.Visible = !tt;

            cboMaGiong.Visible = tt;
            if (isThem==false)
            {
                cboMaDDM.Enabled = !tt;
            }
            txtMaGiong.Visible = !tt;

            dtpNgayNhap.Visible = tt;
            dtpNgayCN.Visible = tt;
            txtNgayCapNhat.Visible = !tt;
            txtNgayNhap.Visible = !tt;

            btnSua.Enabled = !tt;
            btnThem.Enabled = !tt;
            btnLuu.Enabled = tt;
            btnHuy.Enabled = tt;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            isThem = false;
            BatTat(true);

            dtpNgayCN.Enabled = false;
            dtpNgayNhap.Enabled = false;

        }

        private void dGVPhieuNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1);
            if (validClick)
            {
                BatTat(false);
                pnTab.Visible = true;

                maPN = Convert.ToInt32(dGVPhieuNhap.Rows[e.RowIndex].Cells[0].Value.ToString());
                
                txtMa.Text = dGVPhieuNhap.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMaDDM.Text = dGVPhieuNhap.Rows[e.RowIndex].Cells[1].Value.ToString();

                cboMaGiong.DataSource = bllCTDDM.DsGiongTheoDDM(Convert.ToInt32(txtMaDDM.Text));
                cboMaGiong.ValueMember = "MaGiong";
                cboMaGiong.DisplayMember = "TenGiong";


                cboMaDDM.SelectedValue = Convert.ToInt32(dGVPhieuNhap.Rows[e.RowIndex].Cells[1].Value.ToString());

                txtNgayNhap.Text = dGVPhieuNhap.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtpNgayNhap.Value = Convert.ToDateTime(dGVPhieuNhap.Rows[e.RowIndex].Cells[3].Value.ToString());
                txtNgayCapNhat.Text = dGVPhieuNhap.Rows[e.RowIndex].Cells[4].Value.ToString();

                txtNoiDung.Text = dGVPhieuNhap.Rows[e.RowIndex].Cells[5].Value.ToString();

                dGVChiTietPN.DataSource = bllChiTietPN.ChiTietPhieuNhap(Convert.ToInt32(dGVPhieuNhap.Rows[e.RowIndex].Cells[0].Value.ToString()));
               

            }
        }

        private void dGVChiTietPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1);
            if (validClick)
            {
                maTCClick = Convert.ToInt32(dGVChiTietPN.Rows[e.RowIndex].Cells[1].Value.ToString());

                txtMaGiong.Text = dGVChiTietPN.Rows[e.RowIndex].Cells[0].Value.ToString();
                cboMaGiong.SelectedValue = Convert.ToInt32(dGVChiTietPN.Rows[e.RowIndex].Cells[0].Value.ToString());

                txtTenTC.Text = bllThuCung.LayTenTC(Convert.ToInt32(dGVChiTietPN.Rows[e.RowIndex].Cells[1].Value.ToString())).ToString();
                txtGiaNhap.Text = dGVChiTietPN.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTat(false);
            dGVPhieuNhap.DataSource = bllPhieuNhap.PhieuNhap();
            if (isThemCT)
            {
                dGVChiTietPN.DataSource = null;

            }
            if (isThem)
            {
                dGVPhieuNhap.Enabled = true;
                dGVChiTietPN.Enabled = true;
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                isThemCT = true;
                if (!dt.Columns.Contains("MaGiong") && !dt.Columns.Contains("MaTC") && !dt.Columns.Contains("TenTC") && !dt.Columns.Contains("GiaNhap"))
                {
                    //Đặt tên cho cột trong datagirdview
                    dt.Columns.Add("MaGiong", typeof(int));
                    dt.Columns.Add("MaTC", typeof(int));
                    dt.Columns.Add("TenTC", typeof(string));
                    dt.Columns.Add("GiaNhap", typeof(decimal));
                }

                if (txtTenTC.Text.Trim() == "")
                    this.Alert("Vui lòng nhập tên thú cưng", frmCustomTB.enmType.Error);
                else if (txtGiaNhap.Text == "")
                    this.Alert("Vui lòng nhập giá nhập", frmCustomTB.enmType.Error);
                else 
                {
                    maTCMoi++;
                    dt.Rows.Add(cboMaGiong.SelectedValue, maTCMoi, txtTenTC.Text, Convert.ToDecimal(txtGiaNhap.Text));
                    dGVChiTietPN.DataSource = dt;
                    //dGVChiTietPN.Columns["GiaNhap"].DefaultCellStyle.Format = "c0";
                }
            }
            else
            {

                int slmua = Convert.ToInt32(bllCTDDM.DsMuaSL(Convert.ToInt32(cboMaDDM.SelectedValue), Convert.ToInt32(cboMaGiong.SelectedValue)).Rows[0][0].ToString());
                int slmuadu = Convert.ToInt32(bllCTDDM.DsMuaDuSL(Convert.ToInt32(cboMaDDM.SelectedValue), Convert.ToInt32(cboMaGiong.SelectedValue)).Rows[0][0].ToString());
                if (txtTenTC.Text.Trim() == "")
                    this.Alert("Vui lòng nhập tên thú cưng", frmCustomTB.enmType.Error);
                else if (txtGiaNhap.Text == "")
                    this.Alert("Vui lòng nhập giá nhập", frmCustomTB.enmType.Error);
                else if (slmua <= slmuadu)
                    this.Alert("Số lượng nhập đã đủ ", frmCustomTB.enmType.Error);
                else
                {
                    DateTime ngay = DateTime.Now;

                    ThuCungDTO info = new ThuCungDTO();
                    info.TenTC = txtTenTC.Text;
                    info.GiaBan = Convert.ToDecimal(txtGiaNhap.Text);
                    info.Anh = "cho.png";
                    info.CreateDate = ngay;
                    info.NgayCapNhat = ngay;
                    info.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue.ToString());
                    info.MaLoai = Convert.ToInt32(bllGiong.LayMaLoai(Convert.ToInt32(cboMaGiong.SelectedValue.ToString())).Rows[0][0].ToString());
                    info.TrangThai = 0;

                    if (bllThuCung.ThemTCChiTiet(info))
                    {
                        ChiTietPhieuNhapDTO ctpn = new ChiTietPhieuNhapDTO();
                        ctpn.MaPN = maPN;
                        ctpn.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue.ToString());
                        ctpn.MaTC = Convert.ToInt32(bllThuCung.DanhSachTCTheoMa().Rows[0][0].ToString());
                        ctpn.GiaNhap = Convert.ToDecimal(txtGiaNhap.Text);

                        //Thêm qrcode()
                        QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                        var mydata = QG.CreateQrCode(ctpn.MaTC.ToString(), QRCoder.QRCodeGenerator.ECCLevel.H);
                        var code = new QRCoder.QRCode(mydata);
                        Bitmap qrcode = code.GetGraphic(50);

                        luuAnhQRCODE(qrcode, ctpn.MaTC.ToString());

                        if (bllChiTietPN.Them(ctpn))
                        {
                            this.Alert("Thêm chi tiết phiếu nhập thành công", frmCustomTB.enmType.Success);
                        }
                        else
                            this.Alert("Thêm chi tiết phiếu nhập thất bại", frmCustomTB.enmType.Error);
                        dGVChiTietPN.DataSource = bllChiTietPN.ChiTietPhieuNhap(Convert.ToInt32(maPN));
                        dGVPhieuNhap.DataSource = bllPhieuNhap.PhieuNhap();
                    }
                    else
                    {
                        this.Alert("Thêm thú cưng mới thất bại", frmCustomTB.enmType.Error);
                    }
                }
            }
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                this.Alert("Vui lòng nhập số", frmCustomTB.enmType.Error);
            }
        }

        public void luuAnhQRCODE(Bitmap hinh, string tenFile)
        {
            bool kt = File.Exists(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile);
            if (kt == false)
                hinh.Save(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile, ImageFormat.Jpeg);
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                int slmua = Convert.ToInt32(bllCTDDM.DsMuaSL(Convert.ToInt32(cboMaDDM.SelectedValue), Convert.ToInt32(cboMaGiong.SelectedValue)).Rows[0][0].ToString());
                int slmuadu = Convert.ToInt32(bllCTDDM.DsMuaDuSL(Convert.ToInt32(cboMaDDM.SelectedValue), Convert.ToInt32(cboMaGiong.SelectedValue)).Rows[0][0].ToString());

                if (slmua <= slmuadu)
                    this.Alert("Số lượng nhập đã đủ ", frmCustomTB.enmType.Error);
                else if (dt.Rows.Count > 0)
                {
                    DateTime ngay = DateTime.Now;
                    PhieuNhapDTO info = new PhieuNhapDTO();
                    info.MaDDM = Convert.ToInt32(cboMaDDM.SelectedValue.ToString());
                    info.MaNV = maNV;
                    info.NgayNhap = ngay;
                    info.NgayCapNhat = ngay;
                    info.NoiDung = txtNoiDung.Text;
                    if (bllPhieuNhap.Them(info))
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DateTime ngayCT = DateTime.Now;

                            ThuCungDTO tc = new ThuCungDTO();
                            tc.TenTC = dt.Rows[i][2].ToString();
                            tc.GiaBan = decimal.Parse(dt.Rows[i][3].ToString());
                            tc.Anh = "cho.png";
                            tc.CreateDate = ngayCT;
                            tc.NgayCapNhat = ngayCT;
                            tc.MaGiong = int.Parse(dt.Rows[i][0].ToString());
                            tc.MaLoai = Convert.ToInt32(bllGiong.LayMaLoai(tc.MaGiong).Rows[0][0].ToString());
                            tc.TrangThai = 0;

                            int maddmtheongay = Convert.ToInt32(bllPhieuNhap.LayMaDDMTheoNgay(ngay).Rows[0][0].ToString());

                            int slmua1 = Convert.ToInt32(bllCTDDM.DsMuaSL(maddmtheongay, Convert.ToInt32(cboMaGiong.SelectedValue)).Rows[0][0].ToString());
                            int slmuadu1 = Convert.ToInt32(bllCTDDM.DsMuaDuSL(maddmtheongay, Convert.ToInt32(cboMaGiong.SelectedValue)).Rows[0][0].ToString());


                            if (slmua1 <= slmuadu1)
                            {
                                this.Alert("Số lượng nhập đã đủ ", frmCustomTB.enmType.Error);
                                break;
                            }
                            else
                            if (bllThuCung.ThemTCChiTiet(tc))
                            {

                                ChiTietPhieuNhapDTO ctpn = new ChiTietPhieuNhapDTO();
                                ctpn.MaPN = Convert.ToInt32(bllPhieuNhap.LayMaPNTheoNgay(ngay).Rows[0][0].ToString());
                                ctpn.MaGiong = tc.MaGiong;
                                ctpn.MaTC = Convert.ToInt32(bllThuCung.DanhSachTCTheoMa().Rows[0][0].ToString());
                                ctpn.GiaNhap = tc.GiaBan;

                                //Thêm qrcode()
                                QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                                var mydata = QG.CreateQrCode(ctpn.MaTC.ToString(), QRCoder.QRCodeGenerator.ECCLevel.H);
                                var code = new QRCoder.QRCode(mydata);
                                Bitmap qrcode = code.GetGraphic(50);

                                luuAnhQRCODE(qrcode, ctpn.MaTC.ToString());

                                bllChiTietPN.Them(ctpn);
                            }
                        }
                        this.Alert("Thêm chi tiết phiếu nhập thành công", frmCustomTB.enmType.Success);
                        dGVPhieuNhap.DataSource = bllPhieuNhap.PhieuNhap();
                        dGVChiTietPN.DataSource = bllChiTietPN.ChiTietPhieuNhapTheoNgay(ngay);
                    }
                    else
                    {
                        this.Alert("Thêm chi tiết phiếu nhập thất bại", frmCustomTB.enmType.Error);
                    }
                }
                else
                {
                    this.Alert("Vui lòng thêm chi tiết phiếu nhập", frmCustomTB.enmType.Info);
                }
                dGVPhieuNhap.Enabled = true;
                dGVChiTietPN.Enabled = true;
            }
            else
            {

                int slmua = Convert.ToInt32(bllCTDDM.DsMuaSL(Convert.ToInt32(cboMaDDM.SelectedValue), Convert.ToInt32(cboMaGiong.SelectedValue)).Rows[0][0].ToString());
                int slmuadu = Convert.ToInt32(bllCTDDM.DsMuaDuSL(Convert.ToInt32(cboMaDDM.SelectedValue), Convert.ToInt32(cboMaGiong.SelectedValue)).Rows[0][0].ToString());

                if (txtTenTC.Text.Trim() == "")
                    this.Alert("Vui lòng nhập tên thú cưng", frmCustomTB.enmType.Error);
                else if (txtGiaNhap.Text == "")
                    this.Alert("Vui lòng nhập giá nhập", frmCustomTB.enmType.Error);
                else if (bllChiTietPN.DSPNTheoMaTC(maTCClick).Rows.Count > 0)
                {
                    DateTime ngay = DateTime.Now;
                    PhieuNhapDTO info = new PhieuNhapDTO();
                    info.MaPN = maPN;
                    info.MaDDM = Convert.ToInt32(cboMaDDM.SelectedValue.ToString());
                    info.MaNV = maNV;
                    info.NgayCapNhat = ngay;
                    info.NoiDung = txtNoiDung.Text;

                    if (bllPhieuNhap.Sua(info, info.MaPN))
                    {
                        ChiTietPhieuNhapDTO ctpn = new ChiTietPhieuNhapDTO();
                        ctpn.MaPN = info.MaPN;
                        ctpn.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue.ToString());
                        ctpn.MaTC = maTCClick;
                        ctpn.GiaNhap = Convert.ToDecimal(txtGiaNhap.Text);

                        if (bllChiTietPN.Sua(ctpn, ctpn.MaTC))
                        {
                            DateTime ngayCT = DateTime.Now;
                            ThuCungDTO tc = new ThuCungDTO();
                            tc.MaTC = maTCClick;
                            tc.TenTC = txtTenTC.Text;
                            tc.GiaBan = Convert.ToDecimal(txtGiaNhap.Text);
                            tc.Anh = "cho.png";
                            tc.NgayCapNhat = ngayCT;
                            tc.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue.ToString());
                            tc.MaLoai = Convert.ToInt32(bllGiong.LayMaLoai(Convert.ToInt32(cboMaGiong.SelectedValue.ToString())).Rows[0][0].ToString());

                            if (bllThuCung.SuaThuCungChiTiet(tc, tc.MaTC))
                            {
                                this.Alert("Sửa chi tiết phiếu nhập thành công", frmCustomTB.enmType.Success);
                                dGVChiTietPN.DataSource = bllChiTietPN.ChiTietPhieuNhap(maPN);
                                dGVPhieuNhap.DataSource = bllPhieuNhap.PhieuNhap();
                                BatTat(false);
                            }
                        }
                    }
                    else
                    {
                        this.Alert("Sửa chi tiết phiếu nhập thất bại", frmCustomTB.enmType.Error);
                    }
                }
                else
                {
                    DateTime ngay = DateTime.Now;

                    ThuCungDTO info = new ThuCungDTO();
                    info.TenTC = txtTenTC.Text;
                    info.GiaBan = Convert.ToDecimal(txtGiaNhap.Text);
                    info.Anh = "cho.png";
                    info.CreateDate = ngay;
                    info.NgayCapNhat = ngay;
                    info.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue.ToString());
                    info.MaLoai = Convert.ToInt32(bllGiong.LayMaLoai(Convert.ToInt32(cboMaGiong.SelectedValue.ToString())).Rows[0][0].ToString());
                    info.TrangThai = 0;

                    if (slmua <= slmuadu)
                        this.Alert("Số lượng nhập đã đủ ", frmCustomTB.enmType.Error);
                    else if (bllThuCung.ThemTCChiTiet(info))
                    {
                        ChiTietPhieuNhapDTO ctpn = new ChiTietPhieuNhapDTO();
                        ctpn.MaPN = maPN;
                        ctpn.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue.ToString());
                        ctpn.MaTC = Convert.ToInt32(bllThuCung.DanhSachTCTheoMa().Rows[0][0].ToString());
                        ctpn.GiaNhap = Convert.ToDecimal(txtGiaNhap.Text);

                        //Thêm qrcode()
                        QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
                        var mydata = QG.CreateQrCode(ctpn.MaTC.ToString(), QRCoder.QRCodeGenerator.ECCLevel.H);
                        var code = new QRCoder.QRCode(mydata);
                        Bitmap qrcode = code.GetGraphic(50);

                        luuAnhQRCODE(qrcode, ctpn.MaTC.ToString());

                        if (bllChiTietPN.Them(ctpn))
                        {
                            this.Alert("Thêm chi tiết phiếu nhập thành công", frmCustomTB.enmType.Success);
                        }
                        else
                            this.Alert("Thêm chi tiết phiếu nhập thất bại", frmCustomTB.enmType.Error);
                        dGVChiTietPN.DataSource = bllChiTietPN.ChiTietPhieuNhap(Convert.ToInt32(maPN));
                        dGVPhieuNhap.DataSource = bllPhieuNhap.PhieuNhap();
                    }
                    else
                    {
                        this.Alert("Thêm thú cưng mới thất bại", frmCustomTB.enmType.Error);
                    }
                }
            }
        }

        private void btnDongTab_Click(object sender, EventArgs e)
        {
            pnTab.Visible = false;
            if (isThem)
            {
                dGVPhieuNhap.Enabled = true;
                dGVChiTietPN.Enabled = true;
            }
        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaNhap.Text == "" || txtGiaNhap.Text == "0") return;
            decimal number;
            number = decimal.Parse(txtGiaNhap.Text, System.Globalization.NumberStyles.Currency);
            txtGiaNhap.Text = number.ToString("#,#");
            txtGiaNhap.SelectionStart = txtGiaNhap.Text.Length;
        }

        private void txtTimKiem_IconLeftClick(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "")
            {
                dGVPhieuNhap.DataSource = bllPhieuNhap.PhieuNhap();
            }
            else
            {
                dGVPhieuNhap.DataSource = bllPhieuNhap.PhieuNhapTheoMa(Convert.ToInt32(txtTimKiem.Text));
            }
        }

        private void cboMaGiong_DropDownClosed(object sender, EventArgs e)
        {
            if (bllCTDDM.DsGiaMuaSL(Convert.ToInt32(cboMaDDM.SelectedValue), Convert.ToInt32(cboMaGiong.SelectedValue)).Rows.Count < 1)
            {
                this.Alert("Vui lòng chọn đơn đặt mua", frmCustomTB.enmType.Error);
            }
            else
            {
                lblGiaMua.Text = bllCTDDM.DsGiaMuaSL(Convert.ToInt32(cboMaDDM.SelectedValue), Convert.ToInt32(cboMaGiong.SelectedValue)).Rows[0][2].ToString();

                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("vi-VN");
                decimal value = decimal.Parse(lblGiaMua.Text, System.Globalization.NumberStyles.AllowThousands);
                lblGiaMua.Text = String.Format(culture, "{0:C0}", value);
                lblSL.Text = bllCTDDM.DsGiaMuaSL(Convert.ToInt32(cboMaDDM.SelectedValue), Convert.ToInt32(cboMaGiong.SelectedValue)).Rows[0][3].ToString();

            }

        }

        private void cboMaDDM_DropDownClosed(object sender, EventArgs e)
        {
            cboMaGiong.DataSource = bllCTDDM.DsGiongTheoDDM(Convert.ToInt32(cboMaDDM.SelectedValue));
            cboMaGiong.ValueMember = "MaGiong";
            cboMaGiong.DisplayMember = "TenGiong";
        }
    }
}
