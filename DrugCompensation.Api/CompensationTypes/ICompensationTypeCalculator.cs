using DrugCompensation.Api.Entities;

namespace DrugCompensation.Api.CompensationTypes
{
    public interface ICompensationTypeCalculator
    {
        Type Type { get; }
        /// <summary>
        /// todo: should i implement by dynamic formula?!
        /// </summary>
        /// <param name="q">quantity</param>
        /// <param name="r">retail price</param>
        /// <param name="b">basic compensation</param>
        /// <param name="c">compensation percent</param>
        /// <param name="d">discount percent</param>
        /// <returns>p = payable sum</returns>
        double Calculate(int q, double r, double b, double c, double d);
    }
}
