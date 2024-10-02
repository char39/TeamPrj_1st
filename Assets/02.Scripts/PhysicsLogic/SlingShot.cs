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

    [Range(1, 8)]
    public int launchForce = 4;
    [Range(1, 8)]
    public int maxStretch = 1;

    public bool isMouseOn = false;         // 당기기 전에 마우스가 위에 있는가
    public bool isClicked = false;         // 새를 클릭 했는가
    public bool isStretching = false;      // 당기고 있는가
    public bool isSpawn = false;           // preBird가 스폰이 됐는가

    void Start()
    {
        birdPref = Resources.Load<GameObject>("Bird");
        preBirdPref = Resources.Load<GameObject>("PreBird");
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
    }
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

    private void CreatePreBird()
    {
        if (preBirdObj != null && isSpawn) return;
        preBirdObj = Instantiate(preBirdPref, startPos, Quaternion.identity);
        isSpawn = true;
    }

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
            isStretching = false;
            isClicked = false;

            Destroy(preBirdObj);
            preBirdObj = null;
            
            isSpawn = false;
            CreateBird();

            _bird = birdObj.GetComponent<Bird>();
            direction = startPos - launchPos;
            float distance = direction.magnitude;
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            _bird.setVelocity = distance * launchForce * direction;
            _bird.IsShot = true;
            if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) <= 180)
                _bird.Flip();

            birdObj = null;

            Invoke(nameof(CreatePreBird), 1f);
        }
        launchPos = startPos;
    }
}
