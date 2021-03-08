using System;
using System.ComponentModel.DataAnnotations;

namespace DrugCompensation.Api.Entities
{
    public class CompensationRecord
    {
        [Key]
        public int ID { get; set; }
        public DateTime CreateTime { get; set; }
        public virtual Drug Drug { get; set; }
        public double PayableSum { get; set; }
        public virtual Compensation CompensationType { get; set; }
    }
}
