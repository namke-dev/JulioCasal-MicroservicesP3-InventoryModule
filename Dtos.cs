using System;

namespace Play.Inventory.Service
{
    public class Dtos
    {
        public record GrandItemsDto(Guid UserId, Guid CatalogItemId, int Quantity);
        public record InventoryItemDto(Guid CatalogItemId, int Quantity, DateTimeOffset AcquiredDate);
    }
}