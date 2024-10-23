using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManage : MonoBehaviour
{
    private GameObject s_5;
    private GameObject s_10;

    void Start()
    {
        s_5 = Resources.Load<GameObject>("ScoreImg/Score_5000");
        s_10 = Resources.Load<GameObject>("ScoreImg/Score_10000");
    }

    public void CreateScoreImg(Transform newTr)
    {
        GameObject score5 = Instantiate(s_5, newTr.position, Quaternion.identity);
        Destroy(score5, 1.25f);
    }
}