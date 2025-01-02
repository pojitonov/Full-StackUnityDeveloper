using System.Collections.Generic;
using System.Linq;
using Modules.Entities;

namespace Game.App
{
    public class WorldSerializer : Serializer<EntityWorld, EntitySerializer, EntityWorldData>
    {
        protected override EntityWorldData Serialize(EntityWorld world, EntitySerializer entitySerializer)
        {
            var entities = world.GetAll();
            var entitiesData = entities.Select(entitySerializer.SerializeEntity).ToList();

            return new EntityWorldData
            {
                entities = entitiesData
            };
        }
        
        protected override void Deserialize(EntityWorld world, EntitySerializer entitySerializer, EntityWorldData data)
        {
            world.DestroyAll();
            var entities = SpawnEntities(entitySerializer, data);
            foreach (var entity in entities)
            {
                entitySerializer.DeserializeComponents(entity.entity, entity.data.components);
            }
        }

        private IEnumerable<(Entity entity, EntityData data)> SpawnEntities(EntitySerializer entitySerializer, EntityWorldData data)
        {
            var entities = new List<(Entity, EntityData)>();
            foreach (var entityData in data.entities)
            {
                if (entitySerializer.TrySpawnEntity(entityData, out var entity))
                {
                    entities.Add((entity, entityData));
                }
            }

            return entities;
        }
    }
}