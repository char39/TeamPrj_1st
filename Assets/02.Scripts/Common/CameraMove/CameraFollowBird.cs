using UnityEngine;

public class CameraFollowBird : MonoBehaviour
{
    private readonly string preBirdTag = "PreBird";

    Transform camTr;
    [SerializeField] MoveCameraByDrag _moveCam;

    void Start()
    {
        camTr = Camera.main.transform;
        _moveCam = FindObjectOfType<MoveCameraByDrag>();

        camTr.position = GameObject.FindWithTag(preBirdTag).transform.position;
    }

    void LateUpdate()
    {
        Bird[] birds = FindObjectsOfType<Bird>();
        Rigidbody2D[] rb = new Rigidbody2D[birds.Length];
        SlingShot slingShot = FindObjectOfType<SlingShot>();

        for (int i = 0; i < birds.Length; i++)
        {
            rb[i] = birds[i].GetComponent<Rigidbody2D>();
            if (rb[i].velocity.magnitude > 1f)
            {
                camTr.position = new Vector3(birds[i].transform.position.x, 0f, -10f);
                break;
            }
            else
            {
                camTr.position = new Vector3(slingShot.transform.position.x, 0f, -10f);
            }
        }

        if (_moveCam != null)
        {
            // 카메라 이동 범위 제한
            Vector3 limitPos = camTr.position;
            limitPos.x = Mathf.Clamp(limitPos.x, _moveCam.min.x, _moveCam.max.x);
            limitPos.y = Mathf.Clamp(limitPos.y, _moveCam.min.y, _moveCam.max.y);
            limitPos.z = -10f;
            camTr.position = limitPos;
        }
    }
}