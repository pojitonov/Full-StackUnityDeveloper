#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Atomic.Entities
{
    public partial class SceneEntity
    {
        [Header("Gizmos")]
        [SerializeField]
        private bool _onlySelectedGizmos;

        [SerializeField]
        private bool _onlyEditModeGizmos;

        [Tooltip("Specify the gizmos in editor mode")]
        [Space, SerializeField]
        private List<SceneEntityGizmos> gizmoses;

        private void OnDrawGizmos()
        {
            if (!_onlySelectedGizmos)
                this.OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            if (EditorApplication.isPlaying && _onlyEditModeGizmos)
                return;

            if (this.gizmoses == null)
                return;

            int count = this.gizmoses.Count;
            if (count == 0)
                return;
            
            for (int i = 0; i < count; i++)
            {
                SceneEntityGizmos gizmos = this.gizmoses[i];
                if (gizmos == null)
                {
                    Debug.LogWarning("SceneEntity: Ops! Detected null gizmos!", this);
                }
                else
                {
                    try
                    {
                        gizmos.OnGizmosDraw(this.entity);
                    }
                    catch (Exception e)
                    {
                        Debug.LogWarning($"Ops: detected exception in gizmos: {e.Message}");
                    }
                }
            }
        }
    }
}
#endif