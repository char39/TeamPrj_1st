using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GravityFieldRadius))]
public class GravityFieldRadiusMatch : Editor
{
    public override void OnInspectorGUI()
    {
        GravityFieldRadius G_Radius = (GravityFieldRadius)target;

        DrawDefaultInspector();

        // size 슬라이더 추가
        //G_Radius.radius = EditorGUILayout.Slider("Radius", G_Radius.radius, 1f, 300f);
        //G_Radius.gravityPower = EditorGUILayout.Slider("Gravity Power", G_Radius.gravityPower, 0f, 50f);

        if (G_Radius.transform.GetChild(1).TryGetComponent(out SpriteRenderer spriteRenderer) && spriteRenderer.size.x != G_Radius.radius)
            spriteRenderer.size = new Vector2(G_Radius.radius, G_Radius.radius);



        Transform parentTr = G_Radius.transform.GetChild(1);
        if (parentTr != null && parentTr.CompareTag("Gravity"))
        {
            foreach (Transform childTr in parentTr)
            {
                foreach (Transform grandChildTr in childTr)
                {
                    foreach (Transform greatGrandChildTr in grandChildTr)
                    {
                        greatGrandChildTr.localPosition = new Vector3(-(G_Radius.radius / 2f), 0, 0);
                        greatGrandChildTr.localScale = new Vector3(G_Radius.radius / 7, G_Radius.radius / 7, G_Radius.radius / 7);
                    }
                }
            }
        }

        // 변경 사항이 있을 경우 씬을 다시 그리도록 설정
        if (GUI.changed)
            EditorUtility.SetDirty(G_Radius);
    }
}