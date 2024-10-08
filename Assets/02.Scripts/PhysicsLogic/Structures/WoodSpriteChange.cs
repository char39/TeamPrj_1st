using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    Transform tr;
    [SerializeField] private Sprite woodFirst;
    [SerializeField] private Sprite woodSecond;
    [SerializeField] private Sprite woodThird;
    [SerializeField] private Sprite woodFourth;
    [SerializeField] private Sprite stoneFirst;
    [SerializeField] private Sprite stoneSecond;
    [SerializeField] private Sprite stoneThird;
    [SerializeField] private Sprite stoneFourth;

    void Start()
    {        
        tr = transform;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

    }
}
