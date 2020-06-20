using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using Microsoft.Office.Interop.Word;
using Kindle.Controllers;
using System.Drawing.Imaging;
using Org.BouncyCastle.Bcpg;

namespace Kindle.Views
{
    public partial class frmCollection : Form
    {
       
        KindleEntities6 kd = new KindleEntities6();
        DrawItem drawNote = new DrawItem();
        private int ID;
        private Bitmap bitmapNote;
        private Bitmap bmNew;
        private Bitmap bmOld;
        List<User> listUser;
        
        //List<User> listuser;
        public frmCollection(ref List<User> listuser)
        {
            InitializeComponent();
            bitmapNote = new Bitmap(this.picNote.ClientSize.Width, this.picNote.ClientSize.Height, this.picNote.CreateGraphics());
            bmNew = new Bitmap(this.picNote.ClientSize.Width, this.ClientSize.Height, this.picNote.CreateGraphics());
            bmOld = new Bitmap(this.picNote.ClientSize.Width, this.ClientSize.Height, this.picNote.CreateGraphics());
            this.listUser = listuser;
            Controller cl = new Controller();
            dataGridView2.DataSource = cl.LoadFile(listUser[0].ID);

            dataGridView2.ClearSelection();
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            Controller cl = new Controller();
            int i = listUser[0].ID;
            dataGridView2.DataSource = cl.LoadFile(i);
        }

        private void btnOKEdit_Click(object sender, EventArgs e)
        {

            Controller cl = new Controller();
            int id = Convert.ToInt32(dataGridView2.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            string s = string.Format("C:/Users/vu/source/repos/Window_programing/Kindle/Kindle/bin/Debug/{0}.jpg", id);
            cl.Edit(id, txtNameFromDtg.Text, txtFromDatagrid.Text, s);
            dataGridView2.DataSource = cl.LoadFile(listUser[0].ID);
            MessageBox.Show("Update thanh cong");
        }



        private void btndelete_Click(object sender, EventArgs e)
        {
            string s = dataGridView2.SelectedCells[0].OwningRow.Cells["Name"].Value.ToString();

            Controller cl = new Controller();
            cl.delete(s);

            MessageBox.Show("Xoa document thanh cong ! Hay Bam Nut (Load) de xem ket qua ");
            dataGridView2.DataSource = cl.LoadFile(listUser[0].ID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //frmmdi = new frmMDI(ref lstu);
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pnlAddDoc.Visible == false)
            {
                pnlAddDoc.Visible = true;
            }
            else
            {
                pnlAddDoc.Visible = false;
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            Controller cl = new Controller();
            if (txtAddDoc.Text == "" || txtAddLinkDOc.Text == "")
            {
                MessageBox.Show("Vui long dien thong tin day du !");
                return;

            }
            //bitmapNote.Save(string.Format("{0}.png", listUser[0].ID));
            string s = "";

            cl.Add(txtAddLinkDOc.Text, txtAddDoc.Text, s, (Convert.ToInt32(listUser[0].ID)));
            dataGridView2.DataSource = cl.LoadFile(listUser[0].ID);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            var rs = from c in kd.Users select new { Username = c.USERNAME, ID_User = c.ID };

            dtgUsers.DataSource = rs.ToList();
        }

        private void frmCollection_Load(object sender, EventArgs e)
        {

            ID = 1;
            drawNote = new DrawItem();
        }

        private void picNote_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawNote.IsDraw)
            {
                Graphics G = this.picNote.CreateGraphics();
                G.DrawLine(drawNote.pen, drawNote.X, drawNote.Y, e.X, e.Y);
                using (Graphics gr = Graphics.FromImage(bitmapNote))
                {
                    gr.DrawLine(drawNote.pen, drawNote.X, drawNote.Y, e.X, e.Y);
                }
                drawNote.X = e.X;
                drawNote.Y = e.Y;

            }
        }

        private void picNote_MouseUp(object sender, MouseEventArgs e)
        {
            drawNote.IsDraw = false;
        }

