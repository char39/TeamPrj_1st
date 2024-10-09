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

    [Header("Cold_SelectLevel_Scene")]
    public Button c_backBtn;
    public Button level1;
    public Button level2;


}