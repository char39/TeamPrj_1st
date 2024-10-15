using UnityEngine;

public class Sprites
{
    public static Sprite[] MenuElements1;
    public static Sprite[] AngryBirdsCharacters;
    public static Sprite[] MenuCommon;
    
    public static Sprite[] InGameBlocksStone;
    public static Sprite[] InGameBlocksGlass;
    public static Sprite[] InGameBlocksWood;

    public Sprites()
    {
        MenuElements1 = Resources.LoadAll<Sprite>("Sprite/MenuElements1");
        AngryBirdsCharacters = Resources.LoadAll<Sprite>("Sprite/AngryBirdsCharacters");
        MenuCommon = Resources.LoadAll<Sprite>("Sprite/MENU_COMMON");

        InGameBlocksStone = Resources.LoadAll<Sprite>("Sprite/INGAME_BLOCKS_STONE");
        InGameBlocksGlass = Resources.LoadAll<Sprite>("Sprite/INGAME_BLOCKS_GLASS");
        InGameBlocksWood = Resources.LoadAll<Sprite>("Sprite/INGAME_BLOCKS_WOOD");
    }

    public static void Load() { }       // Dummy < 생성자 호출을 위해 1회 호출
    // 이제 Sprites.MenuElements1[0] 이런식으로 사용 가능
}