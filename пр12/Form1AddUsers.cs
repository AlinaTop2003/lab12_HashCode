using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using пр12.ModelEF;

namespace пр12
{
    public partial class Form1AddUsers : Form
    {
        public Form1AddUsers()
        {
            InitializeComponent();
        }
        Model1 model = new Model1();

        void StartLoad()
        {
            dataGridView1.DataSource = model.UsersHash.ToList();
        }
        private void Form1AddUsers_Load(object sender, EventArgs e)
        {
            StartLoad();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (LoginTextBox.Text == ""||
            PasswordTextBox.Text == ""||
            FirstNameTextBox.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            UsersHash usersHash = new UsersHash();
            usersHash.Login = LoginTextBox.Text;
            usersHash.Password = SHA256Builder.ConvertToHash(PasswordTextBox.Text);
            usersHash.FirstName = FirstNameTextBox.Text;
            try
            {
                model.UsersHash.Add(usersHash);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                StartLoad();
            }
            LoginTextBox.Text = "";
            PasswordTextBox.Text = "";
            FirstNameTextBox.Text = "";
            MessageBox.Show("Данные добавлены");
        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            Form2Authorization form2 = new Form2Authorization();
            form2.ShowDialog();
        }
    }
}
