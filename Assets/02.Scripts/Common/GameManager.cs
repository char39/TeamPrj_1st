using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SlingShot _slingShot;

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
            DataList.data[1].isClear = true;
            LevelManage.Instance.SetStarRating();
            DataList.data[1].isClear = false;
        }

        else if (_slingShot != null)
        {
            if (_slingShot.totalBirdCnt == _slingShot.usedBirdCnt)
                //DataList.data[(int)SceneManage.GetLoadScene()].isClear = false;
                DataList.data[1].isClear = false;
        }
    }

    public void UpdateSlingShot() => _slingShot = FindObjectOfType<SlingShot>();

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
