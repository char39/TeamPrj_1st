using System.Collections.Generic;

public static class SceneList
{
    public readonly static Dictionary<int, string> name;

    static SceneList()
    {
        // 사용 예시 : SceneList.name[0] : "GameStartScene" << 수정은 불가.
        // Scene 이름이 중복되면 안됨.

        name = new Dictionary<int, string>()
        {
            {0, "AllManagement"},       // 사라지면 안되는 Scene
            {1, "GameStartScene"},
            {2, "PlanetScene"},
            {3, "UIScene"},

            {100, "Cold_SelectLevel"},  // (Cold Cuts) Planet
            {101, "Cold_Level1"},
            {102, "Cold_Level2"},
            {103, "Cold_Level3"},
            {104, "Cold_Level4"},
            {105, "Cold_Level5"},
            {106, "Cold_Level6"},
            {107, "Cold_Level7"},

            {200, "Egg_SelectLevel"},   // (EggSteroids) Planet
            {201, "Egg_Level1"},
            {202, "Egg_Level2"},
            {203, "Egg_Level3"},
            {204, "Egg_Level4"},
            {205, "Egg_Level5"},
            {206, "Egg_Level6"},
            {207, "Egg_Level7"},

            {300, "Moon_SelectLevel"},  // (Fry me to the Moon) Planet
            {301, "Moon_Level1"},
            {302, "Moon_Level2"},
            {303, "Moon_Level3"},
            {304, "Moon_Level4"},
            {305, "Moon_Level5"},
            {306, "Moon_Level6"},
            {307, "Moon_Level7"},
        };
    }

    public static int? GetKeyByValue(string value)
    {
        foreach (var n in name)
            if (n.Value == value)
                return n.Key;
        return null;
    }
}