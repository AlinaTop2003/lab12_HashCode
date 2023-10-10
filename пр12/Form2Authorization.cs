using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using пр12.ModelEF;

namespace пр12
{
    public partial class Form2Authorization : Form
    {
        public Form2Authorization()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            Model1 model = new Model1();
            if (model.UsersHash.ToList().Any(x =>
            x.Login == LoginTextBox.Text &&
            x.Password == SHA256Builder.ConvertToHash(PasswordTextBox.Text)))
            {
                MessageBox.Show("Пользователь найден!");
                return;
            }
            MessageBox.Show("Пользователь не найден!");
        }
    }
}
