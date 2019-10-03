using System.ComponentModel.DataAnnotations.Schema;

namespace evil_librarian.Models
{
    [Table("book_creator")]
    public class BookCreator
    {
        [Column("id_book_cr")]
        public int IdBookCr { get; set; }

        [Column("id_creator_cr")]
        public int IdCreatorCr { get; set; }

    }
}
