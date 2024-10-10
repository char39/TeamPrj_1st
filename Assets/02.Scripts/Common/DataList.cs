using System.Collections.Generic;

public static class DataList
{
    public static Dictionary<int, ScoreData> result;

    static DataList()
    {
        result = new Dictionary<int, ScoreData>()
        {
            {1, new ScoreData(0, 0, 0)},    // 임시 score 저장용

            {101, new ScoreData(10000, 23000, 40000)},
            {102, new ScoreData(0, 0, 0)},
            {103, new ScoreData(0, 0, 0)},
            {104, new ScoreData(0, 0, 0)},
            {105, new ScoreData(0, 0, 0)},
            {106, new ScoreData(0, 0, 0)},
            {107, new ScoreData(0, 0, 0)},

            {201, new ScoreData(0, 0, 0)},
            {202, new ScoreData(0, 0, 0)},
            {203, new ScoreData(0, 0, 0)},
            {204, new ScoreData(0, 0, 0)},
            {205, new ScoreData(0, 0, 0)},
            {206, new ScoreData(0, 0, 0)},
            {207, new ScoreData(0, 0, 0)},

            {301, new ScoreData(0, 0, 0)},
            {302, new ScoreData(0, 0, 0)},
            {303, new ScoreData(0, 0, 0)},
            {304, new ScoreData(0, 0, 0)},
            {305, new ScoreData(0, 0, 0)},
            {306, new ScoreData(0, 0, 0)},
            {307, new ScoreData(0, 0, 0)},
        };
    }
}