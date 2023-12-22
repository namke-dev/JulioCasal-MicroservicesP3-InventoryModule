using System.Threading.Tasks;
using MassTransit;
using Play.Catalog.Contracts;
using Play.Common;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service.Consumers
{
    public class CatalogItemUpdatedConsumer : IConsumer<CatalogItemUpdated>
    {
        private readonly IRepository<CatalogItem> repository;
        public CatalogItemUpdatedConsumer(IRepository<CatalogItem> repository)
        {
            this.repository = repository;
        }
        public async Task Consume(ConsumeContext<CatalogItemUpdated> context)
        {
            var message = context.Message;

            var catalogItem = await repository.GetAsync(message.ItemId);

            if (catalogItem is null)
            {
                catalogItem = new CatalogItem
                {
                    Id = catalogItem.Id,
                    Name = message.Name,
                    Description = message.Description
                };
                await repository.CreateAsync(catalogItem);
            }

            catalogItem.Name = message.Name;
            catalogItem.Description = message.Description;

            await repository.UpdateAsync(catalogItem);
        }
    }
}