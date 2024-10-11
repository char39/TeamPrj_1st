using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public int score;
    public int stars;
    public int[] requireScore;
    public bool Star1 => score >= requireScore[0];
    public bool Star2 => score >= requireScore[1];
    public bool Star3 => score >= requireScore[2];
    public bool isClear;
    public List<int> BirdList;

    public LevelData(int oneStar = 0, int twoStar = 0, int threeStar = 0)
    {
        score = 0;
        stars = 0;
        requireScore = new int[] { oneStar, twoStar, threeStar };

        isClear = false;
        BirdList = new List<int>();
    }

    public void AddBirdsInOrder(int[] order)
    {
        Debug.Log("AddBirdsInOrder called");
        foreach (int index in order)
        {
            if (index >= 0 && index < BirdPrefs.preBirds.Length)
            {
                BirdList.Add(index);
                Debug.Log(index);
            }
        }
    }
}