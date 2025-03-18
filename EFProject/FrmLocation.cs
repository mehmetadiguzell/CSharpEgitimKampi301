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
    public partial class FrmLocation: Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities(); 
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x=> new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            cbGuide.DisplayMember = "FullName";
            cbGuide.ValueMember = "GuideId";
            cbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capacity = byte.Parse(nmCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.DayNight = txtDayNight.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.GuideId = Convert.ToInt32(cbGuide.SelectedValue);
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Lokasyon Eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var value = db.Location.Find(id);
            db.Location.Remove(value);
            db.SaveChanges();
            MessageBox.Show("Lokasyon Silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var value = db.Location.Find(id);
            value.Capacity = byte.Parse(nmCapacity.Value.ToString());
            value.City = txtCity.Text;
            value.Country = txtCountry.Text;
            value.DayNight = txtDayNight.Text;
            value.Price = decimal.Parse(txtPrice.Text);
            value.GuideId = Convert.ToInt32(cbGuide.SelectedValue);
            db.SaveChanges();
            MessageBox.Show("Lokasyon Güncellendi");
        }
    }
}
