using TMPro;
using UnityEngine;
using UnityEngine.UI;

public partial class GameManage : MonoBehaviour
{
    public static GameManage Instance;

    private Transform tr;
    [SerializeField] private Sprite star_l;
    [SerializeField] private Sprite star_m;
    [SerializeField] private Sprite star_r;
    private GameObject empty_starL;
    private GameObject empty_starM;
    private GameObject empty_starR;
    private TMP_Text scoreText;

    private int score = 50000;
    public int initScore = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        tr = transform;
        Transform starTr = GameObject.Find("Canvas_score").transform.GetChild(0).GetChild(0);
        empty_starL = starTr.GetChild(0).gameObject;
        empty_starM = starTr.GetChild(1).gameObject;
        empty_starR = starTr.GetChild(2).gameObject;
        scoreText = GameObject.Find("Canvas_score").transform.GetChild(0).GetChild(2).GetComponent<TMP_Text>();
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
