using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evil_librarian.Models
{
    [Table("Workers")]
    class Worker
    {
        public int IDCompany { get; set; }
        public int IDCustomer { get; set; }
    }
}
