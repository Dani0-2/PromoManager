using PromoManager.Application.Interfaces;

namespace PromoManager.Infrastructure.Repositories;

public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.UtcNow;
}