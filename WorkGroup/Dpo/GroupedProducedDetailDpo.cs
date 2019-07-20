using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkGroup.Entities
{
    public class GroupedProducedDetailDpo 
    {

        public string Name { get; set; }

        public int Count { get; set; }
        
        public double sumWH { get; set; }
    }
}
