using Maxsociety;
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

    // GET: maxsociety/Visitors
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<Visitors>>>> GetVisitors()
    {
        var visitors = await _visitorsService.GetVisitorsAsync();
        return Ok(new ApiResponse<IEnumerable<Visitors>>(true, "Visitors retrieved successfully", visitors));
    }

    // GET: maxsociety/Visitors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<Visitors>>> GetVisitor(long id)
    {
        var visitor = await _visitorsService.GetVisitorByIdAsync(id);

        if (visitor == null)
        {
            return NotFound(new ApiResponse<Visitors>(false, "Visitor not found", null));
        }

        return Ok(new ApiResponse<Visitors>(true, "Visitor retrieved successfully", visitor));
    }

    // GET: maxsociety/Visitors/phone/{mobileNo}
    [HttpGet("mobileNo/{mobileNo}")]
    public async Task<ActionResult<ApiResponse<Visitors>>> GetVisitorByMobileNo(string mobileNo)
    {
        var visitor = await _visitorsService.GetVisitorByMobileNoAsync(mobileNo);

        if (visitor == null)
        {
            return NotFound(new ApiResponse<Visitors>(false, "Visitor not found", null));
        }

        return Ok(new ApiResponse<Visitors>(true, "Visitor retrieved successfully", visitor));
    }

    // POST: maxsociety/Visitors
    [HttpPost]
    public async Task<ActionResult<ApiResponse<Visitors>>> PostVisitor(Visitors visitor)
    {
        try
        {
            var addedVisitor = await _visitorsService.AddVisitorAsync(visitor);
            return CreatedAtAction(nameof(GetVisitor), new { id = addedVisitor.VisitorId }, new ApiResponse<Visitors>(true, "Visitor created successfully", addedVisitor));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<Visitors>(false, ex.Message, null));
        }
    }

    // PUT: maxsociety/Visitors/5
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<Visitors>>> PutVisitor(long id, Visitors visitor)
    {
        if (id != visitor.VisitorId)
        {
            return BadRequest(new ApiResponse<Visitors>(false, "Id mismatch", null));
        }

        try
        {
            await _visitorsService.UpdateVisitorAsync(id, visitor);
            return Ok(new ApiResponse<Visitors>(true, "Visitor updated successfully", visitor));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<Visitors>(false, ex.Message, null));
        }
    }

    // DELETE: maxsociety/Visitors/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<Visitors>>> DeleteVisitor(long id)
    {
        try
        {
            await _visitorsService.DeleteVisitorAsync(id);
            return Ok(new ApiResponse<Visitors>(true, "Visitor deleted successfully", null));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ApiResponse<Visitors>(false, ex.Message, null));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponse<Visitors>(false, ex.Message, null));
        }
    }
}
