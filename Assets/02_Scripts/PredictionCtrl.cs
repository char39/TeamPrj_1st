using System.Collections.Generic;
using UnityEngine;

public class PredictionCtrl : MonoBehaviour
{
    public SlingShot _slingshot;                       // SlingShot 참조
    public GameObject preBirdPrefab;                    // 경로를 표시할 작은 Bird 프리팹
    private int predictionPointsCount = 10;             // 경로에 표시할 점 개수
    private float timeStep = 0.3f;                      // 시뮬레이션 시간 간격
    public Vector2 launchPoint;                          // 발사 위치
    public float gravityScale = 1.0f;                   // 중력 계수

    private List<GameObject> predictionPoints = new List<GameObject>(); // 예측된 위치에 나타날 작은 Bird들
    private Gravity gravity;                             // Gravity 인스턴스

    void Start()
    {
        _slingshot = GetComponent<SlingShot>();
        gravity = FindObjectOfType<Gravity>(); // Gravity 컴포넌트 찾기

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
        launchPoint = _slingshot.launchPos; // 발사 위치 업데이트
    }

    // 경로 계산 및 점 보여주기
    public void ShowPrediction(Vector2 startVelocity)
{
    Vector2 currentPos = launchPoint;
    Vector2 currentVelocity = startVelocity;

    // 중력장이 없을 때는 중력 벡터를 사용하지 않음
    Vector2 gravityForce = Vector2.zero;
    if (gravity != null)
    {
        gravityForce = gravity.gravityNormalVector * gravity.gravityPower * gravity.scalar;
    }

    // PreBird의 속도를 가져오기
    PreBird preBird = FindObjectOfType<PreBird>();
    if (preBird != null)
    {
        currentVelocity += preBird.setVelocity;  // PreBird의 setVelocity를 currentVelocity에 추가
    }

    for (int i = 0; i < predictionPointsCount; i++)
    {
        // 예측된 위치에 작은 Bird 오브젝트 배치
        predictionPoints[i].transform.position = currentPos;
        predictionPoints[i].SetActive(true);  // 점 보이게

        // 중력 적용
        currentVelocity += gravityForce * timeStep;  // 중력에 의한 속도 변화

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
