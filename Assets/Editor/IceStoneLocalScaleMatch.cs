using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(IceStone))]
public class IceStoneLocalScaleMatch : Editor
{
    public override void OnInspectorGUI()
    {
        IceStone ice = (IceStone)target;

        DrawDefaultInspector();

        if (ice.TryGetComponent(out Transform tr))
            tr.localScale = new Vector3((int)ice.state, (int)ice.state, 1);

        if (GUI.changed)
            EditorUtility.SetDirty(ice);
    }
}
