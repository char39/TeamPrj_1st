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

        GameObject.Find("SceneChange").TryGetComponent(out sceneChange);
        SetSceneChange(false, 1f);
    }

    /// <summary> Scene 전환. </summary>
    private void SceneChange(float duration = 0.5f)
    {
        isSceneChanging = true;
        StartCoroutine(SceneChangeCor(true, duration));
        while (true)
        {
            if (isSceneChanging == false)
            {
                StartCoroutine(SceneChangeCor(false, duration));
                break;
            }
        }
    }
    /// <summary> 수동으로 onoff를 조절할 때 </summary>
    private void SetSceneChange(bool on = true, float duration = 1f) => StartCoroutine(SceneChangeCor(on, duration));
    /// <summary> Scene 전환을 위해 검은 배경을 duration초 동안 onoff 할 것인가 </summary>
    private IEnumerator SceneChangeCor(bool on, float duration)
    {
        isSceneChanging = true;
        float elapsed = 0f;
        float startAlpha = sceneChange.alpha;
        float endAlpha = on ? 1 : 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            sceneChange.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            yield return null;
        }

        sceneChange.alpha = endAlpha;
        sceneChange.interactable = on;
        sceneChange.blocksRaycasts = on;
        isSceneChanging = false;
    }



    void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameStartScene")
        {
            playBtn = GameObject.Find("Canvas_Start").transform.GetChild(2).GetComponent<Button>();
            playBtn.onClick.AddListener(LoadSelectPlanet);
        }
        else if (scene.name == "PlanetScene")
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
    }



    public void LoadSelectPlanet() => SceneManager.LoadScene("PlanetScene");
    public void LoadSelectLevel() => SceneManager.LoadScene("03.SelectLevel");
    public void LoadGameStart() => SceneManager.LoadScene("GameStartScene");
}
