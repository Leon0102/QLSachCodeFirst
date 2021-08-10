using QLSach.DAL;
using QLSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.BLL
{
    public class Author_BLL
    {
        private static Author_BLL _instance = null;
        public static Author_BLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Author_BLL();
                }
                return _instance;
            }
        }
        private Author_BLL()
        {
        }
        public List<Author> GetListA_BLL()
        {
            return Author_DAL.Instance.GetListAuthor();
        }
    }
}
