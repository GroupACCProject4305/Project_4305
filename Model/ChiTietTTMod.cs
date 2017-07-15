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
    class ChiTietTTMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = @"select ChiTietToaThuoc.MaToa, Thuoc.TenThuoc TenThuoc, ChiTietToaThuoc.SoLuong, ChiTietToaThuoc.CachDung from ChiTietToaThuoc, Thuoc where ChiTietToaThuoc.MaThuoc = Thuoc.MaThuoc";
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

        public DataTable LayData(string dk)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = @"select * from ChiTietToaThuoc INNER JOIN Thuoc ON ChiTietToaThuoc.MaThuoc=Thuoc.MaThuoc" + dk;
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

        public bool AddData(ChiTietToaThuocObj ctObj)
        {
            cmd.CommandText = @"Insert into ChiTietToaThuoc values ('" + ctObj.MaToa + "','" + ctObj.MaThuoc + "','" + ctObj.SoLuong + "',N'" + ctObj.CachDung + "')";
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
            cmd.CommandText = "Delete ChiTietToaThuoc Where MaToa = '" + ma + "'";
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
