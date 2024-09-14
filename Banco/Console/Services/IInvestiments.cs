namespace Banco.Services
{
    public interface IInvestiments
    {
        public double Mensal (double value, int years);
        public double Anual (double value,int duration);
    } 
}