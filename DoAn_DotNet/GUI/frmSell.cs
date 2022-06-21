using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_DotNet.Custom;
using DTO;
using DAL;
using BLL;
using System.Text.RegularExpressions;
using System.Globalization;

namespace DoAn_DotNet.GUI
{
    public partial class frmSell : Form
    {
        //Gọi frm tương tác
        frmKhachHang fKH = null;
        frmThanhToan fTT = null;
        frmCode fCode = null;

        //Gọi BLL tương tác
        ChiTietDonHangBLL bllCTDH = new ChiTietDonHangBLL();
        KhachHangBLL bllKhachHang = new KhachHangBLL();
        LoaiBLL bllLoai = new LoaiBLL();
        GiongBLL bllGiong = new GiongBLL();
        DonHangBLL bllDonHang = new DonHangBLL();
        ThuCungBLL bllThuCung = new ThuCungBLL();

        //Gọi DAO tương tác
        ThuCungDAO tc = new ThuCungDAO();

        //Variable(Biến lưu trữ)
        public int maTCQRCode = 0;

        string tenTC = "";
        string anh = "";
        string ma = "";
        decimal giaBan = 0;
        int maNV = NhanVienBLL.frmDonHangmaNV;
        int soLuongTC = 0;
        int dongSLTC;
        double tongTien = 0;
        public static int maDH = 0;
        DataTable dt = new DataTable();


        public frmSell()
        {
            InitializeComponent();
        }


        public delegate bool layMaTCQR(String maTCQR);

        

        private void frmSell_Load(object sender, EventArgs e)
        {            
            //Mã Nhân Viên
            txtMaNV.Text = maNV.ToString();

            //Load Số Thú Cưng
            lblSoLuongTC.Text = tc.DanhSachTCSell().Rows.Count.ToString();

            //Load Time
            HienThiThoiGian();
            //Load Thú Cưng
            LoadThuCung();
            //Load cbo
            LoadCboThuCung();
            //Load BatTat
            BatTat(false);



            //Format tiền cho dataGridView1
            dataGridView1.Columns["Column3"].DefaultCellStyle.Format = "c0";

        }

        //Load thông báo
        public void Alert(string msg, frmCustomTB.enmType type)
        {
            frmCustomTB frm = new frmCustomTB();
            frm.showAlert(msg, type);
        }

        public void LoadThuCung()
        {
            pnDSThuCung.Controls.Clear();
            //Gọi Thú Cưng in pnBtnThuCung
            int StartY = 10;
            int x = 20;
            int y = 210;
            int StartX = 20;
            int dem = 0;
            Button[] btn = new Button[tc.DanhSachTCSell().Rows.Count];

            //Button[] hinh = new Button[tc.DanhSachTCSell().Rows.Count];

            Guna.UI2.WinForms.Guna2Button[] hinh = new Guna.UI2.WinForms.Guna2Button[tc.DanhSachTCSell().Rows.Count];

            for (int i = 0; i < tc.DanhSachTCSell().Rows.Count; i++)
            {
                btn[i] = new Button();
                hinh[i] = new Guna.UI2.WinForms.Guna2Button();
                

                tenTC = tc.DanhSachTCSell().Rows[i][1].ToString();
                anh = tc.DanhSachTCSell().Rows[i][3].ToString();
                ma = tc.DanhSachTCSell().Rows[i][0].ToString();
                giaBan = Convert.ToDecimal(tc.DanhSachTCSell().Rows[i][2].ToString());

                btn[i].BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + anh + "");
                btn[i].BackgroundImageLayout = ImageLayout.Stretch;
                btn[i].Size = new System.Drawing.Size(200, 200);
                hinh[i].Size = new System.Drawing.Size(200, 50);
                hinh[i].BorderRadius = 10;
                hinh[i].FillColor = Color.FromArgb(255, 128, 128);

                if (dem == 5)
                {
                    dem = 0;
                    StartY += 270;
                    StartX = 20;

                    x = 20;
                    y += 270;
                }

                btn[i].Location = new Point(StartX, StartY);
                hinh[i].Location = new Point(x, y);

                StartX += 210;
                x += 210;

                btn[i].Name = ma;
                hinh[i].Name = ma;
                string textButton;
                if (tenTC.Length > 20)
                {
                    textButton = "" + tenTC.Substring(0,20) + "...\n Giá Bán: " + giaBan.ToString("c0") + "";
                }
                else
                    textButton = "" + tenTC + "\n Giá Bán: " + giaBan.ToString("c0") + "";

                hinh[i].Text = textButton;
                btn[i].TextAlign = System.Drawing.ContentAlignment.BottomCenter;

                hinh[i].Click += new System.EventHandler(this.btnProductPet_Click);

                pnDSThuCung.Controls.Add(btn[i]);
                pnDSThuCung.Controls.Add(hinh[i]);

                dem++;
            }
        }

