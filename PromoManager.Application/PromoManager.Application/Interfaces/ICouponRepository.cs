// -------------------------------------------------------------
// ISP (Interface Segregation Principle)
// La interfaz define solo las operaciones necesarias para 
// administrar cupones, separando lectura y escritura.
// -------------------------------------------------------------
// DIP (Dependency Inversion Principle)
// La capa Application depende de esta abstracción y no de una 
// implementación concreta (como una base de datos).
// -------------------------------------------------------------
using PromoManager.Domain.Entities;

namespace PromoManager.Application.Interfaces;

public interface ICouponRepository
{
    void Add(Coupon coupon);
    IEnumerable<Coupon> GetAll();
    Coupon? GetByCode(string code);
    void Update(Coupon coupon);
    void Remove(string code);
}