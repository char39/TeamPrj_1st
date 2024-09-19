using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererCtrl : MonoBehaviour
{
    public LineRenderer lineRen;

    void Start()
    {
        lineRen = GetComponent<LineRenderer>();
        
        if (lineRen != null)
        {
            lineRen.positionCount = 2;  // 라인 끝점 2개
            lineRen.startWidth = 0.1f;  // 시작 굵기
            //lineRen.material = new Material(Shader.Find("Sprites/Default"));  // 라인 색상 설정
            lineRen.startColor = Color.red;  // 시작 색상
            lineRen.endColor = Color.red;    // 끝 색상
            lineRen.enabled = false;  // 초기에는 가이드라인 비활성화
        }
    }

    public void UpdateLineRenderer(Vector2 start, Vector2 end)
    {
        if (lineRen != null)
        {
            lineRen.enabled = true;  // 가이드라인 활성화
            lineRen.SetPosition(0, start);  // 라인의 시작점
            lineRen.SetPosition(1, end);    // 라인의 끝점
        }
    }

    public void HideLineRenderer()
    {
        if (lineRen != null)
            lineRen.enabled = false;  // 가이드라인 비활성화
    }
}
