using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public partial class LevelManage : MonoBehaviour
{
    void Update()
    {
        // test
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     LevelDataList.levelData[1].isClear = true;
        //     UIActive = false;
        // }

        ClearCheck();
        if (LevelDataList.levelData[1].isClear && !UIActive)
        {
            Debug.Log("Clear");
            UIActive = true;
            Invoke(nameof(ASDF), 1f);
        }
    }
    void ASDF()
    {
        GameManage.UI.SetStarRating();
    }

    private void ClearCheck()
    {
        if (_slingShot == null) return;
        int pigCnt = FindObjectsOfType<Pig>().Length;
        if (pigCnt == 0)
        {
            // #2 _bird.velocity.magnitude 말고 중력 받는 모든 클래스 검색하는걸로
            GravityTarget[] _gravityTarget = FindObjectsOfType<GravityTarget>();
            bool[] CheckLowSpeed = new bool[_gravityTarget.Length];
            for (int i = 0; i < _gravityTarget.Length; i++)
            {
                CheckLowSpeed[i] = _gravityTarget[i].desiredSpeed;
                // Debug.Log(_gravityTarget[i].gameObject.name + CheckLowSpeed[i]);
            }

            for (int i = 0; i < CheckLowSpeed.Length; i++)
            {
                if (!CheckLowSpeed[i])
                    return;
            }
            LevelDataList.levelData[1].isClear = true;
        }
        else
        {
            LevelDataList.levelData[1].isClear = false;
        }
    }

    public void UpdateSlingShot() => _slingShot = FindObjectOfType<SlingShot>();
}