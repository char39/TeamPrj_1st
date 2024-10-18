using UnityEngine;

public partial class LevelManage : MonoBehaviour
{
    void Update()
    {
        Timer();
        SetTimerCondition();
        SetClearCondition();

        if (IsClear && !LevelDataList.levelData[1].isClear)
        {
            LevelDataList.levelData[1].isClear = true;
            Invoke(nameof(Clear), 0.2f);
        }
    }
    
    private void Timer()
    {
        if (ForceTimerOff)
        {
            TimerOn = false;
            return;
        }

        if (TimerOn)
            clearTimer += Time.deltaTime;
        else
            clearTimer = 0f;
    }

    private void Clear()
    {
        GameManage.UI.SetStarRating();
    }

    private void SetTimerCondition()
    {
        if (_slingShot == null)
            return;
        int pigCnt = FindObjectsOfType<Pig>().Length;

        if (pigCnt == 0)
        {
            GravityTarget[] _gravityTarget = FindObjectsOfType<GravityTarget>();
            bool[] CheckLowSpeed = new bool[_gravityTarget.Length];

            for (int i = 0; i < _gravityTarget.Length; i++)
                CheckLowSpeed[i] = _gravityTarget[i].desiredSpeed;

            for (int i = 0; i < CheckLowSpeed.Length; i++)
            {
                if (!CheckLowSpeed[i])
                {
                    TimerOn = false;
                    return;
                }
            }
            TimerOn = true;
        }
    }

    private void SetClearCondition() => IsClear = clearTimer >= clearTime;

    public void UpdateSlingShot() => _slingShot = FindObjectOfType<SlingShot>();
}