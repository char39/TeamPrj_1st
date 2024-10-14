using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SlingShot _slingShot;
    public Bird _bird;

    [SerializeField] private List<Pig> pigList = new List<Pig>();
    public int pigCnt;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        ClearCheck();
    }

    private void ClearCheck()
    {
        if (pigCnt == 0 && _slingShot != null)
        {
            // #2 _bird.velocity.magnitude 말고 중력 받는 모든 클래스 검색하는걸로
            if (_bird != null && _bird.velocity.magnitude <= 0.2)
            {
                DataList.data[1].isClear = true;
                LevelManage.Instance.SetStarRating();
            }
        }

        else if (_slingShot != null)
        {
            if (_slingShot.totalBirdCnt == _slingShot.usedBirds)
                DataList.data[1].isClear = false;
        }
    }

    public void UpdateSlingShot() => _slingShot = FindObjectOfType<SlingShot>();
    public void UpdateBird() => _bird = FindObjectOfType<Bird>();

    public void AddPig(Pig pig)
    {
        pigList.Add(pig);
        pigCnt = pigList.Count;
    }

    public void RemovePig(Pig pig)
    {
        pigList.Remove(pig);
        pigCnt = pigList.Count;
    }
}
