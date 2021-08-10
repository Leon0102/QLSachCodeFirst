using QLSach.DAL;
using QLSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.BLL
{
    public class Book_BLL
    {
        private static Book_BLL _Instance;
        public static Book_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Book_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private Book_BLL()
        {
        }
        public List<Book> GetListB_BLL()
        {
            return Book_DAL.Instance.GetListBooks_DAL();
        }
        public Book GetBbyID_BLL(int ID)
        {
            return Book_DAL.Instance.GetBookbyID(ID);
        }
        public List<Book> GetListBbyID_BLL(int id)
        {
            return Book_DAL.Instance.GetListBookbyID(id);
        }
        public bool SaveB_BLL(Book b)
        {
            return Book_DAL.Instance.SaveBook(b);
        }
        public void DelBBLL(Book s)
        {
            Book_DAL.Instance.DelBook(s);
        }
        public List<Book> SearchBookIDBLL(int s)
        {
            return Book_DAL.Instance.SearchBookID(s);
        }
        public List<Book> SortBookDownBLL()
        {
            return Book_DAL.Instance.SortBookDown();
        }
        public List<Book> SortBookUpBLL()
        {
            return Book_DAL.Instance.SortBookUp();
        }
        public List<Book> SortBookNameUpBLL()
        {
            return Book_DAL.Instance.SortBookNameUp();
        }
        public List<Book> SortBookNameDownBLL()
        {
            return Book_DAL.Instance.SortBookNameDown();
        }

    }
}
