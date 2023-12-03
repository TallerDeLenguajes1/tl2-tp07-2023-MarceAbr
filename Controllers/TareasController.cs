using Microsoft.AspNetCore.Mvc;
using tl2_tp07_2023_MarceAbr.Models;

namespace tl2_tp07_2023_MarceAbr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly ILogger<TareasController> _logger;
        private ManejoTareas manejoTareas;

        public TareasController(ILogger<TareasController> logger)
        {
            _logger = logger;
            AccesoADatos datos = new AccesoADatos();
            manejoTareas = new ManejoTareas(datos);
        }

        [HttpPost("Crear_Tarea")]
        public ActionResult<Tarea> CrearTarea(Tarea tarea)
        {
            bool valor = manejoTareas.agregarTarea(tarea);

            if (valor)
            {
                return Ok(tarea);    
            } else {
                return BadRequest();
            }
        }

        [HttpGet("Obtener_Tarea")]
        public ActionResult<Tarea> ObtenerTarea(int id)
        {
            Tarea tarea = manejoTareas.buscarTarea(id);

            if (tarea != null)
            {
                return Ok(tarea);    
            } else {
                return BadRequest();
            }
        }

        [HttpPut("Actualizar_Tarea")]
        public ActionResult<Tarea> ActualizarTarea(Tarea tarea)
        {
            bool valor = manejoTareas.actualizarTarea(tarea);

            if (valor)
            {
                return Ok(tarea);    
            } else {
                return BadRequest();
            }
        }

        [HttpPost("Eliminar_Tarea")]
        public ActionResult<Tarea> EliminarTarea(int id)
        {
            bool valor = manejoTareas.eliminarTarea(id);

            if (valor)
            {
                return Ok();    
            } else {
                return BadRequest();
            }
        }

        [HttpGet("GetTareas")]
        public ActionResult<List<Tarea>> GetTareas()
        {
            List<Tarea> tareas = manejoTareas.getTareas();

            if (tareas != null)
            {
                return Ok(tareas);    
            } else {
                return BadRequest();
            }
        }

        [HttpGet("GetTareas_Completadas")]
        public ActionResult<List<Tarea>> GetTareasCompletadas()
        {
            List<Tarea> tareas = manejoTareas.getCompletadas();

            if (tareas != null)
            {
                return Ok(tareas);    
            } else {
                return BadRequest();
            }
        }
    }
}