using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using APIGestorTareas.Data;
using APIGestorTareas.Models;

namespace APIGestorTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Obtener todas las tareas
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        // {
        //     return await _context.Tasks.ToListAsync();
        // }
        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> GetTasks([FromQuery] string? status)
        {
            if (!string.IsNullOrEmpty(status) && status != "todas")
            {
                return Ok(_context.Tasks.Where(t => t.Status == status).ToList());
            }
            return Ok(_context.Tasks.ToList());
        }

        // ✅ Obtener una tarea por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        // ✅ Crear una nueva tarea
        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        // ✅ Actualizar una tarea
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTask(int id, [FromBody] JsonPatchDocument<TaskItem> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var taskItem = await _context.Tasks.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(taskItem, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.SaveChangesAsync();

            return Ok(taskItem);
        }


        // ✅ Eliminar una tarea
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
