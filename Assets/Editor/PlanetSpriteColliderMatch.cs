using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CircleRadius))]
public class PlanetSpriteColliderMatch : Editor
{
    public override void OnInspectorGUI()
    {
        CircleRadius circle = (CircleRadius)target;

        // 기본 인스펙터 그리기
        DrawDefaultInspector();

        // size 슬라이더 추가
        circle.radius = EditorGUILayout.Slider("Radius", circle.radius, 1f, 300f);

        // SpriteRenderer와 Collider 크기 변경
        if (circle.TryGetComponent(out SpriteRenderer spriteRenderer))
            spriteRenderer.size = new Vector2(circle.radius, circle.radius);

        if (circle.TryGetComponent(out CircleCollider2D collider))
            collider.radius = circle.radius / 2f;

        Transform parentTr = circle.transform;
        if (parentTr != null && parentTr.CompareTag("PlanetGravity"))
        {
            foreach (Transform childTr in parentTr)
            {
                foreach (Transform grandChildTr in childTr)
                {
                    foreach (Transform greatGrandChildTr in grandChildTr)
                    {
                        greatGrandChildTr.localPosition = new Vector3(-(circle.radius / 2f), 0, 0);
                        greatGrandChildTr.localScale = new Vector3(circle.radius / 7, circle.radius / 7, circle.radius / 7);
                    }
                }
            }
        }

        // 변경 사항이 있을 경우 씬을 다시 그리도록 설정
        if (GUI.changed)
            EditorUtility.SetDirty(circle);
    }
}