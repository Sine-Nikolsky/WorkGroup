using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkGroup.Entities
{
    public class Group : EntityBase
    {

        [MaxLength(100)]
        public string Name { get; set; }

        public virtual IList<GroupItem> GroupItems  { get; set; }
    }
}
