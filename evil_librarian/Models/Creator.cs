using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

}
