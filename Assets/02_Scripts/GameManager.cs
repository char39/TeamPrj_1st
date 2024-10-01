using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager g_instance;
    public Button playBtn;
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
        if (scene.name == "01.GameStartScene")
        {
            // StartScene에서 playBtn 설정
            playBtn = GameObject.Find("Canvas_Start").transform.GetChild(2).GetComponent<Button>();
            playBtn.onClick.AddListener(LoadSelectPlanet);
        }
        else if (scene.name == "02.SelectPlanet")
        {
            // 02.SelectPlanet에서 행성 선택 버튼들 설정
            moon = GameObject.Find("Canvas_Planet").transform.GetChild(1).GetComponent<Button>();
            eggsteriods = GameObject.Find("Canvas_Planet").transform.GetChild(2).GetComponent<Button>();
            coldcuts = GameObject.Find("Canvas_Planet").transform.GetChild(3).GetComponent<Button>();

            eggsteriods.onClick.AddListener(LoadSelectLevel);
        }
    }

    public void LoadSelectPlanet()
    {
        SceneManager.LoadScene("02.SelectPlanet");
    }

    public void LoadSelectLevel()
    {
        SceneManager.LoadScene("03.SelectLevel");
    }
}
