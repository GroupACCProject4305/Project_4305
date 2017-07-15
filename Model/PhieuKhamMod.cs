using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLphongkham.Object;


namespace QLphongkham.Model
{
    class PhieuKhamMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = @"select PhieuKham.MaPK, PhieuKham.MaBN, PhieuKham.STT, PhieuKham.NgayKham, PhieuKham.TrieuChung, PhieuKham.ChuanDoan, BenhNhan.HoTen from PhieuKham, BenhNhan where PhieuKham.MaBN = BenhNhan.MaBN";
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

        public bool AddData(PhieuKhamObj pkObj)
        {
            cmd.CommandText = "Insert into PhieuKham values ('" + pkObj.MaPK + "','" + pkObj.MaBN + "',CONVERT(DATE,'" + pkObj.NgayKham + "',103),'" + pkObj.STT + "',N'" + pkObj.TrieuChung + "',N'" + pkObj.ChuanDoan + "')";
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

        public bool UpdData(PhieuKhamObj pkObj)
        {
            cmd.CommandText = "Update PhieuKham set NgayKham = CONVERT(DATE,'" + pkObj.NgayKham + "',103), STT = " + pkObj.STT + ", TrieuChung = N'" + pkObj.TrieuChung + "',ChuanDoan = N'" + pkObj.ChuanDoan + "' Where MaPK = '" + pkObj.MaPK + "'";
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

        public bool DelData(string mapk)
        {
            cmd.CommandText = "Delete PhieuKham Where MaPK = '" + mapk + "'";
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
