using UnityEngine;

public class SlingShot : MonoBehaviour
{
    private Bird _bird;

    private Vector2 startPos;            // 새총 본체 위치
    private Camera cam;                  // 카메라
    private GameObject birdObj;          // 현재 당기고 있는 bird 인스턴스
    private Rigidbody2D birdRb;          // 현재 bird의 Rigidbody2D

    public GameObject birdPrefab;        // 프리팹
    public Vector2 launchPos;            // 발사 위치
    internal float launchForce = 4f;     // 발사 힘
    internal float maxStretch = 2f;      // 새총의 최대 늘어남 거리
    public bool isStretching = false;    // 당기고 있는지 여부
    public LineRenderer lineRenderer;     // 경로를 그리기 위한 LineRenderer
    public Gravity gravity;               // Gravity 스크립트 참조

    void Start()
    {
        cam = Camera.main;
        startPos = new Vector2(transform.position.x, transform.position.y);
        launchPos = new Vector2(startPos.x, startPos.y);
        CreateBird();    // bird 생성

        // LineRenderer 설정
        lineRenderer.positionCount = 30; // 포인트 수 설정
        lineRenderer.enabled = false;     // 처음에는 비활성화
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isStretching = true;
            StretchPosition();  // 새총 당기기 처리
            DrawTrajectory();    // 예상 궤적 그리기
        }
        else if (Input.GetMouseButtonUp(0) && isStretching)
        {
            Shoot();  // 발사
            isStretching = false;
            lineRenderer.enabled = false; // 발사 후 궤적 비활성화
            Invoke(nameof(CreateBird), 1f);  // 1초 후 Bird 생성
        }
    }

    // Bird 생성
    void CreateBird()
    {
        if (birdObj == null)
        {
            birdObj = Instantiate(birdPrefab, startPos, Quaternion.identity);
            birdRb = birdObj.GetComponent<Rigidbody2D>();
            birdRb.isKinematic = true;  // 당기는 동안 물리 영향 받지 않도록 설정
        }
    }

    // 새총 당기기 처리
    void StretchPosition()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 stretch = mousePos - startPos;

        float stretchDistance = Mathf.Clamp(stretch.magnitude, 0f, maxStretch);
        launchPos = startPos + (Vector2)(stretch.normalized * stretchDistance);

        if (birdObj != null)
            birdObj.transform.position = launchPos;
    }

    // 발사 처리
    void Shoot()
    {
        if (birdObj != null)
        {
            _bird = birdObj.GetComponent<Bird>();
            Vector2 direction = startPos - launchPos;
            float distance = direction.magnitude;
            direction.Normalize();

            // Rigidbody2D의 velocity를 직접 설정하여 발사
            birdRb.isKinematic = false;  // 물리 엔진의 영향을 받도록 설정
            _bird.setVelocity = direction * launchForce * distance;

            birdObj = null;  // 발사 후 현재 Bird를 null로 설정
        }

        // 새총을 원래 위치로
        launchPos = startPos;
    }

    // 예상 궤적 그리기
    void DrawTrajectory()
    {
        lineRenderer.enabled = true; // 궤적 활성화
        Vector2 direction = startPos - launchPos; // 발사 방향
        float distance = direction.magnitude; // 발사 거리
        direction.Normalize(); // 방향 정규화

        // 궤적 포인트 계산
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            float t = i * 0.1f; // 시간 비율
            Vector2 trajectoryPoint = launchPos + direction * launchForce * distance * t; // 초기 위치

            // 시간에 따른 중력 영향 적용
            if (IsInGravityField(trajectoryPoint))
            {
                Vector2 gravityEffect = Vector2.down * gravity.gravityPower * t * t; // 중력의 효과
                trajectoryPoint += gravityEffect; // 중력 추가
            }

            // 궤적 포지션 설정
            lineRenderer.SetPosition(i, trajectoryPoint); // 포지션 설정
        }
    }

    // 중력장에 있는지 체크 (태그 사용)
    private bool IsInGravityField(Vector2 position)
    {
        // 중력장 오브젝트를 체크
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.1f); // 작은 반경으로 체크
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("PlanetGravity")) // 태그가 'PlanetGravity'인지 확인
            {
                return true; // 중력장 안에 있다면 true
            }
        }
        return false; // 중력장 안에 없다면 false
    }
}
