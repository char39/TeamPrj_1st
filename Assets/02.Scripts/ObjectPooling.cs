using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling poolingManager;
    public List<GameObject> birdList = new List<GameObject>();
    public GameObject birdPrefab;
    public int poolSize = 10;

    void Awake()
    {
        if (poolingManager == null)
            poolingManager = this;
        else if (poolingManager != this)
            Destroy(gameObject);

        StartCoroutine(CreateBirdPool());
    }

    IEnumerator CreateBirdPool()
    {
        yield return new WaitForSeconds(0.1f);

        GameObject birdGroup = new GameObject("BirdGroup");

        for (int i = 0; i < poolSize; i++)
        {
            var bird = Instantiate(birdPrefab, birdGroup.transform);
            bird.SetActive(false);
            birdList.Add(bird);
        }
    }

    public GameObject GetBirdPool()
    {
        for (int i = 0; i < birdList.Count; i++)
            if (!birdList[i].activeSelf) return birdList[i];

        return null;
    }
}
