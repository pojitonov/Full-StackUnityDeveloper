using System;
using System.Collections.Generic;
using System.Linq;
using Modules.Entities;

namespace Game.App
{
    public sealed class EntitySerializer
    {
        private readonly EntityWorld world;
        private readonly EntityCatalog catalog;

        private readonly Dictionary<Type, IComponentSerializer> _serializers;

        public EntitySerializer(EntityWorld world, EntityCatalog catalog, IEnumerable<IComponentSerializer> serializers)
        {
            this.world = world;
            this.catalog = catalog;

            _serializers = serializers.ToDictionary(
                serializer => serializer.Type,
                serializer => serializer
            );
        }

        public EntityData SerializeEntity(Entity entity)
        {
            var components = entity.GetComponents<ISerializable>();
            var componentsData = new Dictionary<string, string>();

            foreach (var component in components)
            {
                SerializeComponent(component, componentsData);
            }

            return new EntityData
            {
                id = entity.Id,
                entityName = entity.Name,
                entityType = entity.Type.ToString(),
                position = entity.transform.position,
                rotation = entity.transform.rotation,
                components = componentsData.Count > 0 ? componentsData : null
            };
        }
        
        public bool TrySpawnEntity(EntityData entityWorldData, out Entity entity)
        {
            entity = null;
            
            if (!catalog.FindConfig(entityWorldData.entityName, out var config))
                return false;

            entity = world.Spawn(config, entityWorldData.position, entityWorldData.rotation, entityWorldData.id);
            return true;
        }
        
        public void DeserializeComponents(Entity entity, Dictionary<string, string> componentsData)
        {
            foreach (var component in entity.GetComponents<ISerializable>())
            {
                DeserializeComponent(component, componentsData);
            }
        }
        
        private IComponentSerializer GetSerializer(ISerializable component)
        {
            if (_serializers.TryGetValue(component.GetType(), out var serializer))
                return serializer;

            throw new InvalidOperationException($"Serializer for component type {component.GetType()} not found.");
        }

        private void SerializeComponent(ISerializable component, Dictionary<string, string> saveState)
        {
            GetSerializer(component).Serialize(component, saveState);
        }

        private void DeserializeComponent(ISerializable component, Dictionary<string, string> saveState)
        {
            GetSerializer(component).Deserialize(component, saveState);
        }
    }
}