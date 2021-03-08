using System;

namespace DrugCompensation.Api.CompensationTypes
{
    public class SpecialFund : ICompensationTypeCalculator
    {
        public Entities.Type Type { get; private set; }


        public SpecialFund()
        {
            Type = Entities.Type.SpecialFund;
        }


        public double Calculate(int q, double r, double b, double c, double d)
        {
            if (d >= 50) d = 49;
            else if (d <= 0) d = 1;

            return Math.Round(q * r * (1 - (d/100)) * (1 - (c/100)), 2);
        }
    }
}