        private void picNote_MouseDown(object sender, MouseEventArgs e)
        {
            drawNote.IsDraw = true;
            drawNote.X = e.X;
            drawNote.Y = e.Y;

        }
        private void picruteNote_Resize(object sender, EventArgs e)
        {
            if (bitmapNote is null) return;
            bitmapNote.Dispose();
            this.picNote.CreateGraphics().Clear(Color.White);
            bitmapNote = new Bitmap(this.picNote.ClientSize.Width, this.picNote.ClientSize.Height, this.picNote.CreateGraphics());


        }
        private void button8_Click(object sender, EventArgs e)
        {
            //Application ap = new Application();
            //Documents document = ap
        }

    

        private void btnOpenfile_Click(object sender, EventArgs e)
        {
            if(txtFromDatagrid.Text.Contains(".doc"))
            { 
            //form1 = new Form1(ref listUser);
            string path = txtFromDatagrid.Text;
            object readOnly = false;
            object visible = true;
            object save = false;
            object fileName = path;
            object newTemplate = false;
            object docType = 0;
            object missing = Type.Missing;
            //Microsoft.Office.Interop.Word._Document document;
            Microsoft.Office.Interop.Word._Application application = new Microsoft.Office.Interop.Word.Application();
            {
                Visible = true;
            }
            application.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing,
                     ref missing, ref missing, ref missing, ref missing,
                     ref visible, ref missing, ref missing, ref missing, ref missing);
            }
            if (txtFromDatagrid.Text.Contains(".pdf"))
            {
                Process.Start(txtFromDatagrid.Text);
            }
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            this.picNote.CreateGraphics().Clear(Color.White);
            bitmapNote = new Bitmap(this.picNote.ClientSize.Width, this.picNote.ClientSize.Height, this.picNote.CreateGraphics());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Controller cl = new Controller();
            int id = Convert.ToInt32(dataGridView2.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            string link = dataGridView2.SelectedCells[0].OwningRow.Cells["NOTE"].Value.ToString();
            if (!link.Contains("0.jpg"))
            {
                string s = string.Format("C:/Users/vu/source/repos/Window_programing/Kindle/Kindle/bin/Debug/{0}.jpg", id);
                string s2 = string.Format("C:/Users/vu/source/repos/Window_programing/Kindle/Kindle/bin/Debug/{0}(1).jpg", id);
                if (File.Exists(s))
                {
                    if (File.Exists(s2))
                    {
                        File.Delete(s2);
                        bitmapNote.Save(string.Format("{0}(1).jpg", id));

                        bitmapNote.Dispose();
                        bitmapNote = new Bitmap(this.picNote.ClientSize.Width, this.picNote.ClientSize.Height, this.picNote.CreateGraphics());
                    }
                    else
                    {
                        bitmapNote.Save(string.Format("{0}(1).jpg", id));

                        bitmapNote.Dispose();
                        bitmapNote = new Bitmap(this.picNote.ClientSize.Width, this.picNote.ClientSize.Height, this.picNote.CreateGraphics());
                    }
                }
                else
                {
                    bitmapNote.Save(string.Format("{0}.jpg", id));
                    bitmapNote.Dispose();
                    bitmapNote = new Bitmap(this.picNote.ClientSize.Width, this.picNote.ClientSize.Height, this.picNote.CreateGraphics());
                }
                using (FileStream fst = new FileStream(s2, FileMode.Open))
                {
                    bmNew = (Bitmap)System.Drawing.Image.FromStream(fst);
                    fst.Close();

                }
                using (FileStream fst2 = new FileStream(s, FileMode.Open))
                {
                    bmOld = (Bitmap)System.Drawing.Image.FromStream(fst2);
                    fst2.Close();

                }
                Graphics g = Graphics.FromImage(bmOld);
                g.DrawImage(bmNew, 0, 0, bmOld.Size.Width, bmOld.Size.Height);
                g.Dispose();
                if (File.Exists(s))
                {
                    File.Delete(s);
                    bmOld.Save(string.Format("{0}.jpg", id));
                    bitmapNote = new Bitmap(this.picNote.ClientSize.Width, this.picNote.ClientSize.Height, this.picNote.CreateGraphics());
                }
            }
            else
            {
                string s = string.Format("C:/Users/vu/source/repos/Window_programing/Kindle/Kindle/bin/Debug/0.jpg", id);
                string s2 = string.Format("C:/Users/vu/source/repos/Window_programing/Kindle/Kindle/bin/Debug/{0}.jpg", id);
                if (File.Exists(s))
                {
                    if (File.Exists(s2))
                    {
                        File.Delete(s2);
                        bitmapNote.Save(string.Format("{0}.jpg", id));
                        bitmapNote = new Bitmap(this.picNote.ClientSize.Width, this.picNote.ClientSize.Height, this.picNote.CreateGraphics());
                        bitmapNote.Dispose();
                    }
                    else
                    {
                        bitmapNote.Save(string.Format("{0}.jpg", id));
                        bitmapNote = new Bitmap(this.picNote.ClientSize.Width, this.picNote.ClientSize.Height, this.picNote.CreateGraphics());
                        bitmapNote.Dispose();
                    }
                }
                else
                {
                    bitmapNote.Save(string.Format("{0}.jpg", id));
                    bitmapNote.Dispose();
                }
                using (FileStream fst = new FileStream(s2, FileMode.Open))
                {
                    bmNew = (Bitmap)System.Drawing.Image.FromStream(fst);
                    fst.Close();

                }
                using (FileStream fst2 = new FileStream(s, FileMode.Open))
                {
                    bmOld = (Bitmap)System.Drawing.Image.FromStream(fst2);
                    fst2.Close();

                }
                Graphics g = Graphics.FromImage(bmOld);
                g.DrawImage(bmNew, 0, 0, bmOld.Size.Width, bmOld.Size.Height);
                g.Dispose();
                if (File.Exists(s2))
                {
                    File.Delete(s2);
                    bmNew.Save(string.Format("{0}.jpg", id));
                    bitmapNote = new Bitmap(this.picNote.ClientSize.Width, this.picNote.ClientSize.Height, this.picNote.CreateGraphics());
                }
            }
            string s3 = string.Format("C:/Users/vu/source/repos/Window_programing/Kindle/Kindle/bin/Debug/{0}.jpg", id);
            cl.Edit(id, txtNameFromDtg.Text, txtFromDatagrid.Text, s3);
            dataGridView2.DataSource = cl.LoadFile(listUser[0].ID);
            MessageBox.Show("Update thanh cong ");
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow dtrRow = this.dataGridView2.Rows[e.RowIndex];
                txtFromDatagrid.Text = dtrRow.Cells[2].Value.ToString();
                txtNameFromDtg.Text = dtrRow.Cells[1].Value.ToString();
                string filename = dtrRow.Cells[4].Value.ToString();
                
                using (FileStream file = new FileStream(filename, FileMode.Open))
                {
                    picNote.Image = System.Drawing.Image.FromStream(file);
                    file.Close();
                }

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.picNote.CreateGraphics().Clear(Color.White);
            
            Controller cl = new Controller();
            int id = Convert.ToInt32(dataGridView2.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            string s3 = string.Format("C:/Users/vu/source/repos/Window_programing/Kindle/Kindle/bin/Debug/{0}.jpg", id);
            if(File.Exists(s3))
            {
                File.Delete(s3);
                bitmapNote.Save(string.Format("{0}.jpg",id));
                bitmapNote.Dispose();
                cl.Edit(id, txtNameFromDtg.Text, txtFromDatagrid.Text, s3);
                dataGridView2.DataSource = cl.LoadFile(listUser[0].ID);
                MessageBox.Show("Clear note thanh cong ");
                bitmapNote = new Bitmap(this.picNote.ClientSize.Width, this.picNote.ClientSize.Height, this.picNote.CreateGraphics());
            }
          
        }
    }
    public class DrawItem
    {
        public int x;
        public int y;
        public Color color;
        public Pen pen;
        private bool isDraw;

        public DrawItem()
        {
            color = Color.Black;
            pen = new Pen(this.color, 2);
            isDraw = false;
        }


        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Color Color { get => color; set => color = value; }
        public Pen Pen { get => pen; set => pen = value; }
        public bool IsDraw { get => isDraw; set => isDraw = value; }
    }
}
