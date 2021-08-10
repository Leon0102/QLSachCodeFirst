using QLSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.DAL
{
    class Author_DAL
    {
        private static Author_DAL _instance = null;
        public static Author_DAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Author_DAL();
                }
                return _instance;
            }
        }
        private Author_DAL()
        {
        }
        QLSachCF db = new QLSachCF();
        public List<Author> GetListAuthor()
        {
            List<Author> lsh = new List<Author>();
            var b = db.Authors.Select(s => s);
            lsh = b.ToList();
            return lsh;
        }
    }
}
