// -------------------------------------------------------------
// SRP: La clase maneja únicamente los casos de uso de cupones 
// (crear, listar, obtener, desactivar, eliminar, validar).
// -------------------------------------------------------------
// DIP: Depende de abstracciones (ICouponRepository, 
// IDateTimeProvider) en lugar de implementaciones concretas.
// -------------------------------------------------------------
using PromoManager.Application.DTOs;
using PromoManager.Application.Interfaces;
using PromoManager.Application.Requests;
using PromoManager.Domain.Entities;

namespace PromoManager.Application.Services;

public class CouponService
{
    private readonly ICouponRepository _repo;
    private readonly IDateTimeProvider _clock;

    public CouponService(ICouponRepository repo, IDateTimeProvider clock)
    {
        _repo = repo;
        _clock = clock;
    }

    public CouponDto Create(CreateCouponRequest req)
    {
        var code = Guid.NewGuid().ToString("N")[..8].ToUpper();
        var kind = Enum.Parse<CouponKind>(req.kind, ignoreCase: true);
        var coupon = new Coupon(code, kind, req.amount, req.expiresAt);
        _repo.Add(coupon);
        return Map(coupon);
    }

    public IEnumerable<CouponDto> GetAll() => _repo.GetAll().Select(Map);

    public CouponDto? GetByCode(string code) => _repo.GetByCode(code) is { } c ? Map(c) : null;

    public CouponDto Deactivate(string code)
    {
        var c = _repo.GetByCode(code) ?? throw new KeyNotFoundException("Coupon not found");
        c.Deactivate();
        _repo.Update(c);
        return Map(c);
    }

    public void Delete(string code) => _repo.Remove(code);

    public (bool valid, string? reason) Validate(string code)
    {
        var c = _repo.GetByCode(code);
        if (c is null) return (false, "Not found");
        return c.Validate(_clock.Now);
    }

    private static CouponDto Map(Coupon c) =>
        new(c.Id, c.Code, c.Kind.ToString(), c.Amount, c.IsActive, c.CreatedAt, c.ExpiresAt);
}