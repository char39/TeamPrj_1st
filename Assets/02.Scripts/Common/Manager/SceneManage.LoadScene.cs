using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class SceneManage : MonoBehaviour
{
    /// <summary> 자동 Scene onoff 전환.
    /// <para> </para> SceneIndex = SceneList의 index. duration = fade 시간. delay = 대기 시간. </summary>
    private void LoadSceneChange(Action action, int SceneIndex, float duration = 0.5f, float delay = 0.3f) => StartCoroutine(SceneChange(action, SceneIndex, duration, delay));

    /// <summary> 자동 Scene onoff 전환.
    /// <para> </para> SceneIndex = SceneList의 index. duration = fade 시간. delay = 대기 시간. </summary>
    private void LoadSceneChange(int SceneIndex, float duration = 0.5f, float delay = 0.3f) => StartCoroutine(SceneChange(SceneIndex, duration, delay));

    /// <summary> 자동 Scene onoff 전환.
    /// <para> </para> duration = fade 시간. delay = 대기 시간. </summary>
    private void LoadSceneChange(float duration = 0.5f, float delay = 0.3f) => StartCoroutine(SceneChange(-1, duration, delay));

    /// <summary> 수동 Scene 전환 onoff를 조절.
    /// <para> </para> duration = fade 시간. delay = 대기 시간. </summary>
    private void LoadSceneChange(bool on = true, float duration = 0.5f) => StartCoroutine(SceneChangeOnOff(on, duration));

    /// <summary> Scene 전환 Coroutine. </summary>
    private IEnumerator SceneChange(Action action, int SceneIndex = -1, float duration = 0.5f, float delay = 0.3f)
    {
        isSceneChanging = true;
        StartCoroutine(SceneChangeOnOff(true, duration));

        while (isSceneChanging)
            yield return null;

        if (SceneIndex != -1)
        {
            UnloadScene(GetLoadScene());
            LoadScene(SceneIndex);
        }

        yield return new WaitForSeconds(delay);
        action?.Invoke();
        StartCoroutine(SceneChangeOnOff(false, duration));
    }

    /// <summary> Scene 전환 Coroutine. </summary>
    private IEnumerator SceneChange(int SceneIndex = -1, float duration = 0.5f, float delay = 0.3f)
    {
        isSceneChanging = true;
        StartCoroutine(SceneChangeOnOff(true, duration));

        while (isSceneChanging)
            yield return null;

        if (SceneIndex != -1)
        {
            UnloadScene(GetLoadScene());
            LoadScene(SceneIndex);
        }

        yield return new WaitForSeconds(delay);
        StartCoroutine(SceneChangeOnOff(false, duration));
    }

    /// <summary> Scene 전환 onoff Coroutine. </summary>
    private IEnumerator SceneChangeOnOff(bool on, float duration)
    {
        fadeEffect.interactable = true;
        fadeEffect.blocksRaycasts = true;

        float elapsed = 0f;
        float startAlpha = fadeEffect.alpha;
        float endAlpha = on ? 1 : 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            fadeEffect.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            yield return null;
        }

        fadeEffect.alpha = endAlpha;
        fadeEffect.interactable = on;
        fadeEffect.blocksRaycasts = on;
        isSceneChanging = false;
    }





    /// <summary> Scene을 로드 후 해당 Scene을 활성화. 
    /// <para> </para> 활성화 안하면 슬픈일이 벌어짐.. </summary>
    private void LoadScene(int index)
    {
        if (index == -1) return;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneList.name[index], LoadSceneMode.Additive);
        asyncLoad.completed += (AsyncOperation op) =>
        {
            Scene loadedScene = SceneManager.GetSceneByName(SceneList.name[index]);
            if (loadedScene.IsValid())
                SceneManager.SetActiveScene(loadedScene);
        };
    }
    /// <summary> Scene을 언로드. </summary>
    private void UnloadScene(int index) => SceneManager.UnloadSceneAsync(SceneList.name[index], UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);

    /// <summary> 현재 로드 중인 Scene을 반환. </summary>
    public int GetLoadScene() => SceneList.GetKeyByValue(SceneManager.GetActiveScene().name);
}