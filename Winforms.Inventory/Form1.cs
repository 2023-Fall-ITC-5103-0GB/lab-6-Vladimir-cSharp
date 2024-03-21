using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms.Inventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lstBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBox.SelectedItem != null)
            {
                InventoryItem selectedItem = (InventoryItem)lstBox.SelectedItem;
                txtSelectedItem.Text = selectedItem.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2();
            addForm.ShowDialog();
            lstBox.DataSource = null;
            lstBox.DataSource = InventoryDB.GetItems();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstBox.SelectedItem != null)
            {
                InventoryItem selectedItem = (InventoryItem)lstBox.SelectedItem;
                if (MessageBox.Show($"Are you sure you want to delete {selectedItem}?", "Delete item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    InventoryDB.SaveItems(InventoryDB.GetItems().Where(item => item.ItemNo != selectedItem.ItemNo).ToList());
                    lstBox.DataSource = InventoryDB.GetItems();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstBox.DataSource = InventoryDB.GetItems();
        }
    }
}
