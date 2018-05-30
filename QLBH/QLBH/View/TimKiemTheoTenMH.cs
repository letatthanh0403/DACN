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
    public partial class TimKiemTheoTenMH : UserControl
    {
        public static TimKiemTheoTenMH mh= new TimKiemTheoTenMH();
        public TimKiemTheoTenMH()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            HangHoaCtr hh = new HangHoaCtr();

            dt = hh.GetData2("Where TenMH like N'" + timkiem.Text + "%'");
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
    }
}
