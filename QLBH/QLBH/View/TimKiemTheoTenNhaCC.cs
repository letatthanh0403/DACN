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
    public partial class TimKiemTheoTenNhaCC : UserControl
    {
        public static TimKiemTheoTenNhaCC ncc = new TimKiemTheoTenNhaCC();
        public TimKiemTheoTenNhaCC()
        {
            InitializeComponent();
        }
        private void LoadNCC()
        {
            HangHoaCtr khctr = new HangHoaCtr();
            comboBox1.DataSource = khctr.NhaSanXuat();
            comboBox1.DisplayMember = "TenNSX";
            comboBox1.ValueMember = "MaNSX";
            comboBox1.SelectedIndex = 0;
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            HangHoaCtr hh = new HangHoaCtr();
         
            dt = hh.GetData2("Where MaNSX = '" + comboBox1.SelectedValue.ToString() + "'");
            if (dt.Rows.Count > 0)
            {
                dgvDanhSach.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Không tìm thấy.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvDanhSach.DataSource = dt;
               
                dgvDanhSach.ClearSelection();
            }
        }

        private void TimKiemTheoTenNhaCC_Load(object sender, EventArgs e)
        {
            LoadNCC();
        }
    }
}
