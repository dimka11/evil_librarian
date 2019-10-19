using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using evil_librarian.Models;

[Table("book_genre")]
public class BookGenre
{

    [Key]
    [Column("id_genre_gn", Order = 0)]
    [ForeignKey("Book")]
    public int IdGenreGn { get; set; }
    public Book Book { get; set; }

    [Key]
    [ForeignKey("Genre")]
    [Column("id_book_gn", Order = 1)]
    public int IdBookGn { get; set; }
    public Genre Genre { get; set; }

}
