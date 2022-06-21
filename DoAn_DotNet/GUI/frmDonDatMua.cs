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

namespace DoAn_DotNet.GUI
{
    public partial class frmDonDatMua : Form
    {
        private bool isThem;
        private bool isThemCT;
        DonDatMuaBLL bllDonDatMua = new DonDatMuaBLL();
        ChiTietDDMBLL bllCTDDM = new ChiTietDDMBLL();
        NhaCungCapBLL bllNCC = new NhaCungCapBLL();
        GiongBLL bllGiong = new GiongBLL();
        System.Data.DataTable dt;
        int maNV = NhanVienBLL.frmDonHangmaNV;
        public frmDonDatMua()
        {
            InitializeComponent();
        }

        private void frmDonDatMua_Load(object sender, EventArgs e)
        {
            pnTab.Visible = false;
            dGVDonDatMua.DataSource = bllDonDatMua.DonDatMua();

            cboMaNCC.DataSource = bllNCC.NhaCungCap();
            cboMaNCC.ValueMember = "MaNCC";
            cboMaNCC.DisplayMember = "TenNCC";

            cboMaGiong.DataSource = bllGiong.DanhSach();
            cboMaGiong.ValueMember = "MaGiong";
            cboMaGiong.DisplayMember = "TenGiong";
            BatTat(false);
            Custom(false);

            dtpNgayCN.Value = DateTime.Now;

            //Format tiền cho dataGridView1
            dGVDonDatMua.Columns["Column5"].DefaultCellStyle.Format = "c0";
            dGVChiTietDDM.Columns["Column7"].DefaultCellStyle.Format = "c0";
        }

        //Load thông báo
        public void Alert(string msg, frmCustomTB.enmType type)
        {
            frmCustomTB frm = new frmCustomTB();
            frm.showAlert(msg, type);
        }
        public void BatTat(bool tt)
        {
            txtMaNCC.Enabled = tt;
            txtMaDDM.Enabled = tt;
            txtGiaMua.Enabled = tt;
            txtMaGiong.Enabled = tt;
            numSoLuong.Enabled = tt;
            txtNoiDung.Enabled = tt;

            dtpNgayTao.Enabled = tt;
            dtpNgayCN.Enabled = tt;

            //btnSua.Enabled = tt;
            cboMaNCC.Enabled = tt;
            cboMaGiong.Enabled = tt;

            btnHuy.Enabled = tt;
            btnThemChiTiet.Enabled = tt;
            btnLuu.Enabled = tt;
        }

        public void Custom(bool tt)
        {
            cboMaGiong.Visible = tt;
            cboMaNCC.Visible = tt;

            txtMaGiong.Visible = !tt;
            txtMaNCC.Visible = !tt;
        }

