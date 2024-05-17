using Maxsociety;
using Maxsociety.Models;
using Maxsociety.Services;
using Microsoft.AspNetCore.Mvc;

[Route("maxsociety/[controller]")]
[ApiController]
public class VisitorLogsController : ControllerBase
{
    private readonly IVisitorLogsService _visitorLogsService;
    private readonly IVisitorsService _visitorsService;

    public VisitorLogsController(IVisitorLogsService visitorLogsService, IVisitorsService visitorsService)
    {
        _visitorLogsService = visitorLogsService;
        _visitorsService = visitorsService;
    }

    // GET: maxsociety/VisitorLogs
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<VisitorLogs>>>> GetVisitorLogs()
    {
        var visitorLogs = await _visitorLogsService.GetVisitorLogsAsync();
        return Ok(new ApiResponse<IEnumerable<VisitorLogs>>(true, "Fetched visitor logs successfully", visitorLogs));
    }

    // GET: maxsociety/VisitorLogs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<VisitorLogs>>> GetVisitorLog(long id)
    {
        var visitorLog = await _visitorLogsService.GetVisitorLogByIdAsync(id);

        if (visitorLog == null)
        {
            return NotFound(new ApiResponse<VisitorLogs>(false, "Visitor log not found", null));
        }

        return Ok(new ApiResponse<VisitorLogs>(true, "Fetched visitor log successfully", visitorLog));
    }

    // GET: maxsociety/VisitorLogs/mobileNo/{mobileNo}
    [HttpGet("mobileNo/{mobileNo}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<VisitorLogs>>>> GetVisitorLogsByMobileNo(string mobileNo)
    {
        var visitor = await _visitorsService.GetVisitorByMobileNoAsync(mobileNo);

        if (visitor == null)
        {
            return NotFound(new ApiResponse<IEnumerable<VisitorLogs>>(false, "Visitor not found", null));
        }

        var visitorLogs = await _visitorLogsService.GetVisitorLogsByVisitorIdAsync(visitor.VisitorId);
        return Ok(new ApiResponse<IEnumerable<VisitorLogs>>(true, "Fetched visitor logs successfully", visitorLogs));
    }

    // GET: maxsociety/VisitorLogs/visitor/{visitorId}
    [HttpGet("visitor/{visitorId}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<VisitorLogs>>>> GetVisitorLogsByVisitorId(long visitorId)
    {
        var visitorLogs = await _visitorLogsService.GetVisitorLogsByVisitorIdAsync(visitorId);
        return Ok(new ApiResponse<IEnumerable<VisitorLogs>>(true, "Fetched visitor logs successfully", visitorLogs));
    }

    // POST: maxsociety/VisitorLogs
    [HttpPost]
    public async Task<ActionResult<ApiResponse<VisitorLogs>>> PostVisitorLog(VisitorLogs visitorLog)
    {
        try
        {
            var addedVisitorLog = await _visitorLogsService.AddVisitorLogAsync(visitorLog);
            return CreatedAtAction(nameof(GetVisitorLog), new { id = addedVisitorLog.VisitorLogId }, new ApiResponse<VisitorLogs>(true, "Visitor log added successfully", addedVisitorLog));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<VisitorLogs>(false, ex.Message, null));
        }
    }

    // PUT: maxsociety/VisitorLogs/5
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<VisitorLogs>>> PutVisitorLog(long id, VisitorLogs visitorLog)
    {
        if (id != visitorLog.VisitorLogId)
        {
            return BadRequest(new ApiResponse<VisitorLogs>(false, "Id mismatch", null));
        }

        try
        {
            await _visitorLogsService.UpdateVisitorLogAsync(id, visitorLog);
            return Ok(new ApiResponse<VisitorLogs>(true, "Visitor log updated successfully", visitorLog));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<VisitorLogs>(false, ex.Message, null));
        }
    }

    // DELETE: maxsociety/VisitorLogs/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<VisitorLogs>>> DeleteVisitorLog(long id)
    {
        try
        {
            await _visitorLogsService.DeleteVisitorLogAsync(id);
            return Ok(new ApiResponse<VisitorLogs>(true, "Visitor log deleted successfully", null));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse<VisitorLogs>(false, ex.Message, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<VisitorLogs>(false, ex.Message, null));
        }
    }
}
