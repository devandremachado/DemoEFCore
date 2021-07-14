namespace DemoEFCore.Domain.Entities
{
    public class Cliente
    {
        public Cliente(string nome, string telefone, string cep, string estado, string cidade, string email)
        {
            Nome = nome;
            Telefone = telefone;
            CEP = cep;
            Estado = estado;
            Cidade = cidade;
            Email = email;
        }
        protected Cliente() { }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string CEP { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public string Email { get; private set; }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }
    }
}
