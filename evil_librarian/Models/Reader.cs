using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evil_librarian.Models
{
    [Table("reader")]
    public class Reader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_reader")]
        public int IdReader { get; set; }

        [Required]
        public string Surname { get; set; }

        [Column("name_")]
        [Required]
        public string Name { get; set; }


        public string Patronimic { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Column("Date_Of_Birth")]
        public DateTime DateOfBirth { get; set; }


        public string Passport { get; set; }


        public string Phone { get; set; }

        //public ICollection<Extradition> Extraditions { get; set; }

    }
}
