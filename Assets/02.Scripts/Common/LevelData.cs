using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public int score;
    public int stars;
    public int[] requireScore;
    // public bool Star1 => score >= requireScore[0];
    // public bool Star2 => score >= requireScore[1];
    // public bool Star3 => score >= requireScore[2];
    public bool isClear;
    public List<int> birdList;

    public LevelData(int oneStar = 0, int twoStar = 0, int threeStar = 0, List<int> birdList = null)
    {
        score = 0;
        stars = 0;
        requireScore = new int[] { oneStar, twoStar, threeStar };
        isClear = false;
        this.birdList = birdList;
    }
}