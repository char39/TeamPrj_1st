using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePlacer : MonoBehaviour
{
    [SerializeField] private GameObject stonePref; // 배치할 돌 오브젝트 프리팹
    [SerializeField] private GameObject woodPref;  // 배치할 나무 오브젝트 프리팹
    private int objectCount = 10; // 배치할 오브젝트 개수
    private float radius = 5f; // 원의 반지름
    private GameObject group; // WoodGroup 오브젝트

    void Start()
    {
        // WoodGroup을 미리 생성
        group = new GameObject("Group");
        group.transform.parent = this.transform;
        
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
            float y = Mathf.Sin(angle) * radius + transform.position.y; // y 좌표

            // stonePref 또는 woodPref 중 하나를 랜덤으로 선택
            GameObject selectedPrefab = Random.Range(0, 2) == 0 ? stonePref : woodPref;

            // 선택한 프리팹을 인스턴스화
            GameObject obj = Instantiate(selectedPrefab, new Vector2(x, y), Quaternion.identity);
            obj.transform.parent = group.transform;
            obj.transform.Rotate(0, 0, angle * Mathf.Rad2Deg + 90);
        }
    }
}
