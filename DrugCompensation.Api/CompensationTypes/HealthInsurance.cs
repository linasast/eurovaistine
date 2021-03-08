using System;

namespace DrugCompensation.Api.CompensationTypes
{
    public class HealthInsurance : ICompensationTypeCalculator
    {
        public Entities.Type Type { get; private set; }


        public HealthInsurance()
        {
            Type = Entities.Type.HealthInsurance;
        }


        public double Calculate(int q, double r, double b, double c, double d)
        {
            return Math.Round(q * r * (1 - (c/100)), 2);
        }
    }
}
