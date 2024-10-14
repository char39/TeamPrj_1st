using System.Collections.Generic;

public static class DataList
{
    public static Dictionary<int, LevelData> data;
    public static Dictionary<int, WaveRoomSize> waveRoomSize;

    static DataList()
    {
        data = new Dictionary<int, LevelData>()
        {
            {1, new LevelData()},    // 임시 score 저장용
            // 0: red, 1: yellow, 2: blue
            {101, new LevelData(0, 23000, 40000, new List<int>{ 0, 0, 0 })},
            {102, new LevelData(0, 0, 0, new List<int>{ 1, 1, 1, 1, 1, 1, 1, 1, 1 })},
            {103, new LevelData(0, 0, 0, new List<int>{ 0, 1, 2 })},
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

        waveRoomSize = new Dictionary<int, WaveRoomSize>()
        {
            {101, new WaveRoomSize(30, -30, -60, 60)},
            {102, new WaveRoomSize(30, -25, -55, 50)},
            {103, new WaveRoomSize(0, 0, 0, 0)},
            {104, new WaveRoomSize(0, 0, 0, 0)},
            {105, new WaveRoomSize(0, 0, 0, 0)},
            {106, new WaveRoomSize(0, 0, 0, 0)},
            {107, new WaveRoomSize(0, 0, 0, 0)},

            {201, new WaveRoomSize(0, 0, 0, 0)},
            {202, new WaveRoomSize(0, 0, 0, 0)},
            {203, new WaveRoomSize(0, 0, 0, 0)},
            {204, new WaveRoomSize(0, 0, 0, 0)},
            {205, new WaveRoomSize(0, 0, 0, 0)},
            {206, new WaveRoomSize(0, 0, 0, 0)},
            {207, new WaveRoomSize(0, 0, 0, 0)},

            {301, new WaveRoomSize(0, 0, 0, 0)},
            {302, new WaveRoomSize(0, 0, 0, 0)},
            {303, new WaveRoomSize(0, 0, 0, 0)},
            {304, new WaveRoomSize(0, 0, 0, 0)},
            {305, new WaveRoomSize(0, 0, 0, 0)},
            {306, new WaveRoomSize(0, 0, 0, 0)},
            {307, new WaveRoomSize(0, 0, 0, 0)},
        };
    }
}