using Maxsociety.Models;
using Maxsociety.Services;
using Microsoft.AspNetCore.Mvc;

[Route("maxsociety/[controller]")]
[ApiController]
public class VisitorsController : ControllerBase
{
    private readonly IVisitorsService _visitorsService;

    public VisitorsController(IVisitorsService visitorsService)
    {
        _visitorsService = visitorsService;
    }

    // GET: api/Visitors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Visitors>>> GetVisitors()
    {
        var visitors = await _visitorsService.GetVisitorsAsync();
        return Ok(visitors);
    }

    // GET: api/Visitors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Visitors>> GetVisitor(long id)
    {
        var visitor = await _visitorsService.GetVisitorByIdAsync(id);

        if (visitor == null)
        {
            return NotFound();
        }

        return Ok(visitor);
    }

    // POST: api/Visitors
    [HttpPost]
    public async Task<ActionResult<Visitors>> PostVisitor(Visitors visitor)
    {
        try
        {
            var addedVisitor = await _visitorsService.AddVisitorAsync(visitor);
            return CreatedAtAction(nameof(GetVisitor), new { id = addedVisitor.VisitorId }, addedVisitor);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/Visitors/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVisitor(long id, Visitors visitor)
    {
        if (id != visitor.VisitorId)
        {
            return BadRequest("Id mismatch");
        }

        try
        {
            await _visitorsService.UpdateVisitorAsync(id, visitor);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/Visitors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVisitor(long id)
    {
        try
        {
            await _visitorsService.DeleteVisitorAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
