using UnityEngine;

public class Planet : MonoBehaviour
{
    public const string PlanetTag = "Planet";
    public const float GravityForce = 9.81f;
    private CircleRadius circleRadius;       // 행성의 반지름을 구하기 위한 스크립트
    private Gravity gravity;                 // 중력을 적용하기 위한 스크립트

    [Range(0, 10)]
    public float gravityPower = 1f;         // 중력의 세기
    private float groundRadius;             // 중력의 범위
    [Range(0, 5)]
    public float minScale = 1;              // 중력의 최소 크기
    [Range(1, 10)]
    public float maxScale = 5;              // 중력의 최대 크기

    void Start()
    {
        TryGetComponent(out circleRadius);
        transform.GetChild(0).TryGetComponent(out gravity);

        groundRadius = circleRadius.radius;

        // 중력 스크립트에 필요한 변수들을 이 클래스에서 직접 초기화
        gravity.gravityPower = gravityPower;
        gravity.groundRadius = groundRadius;
        gravity.minScale = minScale;
        gravity.maxScale = maxScale;
    }

    void Update()
    {
        // 중력 스크립트에 필요한 변수들을 이 클래스에서 직접 초기화
        if (gravity.gravityPower != gravityPower)
            gravity.gravityPower = gravityPower;
        if (gravity.groundRadius != groundRadius)
            gravity.groundRadius = groundRadius;
        if (gravity.minScale != minScale)
            gravity.minScale = minScale;
        if (gravity.maxScale != maxScale)
            gravity.maxScale = maxScale;
    }
}
