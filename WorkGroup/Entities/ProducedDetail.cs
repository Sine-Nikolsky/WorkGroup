using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkGroup.Entities
{
    public class ProducedDetail : EntityBase 
    {
        public DateTime ProducedDate { get; set; }
        public virtual Detail Detail { get; set; }
        public virtual Worker Worker { get; set; }
        public int Count { get; set; }

        [NotMapped]
        public string DetailInfo
        {
            get
            {
                return Detail.GroupItem.Name + "   " + "   " + Detail.FullName;
            }
        }

        [NotMapped]
        public double WorkingHour { get
            {
                return Detail.WorkingHour; 
            }
        } 
        [NotMapped]
        public double MultiplyWh {
            get
            {
                double k = Detail.WorkingHour * Count;
                k = Math.Round(k, 4);
                return k;
            }
        }
        [NotMapped]
        public string WorkerName
        {
            get
            {
                return Worker.Name ;
            }
        }
    }
}
