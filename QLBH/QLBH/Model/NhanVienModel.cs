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
    class NhanVienModel
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from NhanVien";
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
        public bool AddData(Nhanvienobj nvObj)
        {
            cmd.CommandText = "Insert into NhanVien values ('" + nvObj.Ma + "',N'" + nvObj.Tennv + "','" + nvObj.Email + "',CONVERT(DATE,'" + nvObj.NgaySinh + "',103),'" + nvObj.Gioitinh + "','" + nvObj.Cmnd + "','" + nvObj.Matkhau + "','" + nvObj.Maqh + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseConn();
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
        public bool UpdData(Nhanvienobj nvObj)
        {
            cmd.CommandText = "Update NhanVien set TenNV =  N'" + nvObj.Tennv + "', Email = N'" + nvObj.Email + "', NgaySinh = CONVERT(DATE,'" + nvObj.NgaySinh + "',103), GioiTinh = N'" + nvObj.Gioitinh + "', CMND = " + nvObj.Cmnd + ", MatKhau = '" + nvObj.Matkhau + "', MaQH = '" + nvObj.Maqh + "' Where MaNV = '" + nvObj.Ma + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseConn();
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
            cmd.CommandText = "Delete NhanVien Where MaNV = '" + ma + "'";
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
