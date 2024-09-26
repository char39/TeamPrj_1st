using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveToLevel : MonoBehaviour, IPointerClickHandler
{
    Transform camTr;

    void Start()
    {
        camTr = Camera.main.transform;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("planet00");
        camTr.transform.position = new Vector3(camTr.transform.position.x, -8f, camTr.transform.position.z);
    }
}
