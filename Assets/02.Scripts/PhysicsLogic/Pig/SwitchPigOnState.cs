// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SwitchPigOnState : MonoBehaviour
// {
//     public Bubble _bubble;
//     public enum State
//     {
//         Normal = 0, Touched = 1, Ice = 2
//     }
//     public State state = State.Normal;

//     Transform tr;
//     GameObject pigIcePref;

//     void Start()
//     {
//         tr = transform;
//         pigIcePref = Resources.Load<GameObject>("Pig/Pig_ice");
//         _bubble = transform.GetChild(6).GetComponent<Bubble>();
//     }

//     void Update()
//     {
//         if (_bubble.ispop)
//             StartCoroutine(ChangeState());
//     }

//     // void OnTriggerEnter2D(Collider2D col)
//     // {
//     //     if (state == State.Normal)
//     //     {
//     //         Destroy(gameObject);
//     //         GameObject pigIce = Instantiate(pigIcePref);
//     //         pigIce.transform.position = tr.position;
//     //         Destroy(pigIce, 1.0f);
//     //     }
//     // }

//     IEnumerator ChangeState()
//     {
//         yield return new WaitForSeconds(0.5f);
//         Destroy(gameObject);
//         GameObject pigIce = Instantiate(pigIcePref);
//         pigIce.transform.position = tr.position;
//         yield return new WaitForSeconds(1f);
//         Destroy(pigIce);
//     }
// }
