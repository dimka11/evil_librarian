using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("book_genre")]
public class BookGenre
{
    [Column("id_book_gn")]
    public int IdBookGn { get; set; }

    [Column("id_genre_gn")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdGenreGn { get; set; }

}
