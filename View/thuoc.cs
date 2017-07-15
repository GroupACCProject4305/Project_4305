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
    public partial class thuoc : Form
    {
        ThuocCtrl THCtr = new ThuocCtrl();
        private int flagLuu = 0;

        public thuoc()
        {
            InitializeComponent();
        }

        private void thuoc_Load(object sender, EventArgs e)
        {
            DataTable dtDS = new System.Data.DataTable();
            dtDS = THCtr.GetData();
            dgvThuoc.DataSource = dtDS;
            binding();
            DisEnl(false);
        }

        void binding()
        {
            txtMaThuoc.DataBindings.Clear();
            txtMaThuoc.DataBindings.Add("Text", dgvThuoc.DataSource, "MaThuoc");
            txtTenThuoc.DataBindings.Clear();
            txtTenThuoc.DataBindings.Add("Text", dgvThuoc.DataSource, "TenThuoc");
            txtDonVi.DataBindings.Clear();
            txtDonVi.DataBindings.Add("Text", dgvThuoc.DataSource, "DonVi");
            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", dgvThuoc.DataSource, "DonGia");
            dtNSX.DataBindings.Clear();
            dtNSX.DataBindings.Add("Text", dgvThuoc.DataSource, "NSX");
            dtHSD.DataBindings.Clear();
            dtHSD.DataBindings.Add("Text", dgvThuoc.DataSource, "HSD");
        }

        private void clearData()
        {
            txtMaThuoc.Text = "";
            txtTenThuoc.Text = "";
            txtDonGia.Text = "";
            txtDonVi.Text = "";
            dtNSX.Value = DateTime.Now.Date;
            dtHSD.Value = DateTime.Now.Date;
        }

        private void addData(ThuocObj th)
        {
            th.MaThuoc = txtMaThuoc.Text.Trim();
            th.TenThuoc = txtTenThuoc.Text.Trim();
            th.DonVi = txtDonVi.Text.Trim();
            th.DonGia = int.Parse(txtDonGia.Text.Trim());
            th.NSX = dtNSX.Text;
            th.HSD = dtHSD.Text;
        }

        private void DisEnl(bool e)
        {
            btnAdd.Enabled = !e;
            btnEdit.Enabled = !e;
            btnDel.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
            txtMaThuoc.Enabled = e;
            txtTenThuoc.Enabled = e;
            txtDonVi.Enabled = e;
            txtDonGia.Enabled = e;
            dtNSX.Enabled = e;
            dtHSD.Enabled = e;
        }

        private void disTxtMath(bool e)
        {
            btnAdd.Enabled = !e;
            btnEdit.Enabled = !e;
            btnDel.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
            txtMaThuoc.Enabled = !e;
            txtTenThuoc.Enabled = e;
            txtDonVi.Enabled = e;
            txtDonGia.Enabled = e;
            dtNSX.Enabled = e;
            dtHSD.Enabled = e;
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            flagLuu = 1;
            disTxtMath(true);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa loại thuốc này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (THCtr.DelData(txtMaThuoc.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            thuoc_Load(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ThuocObj th = new ThuocObj();
            addData(th);
            if (flagLuu == 0)
            {
                if (THCtr.AddData(th))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (THCtr.UpdData(th))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            thuoc_Load(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                thuoc_Load(sender, e);
            else
                return;
        }

    }
}
