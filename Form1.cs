using System;
using System.Data;
using System.Windows.Forms;

namespace OnlineShoppingApp
{
    public partial class Form1 : Form
    {
        DataSet ds;
        DataView dv;

        public Form1()
        {
            InitializeComponent();
        }

        // ✅ FORM LOAD (Designer isi ko call kar raha hai)
        private void Form1_Load_1(object sender, EventArgs e)
        {
            comboCategory.Items.Clear();
            comboCategory.Items.Add("Mobile");
            comboCategory.Items.Add("Laptop");
            comboCategory.Items.Add("Music");
        }

        // ✅ BUTTON CLICK (Load Products)
        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            ds = DBHelper.GetProducts();   // DB call
            dv = new DataView(ds.Tables["Products"]);
            dataGridView1.DataSource = dv;
        }

        // ✅ COMBOBOX CHANGE (Category Filter)
        private void comboCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (dv != null)
            {
                dv.RowFilter = "Category = '" + comboCategory.Text + "'";
            }
        }
    }
}