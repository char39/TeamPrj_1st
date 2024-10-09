using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePigCtrl : MonoBehaviour
{
    public Bubble _bubble;
    public GameObject pig_normal;
    public GameObject pig_ice;
    public GameObject bubble;

    void Start()
    {
        pig_normal = transform.GetChild(0).GetChild(0).gameObject;
        pig_ice = transform.GetChild(0).GetChild(1).gameObject;
        bubble = transform.GetChild(0).GetChild(2).gameObject;

        _bubble = bubble.GetComponent<Bubble>();

        pig_normal.SetActive(true);
        pig_ice.SetActive(false);
        bubble.SetActive(true);
    }

    void Update()
    {
        if (_bubble.ispop && pig_ice != null)
        {
            bubble.SetActive(false);
            pig_normal.SetActive(false);
            pig_ice.SetActive(true);
            Destroy(pig_ice, 1f);
        }
    }
}
