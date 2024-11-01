using UnityEngine;

public partial class LevelManage : MonoBehaviour
{
    void Update()
    {
        Timer(ref clearTIMER);
        SetTimerCondition();

        if (pigCnt == 0)
            SetClearOrFailCondition(out isClear, clearTIMER);
        else if (_slingShot.totalBirdCnt == _slingShot.usedBirds && _slingShot != null)
        {
            Timer(ref failTIMER);
            SetClearOrFailCondition(out isFail, failTIMER);
        }

        if (isClear && !LevelDataList.levelData[1].isClear)
        {
            LevelDataList.levelData[1].isClear = true;
            Clear();
        }
        else if (isFail && !LevelDataList.levelData[1].isFail)
        {
            LevelDataList.levelData[1].isFail = true;
            Fail();
        }
    }

    /// <summary> Timer 값 할당만 다룸. </summary>
    private void Timer(ref float TIMER)
    {
        if (ForceTimerOff)
        {
            timerOn = false;
            TIMER = 0f; //강제 초기화
            return;
        }

        if (timerOn)
            TIMER += Time.deltaTime;
        else
            TIMER = 0f; //움직임 있을 시, 초기화
    }

    private void Clear() => GameManage.UI.SetStarRating();
    private void Fail() => GameManage.UI.LevelFailUI();

    /// <summary> 조건을 만족할 시, Timer을 흐르게 함. </summary>
    private void SetTimerCondition()
    {
        if (_slingShot == null) return;

        pigCnt = FindObjectsOfType<Pig>().Length;

        FindGravityTargets();
    }

    private void FindGravityTargets()
    {
        GravityTarget[] _gravityTarget = FindObjectsOfType<GravityTarget>();
        bool[] CheckLowSpeed = new bool[_gravityTarget.Length];

        for (int i = 0; i < _gravityTarget.Length; i++)
            CheckLowSpeed[i] = _gravityTarget[i].desiredSpeed;

        for (int i = 0; i < CheckLowSpeed.Length; i++)
        {
            if (!CheckLowSpeed[i])
            {
                timerOn = false;
                return;
            }
        }

        timerOn = true;
    }

    /// <summary> 조건을 만족할 시, condition 변경. </summary>
    private void SetClearOrFailCondition(out bool condition, float timer) => condition = timer >= waitTime;

    /// <summary> Level 내부에 slingshot이 무조건 있기에, Timer조건 함수 실행 여부를 판단하기 위해 할당. </summary>
    public void UpdateSlingShot() => _slingShot = FindObjectOfType<SlingShot>();
}