        private void dGVDonDatMua_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1);
            if (validClick)
            {
                pnTab.Visible = true;
                BatTat(false);
                Custom(false);
                btnSua.Enabled = true;
                dGVChiTietDDM.DataSource = bllCTDDM.ChiTietDDM(Convert.ToInt32(dGVDonDatMua.Rows[e.RowIndex].Cells[0].Value.ToString()));

                //if (isThem)
                //{
                //    dGVChiTietDDM.Columns["GiaMua"].DefaultCellStyle.Format = "c0";
                //}

                //Hien thi thong tin 
                txtMaNCC.Text = dGVDonDatMua.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtMaDDM.Text = dGVDonDatMua.Rows[e.RowIndex].Cells[0].Value.ToString();
                dtpNgayTao.Value = Convert.ToDateTime(dGVDonDatMua.Rows[e.RowIndex].Cells[3].Value.ToString());
            }    
        }

        private void dGVChiTietDDM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnSua.Enabled = true;
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1);
            if (validClick)
            {
                txtMaGiong.Text = dGVChiTietDDM.Rows[e.RowIndex].Cells[0].Value.ToString();
                cboMaGiong.SelectedValue = Convert.ToInt32(txtMaGiong.Text);
                txtGiaMua.Text = dGVChiTietDDM.Rows[e.RowIndex].Cells[1].Value.ToString();
                numSoLuong.Value = Convert.ToInt32(dGVChiTietDDM.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
        }

        private void btnDongTab_Click(object sender, EventArgs e)
        {
            pnTab.Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            pnTab.Visible = true;
            dt = new System.Data.DataTable();
            dGVChiTietDDM.DataSource = null;
            isThem = true;
            BatTat(true);
            Custom(true);

            txtMaDDM.Enabled = false;
            dtpNgayTao.Enabled = false;
            dtpNgayCN.Enabled = false;


            dtpNgayTao.Value = DateTime.Now;
            dtpNgayCN.Value = DateTime.Now;

            txtGiaMua.Text = "";
            numSoLuong.Value = 0;

            btnSua.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTat(false);
            Custom(false);
            btnSua.Enabled = true;
            dGVDonDatMua.DataSource = bllDonDatMua.DonDatMua();
            if (isThemCT)
            {
                dGVChiTietDDM.DataSource = null;
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                isThemCT = true;
                if (!dt.Columns.Contains("MaGiong") && !dt.Columns.Contains("GiaMua") && !dt.Columns.Contains("SoLuongMua"))
                {
                    //Đặt tên cho cột trong datagirdview
                    dt.Columns.Add("MaGiong", typeof(int));
                    dt.Columns.Add("GiaMua", typeof(decimal));
                    dt.Columns.Add("SoLuongMua", typeof(int));
                }
                if (txtGiaMua.Text.Trim() == "")
                    this.Alert("Vui lòng nhập giá mua", frmCustomTB.enmType.Error);
                else if (numSoLuong.Value <= 0)
                    this.Alert("Vui lòng nhập số lượng", frmCustomTB.enmType.Error);
                else
                {
                    bool kt = true;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (cboMaGiong.SelectedValue.ToString() == dt.Rows[i][0].ToString())
                        {
                            this.Alert("Giống bạn đặt đã có. Vui lòng chọn giống khác hoặc cập nhật", frmCustomTB.enmType.Error);
                            if (MessageBox.Show("Bạn có cập nhật không ?", "Đơn Đặt Mua", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                dt.Rows[i][2] = numSoLuong.Value;
                                dt.Rows[i][1] = Convert.ToDecimal(txtGiaMua.Text);
                                this.Alert("Cập nhật thành công", frmCustomTB.enmType.Success);
                                kt = false;
                            }
                            else
                            {
                                kt = false;
                            }
                        }
                    }
                    if (kt == true)
                    {
                        dt.Rows.Add(cboMaGiong.SelectedValue, Convert.ToDecimal(txtGiaMua.Text), numSoLuong.Value);
                        this.Alert("Thêm giống vào đơn đặt mua thành công", frmCustomTB.enmType.Success);
                        dGVChiTietDDM.DataSource = dt;
                        //dGVChiTietDDM.Columns["GiaMua"].DefaultCellStyle.Format = "c0";
                    }
                }
            }
            else
            {
                if (txtGiaMua.Text.Trim() == "")
                    this.Alert("Vui lòng nhập giá mua", frmCustomTB.enmType.Error);
                else if (numSoLuong.Value <= 0)
                    this.Alert("Vui lòng nhập số lượng", frmCustomTB.enmType.Error);
                else
                {
                    ChiTietDDMDTO info = new ChiTietDDMDTO();
                    info.MaDDM = Convert.ToInt32(txtMaDDM.Text);
                    info.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue);
                    info.GiaMua = Convert.ToDecimal(txtGiaMua.Text);
                    info.SoLuongMua=  Convert.ToInt32(numSoLuong.Value);
                    bool kt = true;
                    for (int i = 0; i < bllCTDDM.ChiTietDDM(info.MaDDM).Rows.Count; i++)
                    {
                        if (bllCTDDM.ChiTietDDM(info.MaDDM).Rows[i][0].ToString() == info.MaGiong.ToString())
                        {
                            if (MessageBox.Show("Bạn có muốn sửa chi tiết đơn đặt mua không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (bllCTDDM.Sua(info, info.MaDDM, info.MaGiong))
                                {
                                    this.Alert("Sửa chi tiết đơn đặt mua thành công", frmCustomTB.enmType.Success);
                                    dGVChiTietDDM.DataSource = bllCTDDM.ChiTietDDM(Convert.ToInt32(txtMaDDM.Text));
                                    //frmDonDatMua_Load(sender, e);
                                }
                                else
                                {
                                    this.Alert("Sửa chi tiết đơn đặt mua thất bại", frmCustomTB.enmType.Error);
                                }
                            }
                            kt = false;
                        }
                    }
                    if (kt == true)
                    {
                        if (bllCTDDM.Them(info))
                        {
                            this.Alert("Thêm chi tiết đơn đặt mua thành công", frmCustomTB.enmType.Success);
                            dGVChiTietDDM.DataSource = bllCTDDM.ChiTietDDM(Convert.ToInt32(txtMaDDM.Text));

                            //frmDonDatMua_Load(sender, e);
                        }
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isThem = false;
            
            BatTat(true);
            Custom(true);
            btnSua.Enabled = false;

            txtMaDDM.Enabled = false;
            dtpNgayTao.Enabled = false;
            dtpNgayCN.Enabled = false;

            cboMaNCC.SelectedValue = Convert.ToInt32(txtMaNCC.Text);

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isThem)
            {
                if (dt.Rows.Count > 0)
                {
                    DateTime ngay = DateTime.Now;
                    DonDatMuaDTO info = new DonDatMuaDTO();
                    info.MaNCC = Convert.ToInt32(cboMaNCC.SelectedValue);
                    info.MaNV = maNV;
                    info.CreateDate = ngay;
                    info.NgayCapNhat = ngay;
                    info.NoiDung = txtNoiDung.Text;

                    if (bllDonDatMua.Them(info))
                    {
                        bool kt = false;
                        ChiTietDDMDTO ctddm = new ChiTietDDMDTO();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ctddm.MaDDM = Convert.ToInt32(bllDonDatMua.LayMaDDMMoiNhat().Rows[0][0].ToString());
                            ctddm.MaGiong = Convert.ToInt32(dt.Rows[i][0].ToString());
                            ctddm.GiaMua = Convert.ToDecimal(dt.Rows[i][1].ToString());
                            ctddm.SoLuongMua = Convert.ToInt32(dt.Rows[i][2].ToString());
                            if (bllCTDDM.Them(ctddm))
                            {
                                kt = true;
                            }
                        }
                        if (kt == true)
                        {
                            this.Alert("Thêm đơn đặt mua thành công", frmCustomTB.enmType.Success);
                            dGVDonDatMua.DataSource = bllDonDatMua.DonDatMua();
                            dGVChiTietDDM.DataSource = bllCTDDM.ChiTietDDM(Convert.ToInt32(ctddm.MaDDM));
                            BatTat(false);
                            Custom(false);
                        }
                        
                    }
                    else
                    {
                        this.Alert("Thêm đơn đặt mua thất bại", frmCustomTB.enmType.Error);
                    }
                }
                else
                {
                    this.Alert("Vui lòng thêm chi tiết đơn đặt mua", frmCustomTB.enmType.Error);
                }
            }
            else
            {
                bool kt = false;
                if (txtGiaMua.Text.Trim() == "")
                    this.Alert("Vui lòng nhập giá mua", frmCustomTB.enmType.Error);
                else if (numSoLuong.Value <= 0)
                    this.Alert("Vui lòng nhập số lượng", frmCustomTB.enmType.Error);
                else
                {
                    for (int i = 0; i < bllCTDDM.ChiTietDDM(Convert.ToInt32(txtMaDDM.Text)).Rows.Count; i++)
                    {
                        if (bllCTDDM.ChiTietDDM(Convert.ToInt32(txtMaDDM.Text)).Rows[i][0].ToString() == cboMaGiong.SelectedValue.ToString())
                        {
                            ChiTietDDMDTO info = new ChiTietDDMDTO();
                            info.MaDDM = Convert.ToInt32(txtMaDDM.Text);
                            info.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue);
                            info.GiaMua = Convert.ToDecimal(txtGiaMua.Text);
                            info.SoLuongMua = Convert.ToInt32(numSoLuong.Value);

                            if (bllCTDDM.Sua(info, info.MaDDM, info.MaGiong))
                            {
                                kt = true;
                                DateTime ngay = DateTime.Now;
                                DonDatMuaDTO ddm = new DonDatMuaDTO();
                                ddm.MaDDM = Convert.ToInt32(txtMaDDM.Text);
                                ddm.MaNCC = Convert.ToInt32(cboMaNCC.SelectedValue);
                                ddm.MaNV = maNV;
                                ddm.CreateDate = dtpNgayTao.Value;
                                ddm.NgayCapNhat = ngay;
                                ddm.NoiDung = txtNoiDung.Text;

                                if (bllDonDatMua.Sua(ddm, ddm.MaDDM))
                                {
                                    this.Alert("Update đơn đặt mua thành công", frmCustomTB.enmType.Success);
                                    kt = true;
                                    dGVDonDatMua.DataSource = bllDonDatMua.DonDatMua();
                                    dGVChiTietDDM.DataSource = bllCTDDM.ChiTietDDM(Convert.ToInt32(ddm.MaDDM));
                                    BatTat(false);
                                    Custom(false);
                                    //frmDonDatMua_Load(sender, e);
                                }
                                else
                                {
                                    this.Alert("Update đơn đặt mua thất bại", frmCustomTB.enmType.Error);
                                }
                            }
                        }
                    }
                    if (kt == false)
                    {
                        ChiTietDDMDTO info = new ChiTietDDMDTO();
                        info.MaDDM = Convert.ToInt32(txtMaDDM.Text);
                        info.MaGiong = Convert.ToInt32(cboMaGiong.SelectedValue);
                        info.GiaMua = Convert.ToDecimal(txtGiaMua.Text);
                        info.SoLuongMua = Convert.ToInt32(numSoLuong.Value);

                        if (bllCTDDM.Them(info))
                        {
                            this.Alert("Thêm chi tiết đơn đặt mua thành công", frmCustomTB.enmType.Success);
                            dGVDonDatMua.DataSource = bllDonDatMua.DonDatMua();
                            dGVChiTietDDM.DataSource = bllCTDDM.ChiTietDDM(Convert.ToInt32(info.MaDDM));
                            BatTat(false);
                            Custom(false);
                            //frmDonDatMua_Load(sender, e);
                        }

                    }
                }
            }
        }

        private void txtGiaMua_TextChanged(object sender, EventArgs e)
        {
            if (txtGiaMua.Text == "" || txtGiaMua.Text == "0") return;
            decimal number;
            number = decimal.Parse(txtGiaMua.Text, System.Globalization.NumberStyles.Currency);
            txtGiaMua.Text = number.ToString("#,#");
            txtGiaMua.SelectionStart = txtGiaMua.Text.Length;
        }

        private void txtTimKiem_IconLeftClick(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "")
            {
                dGVDonDatMua.DataSource = bllDonDatMua.DonDatMua();
            }
            else
            {
                dGVDonDatMua.DataSource = bllDonDatMua.DonDatMuaTheoMa(Convert.ToInt32(txtTimKiem.Text));
            }

        }
    }
}
