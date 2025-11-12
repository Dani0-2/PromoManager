namespace PromoManager.Application.Requests;

public record CreateCouponRequest(string kind, decimal amount, DateTime? expiresAt);