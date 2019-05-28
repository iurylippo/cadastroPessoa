namespace CadastroPessoa.Domain
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public double Idade { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double Imc { get; set; }
    }
}
