using QLSach.BLL;
using QLSach.DTO;
using QLSach.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBB();
            LoadData();
        }
        public static int a_id { get; set; }
        public void SetCBB()
        {
            cbbTG.Items.Add(new CBBItem { Value = 0, Text = "All" });
            foreach (Author i in Author_BLL.Instance.GetListA_BLL())
            {
                cbbTG.Items.Add(new CBBItem
                {
                    Value = i.A_ID,
                    Text = i.A_Name
                });
            }
            cbbTG.SelectedIndex = 0;
            a_id = ((CBBItem)cbbTG.SelectedItem).Value;
        }
        public void LoadData(int a_id=0)
        {
            if (a_id == 0)
            {
                dgvBook.DataSource = Book_BLL.Instance.GetListB_BLL();
            }
            else
            {
                dgvBook.DataSource = Book_BLL.Instance.GetListBbyID_BLL(a_id);
            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.d = new Form2.MyDel(this.LoadData);
            f.ShowDialog();
        }

        private void cbbTG_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = ((CBBItem)cbbTG.SelectedItem).Value;
            LoadData(id);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int b_id = Convert.ToInt32(dgvBook.SelectedCells[0].OwningRow.Cells["B_ID"].Value);
            Book_BLL.Instance.DelBBLL(Book_BLL.Instance.GetBbyID_BLL(b_id));
           
            LoadData(((CBBItem)cbbTG.SelectedItem).Value);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            switch (cbbSort.SelectedIndex)
            {
                case 0:
                    dgvBook.DataSource = Book_BLL.Instance.SortBookDownBLL();
                    break;
                case 1:
                    dgvBook.DataSource = Book_BLL.Instance.SortBookUpBLL();
                    break;
                case 2:
                    dgvBook.DataSource = Book_BLL.Instance.SortBookNameDownBLL();
                    break;
                case 3:
                    dgvBook.DataSource = Book_BLL.Instance.SortBookNameUpBLL();
                    break;
                default:
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvBook.DataSource = Book_BLL.Instance.SearchBookIDBLL(Convert.ToInt32(txbSearch.Text));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int b_id = Convert.ToInt32(dgvBook.CurrentRow.Cells[0].Value);
            Form2 f = new Form2(b_id);
            f.d = new Form2.MyDel(LoadData);
            f.ShowDialog();
        }
    }
}
