using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH.View
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        internal static List<byte> typePages = new List<byte>();
        public void ThemTabPages(UserControl uct, byte typeControl, string tenTab)
        {
            //Kiểm tra tồn trại trang này chưa
            for (int i = 0; i < tabchinh.TabPages.Count; i++)
            {
                if (tabchinh.TabPages[i].Contains(uct) == true)
                {
                    tabchinh.SelectedTab = tabchinh.TabPages[i];
                    return;
                }
            }
            TabPage tab = new TabPage();
            typePages.Add(typeControl);
            tab.Name = uct.Name;
            tab.Size = tabchinh.Size;
            tab.Text = tenTab;
            tabchinh.TabPages.Add(tab);
            tabchinh.SelectedTab = tab;
            uct.Dock = DockStyle.Fill;
            tab.Controls.Add(uct);
            uct.Focus();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(View.HoaDon.formhd, 4, "Hóa đơn bán");

        }
        public void DongTabHienTai()
        {
            tabchinh.TabPages.Remove(tabchinh.SelectedTab);
        }

     

        private void đóngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DongTabHienTai();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                FormDangNhap dn = new FormDangNhap();
                dn.ShowDialog();
            }
            else
            {
                return;
            }
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ThemTabPages(View.NhanVien.frmNV, 4, "Quản lý nhân viên");
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(View.KhachHang.formkh, 4, "Quản lý khách hàng");
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            chaotxt.Text = "Xin chào, " + bientoancuc.tennv;
            if(bientoancuc.maqh=="QH001")
            {
                quảnLýNhânViênToolStripMenuItem.Enabled = false;
            }
            else { 
                if(bientoancuc.maqh=="QH002")
                {

                }
             }
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(View.PhieuNhap.formpn, 4, "Phiếu Nhập");
        }

        private void tìmKiếmTheoTênNCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(View.TimKiemTheoTenNhaCC.ncc, 4, "Tìm Kiếm");
        }

        private void tìmKiếmTheoTênMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemTabPages(View.TimKiemTheoTenMH.mh, 4, "Tìm Kiếm");
        }
    }
}
