using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kindle.Views

{
    public partial class frmLogin : Form
    {
       
        frmMDI frmmdi;
        Dangki frmdangki;
        KindleEntities6 kd = new KindleEntities6();
        Form1 form1;
        private int idlogin =0 ;
        List<User> listuser;
       

        public int Idlogin { get => idlogin; set => idlogin = value; }
        private string tendn;
        private string pass;
        public frmLogin()
        {
            listuser = new List<User>();
            InitializeComponent();
            
            this.Idlogin = idlogin;
           
            

        }
        public void swap(ref int id)
        {
            id = this.Idlogin;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (this.frmdangki is null || this.frmdangki.IsDisposed)
            {
                this.frmdangki = new Dangki();
                this.frmdangki.Show();
            }
            else
            {
                this.frmdangki.Select();
            }
        }
        public void Dangnhap(ref int id, ref string tdn, ref string pas)
        {
            
            tdn = txtTendn.Text;
            pas = txtPass.Text;
            int count = kd.Users.Count();
            int k = 0;
            for (int i = 1; i <= count; i++)
            {

                User us = kd.Users.Find(i);
               
                if (us.USERNAME == txtTendn.Text && us.PASSWORD.ToString() == txtPass.Text)
                {
                    listuser.Add(us);
                  
                    if (this.frmmdi is null || this.frmmdi.IsDisposed)
                    {
                        this.frmmdi = new frmMDI(ref listuser);
                        this.frmmdi.Show();
                        k = 1;
                        

                        return;
                    }
                    else
                    {
                        this.frmmdi.Select();
                    }
                }

            }

            if (k == 0)
            {
                MessageBox.Show("Ten Nguoi Dung va Mat Khau khong dung !", "THONG BAO", MessageBoxButtons.OK);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            Dangnhap(ref idlogin, ref tendn, ref pass);
            

        }
     
        private void btnExitLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
