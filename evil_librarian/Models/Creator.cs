using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("creator")]
public class Creator
{

    public string Title { get; set; }


    public string Address { get; set; }

    [Column("id_creator")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCreator { get; set; }

}
