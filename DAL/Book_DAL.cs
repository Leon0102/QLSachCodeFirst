using QLSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.DAL
{
    public class Book_DAL
    {
        private static Book_DAL _Instance;
        public static Book_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Book_DAL();
                }
                return _Instance;
            }
            private set { }
        }
        private Book_DAL()
        {
        }
        QLSachCF db = new QLSachCF();
        public List<Book> GetListBooks_DAL()
        {
            List<Book> lsv = new List<Book>();
            var l0 = from p in db.Books
                     select p;
            lsv = l0.ToList();
            return lsv;
        }
        public Book GetBookbyID(int b_id)
        {
            Book s = db.Books.Find(b_id);
            return s;
        }
        public List<Book> GetListBookbyID(int A_ID)
        {
            List<Book> dt = new List<Book>();
            var l1 = db.Books.Select(p => p).Where(p => p.A_ID == A_ID);
            dt = l1.ToList();
            return dt;
        }
        public void DelBook(Book s)
        {
            Book del = db.Books.Where(p => p.B_ID.Equals(s.B_ID)).Select(p => p).SingleOrDefault();
            db.Books.Remove(del);
            db.SaveChanges();
        }
        public bool SaveBook(Book s)
        {
            bool result = false;
            Book _s = db.Books.Where(x => x.B_ID == s.B_ID).Select(x => x).SingleOrDefault();
            if (_s != null)
            {
                // UPDATE
                _s.B_Name = s.B_Name;
                _s.A_ID = s.A_ID;
                _s.B_PublishDate = s.B_PublishDate;
                _s.B_Status = s.B_Status;
            }
            else
            {
                // ADD
                db.Books.Add(s);
            }
            db.SaveChanges();
            result = true;
            return result;
        }
        public List<Book> SortBookDown()
        {
            List<Book> lsv = new List<Book>();
            var l0 = from p in db.Books
                     orderby p.B_ID descending
                     select p;
            lsv = l0.ToList();
            return lsv;
        }
        public List<Book> SortBookUp()
        {
            List<Book> lsv = new List<Book>();
            var l0 = from p in db.Books
                     orderby p.B_ID ascending
                     select p;
            lsv = l0.ToList();
            return lsv;
        }
        public List<Book> SortBookNameUp()
        {
            List<Book> lsv = new List<Book>();
            var l0 = from p in db.Books
                     orderby p.B_Name descending
                     select p;
            lsv = l0.ToList();
            return lsv;
        }
        public List<Book> SortBookNameDown()
        {
            List<Book> lsv = new List<Book>();
            var l0 = from p in db.Books
                     orderby p.B_Name ascending
                     select p;
            lsv = l0.ToList();
            return lsv;
        }
        public List<Book> SearchBookID(int s)
        {
            var l = from p in db.Books
                    where p.B_ID == s
                    select p;
            return l.ToList();
        }
    }
}
