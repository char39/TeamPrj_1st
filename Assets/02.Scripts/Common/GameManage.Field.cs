using UnityEngine;
using TMPro;
using UnityEngine.UI;

public partial class GameManage : MonoBehaviour
{    
    public Canvas canvas_score;
    [SerializeField] private Sprite star_l;
    [SerializeField] private Sprite star_m;
    [SerializeField] private Sprite star_r;
    private GameObject empty_starL;
    private GameObject empty_starM;
    private GameObject empty_starR;
    [SerializeField]private Button replay;
    private TMP_Text scoreText;
    public bool isClear = false;
}
