using UnityEngine;

public static class Sprites
{
    public static Sprite[] MenuElements1;
    public static Sprite[] AngryBirdsCharacters;
    public static Sprite[] MenuCommon;

    public static Sprite[] InGameBlocksStone;
    public static Sprite[] InGameBlocksGlass;
    public static Sprite[] InGameBlocksWood;
    public static Sprite[] InGameBlocksMisc;

    static Sprites()
    {
        MenuElements1 = Resources.LoadAll<Sprite>("Sprite/MENU_ELEMENTS1");
        AngryBirdsCharacters = Resources.LoadAll<Sprite>("Sprite/AngryBirdsCharacters");
        MenuCommon = Resources.LoadAll<Sprite>("Sprite/MENU_COMMON");

        InGameBlocksStone = Resources.LoadAll<Sprite>("Sprite/INGAME_BLOCKS_STONE");
        InGameBlocksGlass = Resources.LoadAll<Sprite>("Sprite/INGAME_BLOCKS_GLASS");
        InGameBlocksWood = Resources.LoadAll<Sprite>("Sprite/INGAME_BLOCKS_WOOD");
        InGameBlocksMisc = Resources.LoadAll<Sprite>("Sprite/INGAME_BLOCKS_MISC_11017x1000");
    }
}