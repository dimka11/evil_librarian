using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using evil_librarian.Models;

[Table("extradition")]
public class Extradition
{
    //todo string to datatime field exception if foreighkeys
    [Key]
    //[ForeignKey("Book")]
    [Column("id_book_ex")]
    public int IdBookEx { get; set; }
    //public Book Book { get; set; }

    //[Key]
    //[ForeignKey("Reader")]
    [Column("id_reader_ex")]
    public int IdReaderEx { get; set; }
    //public Reader Reader { get; set; } 

    [Column("date_extradition")]
    [DataType(DataType.DateTime)]
    [Required]
    public DateTime DateExtradition { get; set; }

    [Column("date_return")]
    [DataType(DataType.DateTime)]
    [Required]
    public DateTime DateReturn { get; set; }

}
