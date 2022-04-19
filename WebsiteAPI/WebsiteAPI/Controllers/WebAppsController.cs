#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteAPI;
using WebsiteAPI.Data;

namespace WebsiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebAppsController : ControllerBase
    {
        private readonly WebsiteAPIContext _context;

        public WebAppsController(WebsiteAPIContext context)
        {
            _context = context;
        }

        // GET: api/WebApps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebApp>>> GetWebApp()
        {
            return await _context.WebApp.ToListAsync();
        }

        // GET: api/WebApps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApp>> GetWebApp(int id)
        {
            var webApp = await _context.WebApp.FindAsync(id);

            if (webApp == null)
            {
                return NotFound();
            }

            return webApp;
        }

        // PUT: api/WebApps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebApp(int id, WebApp webApp)
        {
            if (id != webApp.Id)
            {
                return BadRequest();
            }

            _context.Entry(webApp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebAppExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WebApps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WebApp>> PostWebApp(WebApp webApp)
        {
            _context.WebApp.Add(webApp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWebApp", new { id = webApp.Id }, webApp);
        }

        // DELETE: api/WebApps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWebApp(int id)
        {
            var webApp = await _context.WebApp.FindAsync(id);
            if (webApp == null)
            {
                return NotFound();
            }

            _context.WebApp.Remove(webApp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WebAppExists(int id)
        {
            return _context.WebApp.Any(e => e.Id == id);
        }
    }
}
