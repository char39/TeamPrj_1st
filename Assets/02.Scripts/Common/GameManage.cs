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
        canvas_score.enabled = false;
        Transform starTr = canvas_score.transform.GetChild(0).GetChild(1);
        empty_starL = starTr.GetChild(0).gameObject;
        empty_starM = starTr.GetChild(1).gameObject;
        empty_starR = starTr.GetChild(2).gameObject;
        scoreText = canvas_score.transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>();
        Transform menu = canvas_score.transform.GetChild(0).GetChild(3);
        replay = menu.transform.GetChild(1).GetChild(0).GetComponent<Button>();
        replay.onClick.AddListener(Replay);
        
        // 0 = red, 1 = yellow, 2 = blue
        // 방에 맞는 새의 순서를 설정
        SetBirdOrder(101, new int[] { 0, 0, 0 });
        SetBirdOrder(102, new int[] { 2, 1, 0 });
        SetBirdOrder(103, new int[] { 1, 0, 2 });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            DataList.starScore[1].isClear = true;

        if (DataList.starScore[1].isClear)
            SetStarRating();

    }

    public void SetStarRating()
    {
        DataList.starScore[1].isClear = false;
        canvas_score.enabled = true;

        int roomidx = (int)SceneManage.GetLoadScene();
        SetScore(roomidx, GetScore(1));

        if (DataList.starScore[roomidx].Star3)
        {
            empty_starL.GetComponent<Image>().sprite = star_l;
            empty_starM.GetComponent<Image>().sprite = star_m;
            empty_starR.GetComponent<Image>().sprite = star_r;
            SetStar(roomidx, 3);
            scoreText.text = DataList.starScore[roomidx].score.ToString();
        }
        else if (DataList.starScore[roomidx].Star2)
        {
            empty_starL.GetComponent<Image>().sprite = star_l;
            empty_starM.GetComponent<Image>().sprite = star_m;
            SetStar(roomidx, 2);
            scoreText.text = DataList.starScore[roomidx].score.ToString();
        }
        else if (DataList.starScore[roomidx].Star1)
        {
            empty_starL.GetComponent<Image>().sprite = star_l;
            SetStar(roomidx, 1);
            scoreText.text = DataList.starScore[roomidx].score.ToString();
        }
        else
        {
            SetStar(roomidx, 0);
            scoreText.text = DataList.starScore[roomidx].score.ToString();
        }
    }

    public static void AddScore(int roomidx, int score = 0)
    {
        DataList.starScore[roomidx].score += score;
        Debug.Log(DataList.starScore[roomidx].score);
    }

    public static void SetScore(int roomidx, int score = 0)
    {
        if (DataList.starScore[roomidx].score > score) return;
        DataList.starScore[roomidx].score = score;
    }

    public static int GetScore(int roomidx) => DataList.starScore[roomidx].score;

    public static void SetStar(int roomidx, int star = 0)
    {
        if (DataList.starScore[roomidx].stars > star) return;
        DataList.starScore[roomidx].stars = star;
    }

    public static int GetStar(int roomidx) => DataList.starScore[roomidx].stars;

    public static void Reset(int roomidx)
    {
        DataList.starScore[roomidx].score = 0;
        DataList.starScore[roomidx].stars = 0;
    }

    public void Replay()
    {
        Reset(1);
        SceneManage.Instance.LoadLevel((int)SceneManage.GetLoadScene());
    }

    public void SetBirdOrder(int roomidx, int[] order)
    {
        if (DataList.starScore.ContainsKey(roomidx))
        {
            DataList.starScore[roomidx].AddBirdsInOrder(order);
        }
    }
}
