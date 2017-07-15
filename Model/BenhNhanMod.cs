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
    class BenhNhanMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from BenhNhan";
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

        public bool AddData(BenhNhanObj bnObj)
        {
            cmd.CommandText = "Insert into BenhNhan values ('" + bnObj.MaBN + "',N'" + bnObj.HoTen + "',N'" + bnObj.GioiTinh + "',CONVERT(DATE,'" + bnObj.NgaySinh + "',103),N'" + bnObj.DiaChi + "','" + bnObj.SDT + "')";
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

        public bool UpdData(BenhNhanObj bnObj)
        {
            cmd.CommandText = "Update BenhNhan set HoTen =  N'" + bnObj.HoTen + "', GioiTinh = N'" + bnObj.GioiTinh + "', NgaySinh = CONVERT(DATE,'" + bnObj.NgaySinh + "',103), DiaChi = N'" + bnObj.DiaChi + "',SDT = '" + bnObj.SDT + "' Where MaBN = '" + bnObj.MaBN + "'";
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
        
        public bool DelData(string mabn)
        {
            cmd.CommandText = "Delete BenhNhan Where MaBN = '" + mabn + "'";
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
