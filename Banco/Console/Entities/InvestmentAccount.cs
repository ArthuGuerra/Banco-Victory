using System.Globalization;
using Banco.Services;

namespace Banco.Entities
{
    public class InvestmentAccount
    {
       
        private double _balanceInvest;
        private int _count = 5;
        private List<string> _extrato = new List<string>();
        private Custumer _custumer;
        private DateTime _date = DateTime.UtcNow;

        
        public InvestmentAccount(double balanceInvest,Custumer custumer)
        {
            this._balanceInvest = balanceInvest;
            this._custumer = custumer;
        }

        public void WithDraw(double amount)
        {
            if( amount > _balanceInvest)
            {
                Console.WriteLine("Saldo Insuficiente");
            }
            else if (_count <= 0)
            {
                Console.WriteLine("Limite de Saque Diário Atingido. Tente Amanhã.");
            }
            else
            {
                _balanceInvest -= amount + 5;
                _extrato.Add($"Saque realizado de R${amount.ToString("F2",CultureInfo.InvariantCulture)}\nHorario: {_date.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")}");
                Console.WriteLine("Saque realizado ");
                _count--;
            }        
        }

        public void Deposit(double amount)
        {
            _extrato.Add($"Depósito realizado de R${amount.ToString("F2",CultureInfo.InvariantCulture)}\nHorario: {_date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")}");
            _balanceInvest += amount;
        }


       public void InvestimentServiceAnual(IInvestiments invest, double value, int years)
       {
            if(value > _balanceInvest)
            {
                Console.WriteLine("Saldo insuficiente para investimento.");
            }
            else
            {
                _balanceInvest -= value;
                double rendimento = invest.Anual(value,years);   // renda de x anos de investimentos
                double total = value + rendimento;
                _extrato.Add($"Investimento Anual Aprovado de R${value.ToString("F2",CultureInfo.InvariantCulture)}\nHorario: {_date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")}");

                Console.WriteLine($"O rendimento de {years} anos será de R${rendimento.ToString("F2",CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Saldo em {years} anos: R${total.ToString("F2",CultureInfo.InvariantCulture)}");
            }                  
       }

       public void InvestimentServiceMensal(IInvestiments invest, double value, int months)
       {
          if(value > _balanceInvest)
            {
                Console.WriteLine("Saldo insuficiente para investimento.");
            }
            else
            {  
                _balanceInvest -= value;
                double rendimento = invest.Mensal(value,months);    // renda de x anos de investimentos
                double total = value + rendimento;
                _extrato.Add($"Investimento Mensal Aprovado de R${value.ToString("F2",CultureInfo.InvariantCulture)}\nHorario: {_date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")}");

                Console.WriteLine($"O rendimento de {months} meses será de R${rendimento.ToString("F2",CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Valor total em {months} meses será de R${total.ToString("F2",CultureInfo.InvariantCulture)}");
            }          
       }

       public void Extrato()
       {      
            Console.WriteLine("Extrato");
            Console.WriteLine("");
            Console.WriteLine(_custumer.ToString());
            Console.WriteLine("\n");
            foreach(string str in _extrato)
            {
                Console.WriteLine(str);
                Console.WriteLine("\n");
            }
            Console.WriteLine($"Saldo Atual: R${_balanceInvest.ToString("F2",CultureInfo.InvariantCulture)}");
       }
    }
}