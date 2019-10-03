using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("genre")]
public class Genre
{
    [Column("title_of_genre")]
    public string TitleOfGenre { get; set; }

    [Column("id_genre")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdGenre { get; set; }

}
