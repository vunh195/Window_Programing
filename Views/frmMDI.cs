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
    public partial class frmMDI : Form
    {
        
        List<User> listUser; 
        private int childFormNumber = 0;
        Form1 form1;
       
        frmCollection frmcollection;

        public frmMDI(ref List<User> listuser)
        {
            this.listUser = listuser;
            InitializeComponent();
        }

        private void reaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( this.form1 is null || this.form1.IsDisposed)
            {
                this.form1 = new Form1(ref this.listUser);
                

                this.form1.MdiParent = this;
                this.form1.Show();
            }
            else
            {
                this.form1.Select();
            }
        }


       

        private void readDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabMain.Visible = true;
            if (this.form1 is null || this.form1.IsDisposed)
            {
                this.form1 = new Form1(ref this.listUser);
               
                this.form1.MdiParent = this;
                this.form1.Show();
            }
            else
            {
                this.form1.Select();
            }
        }

        private void yourCollectionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (this.frmcollection is null || this.frmcollection.IsDisposed)
            {
                this.frmcollection = new frmCollection(ref this.listUser);
                this.frmcollection.MdiParent = this;
                this.frmcollection.Show();
            }
            else
            {
                this.frmcollection.Select();
            }
        }
        private void frmMDI_MdiChildActivate(object sender, EventArgs e)
        {
            this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
            if (this.ActiveMdiChild.Tag == null)
            {
                TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                tp.Tag = this.ActiveMdiChild;
                tp.Parent = this.tabMain;
                this.tabMain.SelectedTab = tp;
                this.ActiveMdiChild.Tag = tp;
                this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;
            }
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();

        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabMain.SelectedTab != null && this.tabMain.SelectedTab.Tag != null)
            {
                (this.tabMain.SelectedTab.Tag as Form).Select();
            }
        }

        private void frmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.listUser.Clear();
        }
    }
}
