using UnityEngine;

public class SlingShot : MonoBehaviour
{
    private Bird _bird;

    private GameObject birdPref;
    private GameObject preBirdPref;

    private GameObject birdObj;
    private GameObject preBirdObj;

    private Vector2 launchPos;  // 변수. 마우스로 당기는 발사 위치
    private Vector2 startPos;   // 변수이긴 하나, launchPos부터 startPos까지의 방향벡터 계산용. 1회 할당
    private Vector2 direction;

    [Range(0, 20)]
    public int launchForce = 5;
    [Range(2, 6)]
    public int maxStretch = 3;

    public bool isMouseOn = false;         // 당기기 전에 마우스가 위에 있는가
    public bool isClicked = false;         // 새를 클릭 했는가
    public bool isStretching = false;      // 당기고 있는가
    public bool isSpawn = false;           // preBird가 스폰이 됐는가

    void Start()
    {
        birdPref = BirdPrefs.birds[1];
        preBirdPref = BirdPrefs.preBirds[1];

        launchPos = new Vector2(transform.position.x, transform.position.y);
        startPos = launchPos;
        CreatePreBird();
    }

    void Update()
    {
        IsMouseInBird();
        if (Input.GetMouseButtonDown(0) && isMouseOn && !isClicked)
            OnBeginDrag();
        if (Input.GetMouseButton(0))
            OnDrag();
        if (Input.GetMouseButtonUp(0))
            OnEndDrag();
        //startPos = launchPos; //테스트
    }

    /// <summary> 마우스가 preBirdObj 위에 있는지 확인. </summary>
    private void IsMouseInBird()
    {
        if (!Input.GetMouseButton(0)) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit.collider != null && preBirdObj != null && hit.collider == preBirdObj.GetComponent<Collider2D>())
            isMouseOn = true;
        else
            isMouseOn = false;
    }

    /// <summary> preBirdObj(상호작용 없는 객체) 생성 </summary>
    private void CreatePreBird()
    {
        if (preBirdObj != null && isSpawn) return;
        preBirdObj = Instantiate(preBirdPref, startPos, Quaternion.identity);
        isSpawn = true;
    }

    /// <summary> 실제 발사를 위한 birdObj 생성 </summary>
    private void CreateBird()
    {
        if (birdObj != null) return;
        birdObj = Instantiate(birdPref, launchPos, Quaternion.identity);
    }

    public void OnBeginDrag()
    {
        if (isMouseOn)
            isClicked = true;
    }

    public void OnDrag()
    {
        if (isClicked)
        {
            isStretching = true;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 stretch = mousePos - startPos;

            float stretchDistance = Mathf.Clamp(stretch.magnitude, 0f, maxStretch);
            launchPos = startPos + (stretch.normalized * stretchDistance);

            float angle = Mathf.Atan2(stretch.normalized.y, stretch.normalized.x) * Mathf.Rad2Deg;

            if (preBirdObj != null)
            {
                preBirdObj.transform.position = launchPos;
                preBirdObj.transform.localRotation = Quaternion.Euler(0, 0, angle);

                preBirdObj.GetComponent<SpriteRenderer>().flipX = true;
                preBirdObj.GetComponent<SpriteRenderer>().flipY = Mathf.Abs(angle) > 90 && Mathf.Abs(angle) <= 180;
            }
        }
    }

    public void OnEndDrag()
    {
        if (isClicked && isStretching)
        {
            // 초기화 작업
            isClicked = false;
            isStretching = false;
            Destroy(preBirdObj);
            preBirdObj = null;
            isSpawn = false;

            // birdObj 생성 및 _bird 초기화
            CreateBird();
            _bird = birdObj.GetComponent<Bird>();

            // 발사 방향 및 거리 계산
            direction = startPos - launchPos;
            float distance = direction.magnitude;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // 발사
            Vector2 finalLaunchForce = distance * launchForce * direction;
            Vector2 adjustedLaunchForce = birdObj.GetComponent<Rigidbody2D>().mass * finalLaunchForce;
            birdObj.GetComponent<Rigidbody2D>().AddForce(adjustedLaunchForce, ForceMode2D.Impulse);

            // 발사 후 birdObj의 방향 설정
            if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) <= 180)
                _bird.FlipY();

            // birdObj 초기화
            birdObj = null;

            // preBirdObj 생성
            Invoke(nameof(CreatePreBird), 1f);
        }
        launchPos = startPos;
    }
}
