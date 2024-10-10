using UnityEngine;
using UnityEngine.UI;
using TMPro;

public partial class GameManage : MonoBehaviour
{
    public static GameManage Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        canvas_score = GameObject.Find("Canvas_score").GetComponent<Canvas>();
        Transform starTr = GameObject.Find("Canvas_score").transform.GetChild(0).GetChild(0);
        empty_starL = starTr.GetChild(0).gameObject;
        empty_starM = starTr.GetChild(1).gameObject;
        empty_starR = starTr.GetChild(2).gameObject;
        scoreText = GameObject.Find("Canvas_score").transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>();
    }

    void Update()
    {
        UpdateResult();
    }

    private void UpdateResult()
    {
        int roomidx = (int)SceneManage.Instance.GetLoadScene();

        /* if (curScore >= 10000)
        {
            scoreText.text = $"{curScore}";
            empty_starL.GetComponent<Image>().sprite = star_l;
            stars = 1;
            GetStar(roomidx);
            SetStar(roomidx, stars);
        }
        if (curScore >= 23000)
        {
            scoreText.text = $"{curScore}";
            empty_starL.GetComponent<Image>().sprite = star_l;
            empty_starM.GetComponent<Image>().sprite = star_m;
            stars = 2;
            GetStar(roomidx);
            SetStar(roomidx, stars);
        }
        if (curScore >= 40000)
        {
            scoreText.text = $"{curScore}";
            empty_starL.GetComponent<Image>().sprite = star_l;
            empty_starM.GetComponent<Image>().sprite = star_m;
            empty_starR.GetComponent<Image>().sprite = star_r;
            stars = 3;
            GetStar(roomidx);
            SetStar(roomidx, stars);
        } */
        if (DataList.result[roomidx].score >= DataList.result[roomidx].requireScore[2])
        {
            empty_starL.GetComponent<Image>().sprite = star_l;
            empty_starM.GetComponent<Image>().sprite = star_m;
            empty_starR.GetComponent<Image>().sprite = star_r;
            SetStar(roomidx, 3);
        }
        else if (DataList.result[roomidx].score >= DataList.result[roomidx].requireScore[1])
        {
            empty_starL.GetComponent<Image>().sprite = star_l;
            empty_starM.GetComponent<Image>().sprite = star_m;
            SetStar(roomidx, 2);
        }
        else if (DataList.result[roomidx].score >= DataList.result[roomidx].requireScore[0])
        {
            empty_starL.GetComponent<Image>().sprite = star_l;
            SetStar(roomidx, 1);
        }
    }

    public static void AddScore(int roomidx, int score = 0) => DataList.result[roomidx].score += score;

    public static void SetScore(int roomidx, int score = 0)
    {
        if (DataList.result[roomidx].score > score) return;
        DataList.result[roomidx].score = score;
    }

    public static int GetScore(int roomidx) => DataList.result[roomidx].score;

    public static void SetStar(int roomidx, int star = 0)
    {
        if (DataList.result[roomidx].stars > star) return;
        DataList.result[roomidx].stars = star;
    }

    public static int GetStar(int roomidx) => DataList.result[roomidx].stars;
}
