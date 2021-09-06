using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }
        private void SearchProducts(string key)
        {
            dgwProducts.DataSource = _productDal.GetbyName(key);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
                {
                Name = tbxName.Text,
                UnıtPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
                

                }
            );
            LoadProducts();

            MessageBox.Show("added!");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
                {
                    Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                    Name = txtUName.Text,
                    UnıtPrice = Convert.ToDecimal(txtUUnitPrice.Text),
                    StockAmount = Convert.ToInt32(txtUUStockAmount.Text)


                }
            );
            LoadProducts();
            MessageBox.Show("Updated!!");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUName.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            txtUUnitPrice.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            txtUUStockAmount.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
                {
                    Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
                   


                }
            );
            LoadProducts();
            MessageBox.Show("Deleted!!");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(txtSearch.Text);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            _productDal.GetbyId(1);
        }
    }
}
