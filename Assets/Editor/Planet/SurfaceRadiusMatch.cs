using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SurfaceRadius))]
public class SurfaceRadiusMatch : Editor
{
    public override void OnInspectorGUI()
    {
        SurfaceRadius S_Radius = (SurfaceRadius)target;

        DrawDefaultInspector();

        // size 슬라이더 추가
        S_Radius.radius = EditorGUILayout.Slider("Radius", S_Radius.radius, 1f, 300f);

        if (S_Radius.transform.GetChild(0).TryGetComponent(out SpriteRenderer spriteRenderer) && spriteRenderer.size.x != S_Radius.radius)
            spriteRenderer.size = new Vector2(S_Radius.radius, S_Radius.radius);

        if (S_Radius.transform.GetChild(0).TryGetComponent(out CircleCollider2D collider) && collider.radius != S_Radius.radius / 2f)
            collider.radius = S_Radius.radius / 2f;

        // 변경 사항이 있을 경우 씬을 다시 그리도록 설정
        if (GUI.changed)
            EditorUtility.SetDirty(S_Radius);
    }
}