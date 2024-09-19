using UnityEngine;

public class Planet : MonoBehaviour
{
    public const string PlanetTag = "Planet";
    public const float GravityForce = 9.81f;
    public CircleRadius circleRadius;       // 행성의 반지름을 구하기 위한 스크립트
    public ReboundCtrl reboundCtrl;         // 행성에 닿았을 때 반발 효과를 주기 위한 스크립트
    public Gravity gravity;                 // 중력을 적용하기 위한 스크립트

    public float gravityPower = 1f;         // 중력의 세기
    private float groundRadius;             // 중력의 범위
    public float minScale = 1;              // 중력의 최소 크기
    public float maxScale = 5;              // 중력의 최대 크기

    public Vector2 gravityNormalVector = Vector2.zero;      // 현재 중력의 방향
    public float distance;                                  // 현재 중력의 거리
    public float scalar;                                    // 현재 중력이 적용되는 크기

    void Start()
    {
        TryGetComponent(out circleRadius);
        transform.GetChild(0).TryGetComponent(out gravity);
        TryGetComponent(out reboundCtrl);

        circleRadius.radius = groundRadius;

        // 중력 스크립트에 필요한 변수들을 이 클래스에서 직접 초기화
        gravity.gravityPower = gravityPower;
        gravity.groundRadius = groundRadius;
        gravity.minScale = minScale;
        gravity.maxScale = maxScale;
    }

    void Update()
    {
        // 중력 스크립트에서 적용된 변수들을 이 클래스로 가져오기. Bird.cs에서 사용하기 위함.
        gravityNormalVector = gravity.gravityNormalVector;
        distance = gravity.distance;
        scalar = gravity.scalar;
    }
}
