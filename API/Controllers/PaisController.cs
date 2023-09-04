using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;
using API.Helpers;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class PaisController : BaseApiController
{ 
    private readonly IUnitOfWork unitofwork;
    
    private readonly  IMapper _mapper;

    public PaisController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this._mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
    {
        var pais = await unitofwork.Paises.GetAllAsync();
        return _mapper.Map<List<PaisDto>>(pais);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PaisxDepDto>>> Get11([FromQuery] Params paisParams)
    {
        var pais = await unitofwork.Paises.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var lstPaisesDto = _mapper.Map<List<PaisxDepDto>>(pais.registros);
        return new Pager<PaisxDepDto>(lstPaisesDto, pais.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PaisDto>> Get(int id)
    {
        var pais = await unitofwork.Paises.GetByIdAsync(id);
        if (pais == null){
            return NotFound();
        }
        return this._mapper.Map<PaisDto>(pais);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pais>> Post(PaisDto paisDto)
    {
        var pais = this._mapper.Map<Pais>(paisDto);
        this.unitofwork.Paises.Add(pais);
        await unitofwork.SaveAsync();
        if(pais == null)
        {
            return BadRequest();
        }
        paisDto.Id = pais.Id;
        return CreatedAtAction(nameof(Post), new {id = paisDto.Id}, paisDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PaisDto>> Put(int id, [FromBody]PaisDto paisDto){
        if(paisDto == null)
        {
            return NotFound();
        }
        var pais = this._mapper.Map<Pais>(paisDto);
        unitofwork.Paises.Update(pais);
        await unitofwork.SaveAsync();
        return paisDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var pais = await unitofwork.Paises.GetByIdAsync(id);
        if(pais == null)
        {
            return NotFound();
        }
        unitofwork.Paises.Remove(pais);
        await unitofwork.SaveAsync();
        return NoContent();
    }

}

    