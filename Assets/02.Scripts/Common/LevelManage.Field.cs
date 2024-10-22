using UnityEngine;

public partial class LevelManage : MonoBehaviour
{
    private SlingShot _slingShot;

    private int pigCnt = 0;
    private readonly float waitTime = 3f;
    internal float clearTimer = 0f;
    internal float failTimer = 0f;
    [SerializeField] private bool timerOn;
    [SerializeField] internal bool isClear = false;
    [SerializeField] internal bool isFail = false;

    internal bool ForceTimerOff = false;
}