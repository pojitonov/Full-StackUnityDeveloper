// using Modules.Entities;
//
// namespace Game.App
// {
//     public sealed class EntitySerializer : GenericSerializer<Entity, EntityData>
//     {
//         private readonly Entity _entity;
//         private readonly EntityCatalog _entityCatalog;
//
//         public EntitySerializer(Entity entity, EntityCatalog entityCatalog)
//         {
//             _entity = entity;
//             _entityCatalog = entityCatalog;
//         }
//
//         protected override EntityData Serialize(Entity service)
//         {
//             return new EntityData
//             {
//                 id = service.Id,
//                 name = service.Name,
//                 entityType = service.Type,
//             };
//         }
//
//         protected override void Deserialize(Entity service, EntityData data)
//         {
//             if (_entityCatalog.FindConfig(data.name, out EntityConfig entityConfig))
//             {
//                 service.
//             }
//         }
//     }
// }