using UnityEngine;
using UnityEngine.UI;

public partial class UIManage : MonoBehaviour
{
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

        if ((int)GameManage.Scene.GetLoadScene() == 100)
            LoadWaveImg();

        OnOffScoreUI();

        if (wave_UI != null && LevelDataList.levelData[101].stars != 0)
        {
            SetPlanetStar();
            ChangeUnlockImg();
        }
    }

    private void OnOffScoreUI()
    {
        if (_slingShot != null)
        {
            score_UI.gameObject.SetActive(true);
            inGame_UI.gameObject.SetActive(true);

            int curScore = GetScore(1);
            scoreText.text = curScore.ToString();
            highScoreText.text = LevelDataList.levelData[(int)GameManage.Scene.GetLoadScene()].score.ToString();
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
        wave1 = wave_UI.GetChild(0).GetComponentsInChildren<Image>();
        wave2 = wave_UI.GetChild(1).GetComponentsInChildren<Image>();
        wave3 = wave_UI.GetChild(2).GetComponentsInChildren<Image>();
        wave4 = wave_UI.GetChild(3).GetComponentsInChildren<Image>();
        wave5 = wave_UI.GetChild(4).GetComponentsInChildren<Image>();
        wave6 = wave_UI.GetChild(5).GetComponentsInChildren<Image>();
        wave7 = wave_UI.GetChild(6).GetComponentsInChildren<Image>();
    }

    public void ChangeUnlockImg()
    {
        if(LevelDataList.levelData[101].isClear)
            wave2[0].sprite = unlockImg;
        
    }

    public void SetStarRating()
    {
        level_UI.GetChild(0).gameObject.SetActive(true);
        int roomidx = (int)GameManage.Scene.GetLoadScene();
        int curScore = GetScore(1);
        SetScore(roomidx, curScore);

        totalScoreText.text = curScore.ToString();

        if (LevelDataList.levelData[roomidx].requireScore[2] <= curScore)
        {
            for (int i = 0; i < 3; i++)
                stars[i].sprite = spr_Stars[i];

            SetStar(roomidx, 3);
        }
        else if (LevelDataList.levelData[roomidx].requireScore[1] <= curScore)
        {
            for (int i = 0; i < 2; i++)
                stars[i].sprite = spr_Stars[i];
            for (int i = 2; i < 3; i++)
                stars[i].sprite = spr_EmptyStars[i];

            SetStar(roomidx, 2);
        }
        else if (LevelDataList.levelData[roomidx].requireScore[0] <= curScore)
        {
            for (int i = 0; i < 1; i++)
                stars[i].sprite = spr_Stars[i];
            for (int i = 1; i < 3; i++)
                stars[i].sprite = spr_EmptyStars[i];

            SetStar(roomidx, 1);
        }
        else
        {
            for (int i = 0; i < 3; i++)
                stars[i].sprite = spr_EmptyStars[i];

            SetStar(roomidx, 0);
        }
    }

    private void SetPlanetStar()
    {
        int starCount = LevelDataList.levelData[101].stars;

        for (int i = 0; i < starCount; i++)
            wave1[i + 1].sprite = spr_Stars[i];
        for (int i = starCount; i < 3; i++)
            wave1[i + 1].sprite = spr_EmptyStars[i];
    }

    public void Replay()
    {
        ResetRoomData(1);
        level_UI.GetChild(0).gameObject.SetActive(false);
        GameManage.Level.UIActive = false;
        GameManage.Scene.LoadLevel((int)GameManage.Scene.GetLoadScene());
    }

    public void SelectWave()
    {
        GameManage.Scene.LoadColdSelectLevel();
    }
}
