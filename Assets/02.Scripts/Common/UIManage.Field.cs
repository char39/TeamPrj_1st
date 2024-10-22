using UnityEngine;
using UnityEngine.UI;

public partial class UIManage : MonoBehaviour
{
    #region AllManagement UI ----------------------------------------------------
    [HideInInspector] public Transform level_UI;

    // 클리어 UI (행성으로 돌아가기, 다시하기, 다음 레벨)
    private Transform clear_UI;                 // 클리어 UI
    private Transform starTr;                   // 별 이미지
    private Image[] stars;                      // 별 이미지
    private Sprite[] spr_Stars;                 // 별 스프라이트
    private Sprite[] spr_EmptyStars;            // 빈 별 스프라이트
    private Text totalScoreText;                // 점수 텍스트
    private Button selectWave;                  // 레벨 선택
    private Button replay;                      // 다시하기
    private Button nextLevel;                   // 다음 레벨

    // 인게임 UI (일시정지 메뉴, 다시하기)
    private Transform inGame_UI;            // 인게임 UI
    private Button pause_inGame;            // 일시정지 버튼
    private Button replay_inGame;           // 다시하기 버튼
    private Transform pause_UI;             // 일시정지 UI
    private Button pause_UI_replay;         // 일시정지 다시하기 버튼
    private Button pause_UI_Menu;           // 일시정지 메뉴 버튼
    private Button pause_UI_Resume;         // 일시정지 재개 버튼
    private Text levelText;                 // 레벨 텍스트
    
    // 점수 UI (현재 점수, 최고 점수)
    private Transform score_UI;             // 점수 UI
    private Text scoreText;                 // 점수 텍스트
    private Text highScoreText;             // 최고 점수 텍스트

    // 실패 UI (레벨 선택, 다시하기)
    private Transform fail_UI; // 실패 UI
    private Button selectWave_fail; // 레벨 선택 버튼
    private Button replay_fail; // 다시하기 버튼
    #endregion //-----------------------------------------------------------------


    private Transform planet_UI;

    private Image[,] wave;
    private Button[] waveBtn;

    private Sprite unlockImg = null;
    private Sprite lockImg = null;

    /// <summary> Start()에서 모든 변수들을 가져옴. </summary>
    private void GetAllVars()
    {
        GameObject.Find("Level_UI").TryGetComponent(out level_UI);

        clear_UI = level_UI.GetChild(0);
        starTr = clear_UI.GetChild(1);
        totalScoreText = clear_UI.GetChild(2).GetComponent<Text>();
        selectWave = clear_UI.GetChild(3).GetChild(0).GetChild(0).GetComponent<Button>();
        replay = clear_UI.GetChild(3).GetChild(1).GetChild(0).GetComponent<Button>();
        nextLevel = clear_UI.GetChild(3).GetChild(2).GetChild(0).GetComponent<Button>();

        inGame_UI = level_UI.GetChild(1);
        pause_inGame = inGame_UI.GetChild(0).GetChild(0).GetComponent<Button>();
        replay_inGame = inGame_UI.GetChild(1).GetChild(0).GetComponent<Button>();
        pause_UI = inGame_UI.GetChild(2);
        pause_UI_replay = pause_UI.GetChild(0).GetChild(1).GetChild(0).GetComponent<Button>();
        pause_UI_Menu = pause_UI.GetChild(0).GetChild(2).GetChild(0).GetComponent<Button>();
        pause_UI_Resume = pause_UI.GetChild(0).GetChild(3).GetChild(0).GetComponent<Button>();
        levelText = pause_UI.GetChild(0).GetChild(0).GetComponent<Text>();

        score_UI = level_UI.GetChild(2);
        scoreText = score_UI.GetChild(0).GetChild(0).GetComponent<Text>();
        highScoreText = score_UI.GetChild(1).GetChild(0).GetComponent<Text>();

        fail_UI = level_UI.GetChild(3);
        selectWave_fail = fail_UI.GetChild(2).GetChild(0).GetChild(0).GetComponent<Button>();
        replay_fail = fail_UI.GetChild(2).GetChild(1).GetChild(0).GetComponent<Button>();

        stars = new Image[3];
        spr_Stars = new Sprite[3];
        spr_EmptyStars = new Sprite[3];
    }

    /// <summary> Start()에서 필요한 모든 변수들을 설정함. </summary>
    private void SetAllVars()
    {
        clear_UI.gameObject.SetActive(false);
        pause_UI.gameObject.SetActive(false);
        fail_UI.gameObject.SetActive(false);

        unlockImg = Sprites.MenuElements1[14];
        lockImg = Sprites.MenuCommon[22];

        for (int i = 0; i < 3; i++)
        {
            stars[i] = starTr.GetChild(i).GetComponent<Image>();
            spr_EmptyStars[i] = Sprites.MenuElements1[15 + i];
            spr_Stars[i] = Sprites.MenuElements1[18 + i];
        }
    }

    /// <summary> Start()에서 모든 버튼들의 이벤트를 할당함. </summary>
    private void SetButtonMethod()
    {
        replay.onClick.AddListener(Replay);
        replay_inGame.onClick.AddListener(Replay);
        nextLevel.onClick.AddListener(NextLevel);
        pause_inGame.onClick.AddListener(Pause);
        pause_UI_replay.onClick.AddListener(Replay);
        pause_UI_Menu.onClick.AddListener(LoadSelectLevelScene);
        pause_UI_Resume.onClick.AddListener(Pause);
        selectWave.onClick.AddListener(LoadSelectLevelScene);
        selectWave_fail.onClick.AddListener(LoadSelectLevelScene);
        replay_fail.onClick.AddListener(Replay);
    }
}
