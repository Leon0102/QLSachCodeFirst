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
        public delegate bool Compare(Book o1, Book o2);
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
        public Book GetBbyID_BLL(string ID)
        {
            return Book_DAL.Instance.GetBookbyID(ID);
        }
        public bool SaveB_BLL(Book b)
        {
            return Book_DAL.Instance.SaveBook(b);
        }
        public bool DelBBLL(Book s)
        {
           return Book_DAL.Instance.DelBook(s);
        }
        public List<Book> SearchBookBLL(int id, string s)
        {
            return Book_DAL.Instance.SearchBookID(id,s);
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
        //public List<Book> SortBookList_BLL(List<Book> blist, Compare cmp)
        //{
        //    for (int i = 0; i < blist.Count - 1; ++i)
        //    {
        //        for (int j = i + 1; j < blist.Count; ++j)
        //        {
        //            if (cmp(blist[i], blist[j]))
        //            {
        //                Book temp = blist[i];
        //                blist[i] = blist[j];
        //                blist[j] = temp;
        //            }
        //        }
        //    }
        //    return blist;
        //}
    }
}
