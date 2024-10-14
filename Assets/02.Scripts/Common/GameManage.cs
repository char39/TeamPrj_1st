using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static GameManage Instance;
    public static UIManage UI;
    public static LevelManage Level;
    public static SceneManage Scene;

    void Awake()
    {
        Instance = this;
        TryGetComponent(out UI);
        TryGetComponent(out Level);
        TryGetComponent(out Scene);
    }
}
