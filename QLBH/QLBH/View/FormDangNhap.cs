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
namespace QLBH.View
{

    public partial class FormDangNhap : Form
    {
        NhanVienCtr nvctr = new NhanVienCtr();
        public FormDangNhap()
        {
            InitializeComponent();
        }

    

        private bool kiemtra(string ma, string mk)
        {
            DataTable dt = new DataTable();
            dt = nvctr.GetData("Where MaNV = '" + ma + "' and MatKhau= " + mk);
            if (dt.Rows.Count > 0)
            {
                bientoancuc.bienxy = dt.Rows[0][0].ToString();
                bientoancuc.tennv = dt.Rows[0][1].ToString();
                bientoancuc.maqh = dt.Rows[0][7].ToString();
                return true;
            }
            return false;
        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text;
            string matkhau = txtMatkhau.Text;
            if (kiemtra(manv, matkhau))
            {
                if (bientoancuc.maqh == "QH001") {
                    MessageBox.Show("Đăng nhập thành công! Xin chào nhân viên " + bientoancuc.tennv, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    TrangChu tc = new TrangChu();
                    tc.ShowDialog();
                }
                else
                {
                    if (bientoancuc.maqh == "QH002")
                    {
                        MessageBox.Show("Đăng nhập thành công! Xin chào quản lý " + bientoancuc.tennv, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        TrangChu tc = new TrangChu();
                        tc.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Lỗi");

            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn hủy bỏ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
