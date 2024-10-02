using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScaler : MonoBehaviour
{
    public enum State
    {
        Big, Normal, Small
    }
    public State state;
    private Transform tr;
    //private GameObject iceBig_obj;
    private GameObject iceNormal_obj;
    private GameObject iceSmall_obj;

    void Start()
    {
        tr = transform;
        //iceBig_obj = Resources.Load<GameObject>("Ice_big");
        iceNormal_obj = Resources.Load<GameObject>("Ice_normal");
        iceSmall_obj = Resources.Load<GameObject>("Ice_small");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(HandleCollision());
    }

    IEnumerator HandleCollision()
    {
        Vector3 originPos = tr.position;  // 현재 ice의 위치 저장
        float angleOffset = 120f; // 각 오브젝트 간의 각도 차이

        // 랜덤한 시작 각도 생성
        float randomStartAngle = Random.Range(0f, 360f);

        switch (state)
        {
            case State.Big:
                for (int i = 0; i < 3; i++)
                {
                    GameObject small = Instantiate(iceNormal_obj);

                    // 랜덤 각도에 각도 오프셋 추가
                    float angle = randomStartAngle + (i * angleOffset); // i에 따라 120도씩 추가
                    Vector2 offset = GetSpreadDirectionFromAngle(angle) * tr.localScale.x * transform.GetComponent<CircleCollider2D>().radius * 1.1f;
                    small.transform.position = originPos + (Vector3)offset; // 원래 위치에서 떨어진 위치로 설정

                    Vector2 direction = GetSpreadDirectionFromAngle(angle); // 방향 설정
                    small.GetComponent<Rigidbody2D>().velocity = direction * 4f;

                    // 방향을 나타내는 선 그리기
                    Debug.DrawLine(small.transform.position, small.transform.position + (Vector3)direction * 2f, Color.red, 2f);
                }
                Destroy(gameObject);
                break;

            case State.Normal:
                for (int i = 0; i < 3; i++)
                {
                    GameObject small = Instantiate(iceSmall_obj);

                    // 랜덤 각도에 각도 오프셋 추가
                    float angle = randomStartAngle + (i * angleOffset); // i에 따라 120도씩 추가
                    Vector2 offset = GetSpreadDirectionFromAngle(angle) * tr.localScale.x * transform.GetComponent<CircleCollider2D>().radius * 1.1f;
                    small.transform.position = originPos + (Vector3)offset; // 원래 위치에서 떨어진 위치로 설정

                    Vector2 direction = GetSpreadDirectionFromAngle(angle); // 방향 설정
                    small.GetComponent<Rigidbody2D>().velocity = direction * 4f;

                    // 방향을 나타내는 선 그리기
                    Debug.DrawLine(small.transform.position, small.transform.position + (Vector3)direction * 2f, Color.red, 2f);
                }
                Destroy(gameObject);
                break;

            case State.Small:
                Destroy(gameObject);
                break;
        }

        yield return null;
    }

    // 각도를 기반으로 방향을 계산하는 메서드
    Vector2 GetSpreadDirectionFromAngle(float angle)
    {
        // 각도를 라디안으로 변환
        float radian = angle * Mathf.Deg2Rad;
        // x, y 좌표 계산
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
    }

}