        public void LoadCboThuCung()
        {
            cboLoaiTC.DataSource = bllLoai.DanhSachLinq();
            cboLoaiTC.DisplayMember = "TenLoai";
            cboLoaiTC.ValueMember = "MaLoai";

        }

        public void TinhTongTienTC()
        {
            //Tính tiền
            double total = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                total += Convert.ToDouble(dataGridView1.Rows[i].Cells["Column3"].Value);
            }
            tongTien = total;
            txtTongTien.Text = total.ToString();
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("vi-vn");
            decimal value = decimal.Parse(txtTongTien.Text, System.Globalization.NumberStyles.AllowThousands);
            txtTongTien.Text = String.Format(culture, "{0:C0}", value);
            txtTongTien.Select(txtTongTien.Text.Length, 0);
        }

        public void BatTat(bool tt)
        {
            //dataGridView1.Enabled = tt;

            txtTienNhan.Enabled = tt;
             
            btnThanhToan.Enabled = tt;
            btnInHoaDon.Enabled = tt;

            //pnBtnThuCung.Enabled = tt;

            //groupBox1.Enabled = tt;
        }

        private bool muaHangBangMaQR(String maTCQR)
        {
            string maQuet = maTCQR;

            if (!dt.Columns.Contains("MaTC") && !dt.Columns.Contains("TenTC") && !dt.Columns.Contains("GiaBan"))
            {
                //Đặt tên cho cột trong datagirdview
                dt.Columns.Add("MaTC", typeof(int));
                dt.Columns.Add("TenTC", typeof(String));
                dt.Columns.Add("GiaBan", typeof(Decimal));
            }

            bool kt = false;
            ThuCung tc = bllDonHang.LayTCTheoMa(int.Parse(maQuet));
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (tc.MaTC.ToString() == dataGridView1.Rows[i].Cells[0].Value.ToString())
                {
                    kt = true;
                }
            }
            if (kt == false)
            {
                dt.Rows.Add(tc.MaTC, tc.TenTC, tc.GiaBan);
                dataGridView1.DataSource = dt;

                TinhTongTienTC();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnProductPet_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button pic = (Guna.UI2.WinForms.Guna2Button)sender;

            if (!dt.Columns.Contains("MaTC") && !dt.Columns.Contains("TenTC") && !dt.Columns.Contains("GiaBan"))
            {
                //Đặt tên cho cột trong datagirdview
                dt.Columns.Add("MaTC", typeof(int));
                dt.Columns.Add("TenTC", typeof(String));
                dt.Columns.Add("GiaBan", typeof(Decimal));
            }

            bool kt = false;
            ThuCung tc = bllDonHang.LayTCTheoMa(int.Parse(pic.Name));
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (tc.MaTC.ToString() == dataGridView1.Rows[i].Cells[0].Value.ToString())
                {
                    kt = true;
                }
            }
            if (kt == false)
            {
                dt.Rows.Add(tc.MaTC, tc.TenTC, tc.GiaBan);
                dataGridView1.DataSource = dt;

                TinhTongTienTC();
            }
            else
            {
                this.Alert("Thú cưng đã được thêm vào giỏ hàng", frmCustomTB.enmType.Error);
            }
        }

        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (IsValidVietNamPhoneNumber(txtSDT.Text) == false)
                    this.Alert("Vui lòng đúng định dạng", frmCustomTB.enmType.Error);
                else if (bllKhachHang.DsKHTheoSDT(txtSDT.Text).Rows.Count > 0)
                {
                    txtMaKH.Text = bllKhachHang.DsKHTheoSDT(txtSDT.Text).Rows[0][0].ToString();
                    txtTenKH.Text = bllKhachHang.DsKHTheoSDT(txtSDT.Text).Rows[0][1].ToString();
                    txtEmail.Text = bllKhachHang.DsKHTheoSDT(txtSDT.Text).Rows[0][2].ToString();
                    txtDiaChi.Text = bllKhachHang.DsKHTheoSDT(txtSDT.Text).Rows[0][3].ToString();
                    BatTat(true);
                    btnInHoaDon.Enabled = false;
                }
                else
                {
                    if (MessageBox.Show("Không tìm thấy số điện thoại khách hàng", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (fKH == null || fKH.IsDisposed)
                        {
                            fKH = new frmKhachHang();
                            fKH.Show();
                        }
                        else
                            fKH.Activate();
                    }
                }
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                this.Alert("Vui lòng nhập định dạng số!!!", frmCustomTB.enmType.Error);
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (fKH == null || fKH.IsDisposed)
            {
                fKH = new frmKhachHang();
                fKH.Show();
            }
            else
                fKH.Activate();
        }

        private bool IsValidEmail(string eMail)
        {
            if (string.IsNullOrWhiteSpace(eMail))
                return false;

            try
            {
                //Đọc tên miền email
                eMail = Regex.Replace(eMail, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
                //Kiểm tra miền của email và chuẩn hoá nó
                string DomainMapper(Match match)
                {
                    // Sử dụng lớp IdnMapping để chuyển đổi tên miền Unicode.
                    var idn = new IdnMapping();
                    // Kéo ra và xử lý tên miền (ném ArgumentException vào không hợp lệ)
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(eMail,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HienThiThoiGian();
        }

        private void HienThiThoiGian()
        {
            DateTime t = DateTime.Now;
            lblTime.Text = t.ToString("HH:mm:ss dd-MM-yyyy");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblGiaMax.Text = trackBar1.Value.ToString() + "0.000.000VND";
        }

        private void btnTimKiemTC_Click(object sender, EventArgs e)
        {
            int maThuCung = int.Parse(cboLoaiTC.SelectedValue.ToString());
            decimal tien = 10000000;
            decimal giaBanThuCung = trackBar1.Value * tien;
            pnDSThuCung.Controls.Clear();
            gBoxTimKiem.Controls.Remove(lblSoLuongTC);

            pnDSThuCung.Controls.Clear();
            if (trackBar1.Value == 0)
            {
                //Gọi Thú Cưng in pnBtnThuCung
                int StartY = 10;
                int x = 20;
                int y = 210;
                int StartX = 20;
                int dem = 0;
                soLuongTC = tc.DanhSachTCSell(maThuCung).Rows.Count;
                lblSoLuongTC.Text = soLuongTC.ToString();
                gBoxTimKiem.Controls.Add(lblSoLuongTC);
                Button[] btn = new Button[tc.DanhSachTCSell(maThuCung).Rows.Count];

                Guna.UI2.WinForms.Guna2Button[] hinh = new Guna.UI2.WinForms.Guna2Button[tc.DanhSachTCSell(maThuCung).Rows.Count];
                for (int i = 0; i < tc.DanhSachTCSell(maThuCung).Rows.Count; i++)
                {
                    btn[i] = new Button();

                    hinh[i] = new Guna.UI2.WinForms.Guna2Button();

                    tenTC = tc.DanhSachTCSell(maThuCung).Rows[i][1].ToString();
                    anh = tc.DanhSachTCSell(maThuCung).Rows[i][3].ToString();
                    ma = tc.DanhSachTCSell(maThuCung).Rows[i][0].ToString();
                    giaBan = Convert.ToDecimal(tc.DanhSachTCSell(maThuCung).Rows[i][2].ToString());
                    btn[i].BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + anh + "");
                    btn[i].BackgroundImageLayout = ImageLayout.Stretch;

                    btn[i].Size = new System.Drawing.Size(200, 200);

                    hinh[i].Size = new System.Drawing.Size(200, 50);
                    hinh[i].BorderRadius = 10;
                    hinh[i].FillColor = Color.FromArgb(255, 128, 128);


                    if (dem == 5)
                    {
                        dem = 0;
                        StartY += 270;
                        StartX = 20;

                        x = 20;
                        y += 270;
                    }
                    btn[i].Location = new Point(StartX, StartY);

                    hinh[i].Location = new Point(x, y);
                    StartX += 210;

                    x += 210;

                    btn[i].Name = ma;
                    hinh[i].Name = ma;

                    string textButton;
                    if (tenTC.Length > 20)
                    {
                        textButton = "" + tenTC.Substring(0, 20) + "...\n Giá Bán: " + giaBan.ToString("c0") + "";
                    }
                    else
                        textButton = "" + tenTC + "\n Giá Bán: " + giaBan.ToString("c0") + "";

                    hinh[i].Text = textButton;
                    btn[i].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                    hinh[i].Click += new System.EventHandler(this.btnProductPet_Click);
                    pnDSThuCung.Controls.Add(btn[i]);
                    pnDSThuCung.Controls.Add(hinh[i]);

                    dem++;
                }
            }
            else
            {
                //Gọi Thú Cưng in pnBtnThuCung
                int StartY = 10;
                int x = 20;
                int y = 210;
                int StartX = 20;
                int dem = 0;

                soLuongTC = tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows.Count;
                lblSoLuongTC.Text = soLuongTC.ToString();
                gBoxTimKiem.Controls.Add(lblSoLuongTC);

                Button[] btn = new Button[tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows.Count];

                Guna.UI2.WinForms.Guna2Button[] hinh = new Guna.UI2.WinForms.Guna2Button[tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows.Count];
                for (int i = 0; i < tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows.Count; i++)
                {
                    btn[i] = new Button();

                    hinh[i] = new Guna.UI2.WinForms.Guna2Button();

                    tenTC = tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows[i][1].ToString();
                    anh = tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows[i][3].ToString();
                    ma = tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows[i][0].ToString();
                    giaBan = Convert.ToDecimal(tc.DanhSachTCSell(maThuCung, giaBanThuCung).Rows[i][2].ToString());
                    btn[i].BackgroundImage = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + anh + "");
                    btn[i].BackgroundImageLayout = ImageLayout.Stretch;

                    btn[i].Size = new System.Drawing.Size(200, 200);

                    hinh[i].Size = new System.Drawing.Size(200, 50);
                    hinh[i].BorderRadius = 10;
                    hinh[i].FillColor = Color.FromArgb(255, 128, 128);

                    if (dem == 5)
                    {
                        dem = 0;
                        StartY += 270;
                        StartX = 20;

                        x = 20;
                        y += 270;
                    }
                    btn[i].Location = new Point(StartX, StartY);
                    hinh[i].Location = new Point(x, y);
                    StartX += 210;
                    x += 210;

                    btn[i].Name = ma;
                    hinh[i].Name = ma;

                    string textButton;
                    if (tenTC.Length > 20)
                    {
                        textButton = "" + tenTC.Substring(0, 20) + "...\n Giá Bán: " + giaBan.ToString("c0") + "";
                    }
                    else
                        textButton = "" + tenTC + "\n Giá Bán: " + giaBan.ToString("c0") + "";

                    hinh[i].Text = textButton;
                    btn[i].TextAlign = System.Drawing.ContentAlignment.BottomCenter;

                    hinh[i].Click += new System.EventHandler(this.btnProductPet_Click);
                    btn[i].UseVisualStyleBackColor = true;
                    pnDSThuCung.Controls.Add(btn[i]);
                    pnDSThuCung.Controls.Add(hinh[i]);

                    dem++;
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            dataGridView1.CurrentRow.Selected = true;
            //txtMaTC.Text = e.RowIndex.ToString();
            dongSLTC = e.RowIndex;
            //txtMaTC.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].FormattedValue.ToString();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenu ctx = new ContextMenu();
            MenuItem mItem = new MenuItem();
            mItem.Text = "Xoá";
            mItem.Click += new System.EventHandler(this.menuItem1_Click);
            ctx.MenuItems.Add(mItem);

            //MenuItem mItem2 = new MenuItem();
            //mItem2.Text = "Item.2";
            //ctx.MenuItems.Add(mItem2);

            if (e.Button == MouseButtons.Right)
            {
                Point pt = new Point(e.X, e.Y);
                ctx.Show(dataGridView1, pt);
            }
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            if (dt.Rows.Count > dongSLTC)
            {
                dt.Rows[dongSLTC].Delete();
                dt.AcceptChanges();
                dataGridView1.ClearSelection();

                TinhTongTienTC();
            }
            else
            {
                this.Alert("Vui lòng chọn dòng muốn xoá!!!", frmCustomTB.enmType.Info);
            }
        }
        public bool IsValidVietNamPhoneNumber(string phoneNum)
        {
            if (string.IsNullOrEmpty(phoneNum))
                return false;
            string sMailPattern = @"^((09(\d){8})|(03(\d){8})|(08(\d){8})|(07(\d){8})|(05(\d){8}))$";
            return Regex.IsMatch(phoneNum.Trim(), sMailPattern);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            bool ktThuCung = false;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (bllCTDH.KiemTraMaTCLinq(int.Parse(dt.Rows[i][0].ToString())).Count > 0)
                    {
                        ktThuCung = true;
                    }
                }
                if (ktThuCung == true)
                    this.Alert("Thú cưng đã được bán", frmCustomTB.enmType.Info);
                else if (IsValidEmail(txtEmail.Text) == false)
                    MessageBox.Show("Email không đúng định dạng!", "Thanh Toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txtSDT.Text.Trim() == "")
                    this.Alert("Vui lòng nhập số điện thoại khách hàng!", frmCustomTB.enmType.Info);
                else if (IsValidVietNamPhoneNumber(txtSDT.Text) == false)
                    this.Alert("Số điện thoại không đúng định dạng", frmCustomTB.enmType.Error);
                else if (txtTienNhan.TextLength == 0)
                    this.Alert("Vui lòng nhập số tiền nhận từ khách!", frmCustomTB.enmType.Error);
                else if (Convert.ToDouble(txtTienNhan.Text) < tongTien)
                    this.Alert("Số tiền nhận phải lớn hơn số tiền của hoá đơn!", frmCustomTB.enmType.Error);
                else if (MessageBox.Show("Bạn có muốn thanh toán hoá đơn không?", "Thanh Toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DateTime gio = DateTime.Now;

                    DonHangDTO dh = new DonHangDTO();
                    dh.MaNV = Convert.ToInt32(txtMaNV.Text);
                    dh.CreatedDate = gio;
                    dh.MaKH = Convert.ToInt32(txtMaKH.Text);
                    dh.NguoiNhan = txtTenKH.Text;
                    dh.Email = txtEmail.Text;
                    dh.Phone = txtSDT.Text;
                    dh.Address = txtDiaChi.Text;
                    dh.TongTien = Convert.ToDecimal(null);
                    dh.TrangThai = 1;

                    bllDonHang.Them(dh);
                    maDH = Convert.ToInt32(bllDonHang.DonHangSell(Convert.ToInt32(txtMaKH.Text), gio, Convert.ToInt32(txtMaNV.Text)).Rows[0][0].ToString());

                    if (maDH == 0)
                    {
                        this.Alert("Đơn hàng chưa được tạo!", frmCustomTB.enmType.Error);
                    }
                    else
                    {
                        //var templateHtml = "";
                        //var orderSummaryHtml = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int maTC = int.Parse(dt.Rows[i][0].ToString());
                            decimal thanhTien = decimal.Parse(dt.Rows[i][2].ToString());
                            bllCTDH.ThemLinq(maDH, maTC, thanhTien);

                            bllThuCung.UpdateNgayBan(maTC, gio);

                            //Tính tiền thừa
                            CultureInfo info = new CultureInfo("vi-VN");
                            double tienThua = Convert.ToDouble(txtTienNhan.Text) - tongTien;
                            txtTienThua.Text = tienThua.ToString("c0", info);

                        }
                        decimal emailThanhTien = decimal.Parse(bllDonHang.ThanhTienTheoMaDH(maDH).Rows[0][0].ToString());
                        string content = $@"Cám ơn khách hàng {dh.NguoiNhan} đã mua thú cưng tại StorePet với mã đơn hàng là {maDH} và tổng thanh toán là {emailThanhTien.ToString("c0")} cảm ơn quý khách Hẹn gặp quý khách lần sau";
                        string to = dh.Email;
                        string from = "petstoredpt@gmail.com";
                        string pass = "1234567890Aa";
                        if (SendMail.sendMail(from, to, content, pass) == true)
                        {
                            this.Alert("Đơn hàng đã được gửi vào Email.", frmCustomTB.enmType.Success);
                        }
                        else
                        {
                            this.Alert("Không thể gửi thông tin đơn hàng đến Email", frmCustomTB.enmType.Error);
                        }
                        this.Alert("Thanh toán đơn hàng thành công!", frmCustomTB.enmType.Success);
                        frmSell_Load(sender, e);
                        btnInHoaDon.Enabled = true;
                    }
                }
            }
            else
            {
                this.Alert("Vui lòng thêm thú cưng trước khi thanh toán", frmCustomTB.enmType.Error);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (fTT == null || fTT.IsDisposed)
            {
                fTT = new frmThanhToan();
                loadMaDH.maDH = maDH;
                fTT.Show();
            }
            else
                fTT.Activate();
        }

        private void cboLoaiTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtTienNhan_TextChanged(object sender, EventArgs e)
        {
            if (txtTienNhan.Text == "" || txtTienNhan.Text == "0") return;
            decimal number;
            number = decimal.Parse(txtTienNhan.Text, System.Globalization.NumberStyles.Currency);
            txtTienNhan.Text = number.ToString("#,#");
            txtTienNhan.SelectionStart = txtTienNhan.Text.Length;
        }

        private void btnQuetMa_Click(object sender, EventArgs e)
        {
            if (fCode == null || fCode.IsDisposed)
            {
                fCode = new frmCode(muaHangBangMaQR);
                fCode.Show();
            }
            else
                fCode.Activate();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtSDT.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";

            dt.Clear();

            txtTongTien.Text = "";
            txtTienNhan.Text = "";
            txtTienThua.Text = "";

            frmSell_Load(sender, e);
            this.Alert("Load thành công", frmCustomTB.enmType.Success);
        }
    }
}
