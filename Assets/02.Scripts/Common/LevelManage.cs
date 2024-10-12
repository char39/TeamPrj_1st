using UnityEngine;
using UnityEngine.UI;
using TMPro;

public partial class LevelManage : MonoBehaviour
{
    public static LevelManage Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        stars = new Image[3];
        spr_Stars = new Sprite[3];
        spr_EmptyStars = new Sprite[3];

        GetAllVars();
        SetButtonMethod();

        level_UI.GetChild(0).gameObject.SetActive(false);
        level_UI.GetChild(1).gameObject.SetActive(false);
    }


    void Update()
    {





        if (Input.GetKeyDown(KeyCode.Escape))
            DataList.data[1].isClear = true;

        if (DataList.data[1].isClear)
            SetStarRating();

    }

    public void SetStarRating()
    {
        DataList.data[1].isClear = false;
        level_UI.GetChild(0).gameObject.SetActive(true);
        int roomidx = (int)SceneManage.GetLoadScene();
        int curScore = GetScore(1);
        SetScore(roomidx, curScore);

        // 항상 curScore를 scoreText에 표시
        scoreText.text = curScore.ToString();

        Debug.Log("RoomIdx: " + roomidx);
        Debug.Log("Score: " + DataList.data[roomidx].score);
        Debug.Log("Stars: " + DataList.data[roomidx].stars);

        if (DataList.data[roomidx].requireScore[2] <= curScore)
        {
            stars[0].sprite = spr_Stars[0];
            stars[1].sprite = spr_Stars[1];
            stars[2].sprite = spr_Stars[2];

            SetStar(roomidx, 3);
        }
        else if (DataList.data[roomidx].requireScore[1] <= curScore)
        {
            stars[0].sprite = spr_Stars[0];
            stars[1].sprite = spr_Stars[1];
            stars[2].sprite = spr_EmptyStars[2];

            SetStar(roomidx, 2);
        }
        else if (DataList.data[roomidx].requireScore[0] <= curScore)
        {
            stars[0].sprite = spr_Stars[0];
            stars[1].sprite = spr_EmptyStars[1];
            stars[2].sprite = spr_EmptyStars[2];

            SetStar(roomidx, 1);
        }
        else
        {
            stars[0].sprite = spr_EmptyStars[0];
            stars[1].sprite = spr_EmptyStars[1];
            stars[2].sprite = spr_EmptyStars[2];

            SetStar(roomidx, 0);
        }
    }

    public void Replay()
    {
        Reset(1);
        level_UI.GetChild(0).gameObject.SetActive(false);
        SceneManage.Instance.LoadLevel((int)SceneManage.GetLoadScene());
    }

    public static void AddScore(int roomidx, int score = 0)
    {
        DataList.data[roomidx].score += score;
        Debug.Log(DataList.data[roomidx].score);
    }

    public static void SetScore(int roomidx, int curScore = 0)
    {
        if (DataList.data[roomidx].score > curScore) return;
        DataList.data[roomidx].score = curScore;
    }

    public static int GetScore(int roomidx) => DataList.data[roomidx].score;

    public static void SetStar(int roomidx, int star = 0)
    {
        if (DataList.data[roomidx].stars > star) return;
        DataList.data[roomidx].stars = star;
    }

    public static int GetStar(int roomidx) => DataList.data[roomidx].stars;

    public static void Reset(int roomidx)
    {
        DataList.data[roomidx].score = 0;
        DataList.data[roomidx].stars = 0;
    }
}
