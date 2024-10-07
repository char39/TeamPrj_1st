using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(IceStone))]
public class IceStoneLocalScaleMatch : Editor
{
    public override void OnInspectorGUI()
    {
        IceStone ice = (IceStone)target;

        // 기본 인스펙터 그리기
        DrawDefaultInspector();

        // SpriteRenderer와 Collider 크기 변경
        if (ice.TryGetComponent(out Transform tr))
            tr.localScale = new Vector3((int)ice.state, (int)ice.state, 1);

        // 변경 사항이 있을 경우 씬을 다시 그리도록 설정
        if (GUI.changed)
            EditorUtility.SetDirty(ice);
    }
}