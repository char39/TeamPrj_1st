using UnityEngine;

public partial class SceneManage : MonoBehaviour
{
    // 게임 시작 화면으로 이동.
    public void LoadGameStart() => LoadSceneChange(1, 0.3f, 0.3f);

    // 행성 선택 화면으로 이동.
    public void LoadSelectPlanet() => LoadSceneChange(2, 0.3f, 0.3f);

    // 각 행성 별 레벨 선택 화면으로 이동.
    public void LoadColdSelectLevel() => LoadSceneChange(GameManage.UI.SetAllSelectLevelUI, 100, 0.3f, 0.3f);
    public void LoadEggSelectLevel() => LoadSceneChange(GameManage.UI.SetAllSelectLevelUI, 200, 0.3f, 0.3f);
    public void LoadMoonSelectLevel() => LoadSceneChange(GameManage.UI.SetAllSelectLevelUI, 300, 0.3f, 0.3f);

    // 레벨로 이동. (레벨에 들어가기 전 초기화)
    public void LoadLevel(int idx)
    {
        GameManage.Level.ForceTimerOff = true;
        GameManage.Level.isClear = false;
        GameManage.Level.isFail = false;
        GameManage.Level.clearTIMER = 0f;
        GameManage.Level.failTIMER = 0f;
        LoadSceneChange(GameManage.UI.SetAllIngameUI, idx, 0.3f, 0.3f);
    }
}