using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkGroup.Entities
{
    public class Worker : EntityBase
    {
        [MaxLength(150)]
        public string Name { get; set; }

        public int PersonalNumber { get; set; }

        public DateTime? DismissedDate { get; set; } 

        [NotMapped]
        public string FullName
        {
            get
            {
                return Name + "   (" + PersonalNumber + ")";
            }
        }
    }
}
