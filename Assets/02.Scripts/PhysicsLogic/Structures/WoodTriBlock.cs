using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTriBlock : Blocks
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
        blockSprite[0] = Sprites.InGameBlocksWood[25];
        blockSprite[1] = Sprites.InGameBlocksWood[18];
        blockSprite[2] = Sprites.InGameBlocksWood[17];
        blockSprite[3] = Sprites.InGameBlocksWood[6];
    }
}
