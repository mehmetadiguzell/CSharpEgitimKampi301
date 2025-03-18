using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFProject
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            
            var values = db.Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.GuideName = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber Eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var value = db.Guide.Find(id);
            db.Guide.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Rehber Silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var value = db.Guide.Find(id);
            value.GuideName = txtName.Text;
            value.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber Güncellendi");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var value = db.Guide.Where(x=>x.GuideId==id).ToList();
            dataGridView1.DataSource = value;
        }
    }
}
