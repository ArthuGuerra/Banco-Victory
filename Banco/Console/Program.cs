using Banco.Entities;
using Banco.Services;

try
{

Console.WriteLine($"Bem vindo ao Seu Banco");
Console.WriteLine($"Nome: ");
string nome = Console.ReadLine();
Console.WriteLine($"");
Console.WriteLine($"Coloque seu melhor Email:");
string email = Console.ReadLine();
Console.WriteLine($"");
Console.WriteLine($"CPF: xxx-xxx-xxx ");
string cpf = Console.ReadLine();

Custumer custumer = new Custumer(nome,email,cpf);

int wl = 0;

while(wl != 3)
{
    Console.WriteLine($"Escolha uma opção");
    Console.WriteLine($"1 - Abrir uma Conta Poupança! ");
    Console.WriteLine($"2 - Abrir uma conta de Investimentos");
    Console.WriteLine($"3 - Sair");
    Console.WriteLine($"");
    wl = int.Parse(Console.ReadLine());
    
    switch (wl)
    {
        case 1:
        Console.WriteLine($"É necessário um depósito para abrir uma conta Poupança");
        Console.WriteLine($"Quanto deseja depositar ? ");
        double balance = double.Parse(Console.ReadLine());
        SavingsAccount sacc = new SavingsAccount(balance,custumer);

        int a = 10;
        while (a != 0)
        {      
        Console.WriteLine($"Escolha uma ação ");        
        Console.WriteLine($"1 - Sacar");
        Console.WriteLine($"2 - Depositar");
        Console.WriteLine($"3 - Extrato");
        Console.WriteLine($"4 - Poupança ");
        Console.WriteLine($"0 - Voltar");

        a = int.Parse(Console.ReadLine());

        switch(a)
        {
            case 1:
            Console.WriteLine("Quanto deseja sacar ? ");
            double saq = double.Parse(Console.ReadLine());
            Console.WriteLine($"");
            sacc.WithDraw(saq);
            Console.ReadLine();
            Console.Clear();
            break;

            case 2:
            Console.WriteLine("Quanto deseja depositar ? ");
            double dep = double.Parse(Console.ReadLine());
            sacc.Deposit(dep);
            Console.WriteLine($"");
            Console.WriteLine("Depósito realizado ");
            Console.ReadLine();
            Console.Clear();          
            break;

            case 3:
            sacc.Extrato();
            Console.ReadLine();
            Console.Clear();         
            break;

            case 4: 
            Console.WriteLine($"Digite a finalidade para o investimento");
            string obj = Console.ReadLine();
            Console.WriteLine($"Quanto deseja guardar ? ");
            double meta = double.Parse(Console.ReadLine());
            sacc.ReservaDeDinheiro(obj,meta);
            Console.WriteLine($"");
            sacc.PrintObjetivo();
            Console.ReadLine();
            Console.Clear();
            break;              
        }
        }
        break;

        case 2:
        Console.WriteLine($"É necessário um depósito para abrir a conta de Investimentos");
        Console.WriteLine($"Quanto deseja depositar ? ");
        double invest = double.Parse(Console.ReadLine());
        InvestmentAccount investAcc = new InvestmentAccount(invest,custumer); 
        
        int z = 10;
        while (z != 0)
        {
        Console.WriteLine($"Escolha uma ação ");
        Console.WriteLine($"1 - Sacar");
        Console.WriteLine($"2 - Depositar");
        Console.WriteLine($"3 - Extrato");
        Console.WriteLine($"4 - Investir Anual ");
        Console.WriteLine($"5 - Investir Mensal ");
        Console.WriteLine($"0 - Voltar ");

        z = int.Parse(Console.ReadLine());

        switch(z)
        {
            case 1:
            Console.WriteLine("Quanto deseja sacar ? ");
            double saq = double.Parse(Console.ReadLine());
            Console.WriteLine($"");
            investAcc.WithDraw(saq);
            Console.ReadLine();
            Console.Clear();
            break;

            case 2:
            Console.WriteLine("Quanto deseja depositar ? ");
            double dep = double.Parse(Console.ReadLine());
            investAcc.Deposit(dep);
            Console.WriteLine($"");
            Console.WriteLine("Depósito realizado ");
            Console.ReadLine();
            Console.Clear();
            break;

            case 3:
            investAcc.Extrato();
            Console.ReadLine();
            Console.Clear();
            break;

            case 4: 
            Console.WriteLine($"Quanto deseja Investir ? ");
            double value = double.Parse(Console.ReadLine());
            Console.WriteLine($"Quantos Anos ? ");
            int years = int.Parse(Console.ReadLine());
            Console.WriteLine($"");
            investAcc.InvestimentServiceAnual(new InvestimentService(),value,years);
            Console.ReadLine();
            Console.Clear();
            break;
            case 5: 
            Console.WriteLine($"Quanto deseja Investir ? ");
            double valueMensal = double.Parse(Console.ReadLine());
            Console.WriteLine($"Quantos Meses ? ");
            int months = int.Parse(Console.ReadLine());
            Console.WriteLine($"");
            investAcc.InvestimentServiceMensal(new InvestimentService(),valueMensal,months);
            Console.ReadLine();
            Console.Clear();
            break;   
        }
        }
        break;

        case 3:
        Console.WriteLine("Obrigado por utilizar nosso banco. Bye");
        break;
    } 
}

}catch(FormatException f)
{
    Console.WriteLine("Erro de formato" + f.Message);
} catch(ArgumentException a)
{
    Console.WriteLine(a.Message);
} catch(Exception e)
{
    Console.WriteLine("Erro Genérico" + e.Message);
}