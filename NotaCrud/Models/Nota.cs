namespace NotaCrud.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string sTitulo { get; set; } = null!; // no permite nulos
        public string? sDescripcion { get; set; }
        public DateTime dFechaCreacion { get; set; }
        public DateTime? dFechaModificacion { get; set; }
        public bool bEstado { get; set; } = true;
    }
}
