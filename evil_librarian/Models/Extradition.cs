using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("extradition")]
public class Extradition
{

    [Key]
    [Column("id_book_ex")]
    public int IdBookEx { get; set; }

    [Column("id_reader_ex")]
    public int IdReaderEx { get; set; }

    [Column("date_extradition")]
    [DataType(DataType.DateTime)]
    [Required]
    public DateTime DateExtradition { get; set; }

    [Column("date_return")]
    [DataType(DataType.DateTime)]
    [Required]
    public DateTime DateReturn { get; set; }

}
