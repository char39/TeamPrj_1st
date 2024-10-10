using UnityEngine;

public static class BirdPrefs
{
    private static readonly GameObject bird_Red;
    private static readonly GameObject bird_Yellow;
    private static readonly GameObject bird_Blue;
    private static readonly GameObject preBird_Red;
    private static readonly GameObject preBird_Yellow;
    private static readonly GameObject preBird_Blue;

    public static GameObject[] birds = new GameObject[3];
    public static GameObject[] preBirds = new GameObject[3];

    static BirdPrefs()
    {
        bird_Red = Resources.Load<GameObject>("Birds/Bird_Red");
        bird_Yellow = Resources.Load<GameObject>("Birds/Bird_Yellow");
        bird_Blue = Resources.Load<GameObject>("Birds/Bird_Blue");
        preBird_Red = Resources.Load<GameObject>("Birds/PreBird_Red");
        preBird_Yellow = Resources.Load<GameObject>("Birds/PreBird_Yellow");
        preBird_Blue = Resources.Load<GameObject>("Birds/PreBird_Blue");

        birds[0] = bird_Red;
        birds[1] = bird_Yellow;
        birds[2] = bird_Blue;

        preBirds[0] = preBird_Red;
        preBirds[1] = preBird_Yellow;
        preBirds[2] = preBird_Blue;
    }
}
