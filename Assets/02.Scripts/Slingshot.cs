using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public PredictionCtrl _prediction;

    private Vector2 startPos;            // 새총 본체 위치
    private Camera cam;                  // 카메라
    private GameObject bird;             // 현재 당기고 있는 bird 인스턴스
    private Rigidbody2D birdRb;          // 현재 bird의 Rigidbody2D

    public GameObject birdPrefab;        // 프리팹
    public Vector2 launchPos;            // 발사 위치
    public float launchForce = 4f;       // 발사 힘
    public float maxStretch = 2f;        // 새총의 최대 늘어남 거리
    public bool isStretching = false;    // 당기고 있는지 여부


    void Start()
    {
        cam = Camera.main;
        startPos = GameObject.Find("startPosition").transform.position;
        launchPos = new Vector2(startPos.x, startPos.y);
        _prediction = GetComponent<PredictionCtrl>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isStretching = true;
            CreateBird();    // bird 생성
            StretchPosition();  // 새총 당기기 처리

            // 현재 속도로 경로 예측
            Vector2 direction = startPos - launchPos;
            float distance = direction.magnitude;
            direction.Normalize();
            if (_prediction != null)
                _prediction.ShowPrediction(direction * launchForce * distance);
        }

        else if (Input.GetMouseButtonUp(0) && isStretching)
        {
            Shoot();  // 발사
            isStretching = false;

            // 경로 예측 숨기기
            if (_prediction != null)
                _prediction.HidePrediction();
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
        launchPos = startPos + stretch.normalized * stretchDistance;

        if (bird != null)
            bird.transform.position = launchPos;
    }

    // 발사 처리
    void Shoot()
    {
        if (bird != null)
        {
            Vector2 direction = startPos - launchPos;
            float distance = direction.magnitude;
            direction.Normalize();

            // Rigidbody2D의 velocity를 직접 설정하여 발사
            birdRb.isKinematic = false;  // 물리 엔진의 영향을 받도록 설정
            birdRb.velocity = direction * launchForce * distance;
            Debug.Log(birdRb.velocity);

            ParticleSystem Burner = bird.GetComponent<Bird>().burner;
            ShowParticleSystem(Burner);

            bird = null;  // 발사 후 현재 Bird를 null로 설정
        }

        // 새총을 원래 위치로
        launchPos = startPos;
    }

    void ShowParticleSystem(ParticleSystem burner) => burner.Play();
}