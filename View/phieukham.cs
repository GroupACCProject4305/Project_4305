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
    public partial class phieukham : Form
    {
        PhieuKhamCtrl PKCtr = new PhieuKhamCtrl();

        private int flagLuu = 0;

        public phieukham()
        {
            InitializeComponent();
        }

        private void phieukham_Load(object sender, EventArgs e)
        {
            DataTable dtDS = new System.Data.DataTable();
            dtDS = PKCtr.GetData();
            dgvListPK.DataSource = dtDS;

            binding();
            DisEnl(false);
        }

        void binding()
        {
            txtmapk.DataBindings.Clear();
            txtmapk.DataBindings.Add("Text", dgvListPK.DataSource, "MaPK");
            cmbMaBN.DataBindings.Clear();
            cmbMaBN.DataBindings.Add("Text", dgvListPK.DataSource, "MaBN");
            dtngaykham.DataBindings.Clear();
            dtngaykham.DataBindings.Add("Text", dgvListPK.DataSource, "NgayKham");
            txttrieuchung.DataBindings.Clear();
            txttrieuchung.DataBindings.Add("Text", dgvListPK.DataSource, "TrieuChung");
            txtchuandoan.DataBindings.Clear();
            txtchuandoan.DataBindings.Add("Text", dgvListPK.DataSource, "ChuanDoan");
            txtstt.DataBindings.Clear();
            txtstt.DataBindings.Add("Text", dgvListPK.DataSource, "STT");
            txtTenBN.DataBindings.Clear();
            txtTenBN.DataBindings.Add("Text", dgvListPK.DataSource, "HoTen");
        }

        private void LoadcmbBN()
        {
            BenhNhanCtrl bnctr = new BenhNhanCtrl();
            cmbMaBN.DataSource = bnctr.GetData();
            cmbMaBN.DisplayMember = "MaBN";
            txtTenBN.DataBindings.Clear();
            txtTenBN.DataBindings.Add("Text", cmbMaBN.DataSource, "HoTen");
            cmbMaBN.ValueMember = "MaBN";
        }

        private void clearData()
        {
            txtmapk.Text = "";
            txtstt.Text = "";
            txtchuandoan.Text = "";
            txttrieuchung.Text = "";
            txtTenBN.Text = "";
            dtngaykham.Value = DateTime.Now.Date;
            LoadcmbBN();
        }

        private void addData(PhieuKhamObj pkObj)
        {
            pkObj.MaPK = txtmapk.Text.Trim();
            pkObj.TrieuChung = txttrieuchung.Text.Trim();
            pkObj.ChuanDoan = txtchuandoan.Text.Trim();
            pkObj.MaBN = cmbMaBN.SelectedValue.ToString();
            pkObj.NgayKham = dtngaykham.Text;
            pkObj.STT = int.Parse(txtstt.Text.Trim());
        }

        private void DisEnl(bool e)
        {
            btnAdd.Enabled = !e;
            btnEdit.Enabled = !e;
            btnDel.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
            txtmapk.Enabled = e;
            cmbMaBN.Enabled = e;
            txtstt.Enabled = e;
            dtngaykham.Enabled = e;
            txtchuandoan.Enabled = e;
            txttrieuchung.Enabled = e;
        }

        private void disTxtMa(bool e)
        {
            btnAdd.Enabled = !e;
            btnEdit.Enabled = !e;
            btnDel.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
            txtmapk.Enabled = !e;
            cmbMaBN.Enabled = !e;
            txtstt.Enabled = e;
            dtngaykham.Enabled = e;
            txtchuandoan.Enabled = e;
            txttrieuchung.Enabled = e;
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
            disTxtMa(true);
            LoadcmbBN();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa phiếu khám này này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (PKCtr.DelData(txtmapk.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            phieukham_Load(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PhieuKhamObj pkObj = new PhieuKhamObj();
            addData(pkObj);
            if (flagLuu == 0)
            {
                if (PKCtr.AddData(pkObj))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (PKCtr.UpdData(pkObj))
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            phieukham_Load(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                phieukham_Load(sender, e);
            else
                return;
        }

        private void txtstt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
