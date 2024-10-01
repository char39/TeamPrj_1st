using UnityEngine;
using UnityEngine.UI;

public partial class GameManage : MonoBehaviour
{
    public static GameManage Instance;
    
    void Awake()
    {
        Instance = this;
    }
}
