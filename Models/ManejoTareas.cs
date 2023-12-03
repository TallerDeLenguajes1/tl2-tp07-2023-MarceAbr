namespace tl2_tp07_2023_MarceAbr.Models
{
    public class ManejoTareas
    {
        private AccesoADatos datos;
        public ManejoTareas(AccesoADatos datos)
        {
            this.datos = datos;
        }

        public bool agregarTarea(Tarea tarea)
        {
            List<Tarea> tareas = datos.LeerTarea();
            tareas.Add(tarea);
            tarea.Id = tareas.Count() + 1;
            bool valor = datos.Guardar(tareas);
            if (valor)
            {
                return true;
            } else {
                return false;
            }
        }

        public Tarea buscarTarea(int id)
        {
            List<Tarea> tareas = datos.LeerTarea();
            Tarea? tarea = tareas.FirstOrDefault(t => t.Id == id);

            if (tarea != null)
            {
                return tarea;
            } else {
                return null;
            }
        }

        public bool actualizarTarea(Tarea modificada)
        {
            List<Tarea> tareas = datos.LeerTarea();
            Tarea? tarea = tareas.FirstOrDefault(t => t.Id == modificada.Id);
            tarea.Titulo = modificada.Titulo;
            tarea.Descripcion = modificada.Descripcion;
            tarea.Estado = modificada.Estado;
            bool valor = datos.Guardar(tareas);

            if (valor)
            {
                return true;
            } else {
                return false;
            }
        }

        public bool eliminarTarea(int id)
        {
            List<Tarea> tareas = datos.LeerTarea();
            Tarea? tarea = tareas.FirstOrDefault(t => t.Id == id);

            bool valor = tareas.Remove(tarea);
            datos.Guardar(tareas);

            if (valor)
            {
                return true;
            } else {
                return false;
            }
        }

        public List<Tarea> getTareas()
        {
            return datos.LeerTarea();
        }

        public List<Tarea> getCompletadas()
        {
            List<Tarea> tareas = datos.LeerTarea();
            List<Tarea>? tareasCompletadas = tareas.FindAll(t => t.Estado == Estado.Completada);

            if (tareasCompletadas != null)
            {
                return tareasCompletadas;
            } else {
                return null;
            }
        }
    }
}