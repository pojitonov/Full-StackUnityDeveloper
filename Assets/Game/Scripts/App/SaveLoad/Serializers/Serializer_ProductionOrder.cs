using System.Collections.Generic;
using Modules.Entities;
using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class Serializer_ProductionOrder : Serializer<ProductionOrder, EntityCatalog, Data_ProductionOrder>
    {
        protected override Data_ProductionOrder Serialize(ProductionOrder component, EntityCatalog service)
        {
            List<string> queue = new List<string>();

            foreach (var item in component.Queue)
            {
                queue.Add(item.Name);
            }

            return new Data_ProductionOrder { value = queue };
        }

        protected override void Deserialize(ProductionOrder component, EntityCatalog service, Data_ProductionOrder data)
        {
            var newQueue = new List<EntityConfig>();
            foreach (var entityName in data.value)
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