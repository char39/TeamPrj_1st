using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class SceneManage : MonoBehaviour
{
    // Scene 전환에 사용되는 변수
    private CanvasGroup sceneChange;
    public bool isSceneChanging = false;


    public Button playBtn;

    [Header("SelectScene")]
    public Button backBtn;
    public Button coldcuts;
    public Button moon;
    public Button eggsteriods;

    
}

public static class SceneData
{
    public readonly static Dictionary<int, string> list;

    static SceneData()
    {
        // 사용 예시 : SceneData.list[0] : "GameStartScene" << 수정은 불가.
        // Scene 이름이 중복되면 안됨.

        list = new Dictionary<int, string>()
        {
            {0, "AllManagement"},
            {1, "GameStartScene"},
            {2, "PlanetScene"},

            {3, "Scene3"},
            {4, "Scene4"},
            {5, "Scene5"},
            {6, "Scene6"},
            {7, "Scene7"},
            {8, "Scene8"},
            {9, "Scene9"},
            {10, "Scene10"},
            {11, "Scene11"},
            {12, "Scene12"},
            {13, "Scene13"},
            {14, "Scene14"},
            {15, "Scene15"},
            {16, "Scene16"},
            {17, "Scene17"},
            {18, "Scene18"},
            {19, "Scene19"},
            {20, "Scene20"},
        };
    }
}