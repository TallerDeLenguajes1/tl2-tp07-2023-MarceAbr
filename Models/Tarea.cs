using System.Reflection.Metadata;

namespace tl2_tp07_2023_MarceAbr.Models
{
    public enum Estado
    {
        Pendiente,
        EnProgreso,
        Completada
    }
    public class Tarea
    {
        private int id;
        private string? titulo;
        private string? descripcion;
        private Estado estado;

        public Tarea(){}

       public int Id { get => id; set => id = value; }
        public string? Titulo { get => titulo; set => titulo = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public Estado Estado { get => estado; set => estado = value; } 
    }
}