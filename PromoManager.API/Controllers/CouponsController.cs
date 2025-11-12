// -------------------------------------------------------------
// Este controlador expone los casos de uso solicitados:
// Crear, Listar, Obtener, Desactivar, Eliminar y Validar cupones.
// -------------------------------------------------------------
// Clean Architecture: el controlador llama a la capa Application,
// no tiene lógica de negocio ni depende del repositorio.
// -------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using PromoManager.Application.DTOs;
using PromoManager.Application.Requests;
using PromoManager.Application.Services;

namespace PromoManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouponsController : ControllerBase
{
    private readonly CouponService _service;
    public CouponsController(CouponService service) => _service = service;

    [HttpPost]                               
    public ActionResult<CouponDto> Create([FromBody] CreateCouponRequest req)
        => Ok(_service.Create(req));

    [HttpGet]                               
    public IEnumerable<CouponDto> GetAll() => _service.GetAll();

    [HttpGet("{code}")]                       
    public ActionResult<CouponDto> GetByCode(string code)
        => _service.GetByCode(code) is { } c ? Ok(c) : NotFound();

    [HttpPost("{code}/deactivate")]     
    public ActionResult<CouponDto> Deactivate(string code)
        => Ok(_service.Deactivate(code));

    [HttpDelete("{code}")]                   
    public IActionResult Delete(string code)
    {
        _service.Delete(code);
        return NoContent();
    }

    [HttpGet("{code}/validate")]               
    public IActionResult Validate(string code)
    {
        var (valid, reason) = _service.Validate(code);
        return Ok(new { valid, reason });
    }
}