using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBlock : Blocks
{
    protected override void Awake()
    {
        base.Awake();
        requireForce = 10f;
        requireForceTemp = requireForce;  
        score = 100;
    }

    protected override void Start()
    {
        base.Start();
        for (int i = 0; i < 4; i++)
            blockSprite[i] = Sprites.InGameBlocksStone[32 + i];
    }
}