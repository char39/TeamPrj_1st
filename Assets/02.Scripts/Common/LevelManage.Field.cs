using UnityEngine;

public partial class LevelManage : MonoBehaviour
{
    private SlingShot _slingShot;

    private readonly float clearTime = 3f;
    private float clearTimer = 0f;
    [SerializeField] private bool TimerOn;
    [SerializeField] internal bool IsClear = false;

    internal bool ForceTimerOff = false;
}