using System.Collections.Generic;

public static class DataList
{
    public static Dictionary<int, LevelData> data;

    static DataList()
    {
        data = new Dictionary<int, LevelData>()
        {
            {1, new LevelData()},    // 임시 score 저장용

            {101, new LevelData(0, 23000, 40000, new List<int>{ 0, 0, 0 })},
            {102, new LevelData(0, 0, 0, new List<int>{ 2, 1, 3 })},
            {103, new LevelData(0, 0, 0, new List<int>{ 1, 2, 3 })},
            {104, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {105, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {106, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {107, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},

            {201, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {202, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {203, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {204, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {205, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {206, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {207, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},

            {301, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {302, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {303, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {304, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {305, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {306, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
            {307, new LevelData(0, 0, 0, new List<int>{ 0, 0, 0 })},
        };
    }
}