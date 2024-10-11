using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 싱글톤 패턴 사용
    
    [SerializeField] private List<Pig> pigList = new List<Pig>();
    [SerializeField] private int pigCnt;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

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
