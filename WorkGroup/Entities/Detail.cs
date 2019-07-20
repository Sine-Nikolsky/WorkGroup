using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkGroup.Entities
{
    public class Detail : EntityBase
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string Number { get; set; }
        /// <summary>
        /// Нормочасы Детали
        /// </summary>
        public double WorkingHour { get; set; }
        /// <summary>
        /// Применяемость. Кол-во деталей на одну машину
        /// </summary>
        public int Applicability { get; set; } 

        public virtual GroupItem GroupItem { get; set; }

        [NotMapped]
        public string FullName {
            get
            {
                return Number + "  -  " + "\"" + Name + "\"";
            } }
    }
}
