using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Transform tr;
    [SerializeField] private Sprite star1;
    [SerializeField] private Sprite star2;
    [SerializeField] private Sprite star3;

    public int score = 0;
    public int initScore = 0;
    
    void Start()
    {        
        tr = transform;
    }

    void Update()
    {
        
    }
}
