using UnityEngine;

public partial class UIManage : MonoBehaviour
{
    public void AddScore(int roomidx, int score = 0)
    {
        LevelDataList.levelData[roomidx].score += score;
    }
    public void SetScore(int roomidx, int curScore = 0)
    {
        if (LevelDataList.levelData[roomidx].score > curScore)
            return;
        LevelDataList.levelData[roomidx].score = curScore;
    }
    public int GetScore(int roomidx)
    {
        return LevelDataList.levelData[roomidx].score;
    }

    public void SetStar(int roomidx, int star = 0)
    {
        if (LevelDataList.levelData[roomidx].stars > star)
            return;
        LevelDataList.levelData[roomidx].stars = star;
    }
    public int GetStar(int roomidx)
    {
        return LevelDataList.levelData[roomidx].stars;
    }

    /// <summary> 해당 Room의 모든 데이터를 초기화. </summary>
    public void ResetRoomData(int roomidx)
    {
        LevelDataList.levelData[roomidx].isClear = false;
        LevelDataList.levelData[roomidx].score = 0;
        LevelDataList.levelData[roomidx].stars = 0;
    }
}