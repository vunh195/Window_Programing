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
    public partial class Dangki : Form
    {
        KindleEntities6 kd = new KindleEntities6();
       
        List<Users> lstUsers =new List<Users>();
        Users user;
        public Dangki()
        {
            this.LstUsers = lstUsers;
            InitializeComponent();
        }

        internal List<Users> LstUsers { get => lstUsers; set => lstUsers = value; }

        private void btnCloseDangki_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        public void addUsertoDatabase()
        {
            User us = new User() { USERNAME = txtDangKi.Text, PASSWORD = Convert.ToInt32(txtPassdangki.Text), ID = 1 };
            kd.Users.Add(us);
            kd.SaveChanges();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtPassdangki.Text == txtXNPass.Text)
            {
                addUsertoDatabase();
                user = new Users();
                user.Name = txtDangKi.Text;
                user.Pass = txtPassdangki.Text;
                
                
                
                lstUsers.Add(user);
                MessageBox.Show("Dang ki thanh cong !", "Nguoi dung " + lstUsers.Count.ToString(), MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Mat khau nhap lai khong dung !", "THONG BAO", MessageBoxButtons.OK);
            }
        }

      
    }
}
