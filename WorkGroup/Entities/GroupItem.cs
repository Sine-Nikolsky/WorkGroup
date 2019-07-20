namespace WorkGroup.Entities
{
    public class GroupItem : EntityBase
    {
        public virtual Group Group { get; set; }
        
        public string Name { get; set; } 
    }
}
