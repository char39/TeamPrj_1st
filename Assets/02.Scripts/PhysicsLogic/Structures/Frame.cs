using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : Blocks
{
    public float localRequireForce;
    protected override void Awake()
    {
        base.Awake();
        requireForce = localRequireForce;
        requireForceTemp = requireForce;  
        score = 50;
    }

    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < 4; i++)
            blockSprite[i] = Sprites.InGameBlocksMisc[4];
    }
}