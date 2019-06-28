using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

public class NewBehaviourScript : MonoBehaviour
{
    public List<GameObject> colliderHolders = new List<GameObject>();

    [ContextMenu("Create PlaceHolder Colliders")]
    public void CreateGameObjects()
    {
        var selected = Selection.activeObject as GameObject;
        var colliders = selected.GetComponents<BoxCollider>();
        foreach(var col in colliders)
        {
            var go = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity, selected.transform);
            var go_col = go.AddComponent<BoxCollider>();
            EditorUtility.CopySerialized(col, go_col);
            colliderHolders.Add(go);
        }
    }

    [ContextMenu("Remove Colliders")]
    public void RemoveAllColliders()
    {
        var selected = Selection.activeObject as GameObject;
        
        var colliders = selected.GetComponents<BoxCollider>();
        foreach (var col in colliders)
        {
            DestroyImmediate(col);

        }
    }

  
}
#endif
