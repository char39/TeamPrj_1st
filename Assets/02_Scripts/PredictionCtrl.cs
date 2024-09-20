using System.Collections.Generic;
using UnityEngine;

public class PredictionCtrl : MonoBehaviour
{
    public SlingShot _slingshot;
    public GameObject preBirdPrefab;            // 경로를 표시할 작은 Bird 프리팹
    int predictionPointsCount = 10;   // 경로에 표시할 점 개수
    float timeStep = 0.3f;            // 시뮬레이션 시간 간격
    public Vector2 launchPoint;            // 발사 위치
    public float gravityScale = 1.0f;        // 중력 계수

    private List<GameObject> predictionPoints = new List<GameObject>();  // 예측된 위치에 나타날 작은 Bird들

    void Start()
    {
        _slingshot = GetComponent<SlingShot>();

        // 예측된 경로를 따라 작은 Bird들을 생성해 비활성화
        for (int i = 0; i < predictionPointsCount; i++)
        {
            GameObject point = Instantiate(preBirdPrefab, launchPoint, Quaternion.identity);
            point.SetActive(false);  // 처음엔 보이지 않도록 설정
            predictionPoints.Add(point);
        }
    }

    void Update()
    {
        launchPoint = _slingshot.launchPos;
    }

    // 경로 계산 및 점 보여주기
    public void ShowPrediction(Vector2 startVelocity)
    {
        Vector2 currentPos = launchPoint;
        Vector2 currentVelocity = startVelocity;

        for (int i = 0; i < predictionPointsCount; i++)
        {
            // 예측된 위치에 작은 Bird 오브젝트 배치
            predictionPoints[i].transform.position = currentPos;
            predictionPoints[i].SetActive(true);  // 점 보이게

            // 중력과 속도를 반영한 새 위치 계산
            currentVelocity += Physics2D.gravity * gravityScale * timeStep;  // 중력에 의한 속도 변화
            currentPos += currentVelocity * timeStep;  // 속도에 의한 위치 변화
        }
    }

    // 경로 예측 점을 숨기기
    public void HidePrediction()
    {
        foreach (var point in predictionPoints)
        {
            point.SetActive(false);
        }
    }
}
