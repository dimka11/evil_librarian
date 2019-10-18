using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evil_librarian.Models
{
    [Table("book")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_book")]
        public int IdBook { get; set; }

        [Required]
        public string Autor { get; set; }

        [Column("Title_of_book")]
        [Required]
        public string TitleOfBook { get; set; }


        [DataType(DataType.DateTime)]
        [Column("Date_Of_print")]
        [Required]
        public DateTime DateOfPrint { get; set; }


        public int? Quantity { get; set; }


        public int? Price { get; set; }

    }
}
