using UnityEngine;

public partial class LevelManage : MonoBehaviour
{
    /// <summary> 해당 Room의 점수를 추가. </summary>
    public void AddScore(int roomidx, int score = 0)
    {
        LevelDataList.levelData[roomidx].score += score;
        GameManage.UI.UpdateScoreUI();
    }
    /// <summary> 해당 Room의 점수를 설정. (현재 점수보다 작으면 설정하지 않음) </summary>
    public void SetScore(int roomidx, int curScore = 0)
    {
        if (LevelDataList.levelData[roomidx].score > curScore) return;
        LevelDataList.levelData[roomidx].score = curScore;
    }
    /// <summary> 해당 Room의 점수를 반환. </summary>
    public int GetScore(int roomidx) => LevelDataList.levelData[roomidx].score;
    /// <summary> 해당 Room의 별을 설정. (현재 별보다 작으면 설정하지 않음) </summary>
    public void SetStar(int roomidx, int star = 0)
    {
        if (LevelDataList.levelData[roomidx].stars > star) return;
        LevelDataList.levelData[roomidx].stars = star;
    }
    /// <summary> 해당 Room의 별을 반환. </summary>
    public int GetStar(int roomidx) => LevelDataList.levelData[roomidx].stars;
    /// <summary> 해당 Room의 모든 데이터를 초기화. </summary>
    public void ResetRoomData(int roomidx)
    {
        LevelDataList.levelData[roomidx].isClear = false;
        LevelDataList.levelData[roomidx].isFail = false;
        LevelDataList.levelData[roomidx].score = 0;
        LevelDataList.levelData[roomidx].stars = 0;
    }
}