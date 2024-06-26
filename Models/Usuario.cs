namespace PracticaProgramada2_JuanDiegoSanchez.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Email { get; set; }
        public required string Contrasena { get; set; }
        public List<Lista>? Listas { get; set; } //Necesitaba ponerla vacia ya que no puedo hacer la lista desde un inicio
    }
}
