using System.Collections.Generic;

public class LevelData
{
    public int score;
    public int stars;
    public int[] requireScore;
    public bool Star1 => score >= requireScore[0];
    public bool Star2 => score >= requireScore[1];
    public bool Star3 => score >= requireScore[2];

    public LevelData(int oneStar = 0, int twoStar = 0, int threeStar = 0)
    {
        score = 0;
        stars = 0;
        requireScore = new int[] { oneStar, twoStar, threeStar };
    }
}
