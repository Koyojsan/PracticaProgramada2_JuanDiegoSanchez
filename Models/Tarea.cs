namespace PracticaProgramada2_JuanDiegoSanchez.Models
{
    public class Tarea
    {
        public int IdTarea { get; set; }
        public int IdLista { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public bool Pendiente { get; set; }
        public Lista Listas { get; set; }

    }
}
