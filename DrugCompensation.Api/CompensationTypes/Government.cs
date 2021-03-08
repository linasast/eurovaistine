using System;

namespace DrugCompensation.Api.CompensationTypes
{
    public class Government : ICompensationTypeCalculator
    {
        public Entities.Type Type { get; private set; }


        public Government()
        {
            Type = Entities.Type.Government;
        }


        public double Calculate(int q, double r, double b, double c, double d)
        {
            if (r < b) r = b;

            return Math.Round(q * (r - b), 2);
        }
    }
}
