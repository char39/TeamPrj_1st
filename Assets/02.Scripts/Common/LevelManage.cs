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
        SetScore(roomidx, GetScore(1));

        if (DataList.data[roomidx].Star3)
        {
            stars[0].sprite = spr_Stars[0];
            stars[1].sprite = spr_Stars[1];
            stars[2].sprite = spr_Stars[2];

            SetStar(roomidx, 3);
            scoreText.text = DataList.data[roomidx].score.ToString();
        }
        else if (DataList.data[roomidx].Star2)
        {
            stars[0].sprite = spr_Stars[0];
            stars[1].sprite = spr_Stars[1];
            stars[2].sprite = spr_EmptyStars[2];

            SetStar(roomidx, 2);
            scoreText.text = DataList.data[roomidx].score.ToString();
        }
        else if (DataList.data[roomidx].Star1)
        {
            stars[0].sprite = spr_Stars[0];
            stars[1].sprite = spr_EmptyStars[1];
            stars[2].sprite = spr_EmptyStars[2];

            SetStar(roomidx, 1);
            scoreText.text = DataList.data[roomidx].score.ToString();
        }
        else
        {
            stars[0].sprite = spr_EmptyStars[0];
            stars[1].sprite = spr_EmptyStars[1];
            stars[2].sprite = spr_EmptyStars[2];

            SetStar(roomidx, 0);
            scoreText.text = DataList.data[roomidx].score.ToString();
        }
    }

    public static void AddScore(int roomidx, int score = 0)
    {
        DataList.data[roomidx].score += score;
        Debug.Log(DataList.data[roomidx].score);
    }

    public static void SetScore(int roomidx, int score = 0)
    {
        if (DataList.data[roomidx].score > score) return;
        DataList.data[roomidx].score = score;
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

    public void Replay()
    {
        Reset(1);
        level_UI.GetChild(0).gameObject.SetActive(false);
        SceneManage.Instance.LoadLevel((int)SceneManage.GetLoadScene());
    }

    // public void SetBirdOrder(int roomidx, int[] order)
    // {
    //     if (DataList.data.ContainsKey(roomidx))
    //     {
    //         DataList.data[roomidx].AddBirdsInOrder(order);
    //     }
    // }
}
