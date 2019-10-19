using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using evil_librarian.Models;

[Table("creator")]
public class Creator
{

    [Column("id_creator")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCreator { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Address { get; set; }

    public virtual ICollection<BookCreator> BookCreator { get; set; }
}
