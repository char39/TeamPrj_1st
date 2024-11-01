using UnityEngine;

public partial class UIManage : MonoBehaviour
{
    #region 버튼 이벤트
    public void Replay()
    {
        SetTimeScale(false);
        GameManage.Scene.LoadLevel(GameManage.Scene.GetLoadScene());
    }
    public void Pause()
    {
        bool isPause = pause_UI.gameObject.activeSelf;
        if (isPause)
        {
            SetTimeScale(false);
        }
        else
        {
            PauseLevelText();
            SetTimeScale(true);
        }
        OnOffUI(false, true, !isPause, true, false, !bird_UI.gameObject.activeSelf);
    }

    public void SetTimeScale(bool isPause) => Time.timeScale = isPause ? 0 : 1;

    /// <summary> 일시정지 시, 좌상단에 있는 Text 변경. </summary>
    public void PauseLevelText()
    {
        int roomidx = GameManage.Scene.GetLoadScene();
        int planetNum = roomidx / 100;  // 1 ~ 3
        int levelNum = roomidx % 100;   // 1 ~ 7
        levelText.text = planetNum + " - " + levelNum;
    }

    /// <summary> 다음 레벨로 이동. </summary>
    public void NextLevel()
    {
        SetTimeScale(false);

        int roomidx = GameManage.Scene.GetLoadScene();
        int planetNum = roomidx / 100;  // 1 ~ 3
        int levelNum = roomidx % 100;   // 1 ~ 7

        if (levelNum < 7)
            GameManage.Scene.LoadLevel(roomidx + 1);
        else
        {
            if (planetNum == 1)
                GameManage.Scene.LoadColdSelectLevel();
            else if (planetNum == 2)
                GameManage.Scene.LoadEggSelectLevel();
            else if (planetNum == 3)
                GameManage.Scene.LoadMoonSelectLevel();
        }
    }

    /// <summary> 해당 행성의 Level 선택 Scene으로 돌아가기. </summary>
    public void LoadSelectLevelScene()
    {
        SetTimeScale(false);
        int roomidx = GameManage.Scene.GetLoadScene();

        if (100 < roomidx && roomidx < 200)         // 101 ~ 199
            GameManage.Scene.LoadColdSelectLevel();
        else if (200 < roomidx && roomidx < 300)    // 201 ~ 299
            GameManage.Scene.LoadEggSelectLevel();
        else if (300 < roomidx && roomidx < 400)    // 301 ~ 399
            GameManage.Scene.LoadMoonSelectLevel();
    }
    #endregion



    #region 호출 함수
    public void OnOffClearUI(bool UI)
    {
        clear_UI.gameObject.SetActive(UI);
    }
    public void OnOffIngameUI(bool UI, bool pauseUI)
    {
        inGame_UI.gameObject.SetActive(UI);
        pause_UI.gameObject.SetActive(pauseUI);
    }
    public void OnOffScoreUI(bool UI) => score_UI.gameObject.SetActive(UI);
    public void OffFailUI(bool UI) => fail_UI.gameObject.SetActive(UI);
    public void OnOffBirdCntUI(bool UI) => bird_UI.gameObject.SetActive(UI);

    public void UpdateScoreUI()
    {
        int curScore = GameManage.Level.GetScore(1);
        int roomidx = GameManage.Scene.GetLoadScene();
        scoreText.text = curScore.ToString();
        highScoreText.text = LevelDataList.levelData[roomidx].score.ToString();
    }

    public void UpdateBirdUI(int totalBird, int usedBird)
    {
        totalBirdText.text = $"TOTAL BIRD: {totalBird}";
        usedBirdText.text = $"USED BIRD: {usedBird}";
    }

    public void CreateScoreImg(Transform newTr)
    {
        GameObject score5 = Instantiate(s_5, newTr.position, Quaternion.identity);
        Destroy(score5, 1.25f);
    }
    #endregion
}