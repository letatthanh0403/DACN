using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLBH.Object;

namespace QLBH.Model
{
    class ChiTietHDModel
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData(string ma)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = @"select ct.MaHD, hh.TenMH HangHoa, ct.SoLuong, hh.DonGia, ct.ThanhTien from ChiTietHoaDon ct, MatHang hh where ct.MaMH = hh.MaMH and MaHD = '" + ma + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return dt;
        }

        public bool AddData(DataTable dt)
        {

            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmd.CommandText = "insert into ChiTietHoaDon values ('" + dt.Rows[i][0].ToString() + "','" + dt.Rows[i][1].ToString() + "'," + dt.Rows[i][2].ToString() + "," + dt.Rows[i][3].ToString() + ")";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con.Connection;
                    con.OpenConn();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
        public bool AddData(ChiTietHDobj hdObj)
        {
            cmd.CommandText = "insert into ChiTietHoaDon(MaHD,MaMH,SoLuong) values ('" + hdObj.MaHoaDon + "','" + hdObj.MaHangHoa + "','" + hdObj.SoLuong + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }

        public bool DelData(string ma)
        {
            cmd.CommandText = "Delete ChiTietHoaDon Where MaHD = '" + ma + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
    }
}
