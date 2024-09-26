using UnityEngine;

public class LoadBirdSprites : MonoBehaviour
{
    public static Sprite[] AllSprites;
    public static Sprite[] birds = new Sprite[4];
    // [0] : 빨강
    // [1] : 노랑
    // [2] : 파랑
    // [3] : 검정

    void Start()
    {
        AllSprites = Resources.LoadAll<Sprite>("Sprite/Mobile - Angry Birds - Post-Chrome Characters/");
        birds[0] = AllSprites[183];
        birds[1] = AllSprites[197];
        birds[2] = AllSprites[87];
        birds[3] = AllSprites[103];
    }

    public void Dummy()
    {

    }
}
