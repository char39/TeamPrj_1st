using UnityEngine;

public class MoveCameraByDrag : MonoBehaviour
{
    private SpriteRenderer bgSprite;
    private SlingShot _slingshot;
    private Camera _cam;

    public Vector2 min, max;
    private Vector3 lastMousePosition;
    private Vector3 delta;
    private Vector3 move;
    private Vector3 limitCamPos;
    internal float moveSpeed = 1f;

    internal float time = 2f;
    private float timer = 0f;
    public bool isDragging = false;
    public bool isMouseOn = false;

    void Start()
    {
        _cam = Camera.main;
        _slingshot = GameObject.Find("SlingShot").GetComponent<SlingShot>();
        bgSprite = GameObject.Find("BG").GetComponent<SpriteRenderer>();

        // 카메라 이동 가능한 범위 계산
        CalculateCameraBounds();
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        DragCheck();
        GetMouseCondition();
        MoveCamera();
    }

    // 배경 이미지 크기와 카메라 크기를 기반으로 이동 가능한 범위 계산
    private void CalculateCameraBounds()
    {
        // 카메라 절반 크기 계산 (카메라의 뷰포트 크기)
        float camHeight = _cam.orthographicSize * 2f;
        float camWidth = camHeight * _cam.aspect;

        // 카메라가 이동할 수 있는 최소, 최대 범위 설정
        min = new Vector2(bgSprite.bounds.min.x + camWidth / 2, bgSprite.bounds.min.y + camHeight / 2);
        max = new Vector2(bgSprite.bounds.max.x - camWidth / 2, bgSprite.bounds.max.y - camHeight / 2);
    }

    private void GetMouseCondition()
    {
        if (_slingshot.isStretching || _slingshot.isMouseOn) return;

        if (Input.GetMouseButtonDown(0))
        {
            isMouseOn = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            delta = Input.mousePosition - lastMousePosition;
            if (delta != Vector3.zero)
            {
                isDragging = true;
                move = moveSpeed * Time.deltaTime * new Vector3(-delta.x, 0, 0);
                lastMousePosition = Input.mousePosition;
            }
            isMouseOn = false;
        }
        else
            isMouseOn = false;
    }

    private void MoveCamera()
    {
        if (!isDragging) return;
        _cam.transform.Translate(move);

        // 카메라 이동 범위 제한
        limitCamPos = _cam.transform.position;
        limitCamPos.x = Mathf.Clamp(limitCamPos.x, min.x, max.x);
        limitCamPos.y = Mathf.Clamp(limitCamPos.y, min.y, max.y);
        _cam.transform.position = limitCamPos;
    }

    private void DragCheck()
    {
        if (!isMouseOn)
        {
            timer += Time.deltaTime;
            if (timer > time)
            {
                isDragging = false;
                timer = 0f;
            }
        }
        else
            timer = 0f;
    }
}
