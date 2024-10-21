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

    /// <summary> Level Select Scene에서 UI를 Off로 설정함. </summary>
    public void SetAllSelectLevelUI() => OnOffUI(false, false, false, false);
    /// <summary> Level 진입, 재시작 시 임시 Level Data 리셋. <para></para> UI도 초기화. </summary>
    public void SetAllIngameUI()
    {
        OnOffUI(false, true, false, true);
        ResetRoomData(1);
        UpdateScoreUI();
        GameManage.Level.ForceTimerOff = false;
    }

    /// <summary> Level 내부에서 사용되는 UI들의 OnOff를 담당함. </summary>
    private void OnOffUI(bool clearUI, bool inGameUI, bool inGameUIPause, bool scoreUI)
    {
        GameManage.UI.OnOffClearUI(clearUI);
        GameManage.UI.OnOffIngameUI(inGameUI, inGameUIPause);
        GameManage.UI.OnOffScoreUI(scoreUI);
    }

    /// <summary> Level Select Scene에서 사용되는 UI들을 가져옴. </summary>
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

    /// <summary> Level Select Scene에서 사용되는 UI들을 초기화함. </summary>
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

    /// <summary> Level Select Scene에서 사용되는 버튼들의 상호작용 여부를 변경함. </summary>
    private void SetWaveBtnInteractable(Button waveBtn, Image waveImages, Sprite unlockImage)
    {
        if (waveImages.sprite == unlockImage)
            waveBtn.interactable = true;
        else
            waveBtn.interactable = false;
    }

    /// <summary> Level Clear UI를 띄움. <para></para> 해당 Level의 데이터 저장. </summary>
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

    /// <summary> Level Clear UI의 Star 이미지를 변경함. </summary>
    private void SetStarSprite(int starCount)
    {
        for (int i = 0; i < starCount; i++)
            stars[i].sprite = spr_Stars[i];
        for (int i = starCount; i < 3; i++)
            stars[i].sprite = spr_EmptyStars[i];
    }
}