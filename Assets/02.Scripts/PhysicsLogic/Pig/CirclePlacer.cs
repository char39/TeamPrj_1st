using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePlacer : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab; // 배치할 오브젝트 프리팹
    private int objectCount = 10; // 배치할 오브젝트 개수
    private float radius = 5f; // 원의 반지름
    private GameObject woodGroup; // WoodGroup 오브젝트

    void Start()
    {
        // WoodGroup을 미리 생성
        woodGroup = new GameObject("WoodGroup");
        
        PlaceObjectsInCircle();
    }

    void PlaceObjectsInCircle()
    {
        // 오브젝트를 원형으로 배치
        for (int i = 0; i < objectCount; i++)
        {
            // 각 오브젝트의 각도를 계산
            float angle = i * Mathf.PI * 2 / objectCount;

            // 원의 좌표 계산
            float x = Mathf.Cos(angle) * radius; // x 좌표
            float y = Mathf.Sin(angle) * radius; // y 좌표

            GameObject obj = Instantiate(objectPrefab, new Vector2(x, y), Quaternion.identity);
            obj.transform.parent = woodGroup.transform;
            obj.transform.Rotate(0, 0, angle * Mathf.Rad2Deg + 90);
        }
    }
}
