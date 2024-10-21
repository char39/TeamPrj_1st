using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class SceneManage : MonoBehaviour
{
    private void Start()
    {
        GetVars();
        LoadScene(1);                       // GameStartScene 로드.
        LoadSceneChange(false, 0.8f);       // Fade 효과.
    }

    /// <summary> 모든 변수 초기화, 할당. </summary>
    private void GetVars() => GameObject.Find(SceneChangeObj).TryGetComponent(out fadeEffect);    // Fade 효과 오브젝트 할당.

    private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;       // Scene 로드 시 이벤트 발생.
    private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;      // Scene 로드 시 이벤트 해제.

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == SceneList.name[1])
            Scene1(scene, mode);
        else if (scene.name == SceneList.name[2])
            Scene2(scene, mode);
        else if (scene.name == SceneList.name[100])
            Scene100(scene, mode);
        else if (scene.name == SceneList.name[200])
            Scene200(scene, mode);
        else if (scene.name == SceneList.name[300])
            Scene300(scene, mode);
    }

    private void Scene1(Scene scene, LoadSceneMode mode)
    {
        playBtn = GameObject.Find(GameStartScene).transform.GetChild(2).GetComponent<Button>();
        playBtn.onClick.AddListener(LoadSelectPlanet);
    }
    private void Scene2(Scene scene, LoadSceneMode mode)
    {
        Transform planetTr = GameObject.Find(PlanetSelectScene).transform;
        planetColdCuts_Btn = planetTr.GetChild(2).GetComponent<Button>();
        planetEgg_Btn = planetTr.GetChild(3).GetComponent<Button>();
        planetMoon_Btn = planetTr.GetChild(4).GetComponent<Button>();
        planet_BackBtn = planetTr.GetChild(5).GetChild(0).GetComponent<Button>();

        planetColdCuts_Btn.onClick.AddListener(LoadColdSelectLevel);
        planetEgg_Btn.onClick.AddListener(LoadEggSelectLevel);
        planetMoon_Btn.onClick.AddListener(LoadMoonSelectLevel);
        planet_BackBtn.onClick.AddListener(LoadGameStart);
    }
    private void Scene100(Scene scene, LoadSceneMode mode)
    {
        GameManage.UI.LoadWaveImg();
        for (int i = 0; i < 7; i++)
            GameManage.UI.ChangeNextImgUnlock(1, i + 1);

        Transform canvasTr = GameObject.Find(SelectLevelScene).transform;
        Transform levelTr = canvasTr.GetChild(1);

        coldCuts_BackBtn = canvasTr.GetChild(2).GetChild(0).GetComponent<Button>();
        coldCuts_BackBtn.onClick.AddListener(LoadSelectPlanet);

        selectColdLevel_Btn = new Button[7];
        for (int i = 0; i < 7; i++)
        {
            int index = i;
            selectColdLevel_Btn[index] = levelTr.GetChild(index).GetComponent<Button>();
            selectColdLevel_Btn[index].onClick.AddListener(() => LoadLevel(100 + index + 1));
        }
    }

    private void Scene200(Scene scene, LoadSceneMode mode)
    {
        GameManage.UI.LoadWaveImg();
        for (int i = 0; i < 7; i++)
            GameManage.UI.ChangeNextImgUnlock(2, i + 1);

        Transform canvasTr = GameObject.Find(SelectLevelScene).transform;
        Transform levelTr = canvasTr.GetChild(1);

        eggsteroids_BackBtn = canvasTr.GetChild(2).GetChild(0).GetComponent<Button>();
        eggsteroids_BackBtn.onClick.AddListener(LoadSelectPlanet);

        selectEggsteroidsLevel_Btn = new Button[7];
        for (int i = 0; i < 7; i++)
        {
            int index = i;
            selectEggsteroidsLevel_Btn[index] = levelTr.GetChild(index).GetComponent<Button>();
            selectEggsteroidsLevel_Btn[index].onClick.AddListener(() => LoadLevel(200 + index + 1));
        }
    }

    private void Scene300(Scene scene, LoadSceneMode mode)
    {
        GameManage.UI.LoadWaveImg();
        for (int i = 0; i < 7; i++)
            GameManage.UI.ChangeNextImgUnlock(3, i + 1);

        Transform canvasTr = GameObject.Find(SelectLevelScene).transform;
        Transform levelTr = canvasTr.GetChild(1);

        moon_BackBtn = canvasTr.GetChild(2).GetChild(0).GetComponent<Button>();
        moon_BackBtn.onClick.AddListener(LoadSelectPlanet);

        selectMoonLevel_Btn = new Button[7];
        for (int i = 0; i < 7; i++)
        {
            int index = i;
            selectMoonLevel_Btn[index] = levelTr.GetChild(index).GetComponent<Button>();
            selectMoonLevel_Btn[index].onClick.AddListener(() => LoadLevel(300 + index + 1));
        }
    }
}