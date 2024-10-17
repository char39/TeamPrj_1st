using UnityEngine;

public partial class UIManage : MonoBehaviour
{
    #region Level Data 관련
    /// <summary> 해당 Room의 점수를 추가. </summary>
    public void AddScore(int roomidx, int score = 0)
    {
        LevelDataList.levelData[roomidx].score += score;
        UpdateScoreUI();
    }
    /// <summary> 해당 Room의 점수를 설정. (현재 점수보다 작으면 설정하지 않음) </summary>
    public void SetScore(int roomidx, int curScore = 0)
    {
        if (LevelDataList.levelData[roomidx].score > curScore) return;
        LevelDataList.levelData[roomidx].score = curScore;
    }
    /// <summary> 해당 Room의 점수를 반환. </summary>
    public int GetScore(int roomidx) => LevelDataList.levelData[roomidx].score;
    /// <summary> 해당 Room의 별을 설정. (현재 별보다 작으면 설정하지 않음) </summary>
    public void SetStar(int roomidx, int star = 0)
    {
        if (LevelDataList.levelData[roomidx].stars > star) return;
        LevelDataList.levelData[roomidx].stars = star;
    }
    /// <summary> 해당 Room의 별을 반환. </summary>
    public int GetStar(int roomidx) => LevelDataList.levelData[roomidx].stars;
    /// <summary> 해당 Room의 모든 데이터를 초기화. </summary>
    public void ResetRoomData(int roomidx)
    {
        LevelDataList.levelData[roomidx].isClear = false;
        LevelDataList.levelData[roomidx].score = 0;
        LevelDataList.levelData[roomidx].stars = 0;
    }
    #endregion


    #region 버튼 이벤트
    public void Replay() => GameManage.Scene.LoadLevel(GameManage.Scene.GetLoadScene());
    public void Pause()
    {
        bool isPause = pause_UI.gameObject.activeSelf;
        if (isPause)
        {
            
        }
        else
        {
            PauseLevelText();
        }
        OnOffUI(false, true, !isPause, true);
    }
    public void PauseLevelText()
    {
        int roomidx = GameManage.Scene.GetLoadScene();
        int planetNum = roomidx / 100;  // 1 ~ 3
        int levelNum = roomidx % 100;   // 1 ~ 7
        levelText.text = planetNum + " - " + levelNum;
    }
    public void NextLevel()
    {
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

    public void SelectWave()
    {
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
    public void OnOffClearUI(bool UI) => clear_UI.gameObject.SetActive(UI);
    public void OnOffIngameUI(bool UI, bool pauseUI)
    {
        inGame_UI.gameObject.SetActive(UI);
        pause_UI.gameObject.SetActive(pauseUI);
    }
    public void OnOffScoreUI(bool UI) => score_UI.gameObject.SetActive(UI);

    public void UpdateScoreUI()
    {
        int curScore = GetScore(1);
        int roomidx = GameManage.Scene.GetLoadScene();
        scoreText.text = curScore.ToString();
        highScoreText.text = LevelDataList.levelData[roomidx].score.ToString();
    }
    #endregion
}