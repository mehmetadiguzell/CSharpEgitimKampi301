using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class FrmCategory: Form
    {
        private readonly ICategoryService _categoryservice;
        public FrmCategory()
        {         
            _categoryservice =new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var result = _categoryservice.TGetAll();
            dgvCategory.DataSource = result;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryStatus = true;
            _categoryservice.TInsert(category);
            MessageBox.Show("Kategori Eklendi");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var deletedCategory = _categoryservice.TGetById(id);
            _categoryservice.TDelete(deletedCategory);
            MessageBox.Show("Kategori Silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            int id = int.Parse(txtCategoryId.Text);
            var updatedCategory = _categoryservice.TGetById(id);
            updatedCategory.CategoryName = txtCategoryName.Text;
            updatedCategory.CategoryStatus = true;
            _categoryservice.TUpdate(updatedCategory);
            MessageBox.Show("Kategori Güncellendi");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var category = _categoryservice.TGetById(id);
            dgvCategory.DataSource = category;
        }
    }
}
