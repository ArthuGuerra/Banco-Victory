using System.Globalization;
using System.Collections.Generic;

namespace Banco.Entities
{
    public class SavingsAccount
    {
        private double _balanceSa;
        private int _count = 3;
        private List<string> _extrato = new List<string>();
        private Custumer _custumer;
        private Dictionary<string,double> objetivo = new Dictionary<string,double>();


        public SavingsAccount(double balanceSa,Custumer custumer)
        {
            this._balanceSa = balanceSa;   
            this._custumer = custumer;             
        }


      public void WithDraw(double amount)
        {
            if( amount > _balanceSa)
            {
                Console.WriteLine("Saldo Insuficiente");
            }
            else if (_count <= 0)
            {
                Console.WriteLine("Limite de Saque Diário Atingido. Tente Amanhã.");
            }
            else
            {
                _balanceSa -= amount;
                _extrato.Add($"Saque realizado de R${amount.ToString("F2",CultureInfo.InvariantCulture)}");
                Console.WriteLine("Saque realizado ");
                _count--;
            }               
        }

        public void Deposit(double amount)
        {
            _extrato.Add($"Depósito realizado de R${amount.ToString("F2",CultureInfo.InvariantCulture)}");
            _balanceSa += amount;
        }

        public void Extrato()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Extrato:");
            Console.WriteLine("");
            Console.WriteLine(_custumer.ToString());
            Console.WriteLine("\n");
            foreach(string str in _extrato)
            {
                Console.WriteLine(str);
                Console.WriteLine("\n"); 
            }
            Console.WriteLine($"Saldo Atual: R${_balanceSa.ToString("F2",CultureInfo.InvariantCulture)}");           
        }

        public void ReservaDeDinheiro(string obj,double value)
        {
           if(value > _balanceSa)
           {
                Console.WriteLine("Saldo Insuficiente para guardar.");
           }
           else
           {
                _balanceSa -= value;
                _extrato.Add($"R${value.ToString("F2",CultureInfo.InvariantCulture)} investidos para {obj}");
                objetivo.Add(obj,value); 
           }                   
        }

         public void PrintObjetivo()
        {
           foreach(KeyValuePair<string,double> item in objetivo)
           {
                Console.WriteLine($"Item: {item.Key} - {item.Value.ToString("F2",CultureInfo.InvariantCulture)}");
           }
        }
    }
}