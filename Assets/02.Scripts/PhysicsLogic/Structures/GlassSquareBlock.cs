using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSquareBlock : Blocks
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
        blockSprite[0] = Sprites.InGameBlocksGlass[34];
        for (int i = 0; i < 3; i++)
            blockSprite[i] = Sprites.InGameBlocksGlass[4 + i];
    }
}
