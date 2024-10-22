using UnityEngine;

public partial class LevelManage : MonoBehaviour
{
    private SlingShot _slingShot;

    private readonly float waitTime = 3f;
    private float timer = 0f;
    [SerializeField] private bool timerOn;
    [SerializeField] internal bool isClear = false;
    [SerializeField] internal bool isFail = false;

    internal bool ForceTimerOff = false;
}