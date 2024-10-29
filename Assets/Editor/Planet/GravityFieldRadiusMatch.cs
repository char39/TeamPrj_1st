using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GravityFieldRadius))]
public class GravityFieldRadiusMatch : Editor
{
    public override void OnInspectorGUI()
    {
        GravityFieldRadius G_Radius = (GravityFieldRadius)target;

        DrawDefaultInspector();

        if (G_Radius.transform.GetChild(1).TryGetComponent(out SpriteRenderer spriteRenderer) && spriteRenderer.size.x != G_Radius.radius)
            spriteRenderer.size = new Vector2(G_Radius.radius, G_Radius.radius);

        Transform parentTr = G_Radius.transform.GetChild(1);
        if (parentTr != null && parentTr.CompareTag("Gravity"))
            foreach (Transform childTr in parentTr)
                foreach (Transform grandChildTr in childTr)
                    foreach (Transform greatGrandChildTr in grandChildTr)
                    {
                        greatGrandChildTr.localPosition = new Vector3(-(G_Radius.radius / 2f), 0, 0);
                        greatGrandChildTr.localScale = new Vector3(G_Radius.radius / 7, G_Radius.radius / 7, G_Radius.radius / 7);
                    }

        if (GUI.changed)
            EditorUtility.SetDirty(G_Radius);
    }
}