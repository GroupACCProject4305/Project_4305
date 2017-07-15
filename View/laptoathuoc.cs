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
    public partial class laptoathuoc : Form
    {
        ToaThuocCtrl ttCtr = new ToaThuocCtrl();
        ChiTietTTCtrl ctCtr = new ChiTietTTCtrl();

        private int flagLuu = 0;
        private int flagsave = 0;

        public laptoathuoc()
        {
            InitializeComponent();
        }

        private void laptoathuoc_Load(object sender, EventArgs e)
        {
            DataTable dtTT = new System.Data.DataTable();
            dtTT = ttCtr.GetData();
            dgvToaThuoc.DataSource = dtTT;

            DataTable dtCT = new System.Data.DataTable();
            dtCT = ctCtr.GetData();
            dgvChiTiet.DataSource = dtCT;

            binding();

            DisEnl(false);
            DisEnl1(false);
        }

        void binding()
        {
            txtMatoa.DataBindings.Clear();
            txtMatoa.DataBindings.Add("Text", dgvToaThuoc.DataSource, "MaToa");
            cmbPK.DataBindings.Clear();
            cmbPK.DataBindings.Add("Text", dgvToaThuoc.DataSource, "MaPK");
            dtNgayKe.DataBindings.Clear();
            dtNgayKe.DataBindings.Add("Text", dgvToaThuoc.DataSource, "NgayKeToa");
            txtBacSi.DataBindings.Clear();
            txtBacSi.DataBindings.Add("Text", dgvToaThuoc.DataSource, "BacSiKeToa");
        }

        void binding1()
        {
            cmbToa.DataBindings.Clear();
            cmbToa.DataBindings.Add("Text", dgvChiTiet.DataSource, "MaToa");
            cmbThuoc.DataBindings.Clear();
            cmbThuoc.DataBindings.Add("Text", dgvChiTiet.DataSource, "MaThuoc");
            txtSL.DataBindings.Clear();
            txtSL.DataBindings.Add("Text", dgvChiTiet.DataSource, "SoLuong");
            txtCD.DataBindings.Clear();
            txtCD.DataBindings.Add("Text", dgvChiTiet.DataSource, "CachDung");
        }

        private void LoadcmbPK()
        {
            PhieuKhamCtrl pkctr = new PhieuKhamCtrl();
            cmbPK.DataSource = pkctr.GetData();
            cmbPK.DisplayMember = "MaPK";
            cmbPK.ValueMember = "MaPK";
        }

        private void LoadcmbToa()
        {
            ToaThuocCtrl ttctr = new ToaThuocCtrl();
            cmbToa.DataSource = ttctr.GetData();
            cmbToa.DisplayMember = "MaToa";
            cmbToa.ValueMember = "MaToa";
        }

        private void LoadcmbThuoc()
        {
            ThuocCtrl thuocctr = new ThuocCtrl();
            cmbThuoc.DataSource = thuocctr.GetData();
            cmbThuoc.DisplayMember = "TenThuoc";
            cmbThuoc.ValueMember = "MaThuoc";
        }

        private void clearData()
        {
            cmbToa.Text = "";
            cmbPK.Text = "";
            cmbThuoc.Text = "";
            txtMatoa.Text = "";
            txtBacSi.Text = "";
            txtSL.Text = "";
            txtCD.Text = "";
            dtNgayKe.Value = DateTime.Now.Date;
            LoadcmbPK();
            LoadcmbThuoc();
            LoadcmbToa();
        }

        private void addData1(ToaThuocObj ttObj)
        {
            ttObj.MaToa = txtMatoa.Text.Trim();
            ttObj.BacSiKeToa = txtBacSi.Text.Trim();
            ttObj.MaPK = cmbPK.SelectedValue.ToString();
            ttObj.NgayKeToa = dtNgayKe.Text;
        }

        private void addData2(ChiTietToaThuocObj ctObj)
        {
            ctObj.MaToa = cmbToa.SelectedValue.ToString();
            ctObj.MaThuoc = cmbThuoc.SelectedValue.ToString();;
            ctObj.SoLuong = int.Parse(txtSL.Text.Trim());
            ctObj.CachDung = txtCD.Text.Trim();
        }

        private void DisEnl(bool e)
        {
            btnAdd.Enabled = !e;
            btnDel.Enabled = !e;
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
            txtBacSi.Enabled = e;
            dtNgayKe.Enabled = e;
            cmbPK.Enabled = e;
            txtMatoa.Enabled = e;
        }

        private void DisEnl1(bool e)
        {
            btnThem.Enabled = !e;
            btnxoa.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
            cmbThuoc.Enabled = e;
            cmbToa.Enabled = e;
            txtCD.Enabled = e;
            txtSL.Enabled = e;
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
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
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa toa thuốc này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (ttCtr.DelData(txtMatoa.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            laptoathuoc_Load(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ToaThuocObj ttObj = new ToaThuocObj();
            addData1(ttObj);
            if (flagsave == 0)
            {
                if (ttCtr.AddData(ttObj))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            laptoathuoc_Load(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                laptoathuoc_Load(sender, e);
            else
                return;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flagsave = 0;
            clearData();
            DisEnl1(true);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa chi tiết toa thuốc này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (ctCtr.DelData(txtMatoa.Text.Trim()))
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            laptoathuoc_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ChiTietToaThuocObj ctObj = new ChiTietToaThuocObj();
            addData2(ctObj);
            if (flagLuu == 0)
            {
                if (ctCtr.AddData(ctObj))
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            laptoathuoc_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn hủy thao tác đang làm?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                laptoathuoc_Load(sender, e);
            else
                return;
        }
    }
}
