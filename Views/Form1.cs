using iTextSharp.text;
using iTextSharp.text.pdf.parser;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Kindle.Views
{
   
    public partial class Form1 : Form
    {
        private DrawItem drawNote;
        
        DoiPassword doipass;
        private int  iduser ;
        private int iD; 
        KindleEntities6 kd = new KindleEntities6();
       
        List<User> listUser;
        
        

        public int Iduser { get => iduser; set => iduser = value; }
        public int ID { get => iD; set => iD = value; }

        public Form1(ref List<User> listuser)
        {
            
            this.listUser = listuser;
            
            InitializeComponent();
            User us = kd.Users.Find(listUser[0].ID);
            userToolStripMenuItem.Text =  "HI "+ us.USERNAME + "!";
           // this.label2.Text = "WelCom to Kindle! " ;
            this.label7.Text =  "Hi  " + us.USERNAME;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            rtbPDf.Visible = true;
            rtfData.Visible = false;
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "PDF files| *.pdf",ValidateNames= true, Multiselect= false})
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    string filename = ofd.FileName;
                    AddPDF(filename);
                    try
                    {
                        iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(ofd.FileName);
                        StringBuilder sb = new StringBuilder();
                        for ( int i = 1; i < reader.NumberOfPages; i ++)
                        {
                            sb.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        }
                        rtbPDf.Text = sb.ToString();
                        reader.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        public void AddPDF(string s)

        {
            
            string s2 = string.Format("C:/Users/vu/source/repos/Window_programing/Kindle/Kindle/bin/Debug/0.jpg");
            int i = listUser[0].ID;
            Document dcm = new Document() { Name = txtPDFname.Text , LINK = s, ID_Users = i ,NOTE = s2 };
            kd.Documents.Add(dcm);
            kd.SaveChanges();
           
            
        }
        private void btnCloseFile_Click(object sender, EventArgs e)
        {
            rtbPDf.Clear();
            rtfData.Visible = false;
            
        }

        private void btnAddfileCollection_Click(object sender, EventArgs e)
        {
            //AddDoc();
        }
        public void AddUser()
        {
            //User us = new User() { }
        }
        public void AddDoc(string s)
        {
            
            string s2 = string.Format("C:/Users/vu/source/repos/Window_programing/Kindle/Kindle/bin/Debug/0.jpg");
            int i = listUser[0].ID;
           
            Document dcm = new Document() { Name =txtNameOpen.Text, LINK = s, ID_Users = i, NOTE = s2};
            kd.Documents.Add(dcm);
            kd.SaveChanges();
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (pnlWORDPDF.Visible == false)
            {
                pnlWORDPDF.Visible = true;
            }
            else
            {
                pnlWORDPDF.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rtfData.Visible = true;
            rtbPDf.Visible = false;
            if(txtNameOpen.Text == "")
            {
                MessageBox.Show("Vui lap dat ten cho Document");
                return;
            }
            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "Word 97 - 2003 | *doc |Word Document | *.docx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filename = ofd.FileName;

                    AddDoc(filename);
                    object readOnly = false;
                    object visible = true;
                    object save = false;
                    object fileName = ofd.FileName;
                    object newTemplate = false;
                    object docType = 0;
                    object missing = Type.Missing;
                    Microsoft.Office.Interop.Word._Document document;
                    Microsoft.Office.Interop.Word._Application application = new Microsoft.Office.Interop.Word.Application()
                    {
                        Visible = false
                    };
                    rtfData.Visible = true;
                    document = application.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref visible, ref missing, ref missing, ref missing, ref missing);
                    document.ActiveWindow.Selection.WholeStory();
                    document.ActiveWindow.Selection.Copy();
                    IDataObject dataObject = Clipboard.GetDataObject();
                    rtfData.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
                    application.Quit(ref missing, ref missing, ref missing);
                }
            }
        }
        //string path = "C:/txt/text.txt";
      

        private void openDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "Word 97 - 2003 | *doc |Word Document | *.docx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filename = ofd.FileName;

                    AddDoc(filename);
                    object readOnly = false;
                    object visible = true;
                    object save = false;
                    object fileName = ofd.FileName;
                    object newTemplate = false;
                    object docType = 0;
                    object missing = Type.Missing;
                    Microsoft.Office.Interop.Word._Document document;
                    Microsoft.Office.Interop.Word._Application application = new Microsoft.Office.Interop.Word.Application()
                    {
                        Visible = false
                    };

                    document = application.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref visible, ref missing, ref missing, ref missing, ref missing);
                    document.ActiveWindow.Selection.WholeStory();
                    document.ActiveWindow.Selection.Copy();
                    IDataObject dataObject = Clipboard.GetDataObject();
                    rtfData.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
                    application.Quit(ref missing, ref missing, ref missing);
                }
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if(doipass is null || doipass.IsDisposed)
            {
                this.doipass = new DoiPassword();
                this.doipass.Show();
            }
            else
            {
                doipass.Select();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pnlOpenName.Visible == false)
            {
                pnlOpenName.Visible = true;
            }
            else
            {
                pnlOpenName.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pnlPDFname.Visible == false)
            {
                pnlPDFname.Visible = true;
            }
            else
            {
                pnlPDFname.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rtfData.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ID = 1;
            drawNote = new DrawItem();
        }
       

    }
    
}
