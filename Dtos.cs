using System;

namespace Play.Inventory.Service
{
    public class Dtos
    {
        public record GrandItemsDto(Guid UserId, Guid CatalogItemId, int Quantity);
        public record InventoryItemDto(Guid CatalogItemId, string Name, string Description, int Quantity, DateTimeOffset AcquiredDate);
        public record CatalogItemDto(Guid Id, string Name, string Description);

    }
}