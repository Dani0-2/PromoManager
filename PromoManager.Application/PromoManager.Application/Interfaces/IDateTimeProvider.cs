// -------------------------------------------------------------
// ISP: Interfaz pequeña y enfocada; solo expone la hora actual.
// DIP: Los servicios dependen de esta abstracción en lugar del 
// sistema operativo o DateTime directamente.
// -------------------------------------------------------------
namespace PromoManager.Application.Interfaces;

public interface IDateTimeProvider
{
    DateTime Now { get; }
}