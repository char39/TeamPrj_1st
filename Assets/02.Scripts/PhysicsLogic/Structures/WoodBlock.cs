using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBlock : Blocks
{
    protected override void Start()
    {
        requireForce = 7f;
        score = 70;
        base.Start();
        for (int i = 0; i < 4; i++)
            blockSprite[i] = Sprites.InGameBlocksWood[44 + i];
    }
}
