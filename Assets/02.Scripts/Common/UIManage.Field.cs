using UnityEngine;
using UnityEngine.UI;

public partial class UIManage : MonoBehaviour
{
    internal SlingShot _slingShot;

    internal Transform level_UI;

    private Transform clear_UI;          // 클리어 UI
    private Transform starTr;                // 별 이미지
    private Image[] stars;                   // 별 이미지
    private Sprite[] spr_Stars;              // 별 스프라이트
    private Sprite[] spr_EmptyStars;         // 빈 별 스프라이트
    private Text totalScoreText;             // 점수 텍스트
    private Button selectWave;              // 레벨 선택
    private Button replay;                   // 다시하기
    private Button nextLevel;                // 다음 레벨

    private Transform inGame_UI;         // 인게임 UI
    private Button pause_inGame;         // 일시정지
    private Button replay_inGame;        // 다시하기

    private Transform score_UI;          // 점수 UI
    private Text scoreText;              // 점수 텍스트
    private Text highScoreText;          // 최고 점수 텍스트

    [SerializeField] private Transform wave_UI;
    private Image[] wave1;
    private Image[] wave2;
    private Image[] wave3;
    private Image[] wave4;
    private Image[] wave5;
    private Image[] wave6;
    private Image[] wave7;
    private Button[] waveBtn1;
    private Button[] waveBtn2;
    private Button[] waveBtn3;
    private Button[] waveBtn4;
    private Button[] waveBtn5;
    private Button[] waveBtn6;
    private Button[] waveBtn7;

    [SerializeField] private Image[,] wave;
    [SerializeField] private Button[] waveBtn;

    private Sprite unlockImg;
    private Sprite lockImg;

    private void GetAllVars()
    {
        GameObject.Find("Level_UI").TryGetComponent(out level_UI);

        clear_UI = level_UI.GetChild(0);
        clear_UI.gameObject.SetActive(false);
        starTr = clear_UI.GetChild(1);
        totalScoreText = clear_UI.GetChild(2).GetComponent<Text>();
        selectWave = clear_UI.GetChild(3).GetChild(0).GetChild(0).GetComponent<Button>();
        replay = clear_UI.GetChild(3).GetChild(1).GetChild(0).GetComponent<Button>();
        nextLevel = clear_UI.GetChild(3).GetChild(2).GetChild(0).GetComponent<Button>();

        inGame_UI = level_UI.GetChild(1);
        pause_inGame = inGame_UI.GetChild(0).GetChild(0).GetComponent<Button>();
        replay_inGame = inGame_UI.GetChild(1).GetChild(0).GetComponent<Button>();

        score_UI = level_UI.GetChild(2);
        scoreText = score_UI.GetChild(0).GetChild(0).GetComponent<Text>();
        highScoreText = score_UI.GetChild(1).GetChild(0).GetComponent<Text>();
    }

    private void SetAllVars()
    {
        Sprite[] allSprites = Resources.LoadAll<Sprite>("Sprite/MENU_ELEMENTS_1");
        unlockImg = allSprites[35];
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprite/MENU_COMMON_ELEMENTS_1801x968");
        lockImg = sprites[35];

        for (int i = 0; i < 3; i++)
        {
            stars[i] = starTr.GetChild(i).GetComponent<Image>();
            spr_EmptyStars[i] = allSprites[36 + i];
            spr_Stars[i] = allSprites[39 + i];
        }
    }

    private void SetButtonMethod()
    {
        replay.onClick.AddListener(Replay);
        replay_inGame.onClick.AddListener(Replay);
        selectWave.onClick.AddListener(SelectWave);
    }

    public void UpdateSlingShot() => _slingShot = FindObjectOfType<SlingShot>();
}