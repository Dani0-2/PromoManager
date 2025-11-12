# Proyecto PromoManager

Este proyecto fue desarrollado para la clase **Ingeniería de Software II**.  
La idea es aplicar los principios de **Clean Architecture** y **SOLID** en una aplicación web usando **ASP.NET Core**.

## Descripción

PromoManager es una API para manejar cupones de descuento.  
Permite crear, listar, buscar, eliminar, desactivar y validar cupones.  
Toda la información se maneja en memoria (no usa base de datos).

## Estructura del Proyecto

El proyecto está dividido en cuatro capas principales:

- **PromoManager.API:** contiene los controladores y la configuración general.
- **PromoManager.Application:** maneja la lógica del negocio.
- **PromoManager.Domain:** define las entidades del sistema.
- **PromoManager.Infrastructure:** tiene las implementaciones de los repositorios.

## Tecnologías usadas

- C# / .NET 8  
- ASP.NET Core Web API  
- Swagger para probar los endpoints  
- Inyección de dependencias (DI)

## Endpoints principales

- `GET /api/Coupons` → muestra todos los cupones  
- `GET /api/Coupons/{code}` → busca un cupón por código  
- `POST /api/Coupons` → crea un nuevo cupón  
- `DELETE /api/Coupons/{code}` → elimina un cupón  
- `POST /api/Coupons/{code}/deactivate` → desactiva un cupón  
- `GET /api/Coupons/{code}/validate` → valida si el cupón está activo
