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
    
    /// <summary> Timer 값 할당만 다룸. </summary>
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

    /// <summary> Level Clear 조건을 만족할 시, Timer을 흐르게 함. </summary>
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

    /// <summary> Level Clear 조건을 모두 만족할 시, IsClear를 true로 변경. </summary>
    private void SetClearCondition() => IsClear = clearTimer >= clearTime;

    /// <summary> Level 내부에 slingshot이 무조건 있기에, Timer조건 함수 실행 여부를 판단하기 위해 할당. </summary>
    public void UpdateSlingShot() => _slingShot = FindObjectOfType<SlingShot>();
}