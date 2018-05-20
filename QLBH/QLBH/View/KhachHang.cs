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
using QLBH.Model;
using QLBH.Object;
namespace QLBH.View
{
    public partial class KhachHang : UserControl
    {
        KhachHangCtr khCtr = new KhachHangCtr();
        private int flagLuu = 0;
        public KhachHang()
        {
            InitializeComponent();
        }
        public static KhachHang formkh = new KhachHang();
        private void DisEnl(bool e)
        {
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            txtMaKH.Enabled = e;
            txttenkh.Enabled = e;
            txtdiachi.Enabled = e;
            txtsdt.Enabled = e;
            cbbGioiTinh.Enabled = e;
            
        }
        private void loadCMB()
        {
            cbbGioiTinh.Items.Clear();
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
            cbbGioiTinh.SelectedItem = 0;
        }
        private void clearData()
        {
            txtMaKH.Text = "";
            txttenkh.Text = "";
            txtdiachi.Text = "";
            txtsdt.Text = "";
   
            
            loadCMB();
        }
        private void binhding()
        {
            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", dtgvDS.DataSource, "MaKH");
            txttenkh.DataBindings.Clear();
            txttenkh.DataBindings.Add("Text", dtgvDS.DataSource, "TenKH");
            txtdiachi.DataBindings.Clear();
            txtdiachi.DataBindings.Add("Text", dtgvDS.DataSource, "DiaChi");
            cbbGioiTinh.DataBindings.Clear();
            cbbGioiTinh.DataBindings.Add("Text", dtgvDS.DataSource, "GioiTinh");
            txtsdt.DataBindings.Clear();
            txtsdt.DataBindings.Add("Text", dtgvDS.DataSource, "SoDT");
          
        }
        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void addData(KhachHangobj kh)
        {
            kh.Ma = txtMaKH.Text.Trim();
            if (cbbGioiTinh.SelectedIndex == 0)
            {
                kh.Gioitinh = "Nam";
            }
            else
                kh.Gioitinh = "Nữ";
            kh.Diachi = txtdiachi.Text.Trim();
            kh.Tenkh = txttenkh.Text.Trim();
            kh.Sdt = txtsdt.Text.Trim();
           
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            DataTable dtDS = new System.Data.DataTable();
            dtDS = khCtr.GetData();
            dtgvDS.DataSource = dtDS;
            binhding();
            DisEnl(false);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            clearData();
            DisEnl(true);
            txtMaKH.Enabled = false;
            txttenkh.Focus();
            DataTable dtDS = new System.Data.DataTable();
            dtDS = khCtr.GetData();
            int count = 0;
            count = dtDS.Rows.Count;
            if (count <= 0)
            {
                txtMaKH.Text = "KH001";
            }
            else
            {
                string chuoi = "";
                int chuoi2 = 0;
                chuoi = Convert.ToString(dtDS.Rows[count - 1][0].ToString());
                chuoi2 = Convert.ToInt32((chuoi.Remove(0, 2)));
                if (chuoi2 + 1 < 10)
                    txtMaKH.Text = "KH00" + (chuoi2 + 1).ToString();
                else
                    if (chuoi2 + 1 < 100)
                    txtMaKH.Text = "KH0" + (chuoi2 + 1).ToString();
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txttenkh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            KhachHangobj khObj = new KhachHangobj();
            addData(khObj);
            if (flagLuu == 0)
            {
                if (khCtr.AddData(khObj))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (khCtr.UpdData(khObj))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            KhachHang_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                KhachHang_Load(sender, e);
            else
                return;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (khCtr.DelData(txtMaKH.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            KhachHang_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flagLuu = 1;
            DisEnl(true);
            loadCMB();
            txtMaKH.Enabled = false;
            txttenkh.Focus();
        }
    }
}
