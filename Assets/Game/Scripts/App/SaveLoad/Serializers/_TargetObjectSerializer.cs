// using Modules.Entities;
// using SampleGame.Gameplay;
//
// namespace Game.App
// {
//     public sealed class TargetObjectSerializer : GenericSerializer<TargetObject, TargetObjectData>
//     {
//         private readonly TargetObject _targetObject;
//         private readonly EntityCatalog _entityCatalog;
//
//         public TargetObjectSerializer(TargetObject targetObject, EntityCatalog entityCatalog)
//         {
//             _targetObject = targetObject;
//             _entityCatalog = entityCatalog;
//         }
//
//         protected override TargetObjectData Serialize(TargetObject service)
//         {
//             return new TargetObjectData { entityName = service.Value.Name };
//         }
//
//         protected override void Deserialize(TargetObject service, TargetObjectData data)
//         {
//             if (_entityCatalog.FindConfig(data.entityName, out EntityConfig entityConfig))
//             {
//                 _targetObject.Value = entityConfig;
//             }
//         }
//     }
// }