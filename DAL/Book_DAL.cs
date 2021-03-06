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
        //public List<Book> GetListBooks_DAL()
        //{
        //    List<Book> lsv = new List<Book>();
        //    var l0 = from p in db.Books
        //             select p;
        //    lsv = l0.ToList();
        //    return lsv;
        //}

        //public List<Book> GetListBookbyID(int A_ID)
        //{
        //    List<Book> dt = new List<Book>();
        //    var l1 = db.Books.Select(p => p).Where(p => p.A_ID == A_ID);
        //    dt = l1.ToList();
        //    return dt;
        //}
        public Book GetBookbyID(string b_id)
        {
            Book s = db.Books.Find(b_id);
            return s;
        }
        public bool DelBook(Book s)
        {
            bool result = false;
            try
            {
                Book del = db.Books.Where(p => p.B_ID.Equals(s.B_ID)).Select(p => p).SingleOrDefault();
                db.Books.Remove(del);
            }
            catch (Exception)
            {
                return result;
            }
            finally
            {
                db.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool SaveBook(Book s)
        {
            bool result = false;
            if (s.B_ID == "") return result;
            else
            {
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
        public List<Book> SearchBookID(int a_id,  string bookname)
        {
            if (a_id == 0)
            {
                var l1 = from p in db.Books
                        where p.B_Name.Contains(bookname)
                        select p;
                return l1.ToList();
            }
            var l = from p in db.Books
                    where p.B_Name.Contains(bookname) && p.Author.A_ID == a_id
                    select p;
                    return l.ToList();
        }
        //public List<Book> SearchBookName(string s)
        //{
        //    var l = from p in db.Books
        //            where p.B_Name == s
        //            select p;
        //    return l.ToList();
        //}
    }
}
