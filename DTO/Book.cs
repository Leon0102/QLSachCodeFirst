using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.DTO
{
    public class Book
    {
        [Key][Required]
        public string B_ID { get; set; }
        public string B_Name { get; set; }
        public DateTime B_PublishDate { get; set; }
        public Boolean B_Status { get; set; }
        public int A_ID { get; set; }

        [ForeignKey("A_ID")]
        public virtual Author Author { get; set; }
         public static bool Compare_NameAZ(Book b1, Book b2)
        {
            if (string.Compare(b1.B_Name, b2.B_Name) > 0)
                return true;
            else
                return false;
        }
        public static bool Compare_NameZA(Book b1, Book b2)
        {
            if (string.Compare(b1.B_Name, b2.B_Name) < 0)
                return true;
            else
                return false;
        }
    }
}
