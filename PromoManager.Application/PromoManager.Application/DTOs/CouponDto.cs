namespace PromoManager.Application.DTOs;

public record CouponDto(Guid Id, string Code, string Kind, decimal Amount,
                        bool IsActive, DateTime CreatedAt, DateTime? ExpiresAt);