using UnityEngine;
using UnityEngine.UI;

public partial class GameManage : MonoBehaviour
{
    public static GameManage Instance;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(Instance);
    }
}
