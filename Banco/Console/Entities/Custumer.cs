namespace Banco.Entities
{
    public class Custumer
    {
        private string _name;
        private string _email;
        private string _cpf;
        

        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
     

        public Custumer(string name, string email, string cpf)
        {
            _name = name;
            _email = email;
            _cpf = cpf;
        }


        public override string ToString()
        {
            return $"Name: {Name}\nEmail Principal: {Email}\nCPF: {Cpf}";
        }
    }
}