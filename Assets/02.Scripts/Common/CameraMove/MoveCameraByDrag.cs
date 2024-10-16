using UnityEngine;

public class MoveCameraByDrag : MonoBehaviour
{
    private SlingShot _slingshot;

    private Camera cam;
    public SpriteRenderer bgSprite;

    public Vector2 min, max;
    private float speed = 5f;
    private float firstClickPointX = 0f;

    void Start()
    {
        cam = Camera.main;
        _slingshot = GameObject.Find("SlingShot").GetComponent<SlingShot>();
        bgSprite = GameObject.Find("BG").GetComponent<SpriteRenderer>();

        // 카메라 이동 가능한 범위 계산
        CalculateCameraBounds();
    }

    void Update() => MoveCamer();

    void MoveCamer()
    {
        if (_slingshot.isStretching) return;

        if (Input.GetMouseButtonDown(0))
        {
            firstClickPointX = Input.mousePosition.x;
            //Debug.Log(firstClickPointX);
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 pos = cam.ScreenToViewportPoint(-new Vector2(Input.mousePosition.x - firstClickPointX, 0));
            Vector2 move = speed * Time.deltaTime * pos;

            cam.transform.Translate(move);

            // 카메라 이동 범위 제한
            Vector3 limitCamPos = cam.transform.position;
            limitCamPos.x = Mathf.Clamp(limitCamPos.x, min.x, max.x);
            limitCamPos.y = Mathf.Clamp(limitCamPos.y, min.y, max.y);
            cam.transform.position = limitCamPos;
        }
    }

    // 배경 이미지 크기와 카메라 크기를 기반으로 이동 가능한 범위 계산
    void CalculateCameraBounds()
    {
        // 카메라 절반 크기 계산 (카메라의 뷰포트 크기)
        float camHeight = cam.orthographicSize * 2f;
        float camWidth = camHeight * cam.aspect;

        // 카메라가 이동할 수 있는 최소, 최대 범위 설정
        min = new Vector2(bgSprite.bounds.min.x + camWidth / 2, bgSprite.bounds.min.y + camHeight / 2);
        max = new Vector2(bgSprite.bounds.max.x - camWidth / 2, bgSprite.bounds.max.y - camHeight / 2);
    }
}
