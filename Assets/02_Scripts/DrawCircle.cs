using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    public Color color;
    private MeshFilter meshFilter;
    private readonly int segments = 100;
    
    public float circleRadius = 5;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        CreateCircle();
    }

    void CreateCircle()
    {
        Mesh mesh = new();
        Vector3[] vertices = new Vector3[segments + 1];
        int[] triangles = new int[segments * 3];
        Color[] colors = new Color[vertices.Length];

        vertices[0] = Vector3.zero;
        colors[0] = color;

        float angle = 0f;
        for (int i = 1; i <= segments; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * circleRadius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * circleRadius;
            vertices[i] = new Vector3(x, y, 0);
            colors[i] = color;

            if (i < segments)
            {
                triangles[(i - 1) * 3] = 0;
                triangles[(i - 1) * 3 + 1] = i;
                triangles[(i - 1) * 3 + 2] = i + 1;
            }
            else
            {
                triangles[(i - 1) * 3] = 0;
                triangles[(i - 1) * 3 + 1] = i;
                triangles[(i - 1) * 3 + 2] = 1;
            }
            angle += 360f / segments;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }







}