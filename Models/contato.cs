namespace AgendaApi.Models
{
    public class Contato
    {
        public Guid Id { get; set; }
        public string Nome{ get; set; } = string.Empty; // Evita valores nulos
        public string Telefone { get; set; } = string.Empty; // Evita valores nulos
        public string Email { get; set; } = string.Empty; 
    }
}
