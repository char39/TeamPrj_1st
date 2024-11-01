using UnityEngine;

public class GameManage : MonoBehaviour
{
    /// <summary> UI 관련 총괄. </summary>
    public static UIManage UI;
    /// <summary> Level Data 관련 총괄. </summary>
    public static LevelManage Level;
    /// <summary> Scene 총괄. 씬 전환, 씬 로드 등을 담당. </summary>
    public static SceneManage Scene;
    /// <summary> Sound 관련 총괄. </summary>
    public static SoundManage Sound;
    
    void Awake()
    {
        TryGetComponent(out UI);
        TryGetComponent(out Level);
        TryGetComponent(out Scene);
        TryGetComponent(out Sound);
    }
}