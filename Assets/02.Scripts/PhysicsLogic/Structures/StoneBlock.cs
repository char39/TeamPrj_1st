using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : ColliderDetection
{
    public enum State { Block1 = 1, Block2 = 2, Block3 = 3, Block4 = 4 }
    public State state = State.Block1;
    protected BoxCollider2D col;
    //protected Sprite[] blockSprite;

    protected override void Start()
    {
        base.Start();
        TryGetComponent(out col);
        //blockSprite = new Sprite[4];
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnCollisionEnter2D(Collision2D col) { }

    protected override void Detection(int roomidx = 1)
    {

    }
}

public class BlockStone1 : Blocks
{
    protected override void Start()
    {
        base.Start();
        state = State.Block1;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Bird_Blue _blue))
        {
            switch (state)
            {
                case State.Block1:
                    break;
                case State.Block2:
                    break;
                case State.Block3:
                    break;
                case State.Block4:
                    break;
            }
        }
    }
}

public class BlockStone2 : Blocks
{
    protected override void Start()
    {
        base.Start();
        state = State.Block2;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Bird_Blue _blue))
        {
            switch (state)
            {
                case State.Block1:
                    break;
                case State.Block2:
                    break;
                case State.Block3:
                    break;
                case State.Block4:
                    break;
            }
        }
    }
}

public class BlockStone3 : Blocks
{
    //32~35
    protected override void Start()
    {
        base.Start();
        state = State.Block3;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Bird_Blue _blue))
        {
            switch (state)
            {
                case State.Block1:
                    break;
                case State.Block2:
                    break;
                case State.Block3:
                    break;
                case State.Block4:
                    break;
            }
        }
    }
}

public class BlockStone4 : Blocks
{
    protected override void Start()
    {
        base.Start();
        state = State.Block4;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Bird_Blue _blue))
        {
            switch (state)
            {
                case State.Block1:
                    break;
                case State.Block2:
                    break;
                case State.Block3:
                    break;
                case State.Block4:
                    break;
            }
        }
    }
}