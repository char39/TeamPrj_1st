using UnityEngine;

public class LoadBirdSprites : MonoBehaviour
{
    public static Sprite[] birds = new Sprite[4];
    // [0] : 빨강
    // [1] : 노랑
    // [2] : 파랑
    // [3] : 검정

    void Start()
    {
        birds[0] = Sprites.AngryBirdsCharacters[23];
        birds[1] = Sprites.AngryBirdsCharacters[17];
        birds[2] = Sprites.AngryBirdsCharacters[8];
        birds[3] = Sprites.AngryBirdsCharacters[13];
    }

    //public void Dummy() { }
}
