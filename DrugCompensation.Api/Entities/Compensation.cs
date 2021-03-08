using System;

namespace DrugCompensation.Api.Entities
{
    public class Compensation
    {
        /// <summary>
        /// unique compensation identifier
        /// </summary>
        public Guid ID { get; set; }
        //public Guid UniqueID { get; set; }
        public Type Type { get; set; }
        public string DiscountFormula { get; set; }
    }


    public enum Type
    {
        Government,
        HealthInsurance,
        SpecialFund
    }
}
