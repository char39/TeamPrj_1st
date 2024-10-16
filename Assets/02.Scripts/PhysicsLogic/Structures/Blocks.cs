using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : ColliderDetection
{
    public enum State { Block1 = 1, Block2 = 2, Block3 = 3, Block4 = 4 }
    public State state = State.Block1;
    protected BoxCollider2D col;
    protected SpriteRenderer sr;
    protected Sprite[] blockSprite;
    protected float[] force;
    public float requireForceTemp; 

    protected override void Start()
    {
        base.Start();
        TryGetComponent(out col);
        TryGetComponent(out sr);
        requireForceTemp = requireForce;  
        blockSprite = new Sprite[4];
        force = new float[4];
        for (int i = 0; i < 4; i++)
            force[i] = (i + 1) / 4; 
    }

    protected override void Update()
    {
        base.Update();
        
        if (blockSprite != null && sr != null && force != null)
            UpdateBlockSpriteOnForce();

        if (isTouched && canExplode)    // 터치되었을 때, canExplode는 requireForce보다 큰 힘이 가해졌을 때 true
            Detection();
        else if (isTouched && !canExplode)
            Detection(state);
    }

    protected void UpdateBlockSpriteOnForce()
    {
        switch (state)
        {
            case State.Block1:
                sr.sprite = blockSprite[0];
                requireForce = force[3] * requireForceTemp;    // *1
                break;
            case State.Block2:
                sr.sprite = blockSprite[1];
                requireForce = force[2] * requireForceTemp;    // *0.75
                break;
            case State.Block3:
                sr.sprite = blockSprite[2];
                requireForce = force[1] * requireForceTemp;    // *0.5
                break;
            case State.Block4:
                sr.sprite = blockSprite[3];
                requireForce = force[0] * requireForceTemp;    // *0.25
                break;
        }
    }

    protected override void Detection(int roomidx = 1)
    {
        switch (state)
        {
            case State.Block1:
                AddScore(score);
                break;
            case State.Block2:
                AddScore(score * (int)force[2]);
                break;
            case State.Block3:
                AddScore(score * (int)force[1]);
                break;
            case State.Block4:
                AddScore(score * (int)force[0]);
                break;
        }
        DestroyThisObject();
    }

    protected virtual void Detection(State state, int roomidx = 1)
    {
        CollisionExit();
        switch (state)
        {
            case State.Block1:
                if (rb.velocity.magnitude > force[2] * requireForceTemp)       // 1 ~ 0.76 > 0.75 ~ 0.5999...
                    StateScore(State.Block4, (int)force[2]);
                else if (rb.velocity.magnitude > force[1] * requireForceTemp)  // 0.75 ~ 0.6
                    StateScore(State.Block3, (int)force[1]);
                else if (rb.velocity.magnitude > force[0] * requireForceTemp)  // 0.5 ~ 0.25
                    StateScore(State.Block2, (int)force[0]);
                break;
            case State.Block2:
                if (rb.velocity.magnitude > force[1] * requireForceTemp)        // 0.75 ~ 0.5
                    StateScore(State.Block4, (int)force[1]);
                else if (rb.velocity.magnitude > force[0] * requireForceTemp)   // 0.5 ~ 0.25
                    StateScore(State.Block3, (int)force[0]);
                break;
            case State.Block3:
                if (rb.velocity.magnitude > force[0] * requireForceTemp)        // 0.5 ~ 0.25
                    StateScore(State.Block4, (int)force[0]);
                break;
        }

        void StateScore(State _state, int _score)   // 로컬 함수
        {
            this.state = _state;
            AddScore(score * _score);
        }
    }
}