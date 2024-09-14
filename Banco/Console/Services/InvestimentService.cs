namespace Banco.Services
{
    public class InvestimentService : IInvestiments
    {
           public double Anual(double value,int years)
        {
            double duration = years * 0.16;
            value = value * duration;
            return value;         // 16% do valor que serão add no saldo
        }

        public double Mensal(double value,int duration)
        {    
            double acrescimo = duration * 0.01;
            value = value * acrescimo;
            return value; 
        }
    }
}