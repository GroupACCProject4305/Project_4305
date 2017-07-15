using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLphongkham.Control;
using QLphongkham.Object;

namespace QLphongkham.view
{
    public partial class hoadon : Form
    {
        HoaDonCtrl hdCtr = new HoaDonCtrl();
        ThuocCtrl thuocCtr = new ThuocCtrl();
        ChiTietTTCtrl CTTTCtr = new ChiTietTTCtrl();
        private int flagLuu = 0;

        public hoadon()
        {
            InitializeComponent();
        }

        private void hoadon_Load(object sender, EventArgs e)
        {
            DataTable dthd = new System.Data.DataTable();
            dthd = hdCtr.GetData();
            dgvHD.DataSource = dthd;
            
            binding();

            DisEnl(false);
        }

        void binding()
        {
            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("Text", dgvHD.DataSource, "MaHD");
            cmbMaToa.DataBindings.Clear();
            cmbMaToa.DataBindings.Add("Text", dgvHD.DataSource, "MaToa");
            dtNgayBan.DataBindings.Clear();
            dtNgayBan.DataBindings.Add("Text", dgvHD.DataSource, "NgayBan");
            txtTien.DataBindings.Clear();
            txtTien.DataBindings.Add("Text", dgvHD.DataSource, "TienThuoc");
        }

        private void LoadcmbToa()
        {
            ToaThuocCtrl pkctr = new ToaThuocCtrl();
            cmbMaToa.DataSource = pkctr.GetData();
            cmbMaToa.DisplayMember = "MaToa";
            cmbMaToa.ValueMember = "MaToa";
        }

        private void clearData()
        {
            txtMaHD.Text = "";
            txtTien.Text = "";
            cmbMaToa.Text = "";
            dtNgayBan.Text = "";
            dtNgayBan.Value = DateTime.Now.Date;
            LoadcmbToa();
        }

        private void addData(HoaDonThuocObj hdObj)
        {
            hdObj.MaToa = txtMaHD.Text.Trim();
            hdObj.TienThuoc = int.Parse(txtTien.Text.Trim());
            hdObj.MaToa = cmbMaToa.SelectedValue.ToString();
            hdObj.NgayBan = cmbMaToa.Text;
        }

        private void DisEnl(bool e)
        {
            btnAdd.Enabled = !e;
            btnDel.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
            txtMaHD.Enabled = e;
            txtTien.Enabled = e;
            cmbMaToa.Enabled = e;
            dtNgayBan.Enabled = e;
        }

        private void txtTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            clearData();
            DisEnl(true);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (hdCtr.DelData(txtMaHD.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            hoadon_Load(sender, e);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang đc nâng cấp");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HoaDonThuocObj hdObj = new HoaDonThuocObj();
            addData(hdObj);
            if (flagLuu == 0)
            {
                if (hdCtr.AddData(hdObj))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            hoadon_Load(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                hoadon_Load(sender, e);
            else
                return;
        }

        /*private void cmbMaToa_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = CTTTCtr.LayData("where ChiTietToaThuoc.MaToa = '" + cmbMaToa.SelectedValue.ToString() + "'");

            foreach(DataRow dr in dt.Rows)
            {

                if (int.Parse(dr["DonGia"].ToString()) != 0 && int.Parse(dr["SoLuong"].ToString()) != 0)
                {
....                int gia = 0;
                    gia = gia + (int.Parse(dr["DonGia"].ToString()) * int.Parse(dr["SoLuong"].ToString()));
                    txtTien.Text =((int.Parse(dr["DonGia"]) * int.Parse(dr["SoLuong"]))).ToString;
                }
            }
            
        }*/
    }
}
