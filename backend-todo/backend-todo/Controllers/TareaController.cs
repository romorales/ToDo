namespace backend_todo.Controllers
{
    using backend_todo.Context;
    using backend_todo.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly AplicationDbContext context;
        public TareaController(AplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaTareas = await this.context.Tareas.ToListAsync();
                return Ok(listaTareas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Tarea tarea)
        {
            try
            {
                this.context.Tareas.Add(tarea);
                await this.context.SaveChangesAsync();
                return Ok(new { message = "Tarea guardada" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tarea tarea)
        {
            try
            {
                if (id != tarea.Id)
                {
                    return NotFound();
                }

                tarea.Estado = !tarea.Estado;
                this.context.Entry(tarea).State = EntityState.Modified;
                await this.context.SaveChangesAsync();
                return Ok(new { message = "Tarea modificada" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarea = await this.context.Tareas.FindAsync(id);
                if (tarea == null)
                {
                    return NotFound();
                }

                this.context.Tareas.Remove(tarea);
                await this.context.SaveChangesAsync();
                return Ok(new { message = "Tarea eliminada" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
