using System.Globalization;
using Entities;


namespace Banco.Entities
{
    public class SavingsAccount
    {
        private double _balanceSa;
        private int _count = 3;
        private List<string> _extrato = new List<string>();
        private Custumer _custumer;
        private DateTime _date = DateTime.UtcNow;
        private HashSet<Pasta> _past = new HashSet<Pasta>();
        


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
                _extrato.Add($"Saque realizado de R${amount.ToString("F2",CultureInfo.InvariantCulture)}\nHorario: {_date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")}");
                Console.WriteLine("Saque realizado ");
                _count--;
            }               
        }

        public void Deposit(double amount)
        {
            _extrato.Add($"Depósito realizado de R${amount.ToString("F2",CultureInfo.InvariantCulture)}\nHorario: {_date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")}");
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
                _extrato.Add($"R${value.ToString("F2",CultureInfo.InvariantCulture)} investidos para {obj}\nHorario: {_date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")}");
           }                   
        }


        public void AddLista(Pasta past)
        {
            if(_past.Contains(past))
            {
                Console.WriteLine("Esse Objetivo já foi registrado");
            }
            else
            {
                _past.Add(past);
                Console.WriteLine("Objetivo registrado");
            }
        }


        public void Print()
        {
            foreach(Pasta past in _past)
            {
               Console.WriteLine( $"Objetivo: {past.Obj} - Valor Reservado: R${past.Value.ToString("F2",CultureInfo.InvariantCulture)} - Faltam: R${past.Total.ToString("F2",CultureInfo.InvariantCulture)}");           
            }        
        }

        public void AtualizarReserva(Pasta pasta,double atualizacao)
        {
            if (_past.Contains(pasta))
            {
                var pastaExistente = _past.First(p => p.Equals(pasta));

                if(atualizacao > _balanceSa)
                {
                    Console.WriteLine("Saldo Insuficiente para atualização");
                }
                else
                {
                    pastaExistente.Value += atualizacao;
                    _balanceSa -= atualizacao;
                    _extrato.Add($"Acréscimo de R${atualizacao.ToString("F2",CultureInfo.InvariantCulture)} investidos em {pastaExistente.Obj}\nHorario: {_date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss")}");
                    Console.WriteLine("Objetivo Atualizado");
                }
               
            }
            else
            {
                Console.WriteLine("Objetivo não registrado");
            }

        }

    }        
}
