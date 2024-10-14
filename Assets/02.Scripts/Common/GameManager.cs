using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SlingShot _slingShot;
    public Bird _bird;

    [SerializeField] private List<Pig> pigList = new();
    public int pigCnt;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool UIActive = false;
    void Update()
    {
        ClearCheck();
        if (DataList.data[1].isClear && !UIActive)
        {
            Debug.Log("Clear");
            UIActive = true;
            Invoke(nameof(ASDF), 1.5f);
        }
    }

    void ASDF()
    {
        LevelManage.Instance.SetStarRating();
    }

    private void ClearCheck()
    {
        if (_slingShot == null) return;

        if (pigCnt == 0)
        {
            // #2 _bird.velocity.magnitude 말고 중력 받는 모든 클래스 검색하는걸로
            GravityTarget[] _gravityTarget = FindObjectsOfType<GravityTarget>();
            bool[] CheckLowSpeed = new bool[_gravityTarget.Length];
            for (int i = 0; i < _gravityTarget.Length; i++)
            {
                CheckLowSpeed[i] = _gravityTarget[i].desiredSpeed;
                Debug.Log(_gravityTarget[i].gameObject.name + CheckLowSpeed[i]);
            }

            for (int i = 0; i < CheckLowSpeed.Length; i++)
            {
                if (!CheckLowSpeed[i])
                    return;
            }
            DataList.data[1].isClear = true;
        }

        else
        {
            DataList.data[1].isClear = false;
            //LevelManage.Instance.SetStarRating();
        }
    }

    public void UpdateSlingShot() => _slingShot = FindObjectOfType<SlingShot>();
    public void UpdateBird() => _bird = FindObjectOfType<Bird>();

    public void AddPig(Pig pig)
    {
        pigList.Add(pig);
        pigCnt = pigList.Count;
        Debug.Log(pigCnt);
    }

    public void RemovePig(Pig pig)
    {
        pigList.Remove(pig);
        pigCnt = pigList.Count;
        Debug.Log(pigCnt);
    }
}
