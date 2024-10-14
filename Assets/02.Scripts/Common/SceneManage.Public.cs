using UnityEngine;

public partial class SceneManage : MonoBehaviour
{
    // 게임 시작 화면으로 이동.
    public void LoadGameStart() => LoadSceneChange(1, 0.3f, 0.3f);

    // 행성 선택 화면으로 이동.
    public void LoadSelectPlanet() => LoadSceneChange(2, 0.3f, 0.3f);

    // 각 행성 별 레벨 선택 화면으로 이동.
    public void LoadColdSelectLevel() => LoadSceneChange(100, 0.3f, 0.3f);
    public void LoadEggSelectLevel() => LoadSceneChange(200, 0.3f, 0.3f);
    public void LoadMoonSelectLevel() => LoadSceneChange(300, 0.3f, 0.3f);

    // 레벨로 이동. (레벨에 들어가기 전 초기화)
    public void LoadLevel(int idx)
    {
        GameManage.UI.ResetRoomData(1);
        GameManage.UI.level_UI.GetChild(0).gameObject.SetActive(false);
        GameManage.Level.UIActive = false;
        LoadSceneChange(idx, 0.3f, 0.3f);
    }
}