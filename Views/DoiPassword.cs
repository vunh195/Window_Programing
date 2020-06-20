using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kindle.Views

{
    public partial class DoiPassword : Form
    {
        List<User> listuser;

        KindleEntities6 kd = new KindleEntities6();
        Form1 form1;
        private int iduser;
        public DoiPassword()
        {
            InitializeComponent();
        }

       

        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            form1 = new Form1(ref listuser);

            User us = kd.Users.Find(1);
            if (txtPass.Text == "" || txtRePass.Text == "")
            {
                MessageBox.Show("Vui long nhap mat khau !");  
            }
            if (txtPass.Text != "" || txtRePass.Text != "")
            {
                if (txtPass.Text == txtRePass.Text)
                {
                    int id = Convert.ToInt32(this.txtPass.Text);
                    us.PASSWORD = id;
                    kd.SaveChanges();
                    MessageBox.Show("Doi mat khau thanh cong");
                }
                else
                {
                    MessageBox.Show("Xac nhan mat khau khong dung !");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
