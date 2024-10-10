using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class SceneManage : MonoBehaviour
{
    public static SceneManage Instance;

    void Awake()
    {
        Instance = this;

        GetVars();

        LoadScene(1);
        LoadSceneChange(false, 0.8f);
    }

    private void GetVars()
    {
        GameObject.Find("SceneChange").TryGetComponent(out sceneChange);
    }

    void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == SceneList.name[1])
        {
            playBtn = GameObject.Find("Canvas_Start").transform.GetChild(2).GetComponent<Button>();
            playBtn.onClick.AddListener(LoadSelectPlanet);
        }
        else if (scene.name == SceneList.name[2])
        {
            Transform planetTr = GameObject.Find("Canvas_Planet").transform;
            moon = planetTr.GetChild(2).GetComponent<Button>();
            eggsteriods = planetTr.GetChild(3).GetComponent<Button>();
            coldcuts = planetTr.GetChild(4).GetComponent<Button>();
            backBtn = planetTr.GetChild(5).GetChild(0).GetComponent<Button>();

            moon.onClick.AddListener(LoadSelectLevel);
            eggsteriods.onClick.AddListener(LoadSelectLevel);
            coldcuts.onClick.AddListener(LoadSelectLevel);
            backBtn.onClick.AddListener(LoadGameStart);
        }
        else if (scene.name == SceneList.name[100])  // (Cold Cuts) Planet
        {
            Transform canvasTr = GameObject.Find("Canvas").transform;
            Transform levelTr = canvasTr.GetChild(1);

            c_backBtn = canvasTr.GetChild(2).GetChild(0).GetComponent<Button>();
            level1 = levelTr.GetChild(0).GetComponent<Button>();
            level2 = levelTr.GetChild(1).GetComponent<Button>();

            c_backBtn.onClick.AddListener(LoadSelectPlanet); 
            level1.onClick.AddListener(() => LoadLevel(101));
            level2.onClick.AddListener(() => LoadLevel(102));
        }
    }

    public void LoadSelectPlanet() => LoadSceneChange(2, 0.3f, 0.3f);

    public void LoadSelectLevel() => LoadSceneChange(100, 0.3f, 0.3f);

    public void LoadGameStart() => LoadSceneChange(1, 0.3f, 0.3f);

    public void LoadLevel(int idx) => LoadSceneChange(idx, 0.3f, 0.3f);
}