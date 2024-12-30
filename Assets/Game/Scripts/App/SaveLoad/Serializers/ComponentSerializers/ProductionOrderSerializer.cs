using System.Collections.Generic;
using Modules.Entities;
using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class
        ProductionOrderSerializer : ComponentSerializer<ProductionOrder, EntityCatalog, ProductionOrderData>
    {
        protected override ProductionOrderData Serialize(ProductionOrder component, EntityCatalog service)
        {
            List<string> queue = new List<string>();

            foreach (var item in component.Queue)
            {
                queue.Add(item.Name);
            }

            return new ProductionOrderData
            {
                value = queue
            };
        }

        protected override void Deserialize(ProductionOrder component, EntityCatalog service, ProductionOrderData productionOrderData)
        {
            var newQueue = new List<EntityConfig>();
            foreach (var entityName in productionOrderData.value)
            {
                if (service.FindConfig(entityName, out var config))
                {
                    newQueue.Add(config);
                }
            }

            component.Queue = newQueue;
        }
    }
}