#if UNITY_EDITOR && ODIN_INSPECTOR
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Atomic.Contexts
{
    public partial class SceneContext
    {
        ///Main
        [PropertySpace(12)]
        [FoldoutGroup("Debug")]
        [ShowInInspector, ReadOnly]
        [HideInEditorMode, LabelText("Name")]
        private string NameDebug
        {
            get
            {
                return this.context?.Name ?? "undefined";
            }
            set
            {
                if (this.context != null) this.context.Name = value;
            }
        }

        [FoldoutGroup("Debug")]
        [ShowInInspector, ReadOnly, PropertySpace]
        [HideInEditorMode, LabelText("Initialized")]
        private bool InitializedDebug => this.context?.Initialized ?? default;

        [FoldoutGroup("Debug")]
        [ShowInInspector, ReadOnly]
        [HideInEditorMode, LabelText("Enabled")]
        private bool EnabledDebug => this.context?.Enabled ?? default;

        ///Values
        private static readonly List<ValueElement> _valueElementsCache = new();

        private struct ValueElement
        {
            [HorizontalGroup(200), ShowInInspector, ReadOnly, HideLabel]
            public string name;

            [HorizontalGroup, ShowInInspector, HideLabel]
            public object value;

            internal readonly int id;

            public ValueElement(string name, object value, int id)
            {
                this.name = name;
                this.value = value;
                this.id = id;
            }
        }

        [Searchable]
        [FoldoutGroup("Debug")]
        [LabelText("Values")]
        [ShowInInspector, PropertyOrder(100)]
        [ListDrawerSettings(
            CustomRemoveElementFunction = nameof(RemoveValueElement),
            CustomRemoveIndexFunction = nameof(RemoveValueElementAt),
            HideAddButton = true
        )]
        private List<ValueElement> ValuesDebug
        {
            get
            {
                _valueElementsCache.Clear();

                IReadOnlyDictionary<int, object> values = this.context?.Values;
                if (values == null)
                    return _valueElementsCache;

                foreach ((int id, object value) in values)
                {
                    string name = ContextUtils.IdToString(id);
                    _valueElementsCache.Add(new ValueElement(name, value, id));
                }

                return _valueElementsCache;
            }

            set
            {
                /** noting... **/
            }
        }

        private void RemoveValueElement(ValueElement valueElement)
        {
            if (this.context != null) this.DelValue(valueElement.id);
        }

        private void RemoveValueElementAt(int index)
        {
            if (this.context != null) this.DelValue(this.ValuesDebug[index].id);
        }

        ///Logics
        private static readonly List<SystemElement> _systemElementsCache = new();

        [InlineProperty]
        private struct SystemElement
        {
            [ShowInInspector, ReadOnly, HideLabel]
            public string name;

            internal readonly IContextSystem value;

            public SystemElement(IContextSystem value)
            {
                this.name = value.GetType().Name;
                this.value = value;
            }
        }

        [Searchable]
        [FoldoutGroup("Debug")]
        [LabelText("Systems")]
        [ShowInInspector, PropertyOrder(100)]
        [ListDrawerSettings(
            CustomRemoveElementFunction = nameof(RemoveSystemElement),
            CustomRemoveIndexFunction = nameof(RemoveSystemElementAt)
        )]
        private List<SystemElement> SystemsDebug
        {
            get
            {
                _systemElementsCache.Clear();

                IReadOnlyCollection<IContextSystem> logics = this.context?.Systems;
                if (logics == null)
                    return _systemElementsCache;

                foreach (var system in logics) 
                    _systemElementsCache.Add(new SystemElement(system));

                return _systemElementsCache;
            }
            set
            {
                /** noting... **/
            }
        }
        
        [FoldoutGroup("Debug")]
        [ShowInInspector, PropertyOrder(100)]
        [Button("Add System"), HideInEditorMode]
        private void AddSystemDebug(IContextSystem system) => this.context.AddSystem(system);

        [FoldoutGroup("Debug")]
        [ShowInInspector, PropertyOrder(100)]
        [Button("Add Value"), HideInEditorMode]
        private void AddValueDebug(int key, object value) => this.context.AddValue(key, value);

        private void RemoveSystemElement(SystemElement systemElement)
        {
            if (this.context != null) this.DelSystem(systemElement.value);
        }

        private void RemoveSystemElementAt(int index)
        {
            if (this.context != null) this.DelSystem(this.SystemsDebug[index].value);
        }

        [ShowInInspector, PropertyOrder(100)]
        [GUIColor(0f, 0.83f, 1f)]
        [Button("Test Install"), HideInPlayMode]
        private void InstallDebug()
        {
            this.InstallInternal(this.initialParent);
        }
    }
}

#endif
