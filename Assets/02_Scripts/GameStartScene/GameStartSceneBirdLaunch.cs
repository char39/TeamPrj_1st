using System.Collections;
using UnityEngine;

public class GameStartSceneBirdLaunch : MonoBehaviour
{
    private LoadBirdSprites loadBirdSprites;
    private GameObject birdPref;
    private readonly float minYpos = -8f;
    private readonly float maxYpos = -5f;
    private readonly float minForce = 12.5f;
    private readonly float maxForce = 15f;
    private int spriteIndex = -1;
    private int tempIndex = 0;

    void Start()
    {
        gameObject.AddComponent<LoadBirdSprites>();
        loadBirdSprites = GetComponent<LoadBirdSprites>();
        loadBirdSprites.Dummy();
        birdPref = Resources.Load<GameObject>("GameStartSceneBird");
        StartCoroutine(BirdLaunch());
    }

    private IEnumerator BirdLaunch()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 7f));

            Vector2 launchPos = new(-25, Random.Range(minYpos, maxYpos));
            float launchForce = Mathf.Lerp(minForce, maxForce, (launchPos.y - minYpos) / (maxYpos - minYpos));

            while (true)
            {
                if (spriteIndex != tempIndex)
                    break;
                tempIndex = Random.Range(0, 4);
                yield return new WaitForSeconds(0.01f);
            }
            
            spriteIndex = tempIndex;

            Launch(launchPos, launchForce, spriteIndex);

            if (gameObject == null)
                break;
        }
    }

    private void Launch(Vector2 launchPos, float launchForce, int index)
    {
        GameObject bird = Instantiate(birdPref, launchPos, Quaternion.identity);
        bird.GetComponent<Bird>().setVelocity = (Vector2.zero - launchPos).normalized * launchForce;
        bird.GetComponent<SpriteRenderer>().sprite = LoadBirdSprites.birds[index];
    }
}
