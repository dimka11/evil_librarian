using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evil_librarian.Models
{
    [Table("reader")]
    public class Reader
    {

        public string Surname { get; set; }


        public string Name_ { get; set; }


        public string Patronimic { get; set; }

        //[DataType(DataType.DateTime)]
        //public DateTime? Date_Of_Birth { get; set; }
        public string Date_Of_Birth { get; set; }


        public int Passport { get; set; }


        public int Phone { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Reader { get; set; }

    }
}
