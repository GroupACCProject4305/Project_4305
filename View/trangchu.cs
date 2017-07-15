using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLphongkham.view;

namespace QLphongkham
{
    public partial class qlpk : Form
    {
        public qlpk()
        {
            InitializeComponent();
        }

        private void home_Click(object sender, EventArgs e)
        {
            
        }

        private void benhnhan_Click(object sender, EventArgs e)
        {
            thongtinbenhnhan f = new view.thongtinbenhnhan();
            f.Show();
        }

        private void phieukham_Click(object sender, EventArgs e)
        {
            phieukham f = new view.phieukham();
            f.Show();
        }

        private void thuoc_Click(object sender, EventArgs e)
        {
            thuoc f = new view.thuoc();
            f.Show();
        }

        private void toathuoc_Click(object sender, EventArgs e)
        {
            laptoathuoc f = new view.laptoathuoc();
            f.Show();
        }

        private void hoadon_Click(object sender, EventArgs e)
        {
            hoadon f = new view.hoadon();
            f.Show();
        }

        private void doanhthu_Click(object sender, EventArgs e)
        {

        }
    }
}
