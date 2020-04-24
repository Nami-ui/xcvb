using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKO
{
    public partial class Info : Form
    {
        Human client;
        public Info(Human client)
        {
            this.client = client;
            InitializeComponent();
            CenterToScreen();
            if (client.id != 0) 
            fill();
            comboBox2.DataSource = DBobgects.Entities.Dep.Select(c => c.NameDep).ToList();
            comboBox1.DataSource = DBobgects.Entities.Position.Select(c => c.NameJob).ToList();
        }

        private void Info_Load(object sender, EventArgs e)
        {

        }

        void fill()
        {
            textBox2.Text = client.Fname.ToString();
            textBox1.Text = client.Mname.ToString();
            textBox3.Text = client.Lname.ToString();
            textBox4.Text = client.Age.ToString();
            comboBox1.Text = DBobgects.Entities.Position.Where(c => c.id == client. Position).Select(c => c.NameJob).ToString() ;
            comboBox2.Text = DBobgects.Entities.Dep.Where(c => c.id == client.DepId).Select(c => c.NameDep).ToString();
        }
        void fillentity()
        {
            client.Fname = textBox2.Text;
            client.Mname = textBox1.Text;
            client.Lname = textBox3.Text;
            client.Age = Convert.ToInt16(textBox4.Text);
            client.DepId = DBobgects.Entities.Dep.Where(c=>c.NameDep == comboBox2.SelectedItem).Select(c=>c.id).FirstOrDefault();
            client.Position = DBobgects.Entities.Position.Where(c => c.NameJob == comboBox1.SelectedItem).Select(c => c.id).FirstOrDefault();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fillentity();
            if (!DBobgects.Entities.Human.ToArray().Contains(client))
            {
                DBobgects.Entities.Human.Add(client);
            }
            DBobgects.Entities.SaveChanges();
        }
    }
}
