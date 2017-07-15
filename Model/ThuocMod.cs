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
    class ThuocMod
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from Thuoc";
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

        public bool AddData(ThuocObj thObj)
        {
            cmd.CommandText = "insert into Thuoc values('"+thObj.MaThuoc+"',N'"+thObj.TenThuoc+"',N'"+thObj.DonVi+"',"+thObj.DonGia+",CONVERT(DATE,'"+ thObj.NSX +"',103),CONVERT(DATE,'"+thObj.HSD+"',103))";
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

        public bool UpdData(ThuocObj thObj)
        {
            cmd.CommandText = "Update Thuoc set TenThuoc =  N'" + thObj.TenThuoc + "', DonVi = N'" + thObj.DonVi + "',  DonGia = '" + thObj.DonGia + "',NSX = CONVERT(DATE,'" + thObj.NSX + "',103), HSD = CONVERT(DATE,'" + thObj.HSD + "',103) Where MaThuoc = '" + thObj.MaThuoc + "'";
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

        public bool DelData(string mathuoc)
        {
            cmd.CommandText = "Delete Thuoc Where MaThuoc = '" + mathuoc + "'";
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
