using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public GameObject birdPrefab;   // 프리팹
    public Transform launchPoint;
    public float launchForce = 4f;  // 발사 힘
    public float maxStretch = 2f;   // 새총의 최대 늘어남 거리
    //public LineRendererCtrl _lineRendererCtrl;

    private _Bird _bird;

    private Vector2 startPos;          // 새총 본체. bird 생성될 때 위치
    private Camera cam;
    private GameObject bird;         // 현재 당기고 있는 bird 인스턴스
    private Rigidbody2D birdRb;      // 현재 bird Rigidbody2D
    private bool isStretching = false;

    void Start()
    {
        cam = Camera.main;
        startPos = transform.GetChild(2).transform.position;

        if (launchPoint == null)
        {
            GameObject temp = new GameObject("LaunchPoint");
            launchPoint = temp.transform;
            launchPoint.position = startPos;
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isStretching = true;
            CreateBird();    // bird 생성
            StretchPosition();  // 새총 당기기 처리

            // if (_lineRendererCtrl != null)
            //     _lineRendererCtrl.UpdateLineRenderer(bird.transform.position, startPos);  // 가이드라인 업데이트
        }

        else if (Input.GetMouseButtonUp(0) && isStretching)
        {
            Shoot();  // 발사
            isStretching = false;
            // if (_lineRendererCtrl != null)
            //     _lineRendererCtrl.HideLineRenderer();  // 발사 후 가이드라인 비활성화
        }
    }

    // Bird 생성
    void CreateBird()
    {
        if (bird == null)
        {
            bird = Instantiate(birdPrefab, startPos, Quaternion.identity);
            birdRb = bird.GetComponent<Rigidbody2D>();
            birdRb.isKinematic = true;  // 당기는 동안 물리 영향 받지 않도록 설정
        }
    }

    // 새총 당기기 처리
    void StretchPosition()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 stretch = mousePos - startPos;
        //  float stretchDistance = Mathf.Min(stretch.magnitude, maxStretch);
        float stretchDistance = Mathf.Clamp(stretch.magnitude, 0f, maxStretch);
        launchPoint.position = startPos + (Vector2)(stretch.normalized * stretchDistance);

        if (bird != null)
            bird.transform.position = launchPoint.position;
    }

    // 발사 처리
    void Shoot()
    {
        if (bird != null)
        {
            _bird = bird.GetComponent<_Bird>();
            Vector2 direction = startPos - (Vector2)launchPoint.position;
            float distance = direction.magnitude;
            direction.Normalize();

            // Rigidbody2D의 velocity를 직접 설정하여 발사
            birdRb.isKinematic = false;  // 물리 엔진의 영향을 받도록 설정
            _bird.setVelocity = direction * launchForce * distance;
            Debug.Log(birdRb.velocity);

            bird = null;  // 발사 후 현재 Bird를 null로 설정
        }

        // 새총을 원래 위치로
        launchPoint.position = startPos;
    }
}
