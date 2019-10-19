using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evil_librarian.Models
{
    [Table("book_creator")]
    public class BookCreator
    {
        [Key]
        [ForeignKey("Book")]
        [Column("id_book_cr", Order = 0)]
        public int IdBookCr { get; set; }
        public Book Book { get; set; }

        [Key]
        [ForeignKey("Creator")]
        [Column("id_creator_cr", Order = 1)]
        public int IdCreatorCr { get; set; }
        public Creator Creator { get; set; }
    }
}
