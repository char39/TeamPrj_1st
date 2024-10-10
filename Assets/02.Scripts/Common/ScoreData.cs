using System.Collections.Generic;

public class ScoreData
{
    public int score;
    public int stars;
    public int[] requireScore;

    public ScoreData(int oneStar, int twoStar, int threeStar)
    {
        score = 0;
        stars = 0;
        requireScore = new int[] { oneStar, twoStar, threeStar };
    }
}
