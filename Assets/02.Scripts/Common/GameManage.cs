using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static GameManage Instance;
    /// <summary> UI 관련 총괄. </summary>
    public static UIManage UI;
    /// <summary> Level 관련 총괄. Clear 판정 등을 담당. </summary>
    public static LevelManage Level;
    /// <summary> Scene 관련 총괄. 씬 전환, 씬 로드 등을 담당. </summary>
    public static SceneManage Scene;
    public static ScoreManage Score;

    void Awake()
    {
        Instance = this;
        TryGetComponent(out UI);
        TryGetComponent(out Level);
        TryGetComponent(out Scene);
        TryGetComponent(out Score);
    }
}

// 각각의 관리자 클래스들에 설명을 추가함.