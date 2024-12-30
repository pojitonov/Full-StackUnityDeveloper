using System.Collections.Generic;
using System.Linq;
using Modules.Entities;

namespace Game.App
{
    public class WorldSerializer : GameSerializer<EntityWorld, EntitySerializer, EntityWorldData>
    {
        protected override EntityWorldData Serialize(EntityWorld world, EntitySerializer esh)
        {
            var entities = world.GetAll();
            var entitiesData = entities.Select(esh.SerializeEntity).ToList();

            return new EntityWorldData
            {
                entities = entitiesData
            };
        }
        
        protected override void Deserialize(EntityWorld world, EntitySerializer esh, EntityWorldData data)
        {
            world.DestroyAll();
            var entities = SpawnEntities(esh, data);
            foreach (var e in entities)
            {
                esh.DeserializeComponents(e.entity, e.data.components);
            }
        }

        private IEnumerable<(Entity entity, EntityData data)> SpawnEntities(EntitySerializer esh, EntityWorldData data)
        {
            var entities = new List<(Entity, EntityData)>();
            foreach (var entityData in data.entities)
            {
                if (esh.TrySpawnEntity(entityData, out var entity))
                {
                    entities.Add((entity, entityData));
                }
            }

            return entities;
        }
    }
}