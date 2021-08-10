using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.DTO
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        [Key]
        public int A_ID { get; set; }
        [Required]
        public string A_Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public override string ToString()
        {
            return A_Name;
        }
    }
}
