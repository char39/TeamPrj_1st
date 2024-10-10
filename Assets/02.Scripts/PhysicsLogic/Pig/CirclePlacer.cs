using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePlacer : MonoBehaviour
{
    [SerializeField] private GameObject stonePref;
    [SerializeField] private GameObject woodPref;
    private int objCnt = 10;
    private float radius = 5f;
    private GameObject group;

    void Start()
    {
        // WoodGroup을 미리 생성
        group = new GameObject("Group");
        group.transform.parent = this.transform;
        group.transform.localPosition = Vector3.zero;
        PlaceObjectsInCircle();
    }

    void PlaceObjectsInCircle()
    {
        for (int i = 0; i < objCnt; i++)
        {
            // 각 오브젝트의 각도를 계산
            float angle = i * Mathf.PI * 2 / objCnt;

            // 원의 좌표 계산
            float x = Mathf.Cos(angle) * radius + transform.position.x; // x 좌표
            float y = Mathf.Sin(angle) * radius + transform.position.y; // y 좌표

            GameObject selectedPrefab = Random.Range(0, 2) == 0 ? stonePref : woodPref;
            GameObject obj = Instantiate(selectedPrefab, new Vector2(x, y), Quaternion.identity);
            obj.transform.parent = group.transform;
            obj.transform.Rotate(0, 0, angle * Mathf.Rad2Deg + 90);
        }
    }
}
