using UnityEngine;
using UnityEngine.UI;

public partial class SceneManage : MonoBehaviour
{
    // Scene 전환에 사용되는 변수
    private CanvasGroup fadeEffect;
    public bool isSceneChanging = false;

    internal const string SceneChangeObj = "SceneChange";

    internal const string GameStartScene = "Canvas_Start";
    internal const string PlanetSelectScene = "Canvas_Planet";
    internal const string ColdSelectLevelScene = "Planet_UI";
    internal const string EggsteroidsSelectLevelScene = "Eggsteroids_UI";
    internal const string MoonSelectLevelScene = "Moon_UI";

    // GameStartScene UI
    private Button playBtn;

    // PlanetSelectScene UI
    private Button planetColdCuts_Btn;
    private Button planetEgg_Btn;
    private Button planetMoon_Btn;
    private Button planet_BackBtn;

    // Cold_SelectLevel_Scene UI
    private Button coldCuts_BackBtn;
    private Button[] selectColdLevel_Btn;

    // Eggsteroids_SelectLevel_Scene UI
    private Button eggsteroids_BackBtn;
    private Button[] selectEggsteroidsLevel_Btn;

    // Moon_SelectLevel_Scene UI
    private Button moon_BackBtn;
    private Button[] selectMoonLevel_Btn;
}