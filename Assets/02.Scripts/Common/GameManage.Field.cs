using UnityEngine;
using TMPro;

public partial class GameManage : MonoBehaviour
{    
    public Canvas canvas_score;
    [SerializeField] private Sprite star_l;
    [SerializeField] private Sprite star_m;
    [SerializeField] private Sprite star_r;
    private GameObject empty_starL;
    private GameObject empty_starM;
    private GameObject empty_starR;
    private TMP_Text scoreText;
}
