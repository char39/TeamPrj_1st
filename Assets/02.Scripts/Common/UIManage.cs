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
        SetAllVars();
        SetButtonMethod();
    }

    void Update()
    {
        UpdateSlingShot();

        if (GameManage.Scene.GetLoadScene() == 100)
            LoadWaveImg();

        OnOffScoreUI();

        if (wave_UI != null)
        {
            SetPlanetStar();

            for (int i = 101; i < 107; i++)
            {
                if (LevelDataList.levelData[i].isClear)
                    ChangeNextImgUnlock(LevelDataList.levelData[i].isClear, i);
            }

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
            highScoreText.text = LevelDataList.levelData[GameManage.Scene.GetLoadScene()].score.ToString();
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

        /* 아래 코드로 수정
        // wave1 = wave_UI.GetChild(0).GetComponentsInChildren<Image>();
        // waveBtn1 = wave_UI.GetChild(0).GetComponentsInChildren<Button>();
        // wave2 = wave_UI.GetChild(1).GetComponentsInChildren<Image>();
        // waveBtn2 = wave_UI.GetChild(1).GetComponentsInChildren<Button>();
        // wave3 = wave_UI.GetChild(2).GetComponentsInChildren<Image>();
        // waveBtn3 = wave_UI.GetChild(2).GetComponentsInChildren<Button>();
        // wave4 = wave_UI.GetChild(3).GetComponentsInChildren<Image>();
        // waveBtn4 = wave_UI.GetChild(3).GetComponentsInChildren<Button>();
        // wave5 = wave_UI.GetChild(4).GetComponentsInChildren<Image>();
        // waveBtn5 = wave_UI.GetChild(4).GetComponentsInChildren<Button>();
        // wave6 = wave_UI.GetChild(5).GetComponentsInChildren<Image>();
        // waveBtn6 = wave_UI.GetChild(5).GetComponentsInChildren<Button>();
        // wave7 = wave_UI.GetChild(6).GetComponentsInChildren<Image>();
        // waveBtn7 = wave_UI.GetChild(6).GetComponentsInChildren<Button>();
        */

        wave = new Image[7, 4];
        waveBtn = new Button[7];

        for (int i = 0; i < 7; i++)
        {
            wave[i, 0] = wave_UI.GetChild(i).GetComponent<Image>();
            waveBtn[i] = wave_UI.GetChild(i).GetComponent<Button>();

            for (int j = 1; j < 4; j++)
                wave[i, j] = wave_UI.GetChild(i).GetChild(0).GetChild(j - 1).GetComponent<Image>();
        }
    }

    public void ChangeNextImgUnlock(bool clear, int level)
    {
        Debug.Log("ChangeUnlockImg");

        Sprite img = clear ? unlockImg : lockImg;

        int leveIdx = level - 100;
        Image _wave = wave[leveIdx, 0];
        Button _waveBtn = waveBtn[leveIdx];

        if (_wave != null && img != null)
        {
            _wave.sprite = img;
            SetWaveBtnInteractable(_waveBtn, _wave, unlockImg);
        }
    }

    private void SetWaveBtnInteractable(Button waveBtn, Image waveImages, Sprite unlockImage)
    {
        if (waveImages.sprite == unlockImage)
            waveBtn.interactable = true;
        else
            waveBtn.interactable = false;
    }


    public void SetStarRating()
    {
        level_UI.GetChild(0).gameObject.SetActive(true);
        int roomidx = GameManage.Scene.GetLoadScene();
        int curScore = GetScore(1);
        SetScore(roomidx, curScore);
        LevelDataList.levelData[roomidx].isClear = true;

        totalScoreText.text = curScore.ToString();

        if (LevelDataList.levelData[roomidx].requireScore[2] <= curScore)
        {
            SetStarSprite(3);
            SetStar(roomidx, 3);
        }
        else if (LevelDataList.levelData[roomidx].requireScore[1] <= curScore)
        {
            SetStarSprite(2);
            SetStar(roomidx, 2);
        }
        else if (LevelDataList.levelData[roomidx].requireScore[0] <= curScore)
        {
            SetStarSprite(1);
            SetStar(roomidx, 1);
        }
        else
        {
            SetStarSprite(0);
            SetStar(roomidx, 0);
        }
    }

    private void SetStarSprite(int starCount)
    {
        for (int i = 0; i < starCount; i++)
            stars[i].sprite = spr_Stars[i];
        for (int i = starCount; i < 3; i++)
            stars[i].sprite = spr_EmptyStars[i];
    }

    private void SetPlanetStar()
    {
        int starCount;

        for (int i = 0; i < 7; i++)
        {
            starCount = LevelDataList.levelData[101 + i].stars;   // 101 ~ 107 기존 코드는 101 하나로 7번 돌림
            for (int j = 0; j < starCount; j++)
                wave[i, j + 1].sprite = spr_Stars[j];
            for (int j = starCount; j < 3; j++)
                wave[i, j + 1].sprite = spr_EmptyStars[j];
        }
    }

    public void Replay()
    {
        ResetRoomData(1);
        level_UI.GetChild(0).gameObject.SetActive(false);
        GameManage.Level.UIActive = false;
        GameManage.Scene.LoadLevel(GameManage.Scene.GetLoadScene());
    }

    public void SelectWave()
    {
        GameManage.Scene.LoadColdSelectLevel();
    }
}