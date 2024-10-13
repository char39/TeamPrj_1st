using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
    }

    void Update()
    {
        UpdateSlingShot();

        if ((int)SceneManage.GetLoadScene() == 100)
            LoadWaveImg();

        OnOffScoreUI();

        // if (Input.GetKeyDown(KeyCode.Escape))
        //     DataList.data[1].isClear = true;

        if (DataList.data[1].isClear)
            SetStarRating();

        if (wave_UI != null && DataList.data[101].stars != 0)
            SetPlanetStar();
    }

    private void OnOffScoreUI()
    {
        if (_slingShot != null)
        {
            score_UI.gameObject.SetActive(true);
            inGame_UI.gameObject.SetActive(true);

            int curScore = GetScore(1);
            scoreText.text = curScore.ToString();
            highScoreText.text = DataList.data[(int)SceneManage.GetLoadScene()].score.ToString();
        }
        else if (_slingShot == null)
        {
            score_UI.gameObject.SetActive(false);
            inGame_UI.gameObject.SetActive(false);
        }
    }

    private void LoadWaveImg()
    {
        wave_UI = GameObject.Find("Planet_UI").transform.GetChild(1);
        wave1 = wave_UI.GetChild(0).GetComponentsInChildren<Image>().Skip(1).ToArray();
        wave2 = wave_UI.GetChild(1).GetComponentsInChildren<Image>().Skip(1).ToArray();
        wave3 = wave_UI.GetChild(2).GetComponentsInChildren<Image>().Skip(1).ToArray();
        wave4 = wave_UI.GetChild(3).GetComponentsInChildren<Image>().Skip(1).ToArray();
        wave5 = wave_UI.GetChild(4).GetComponentsInChildren<Image>().Skip(1).ToArray();
        wave6 = wave_UI.GetChild(5).GetComponentsInChildren<Image>().Skip(1).ToArray();
        wave7 = wave_UI.GetChild(6).GetComponentsInChildren<Image>().Skip(1).ToArray();
    }

    public void SetStarRating()
    {
        DataList.data[1].isClear = false;
        level_UI.GetChild(0).gameObject.SetActive(true);
        int roomidx = (int)SceneManage.GetLoadScene();
        int curScore = GetScore(1);
        SetScore(roomidx, curScore);

        totalScoreText.text = curScore.ToString();

        // 테스트용
        // Debug.Log("RoomIdx: " + roomidx);
        // Debug.Log("Score: " + DataList.data[roomidx].score);
        // Debug.Log("Stars: " + DataList.data[roomidx].stars);

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

    private void SetPlanetStar()
    {
        int starCount = DataList.data[101].stars;

        if (starCount == 3)
        {
            wave1[0].sprite = spr_Stars[0];
            wave1[1].sprite = spr_Stars[1];
            wave1[2].sprite = spr_Stars[2];
        }
        else if (starCount == 2)
        {
            wave1[0].sprite = spr_Stars[0];
            wave1[1].sprite = spr_Stars[1];
            wave1[2].sprite = spr_EmptyStars[2];
        }
        else if (starCount == 1)
        {
            wave1[0].sprite = spr_Stars[0];
            wave1[1].sprite = spr_EmptyStars[1];
            wave1[2].sprite = spr_EmptyStars[2];
        }
    }

    public void Replay()
    {
        Reset(1);
        level_UI.GetChild(0).gameObject.SetActive(false);
        SceneManage.Instance.LoadLevel((int)SceneManage.GetLoadScene());
    }

    public void SelectWave()
    {
        SceneManage.Instance.LoadSelectLevel();
    }

    public static void AddScore(int roomidx, int score = 0)
    {
        // if (DataList.data[1].isClear) return;
        // Debug.Log(DataList.data[1].isClear);

        DataList.data[roomidx].score += score;
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
