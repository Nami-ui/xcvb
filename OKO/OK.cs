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
    public partial class OK : Form
    {
        public OK()
        {
            InitializeComponent();
            CenterToScreen();
            Fill();
        }

        private void OK_Load(object sender, EventArgs e)
        {

        }
        public void Fill()
        {
            dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = DBobgects.Entities.Human.ToList();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["DepId"].Visible = false;
            dataGridView1.Columns["Position"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete();
        }

        void Delete()
        {
            Human human = (Human)dataGridView1.Rows[dataGridView1.CurrentRow.Index].DataBoundItem;
            if (DBobgects.Entities.Human.Where(c => c.id == human.id).Count() > 0)
            {
                DBobgects.Entities.Human.Remove(human);
                DBobgects.Entities.SaveChanges();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Human human = new Human();
            Info i = new Info(human);
            i.ShowDialog();
            this.Fill();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DBobgects.Entities.SaveChanges();
            Fill();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Human human = (Human)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;
            Info i = new Info(human);
            i.ShowDialog();
            this.Fill();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DBobgects.Entities.CoutOfRecords().FirstOrDefault().ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(DBobgects.Entities.Database.SqlQuery<int>($"use OKO select dbo.Stach({dataGridView1.CurrentRow.Cells[0].Value.ToString()})").FirstOrDefault().ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не выбрана строка");

            }
        }
    }
}
