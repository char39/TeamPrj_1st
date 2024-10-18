using UnityEngine;
using UnityEngine.UI;

public partial class UIManage : MonoBehaviour
{
    void Start()
    {
        GetAllVars();
        SetButtonMethod();
        SetAllVars();

        GameManage.UI.OnOffClearUI(false);
        GameManage.UI.OnOffIngameUI(false, false);
        GameManage.UI.OnOffScoreUI(false);
    }

    public void SetAllSelectLevelUI() => OnOffUI(false, false, false, false);
    public void SetAllIngameUI()
    {
        OnOffUI(false, true, false, true);
        ResetRoomData(1);
        UpdateScoreUI();
        GameManage.Level.ForceTimerOff = false;
    }

    private void OnOffUI(bool clearUI, bool inGameUI, bool inGameUIPause, bool scoreUI)
    {
        GameManage.UI.OnOffClearUI(clearUI);
        GameManage.UI.OnOffIngameUI(inGameUI, inGameUIPause);
        GameManage.UI.OnOffScoreUI(scoreUI);
    }

    public void LoadWaveImg()
    {
        planet_UI = GameObject.Find("Planet_UI").transform.GetChild(1);

        wave = null;
        waveBtn = null;
        wave = new Image[7, 4];
        waveBtn = new Button[7];

        for (int i = 0; i < 7; i++)
        {
            wave[i, 0] = planet_UI.GetChild(i).GetComponent<Image>();
            waveBtn[i] = planet_UI.GetChild(i).GetComponent<Button>();

            for (int j = 1; j < 4; j++)
                wave[i, j] = planet_UI.GetChild(i).GetChild(0).GetChild(j - 1).GetComponent<Image>();
        }
    }
    public void ChangeNextImgUnlock(int planetNum, int levelNum)
    {
        int roomidx = planetNum * 100 + levelNum;
        int starCount = LevelDataList.levelData[roomidx].stars;
        
        for (int i = 0; i < starCount; i++)
            wave[levelNum - 1, i + 1].sprite = spr_Stars[i];
        for (int i = starCount; i < 3; i++)
            wave[levelNum - 1, i + 1].sprite = spr_EmptyStars[i];

        if (levelNum == 7) return;
        bool clear = LevelDataList.levelData[roomidx].isClear;
        Sprite img = clear ? unlockImg : lockImg;

        wave[levelNum, 0].sprite = img;
        SetWaveBtnInteractable(waveBtn[levelNum], wave[levelNum, 0], unlockImg);
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
}