using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBlock : Blocks
{
    protected override void Start()
    {
        requireForce = 5f;
        score = 50;
        base.Start();
        for (int i = 0; i < 4; i++)
            blockSprite[i] = Sprites.InGameBlocksGlass[13 + i];
    }
}