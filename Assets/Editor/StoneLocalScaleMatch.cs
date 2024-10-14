using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Stone))]
public class StoneLocalScaleMatch : Editor
{
    public override void OnInspectorGUI()
    {
        Stone stone = (Stone)target;

        DrawDefaultInspector();

        if (stone.TryGetComponent(out Transform tr))
            tr.localScale = new Vector3((int)stone.state, (int)stone.state, 1);

        if (GUI.changed)
            EditorUtility.SetDirty(stone);
    }
}