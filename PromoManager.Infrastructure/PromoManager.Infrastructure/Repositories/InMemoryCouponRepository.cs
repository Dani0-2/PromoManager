// -------------------------------------------------------------
// Implementación concreta de ICouponRepository (In-Memory).
// Cumple DIP: la API no depende de esta clase, sino de la 
// abstracción registrada en Program.cs.
// -------------------------------------------------------------
using PromoManager.Application.Interfaces;
using PromoManager.Domain.Entities;

namespace PromoManager.Infrastructure.Repositories;

public class InMemoryCouponRepository : ICouponRepository
{
    private readonly List<Coupon> _items = new();

    public void Add(Coupon coupon) => _items.Add(coupon);
    public IEnumerable<Coupon> GetAll() => _items;
    public Coupon? GetByCode(string code) => _items.FirstOrDefault(c => c.Code == code);

    public void Update(Coupon coupon)
    {
        var existing = GetByCode(coupon.Code);
        if (existing is null) return;
        _items.Remove(existing);
        _items.Add(coupon);
    }

    public void Remove(string code)
    {
        var c = GetByCode(code);
        if (c is not null) _items.Remove(c);
    }
}