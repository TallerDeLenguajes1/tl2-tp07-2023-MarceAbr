using System.Text.Json;

namespace tl2_tp07_2023_MarceAbr.Models
{
    public class AccesoADatos
    {
        public List<Tarea> LeerTarea()
        {
            string? tareaJSON = File.ReadAllText("Tareas.json");
            List<Tarea>? listaTareas = JsonSerializer.Deserialize<List<Tarea>>(tareaJSON);

            if (listaTareas != null)
            {
                return listaTareas;
            } else {
                return null;
            }
        }

        public bool Guardar(List<Tarea> tarea)
        {
            string listaTarea = JsonSerializer.Serialize(tarea);
            File.WriteAllText("Tareas.json", listaTarea);

            if (listaTarea != null)
            {
                return true;
            } else {
                return false;
            }
        }
    }
}