using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBH.Control;
using QLBH.Object;

namespace QLBH.View
{
    public partial class HoaDon : UserControl
    {
        HoaDonCtrl hdCtr = new HoaDonCtrl();
        ChiTietHDCtr ctCtr = new ChiTietHDCtr();
        HangHoaCtr hhctr = new HangHoaCtr();
        NhanVienCtr nvctr = new NhanVienCtr();
        DataTable dtDSCT = new System.Data.DataTable();

        public static HoaDon formhd = new HoaDon();
        public HoaDon()
        {
            InitializeComponent();
        }
        private void Dis_Enl(bool e)
        {
            txtMa.Enabled = e;
            txtTen.Enabled = e;
            cmbKhachHang.Enabled = e;
            btnAdd.Enabled = !e;
            btnDel.Enabled = !e;
           
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
           
            btnThem.Enabled = e;
            btnBot.Enabled = e;
            cmbHH.Enabled = e;
            txtSL.Enabled = e;
        }
        private void bingding()
        {
            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", dtgvDSHD.DataSource, "MaHD");
            txtNgayLap.DataBindings.Clear();
            txtNgayLap.DataBindings.Add("Text", dtgvDSHD.DataSource, "NgayDH");
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dtgvDSHD.DataSource, "TenNV");
            cmbKhachHang.DataBindings.Clear();
            cmbKhachHang.DataBindings.Add("Text", dtgvDSHD.DataSource, "TenKH");
        }
        private void LoadcmbKhachHang()
        {
            KhachHangCtr khctr = new KhachHangCtr();
            cmbKhachHang.DataSource = khctr.GetData();
            cmbKhachHang.DisplayMember = "TenKH";
            cmbKhachHang.ValueMember = "MaKH";
            cmbKhachHang.SelectedIndex = 0;
        }
       // private void Loadnvcbb()
       // {
       //     NhanVienCtr nvctr = new NhanVienCtr();
       //     nvcbb.DataSource = nvctr.GetData();
        //    nvcbb.DisplayMember = "TenNV";
       //     nvcbb.ValueMember = "MaNV";
       //     nvcbb.SelectedIndex = 0;
      //  }

        private void LoadcmbHH()
        {
            HangHoaCtr hhctr = new HangHoaCtr();
            cmbHH.DataSource = hhctr.GetData();
            cmbHH.DisplayMember = "TenMH";
            cmbHH.ValueMember = "MaMH";
          

        }
        private void addData(HoaDonobj hdObj)
        {
            hdObj.NguoiLap = bientoancuc.bienxy;
            hdObj.KhachHang = cmbKhachHang.SelectedValue.ToString();
        }
        private void addData2(ChiTietHDobj cthdobj)
        {
            cthdobj.MaHangHoa = cmbHH.SelectedValue.ToString();
            cthdobj.MaHoaDon = txtMa.Text.Trim();
            cthdobj.SoLuong= int.Parse(txtSL.Text);
                    }
        private void clearData()
        {
            txtMa.Enabled = false;
            txtNgayLap.Text = DateTime.Now.Date.ToShortDateString();
            LoadcmbKhachHang();
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            Dis_Enl(false);
            DataTable dt = new System.Data.DataTable();
            dt = hdCtr.GetData();
            dtgvDSHD.DataSource = dt;
            bingding();
            txtNgayLap.Enabled = false;
            DataTable dt1 = new System.Data.DataTable();
            dt1 = ctCtr.GetData(txtMa.Text.Trim());
            dtgvDSHH.DataSource = dt1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dis_Enl(true);
            clearData();
            LoadcmbHH();
            LoadcmbKhachHang();
            txtTen.Enabled = false;
            txtTen.Text = bientoancuc.tennv;
            txtTen.Focus();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HoaDonobj hdObj = new HoaDonobj();
            addData(hdObj);
            if (hdCtr.AddData(hdObj))
                MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Thêm hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            HoaDon_Load(sender, e);
        }
        private bool kiemtraSL(string mahh, int sl)
        {
            DataTable dt = new DataTable();
            dt = hhctr.GetData("Where MaMH = '" + cmbHH.SelectedValue.ToString() + "' and SoLuong>= " + sl);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
           
            ChiTietHDobj hdObj = new ChiTietHDobj();
            addData2(hdObj);
            if (kiemtraSL(cmbHH.SelectedValue.ToString(), int.Parse(txtSL.Text.Trim())))
            {
                if (ctCtr.AddData(hdObj))

                    MessageBox.Show("Thêm chi tiết hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm chi tiêt hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Thiếu hàng", "Lỗi");
                txtSL.Focus();
            }
                    HoaDon_Load(sender, e);
        }

        private void nvcbb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
                DataTable dt = new System.Data.DataTable();
                dt = ctCtr.GetData(txtMa.Text.Trim());
                dtgvDSHH.DataSource = dt;

         
        }

        private void cmbHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = hhctr.GetData("Where MaMH = '" + cmbHH.SelectedValue.ToString() + "'");
            if (dt.Rows.Count > 0)
            {
                double gia = double.Parse(dt.Rows[0][3].ToString());
                txtDonGia.Text = (gia * 1).ToString();
                lbThanhTien.Text = (double.Parse(txtDonGia.Text) * int.Parse(txtSL.Text)).ToString();
               
            }

        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            lbThanhTien.Text = (double.Parse(txtDonGia.Text) * int.Parse(txtSL.Text)).ToString();
        }
    }
}
