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
        public int B_ID { get; set; }
        public string B_Name { get; set; }
        public DateTime B_PublishDate { get; set; }
        public Boolean B_Status { get; set; }
        public int A_ID { get; set; }

        [ForeignKey("A_ID")]
        public virtual Author Author { get; set; }
    }
}
