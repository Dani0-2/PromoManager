// -------------------------------------------------------------
// SRP (Single Responsibility Principle)
// La clase Coupon tiene una única responsabilidad: representar
// un cupón y contener sus reglas de negocio (invariantes).
// -------------------------------------------------------------
namespace PromoManager.Domain.Entities;

public enum CouponKind { PERCENT, FIXED }

public class Coupon
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Code { get; private set; }
    public CouponKind Kind { get; private set; }
    public decimal Amount { get; private set; }
    public bool IsActive { get; private set; } = true;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? ExpiresAt { get; private set; }

    public Coupon(string code, CouponKind kind, decimal amount, DateTime? expiresAt = null)
    {
        if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Code required");
        if (amount <= 0) throw new ArgumentException("Amount must be > 0");

        Code = code;
        Kind = kind;
        Amount = amount;
        ExpiresAt = expiresAt;
    }

    public void Deactivate()
    {
        if (!IsActive) throw new InvalidOperationException("Coupon is already inactive");
        IsActive = false;
    }

    public (bool valid, string? reason) Validate(DateTime now)
    {
        if (!IsActive) return (false, "Coupon is inactive");
        if (ExpiresAt.HasValue && ExpiresAt.Value < now) return (false, "Coupon has expired");
        return (true, null);
    }
}