using Maxsociety.Models;
using Maxsociety.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("maxsociety/[controller]")]
[ApiController]
public class VisitorLogsController : ControllerBase
{
    private readonly IVisitorLogsService _visitorLogsService;

    public VisitorLogsController(IVisitorLogsService visitorLogsService)
    {
        _visitorLogsService = visitorLogsService;
    }

    // GET: api/VisitorLogs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VisitorLogs>>> GetVisitorLogs()
    {
        var visitorLogs = await _visitorLogsService.GetVisitorLogsAsync();
        return Ok(visitorLogs);
    }

    // GET: api/VisitorLogs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<VisitorLogs>> GetVisitorLog(long id)
    {
        var visitorLog = await _visitorLogsService.GetVisitorLogByIdAsync(id);

        if (visitorLog == null)
        {
            return NotFound();
        }

        return Ok(visitorLog);
    }

    // POST: api/VisitorLogs
    [HttpPost]
    public async Task<ActionResult<VisitorLogs>> PostVisitorLog(VisitorLogs visitorLog)
    {
        try
        {
            var addedVisitorLog = await _visitorLogsService.AddVisitorLogAsync(visitorLog);
            return CreatedAtAction(nameof(GetVisitorLog), new { id = addedVisitorLog.VisitorLogId }, addedVisitorLog);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT: api/VisitorLogs/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVisitorLog(long id, VisitorLogs visitorLog)
    {
        if (id != visitorLog.VisitorLogId)
        {
            return BadRequest("Id mismatch");
        }

        try
        {
            await _visitorLogsService.UpdateVisitorLogAsync(id, visitorLog);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/VisitorLogs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVisitorLog(long id)
    {
        try
        {
            await _visitorLogsService.DeleteVisitorLogAsync(id);
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
