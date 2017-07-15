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
    public partial class thongtinbenhnhan : Form
    {
        BenhNhanCtrl BNCtr = new BenhNhanCtrl();
        private int flagLuu = 0;

        public thongtinbenhnhan()
        {
            InitializeComponent();
        }

        private void thongtinbenhnhan_Load(object sender, EventArgs e)
        {
            DataTable dtDS = new System.Data.DataTable();
            dtDS = BNCtr.GetData();
            dgvListBN.DataSource = dtDS;
            binding();
            DisEnl(false);
        }

        void binding()
        {
            txtHoten.DataBindings.Clear();
            txtHoten.DataBindings.Add("Text", dgvListBN.DataSource, "HoTen");
            txtMabn.DataBindings.Clear();
            txtMabn.DataBindings.Add("Text", dgvListBN.DataSource, "MaBN");
            cmbGioitinh.DataBindings.Clear();
            cmbGioitinh.DataBindings.Add("Text", dgvListBN.DataSource, "GioiTinh");
            txtDiachi.DataBindings.Clear();
            txtDiachi.DataBindings.Add("Text", dgvListBN.DataSource, "DiaChi");
            txtSdt.DataBindings.Clear();
            txtSdt.DataBindings.Add("Text", dgvListBN.DataSource, "SDT");
            dateNgaysinh.DataBindings.Clear();
            dateNgaysinh.DataBindings.Add("Text", dgvListBN.DataSource, "NgaySinh");
        }

        private void loadCMB()
        {
            cmbGioitinh.Items.Clear();
            cmbGioitinh.Items.Add("Nam");
            cmbGioitinh.Items.Add("Nữ");
            cmbGioitinh.SelectedItem = 0;
        }

        private void clearData()
        {
            txtMabn.Text = "";
            txtHoten.Text = "";
            txtDiachi.Text = "";
            txtSdt.Text = "";
            dateNgaysinh.Value = DateTime.Now.Date;
            loadCMB();
        }

        private void addData(BenhNhanObj bn)
        {
            bn.MaBN = txtMabn.Text.Trim();
            if (cmbGioitinh.SelectedIndex == 0)
            {
                bn.GioiTinh = "Nam";
            }
            else
                bn.GioiTinh = "Nữ";
            bn.DiaChi = txtDiachi.Text.Trim();
            bn.SDT = txtSdt.Text.Trim();
            bn.HoTen = txtHoten.Text.Trim();
            bn.NgaySinh = dateNgaysinh.Text;
        }

        private void DisEnl(bool e)
        {
            btnAdd.Enabled = !e;
            btntEdit.Enabled = !e;
            btnDel.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
            txtMabn.Enabled = e;
            txtHoten.Enabled = e;
            txtDiachi.Enabled = e;
            txtSdt.Enabled = e;
            cmbGioitinh.Enabled = e;
            dateNgaysinh.Enabled = e;
        }

        private void disTxtMabn(bool e)
        {
            btnAdd.Enabled = !e;
            btntEdit.Enabled = !e;
            btnDel.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
            txtMabn.Enabled = !e;
            txtHoten.Enabled = e;
            txtDiachi.Enabled = e;
            txtSdt.Enabled = e;
            cmbGioitinh.Enabled = e;
            dateNgaysinh.Enabled = e;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            flagLuu = 0;
            clearData();
            DisEnl(true);
        }

        private void btntEdit_Click(object sender, EventArgs e)
        {
            flagLuu = 1;
            disTxtMabn(true);
            loadCMB();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa bệnh nhân này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (BNCtr.DelData(txtMabn.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            thongtinbenhnhan_Load(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BenhNhanObj bnObj = new BenhNhanObj();
            addData(bnObj);
            if (flagLuu == 0)
            {
                if (BNCtr.AddData(bnObj))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (BNCtr.UpdData(bnObj))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            thongtinbenhnhan_Load(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                thongtinbenhnhan_Load(sender, e);
            else
                return;
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbSex_Enter(object sender, EventArgs e)
        {

        }
    }
}
