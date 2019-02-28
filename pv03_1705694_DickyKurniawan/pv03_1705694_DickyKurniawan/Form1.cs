using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pv03_1705694_DickyKurniawan.Model;
using pv03_1705694_DickyKurniawan.Repository;

namespace pv03_1705694_DickyKurniawan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {


            TodoRepository todo = new TodoRepository();
            
            string nim = tbNim.Text;
            btnAdd.Enabled = true;
            
            if(todo.validasi(nim) == 1)
            {
                dataGridView1.DataSource = todo.getByNim(nim);
                tbNim.Enabled = false;
                btnOk.Enabled = false;
            }
            else
            {
                MessageBox.Show("Data tidak ada");
            }

            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Todo temp = new Todo();

            temp.NimMhs = tbNim.Text;
            temp.Nama = tbNama.Text;
            temp.Kategori = tbKategori.Text;

            TodoRepository todo = new TodoRepository();

            todo.addTodo(temp);

            string nim = tbNim.Text;

            dataGridView1.DataSource = todo.getByNim(nim);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Todo temp = new Todo();

            temp.Id = Convert.ToInt32(txtIdDel.Text);

            TodoRepository todo = new TodoRepository();

            todo.delTodo(temp);

            string nim = tbNim.Text;

            dataGridView1.DataSource = todo.getByNim(nim);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            Todo temp = new Todo();

            temp.Id = Convert.ToInt32(txtIdUpdate.Text);
            temp.Nama = txtNamaUpdate.Text;
            temp.Kategori = txtKategoriUpdate.Text;
            btnUpdate.Enabled = false;
            txtIdUpdate.Enabled = false;
            TodoRepository todo = new TodoRepository();

            todo.updateTodo(temp);

            string nim = tbNim.Text;

            dataGridView1.DataSource = todo.getByNim(nim);
        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dataGridView1.Rows[ind];
            txtIdDel.Text = selectedRows.Cells[0].Value.ToString();
            txtIdUpdate.Text = selectedRows.Cells[0].Value.ToString();

            txtIdUpdate.Enabled = false;
        }
    }
}
