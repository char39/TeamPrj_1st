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
        if (pigCnt == 0 && _slingShot != null)
        {
            if (_bird != null && _bird.velocity.magnitude <= 5)
            {
                DataList.data[1].isClear = true;
                LevelManage.Instance.SetStarRating();
            }
        }

        else if (_slingShot != null)
        {
            if (_slingShot.totalBirdCnt == _slingShot.usedBirdCnt)
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
