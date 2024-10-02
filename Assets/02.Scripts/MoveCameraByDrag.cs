using UnityEngine;

public class MoveCameraByDrag : MonoBehaviour
{
    SlingShot _slingshot;

    Transform tr;
    [SerializeField] private float speed = 5f;
    private float firstClickPointX = 0f;
    private Camera cam;

    void Start()
    {
        tr = transform;
        cam = Camera.main;
        _slingshot = GameObject.Find("LaunchPlanet").transform.GetChild(0).GetComponent<SlingShot>();
    }

    void Update()
    {
        MoveCamer();
    }

    void MoveCamer()
    {
        if (_slingshot.isStretching) return;

        if (Input.GetMouseButtonDown(0))
        {
            firstClickPointX = Input.mousePosition.x;
            Debug.Log(firstClickPointX);
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 pos = cam.ScreenToViewportPoint(-new Vector2(Input.mousePosition.x - firstClickPointX, 0));
            Vector2 move = speed * Time.deltaTime * pos;

            cam.transform.Translate(move);
        }
    }
}
