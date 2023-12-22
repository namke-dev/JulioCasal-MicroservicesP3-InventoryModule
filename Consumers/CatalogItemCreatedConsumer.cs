using System.Threading.Tasks;
using MassTransit;
using Play.Catalog.Contracts;
using Play.Common;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service.Consumers
{
    public class CatalogItemCreatedConsumer : IConsumer<CatalogItemCreated>
    {
        private readonly IRepository<CatalogItem> repository;
        public CatalogItemCreatedConsumer(IRepository<CatalogItem> repository)
        {
            this.repository = repository;
        }
        public async Task Consume(ConsumeContext<CatalogItemCreated> context)
        {
            var message = context.Message;

            var catalogItem = await repository.GetAsync(message.ItemId);

            if (catalogItem is not null)
            {
                return;
            }

            catalogItem = new CatalogItem
            {
                Id = catalogItem.Id,
                Name = message.Name,
                Description = message.Description
            };
            await repository.CreateAsync(catalogItem);
        }
    }
}