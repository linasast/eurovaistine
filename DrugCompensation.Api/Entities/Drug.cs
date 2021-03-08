namespace DrugCompensation.Api.Entities
{
    public class Drug
    {
        public int ID { get; set; }
        public double RetailPrice { get; set; }
        public double BasicCompensationPrice { get; set; }
        public double CompensationPercent { get; set; }
    }
}
