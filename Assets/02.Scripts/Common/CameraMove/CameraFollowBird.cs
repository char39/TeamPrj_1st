using UnityEngine;

public class CameraFollowBird : MonoBehaviour
{
    private readonly string preBirdTag = "PreBird";

    private Transform camTr;
    private Vector3 pos = Vector3.zero;
    [SerializeField] MoveCameraByDrag _moveCam;

    void Start()
    {
        camTr = Camera.main.transform;
        _moveCam = FindObjectOfType<MoveCameraByDrag>();

        //camTr.position = GameObject.FindWithTag(preBirdTag).transform.position;
    }

    void LateUpdate()
    {
        Follow();
        MoveLimit();
        ApplyPos();
    }

    private void Follow()
    {
        Bird[] birds = FindObjectsOfType<Bird>();
        Rigidbody2D[] rb = new Rigidbody2D[birds.Length];
        SlingShot slingShot = FindObjectOfType<SlingShot>();

        for (int i = 0; i < birds.Length; i++)
        {
            rb[i] = birds[i].GetComponent<Rigidbody2D>();
            if (rb[i].velocity.magnitude > 0.75f)
            {
                pos = new Vector3(birds[i].transform.position.x, 0f, -10f);
                break;
            }
            else
                pos = new Vector3(slingShot.transform.position.x, 0f, -10f);
        }
    }

    private void MoveLimit()
    {
        if (_moveCam != null)
        {
            // 카메라 이동 범위 제한
            Vector3 limitPos = pos;
            limitPos.x = Mathf.Clamp(limitPos.x, _moveCam.min.x, _moveCam.max.x);
            limitPos.y = Mathf.Clamp(limitPos.y, _moveCam.min.y, _moveCam.max.y);
            limitPos.z = -10f;
            pos = limitPos;
        }
    }

    private void ApplyPos()
    {
        camTr.position = Vector3.Lerp(camTr.position, pos, Time.deltaTime * 2.5f);
    }
}