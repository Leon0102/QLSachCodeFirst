using QLSach.BLL;
using QLSach.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSach.GUI
{
    public partial class Form2 : Form
    {
        
        public delegate void MyDel(int id,  string name);
        public MyDel d { get; set; }
        private string BookID;
        public Form2(string ms)
        {
            InitializeComponent();
            SetCBB();
            BookID = ms;
            SetGUI();
        }
        public Form2()
        {
            InitializeComponent();
            SetCBB();
            rbA.Checked = true;
        }
        public void SetCBB(int id =1)
        {
            foreach (Author i in Author_BLL.Instance.GetListA_BLL())
            {
                cbbTG.Items.Add(new CBBItem
                {
                    Value = i.A_ID,
                    Text = i.A_Name,
                });
            }
            cbbTG.SelectedIndex = 1;
        }
        public void SetGUI()
        {
            dtDate.CustomFormat = "MM/dd/yyyy";
            txbMS.Enabled = false;
            Book b = Book_BLL.Instance.GetBbyID_BLL(BookID);
            txbName.Text = b.B_Name;
            txbMS.Text = Convert.ToString(b.B_ID);
            dtDate.Value = b.B_PublishDate;
            if (b.B_Status == true)
            {
                rbA.Checked = true;
            }
            else
            {
                rbU.Checked = true;
            }
            cbbTG.SelectedItem = cbbTG.Items[Convert.ToInt32(b.A_ID) - 1];
            dtDate.Value = b.B_PublishDate;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.B_ID = txbMS.Text;
            b.B_Name = txbName.Text;
            b.A_ID = ((CBBItem)cbbTG.SelectedItem).Value;
            b.B_PublishDate = dtDate.Value;
            b.B_Status = rbA.Checked;
            if (Book_BLL.Instance.SaveB_BLL(b))
            {
                MessageBox.Show("Saved successfully!", "Information", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Failed to save", "Information", MessageBoxButtons.OK);
            }
            d(0,"");
            this.Dispose();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
