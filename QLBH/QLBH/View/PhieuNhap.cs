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
    public partial class PhieuNhap : UserControl
    {
        PhieuNhapCtr pnctr = new PhieuNhapCtr();
        ChiTietPNCtr ctctr = new ChiTietPNCtr();
        public static PhieuNhap  formpn = new PhieuNhap();
        DataTable dtDSCT = new System.Data.DataTable();
        int vitriclick = 0;
        public PhieuNhap()
        {
            InitializeComponent();
        }
        private void LoadcmbHH()
        {
            HangHoaCtr hhctr = new HangHoaCtr();
            cmbHH.DataSource = hhctr.GetData();
            cmbHH.DisplayMember = "TenMH";
            cmbHH.ValueMember = "MaMH";


        }
        private void LoadcmbKhachHang()
        {
            NhaCungCapCtr khctr = new NhaCungCapCtr();
            cmbKhachHang.DataSource = khctr.GetData();
            cmbKhachHang.DisplayMember = "TenNCC";
            cmbKhachHang.ValueMember = "MaNCC";
            cmbKhachHang.SelectedIndex = 0;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dis_Enl(true);
            clearData();
            LoadcmbHH();
            LoadcmbKhachHang();
            dtDSCT.Rows.Clear();
            dtDSCT.Columns.Clear();
            dtDSCT.Columns.Add("MaPN");
            dtDSCT.Columns.Add("MaMH");
            dtDSCT.Columns.Add("So luong");
            dtDSCT.Columns.Add("Don gia");
            dtDSCT.Columns.Add("ThanhTien");
        }
        private void clearData()
        {
            DataTable dt = new DataTable();
            dt = pnctr.GetID();
            int ma = int.Parse(dt.Rows[0][0].ToString()) + 1;
            txtMa.Text = ma.ToString();
            txtMa.Focus();
            txtMa.Enabled = false;
            txtTen.Text = bientoancuc.tennv;
            txtTen.Enabled = false;
            txtNgayLap.Text = DateTime.Now.Date.ToShortDateString();
            LoadcmbKhachHang();
            txtDonGia.Enabled = true;
        }
        private void adddata(PhieuNhapobj pn)
        {
            pn.Nguoilap = bientoancuc.bienxy;
            pn.Ncc = cmbKhachHang.SelectedValue.ToString();
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
            txtMa.DataBindings.Add("Text", dtgvDSHD.DataSource, "MaPN");
  
        }
        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            Dis_Enl(false);
            DataTable dt = new System.Data.DataTable();
            dt = pnctr.GetData();
            dtgvDSHD.DataSource = dt;
            bingding();
            txtNgayLap.Enabled = false;
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new System.Data.DataTable();
                dt = ctctr.GetData(txtMa.Text.Trim());
                dtgvDSHH.DataSource = dt;

            }
            catch
            {
                dtgvDSHH.DataSource = null;
            }
        }

       private void btnThem_Click(object sender, EventArgs e)
        {
                   if (!checktrung(cmbHH.SelectedValue.ToString()))
                    {
                        DataRow dr = dtDSCT.NewRow();
                        dr[0] = txtMa.Text.Trim();
                        dr[1] = cmbHH.SelectedValue.ToString();
                        dr[2] = txtSL.Text;
                        dr[3] =  txtDonGia.Text;
                        dr[4] = (double.Parse(txtDonGia.Text) * int.Parse(txtSL.Text)).ToString();
                        dtDSCT.Rows.Add(dr);
                    }
                    else
                    {
                                 MessageBox.Show("Trùng", "Lỗi");
                     }
                    dtgvDSHH.DataSource = dtDSCT;
        }

        private bool checktrung(string mahh)
        {
            for (int i = 0; i < dtDSCT.Rows.Count; i++)
                if (dtDSCT.Rows[i][1].ToString() == mahh)
                    return true;
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PhieuNhapobj hdObj = new PhieuNhapobj();
            adddata(hdObj);
            if (pnctr.AddData(hdObj))
            {
                if (ctctr.AddData(dtDSCT))
                    MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm chi tiết không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Thêm hóa đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            PhieuNhap_Load(sender, e);
        }

        private void btnBot_Click(object sender, EventArgs e)
        {
            if (vitriclick < dtDSCT.Rows.Count)
            {
                dtDSCT.Rows.RemoveAt(vitriclick);
                dtgvDSHH.DataSource = dtDSCT;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                PhieuNhap_Load(sender, e);
            else
                return;
        }
    }
}
