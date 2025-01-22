using System.Collections.Generic;
using UnityEngine;

namespace Atomic.Entities
{
    public partial class SceneEntity
    {
        private static readonly Dictionary<IEntity, SceneEntity> _entityMap = new();

        public static SceneEntity Instantiate(
            string name = null,
            IEnumerable<int> tags = null,
            IReadOnlyDictionary<int, object> values = null,
            IEnumerable<IEntityBehaviour> behaviours = null,
            bool installOnAwake = false
        )
        {
            GameObject gameObject = new GameObject(name);
            SceneEntity sceneEntity = gameObject.AddComponent<SceneEntity>();
            sceneEntity.Name = name;
            sceneEntity.installOnAwake = installOnAwake;

            sceneEntity.AddTags(tags);
            sceneEntity.AddValues(values);
            sceneEntity.AddBehaviours(behaviours);

            sceneEntity.Install();
            return sceneEntity;
        }

        public static SceneEntity Instantiate(
            SceneEntity prefab,
            Vector3 position,
            Quaternion rotation,
            Transform parent = null
        )
        {
            SceneEntity entity = GameObject.Instantiate(prefab, position, rotation, parent);
            entity.Install();
            return entity;
        }

        public static SceneEntity Cast(IEntity entity)
        {
            if (entity == null)
                return null;

            if (entity is SceneEntity sceneEntity)
                return sceneEntity;

            if (entity is SceneEntityProxy proxy)
                return proxy.source;

            _entityMap.TryGetValue(entity, out sceneEntity);
            return sceneEntity;
        }

        public static bool TryCast(IEntity entity, out SceneEntity result)
        {
            if (entity == null)
            {
                result = null;
                return false;
            }

            if (entity is SceneEntity sceneEntity)
            {
                result = sceneEntity;
                return true;
            }

            if (entity is SceneEntityProxy proxy)
            {
                result = proxy.source;
                return true;
            }

            return _entityMap.TryGetValue(entity, out result);
        }
    }
}