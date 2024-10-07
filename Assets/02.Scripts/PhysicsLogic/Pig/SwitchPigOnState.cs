using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPigOnState : MonoBehaviour
{
    public enum State
    {
        Normal = 0, Touched = 1, Ice = 2
    }
    public State state = State.Normal;

    Transform tr;
    GameObject pigIcePref;

    void Start()
    {
        tr = transform;
        pigIcePref = Resources.Load<GameObject>("Pig/Pig_ice");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (state == State.Normal)
        {
            Destroy(gameObject);
            GameObject pigIce = Instantiate(pigIcePref);
            pigIce.transform.position = tr.position;
            Destroy(pigIce, 2.0f);
        }
    }
}
