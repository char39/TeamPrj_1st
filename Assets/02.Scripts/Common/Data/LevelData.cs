using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public int score;
    public int stars;
    public bool isClear;
    public bool isFail;
    public int[] requireScore;
    public List<int> birdList;

    public LevelData(int oneStar = 0, int twoStar = 0, int threeStar = 0, List<int> birdList = null)
    {
        score = 0;
        stars = 0;
        requireScore = new int[] { oneStar, twoStar, threeStar };
        isClear = false;
        isFail = false;
        this.birdList = birdList;
    }
}