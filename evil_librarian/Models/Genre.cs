using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using evil_librarian.Models;

[Table("genre")]
public class Genre
{

    [Column("id_genre")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdGenre { get; set; }

    [Column("title_of_genre")]
    [Required]
    public string TitleOfGenre { get; set; }

    public ICollection<BookGenre> BookGenre { get; set; }

}
