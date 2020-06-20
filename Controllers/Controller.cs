using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kindle.Views;

namespace Kindle.Controllers
{
    class Controller
    {
        KindleEntities6 kd = new KindleEntities6();
        

        public List<Document> LoadFile(int i)
        {

            var result = from c in kd.Documents where c.ID_Users == i select c;
            return result.ToList();
            
        }
        public void LoadUser()
        {
            var rs = from c in kd.Users select new { Username = c.USERNAME, ID_User = c.ID };
           // return rs.ToList();
        }
        public void delete(string s)
            {
                Document dcm = kd.Documents.Where(p => p.Name == s).FirstOrDefault();
                kd.Documents.Remove(dcm);
                kd.SaveChanges();
            }

        public void Add(string s, string s2, string s3, int i)
        {
            Document dcm = new Document() { LINK = s, Name = s2, ID_Users = i, NOTE  = s3};

            kd.Documents.Add(dcm);
            kd.SaveChanges();
        }
        public void Edit(int i , string s1, string s2, string s3)
        {
            Document dcm = kd.Documents.Find(i);
            dcm.Name = s1;
            dcm.LINK = s2;
            dcm.NOTE = s3;
            kd.SaveChanges();
        }
       
        
    }
}
