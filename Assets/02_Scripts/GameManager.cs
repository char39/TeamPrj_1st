using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager g_instance;

    public Button playBtn;

    [Header("SelectScene")]
    public Button backBtn;
    public Button moon;
    public Button eggsteriods;
    public Button coldcuts;

    void Awake()
    {
        if (g_instance == null)
            g_instance = this;
        else if (g_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(g_instance);
    }

    void OnEnable()
    {
        // 씬이 로드될 때마다 호출되는 이벤트 리스너 추가
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // 씬 로드 이벤트 리스너 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 씬이 로드된 후 호출되는 함수
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameStartScene")
        {
            // StartScene에서 playBtn 설정
            playBtn = GameObject.Find("Canvas_Start").transform.GetChild(2).GetComponent<Button>();
            playBtn.onClick.AddListener(LoadSelectPlanet);
        }
        else if (scene.name == "PlanetScene")
        {
            // 02.SelectPlanet에서 행성 선택 버튼들 설정
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
    }

    public void LoadSelectPlanet()
    {
        SceneManager.LoadScene("PlanetScene");
    }

    public void LoadSelectLevel()
    {
        SceneManager.LoadScene("03.SelectLevel");
    }

    public void LoadGameStart()
    {
        SceneManager.LoadScene("GameStartScene");
    }
}
