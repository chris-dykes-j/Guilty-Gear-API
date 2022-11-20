using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StriveAPI.Models;
using StriveAPI.Services;

namespace StriveAPI.Controllers;

[Route("api/strive/moves")]
[ApiController]
public class StriveMoveController : ControllerBase
{
    private readonly StriveCharacterRepository _repository;
    private readonly IMapper _mapper;

    public StriveMoveController(StriveCharacterRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    [Route("{moveName}")]
    public async Task<ActionResult<List<StriveMoveCharacterNameDto>>> GetMovesByName(string moveName)
    {
        var moveData = await _repository.GetMovesByName(moveName);
        if (moveData == null) return NotFound();
        return Ok(_mapper.Map<IEnumerable<StriveMoveCharacterNameDto>>(moveData));
    }
    
    [HttpGet]
    [Route("inputs/{moveInput}")]
    public async Task<ActionResult<List<StriveMoveCharacterNameDto>>> GetMovesByInput(string moveInput)
    {
        var moveData = await _repository.GetMovesByInput(moveInput);
        if (moveData == null) return NotFound();
        return Ok(_mapper.Map<IEnumerable<StriveMoveCharacterNameDto>>(moveData));
    }

}