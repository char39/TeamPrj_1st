using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBlock : Blocks
{
    protected override void Start()
    {
        requireForce = 10f;
        score = 100;
        base.Start();
        for(int i = 0; i < 4; i++)
            blockSprite[i] = Sprites.InGameBlocksStone[32 + i];
    }
}