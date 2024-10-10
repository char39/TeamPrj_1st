using UnityEngine;
using UnityEngine.UI;
using TMPro;

public partial class GameManage : MonoBehaviour
{
    public static GameManage Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        canvas_score = GameObject.Find("Canvas_score").GetComponent<Canvas>();
        Transform starTr = GameObject.Find("Canvas_score").transform.GetChild(0).GetChild(0);
        empty_starL = starTr.GetChild(0).gameObject;
        empty_starM = starTr.GetChild(1).gameObject;
        empty_starR = starTr.GetChild(2).gameObject;
        scoreText = GameObject.Find("Canvas_score").transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>();

        score = initScore;
    }

    void Update()
    {
        if (score >= 10000)
        {
            scoreText.text = $"{score}";
            empty_starL.GetComponent<Image>().sprite = star_l;
        }

        if (score >= 23000)
        {
            scoreText.text = $"{score}";
            empty_starL.GetComponent<Image>().sprite = star_l;
            empty_starM.GetComponent<Image>().sprite = star_m;
        }
        if (score >= 40000)
        {
            scoreText.text = $"{score}";
            empty_starL.GetComponent<Image>().sprite = star_l;
            empty_starM.GetComponent<Image>().sprite = star_m;
            empty_starR.GetComponent<Image>().sprite = star_r;
        }
    }
}
