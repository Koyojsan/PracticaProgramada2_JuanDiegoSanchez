namespace PracticaProgramada2_JuanDiegoSanchez.Models
{
    public class Lista
    {
        public int IdLista { get; set; }
        public int IdUsuario { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public byte[]? Imagen { get; set; }
        public List<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
}
