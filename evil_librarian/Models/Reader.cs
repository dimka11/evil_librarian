using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evil_librarian.Models
{
    [Table("reader")]
    public class Reader
    {

        public string Surname { get; set; }

        [Column("name_")]
        public string Name { get; set; }


        public string Patronimic { get; set; }


        [DataType(DataType.DateTime)]
        [Column("Date_Of_Birth")]
        public DateTime DateOfBirth { get; set; }


        public string Passport { get; set; }


        public string Phone { get; set; }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_reader")]
        public int IdReader { get; set; }

    }
}
