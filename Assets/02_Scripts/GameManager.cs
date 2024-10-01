using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager g_instance;

    void Awake()
    {
        if(g_instance == null)
            g_instance = this;
        else if( g_instance != this)
            Destroy(gameObject);
 
        DontDestroyOnLoad(g_instance);
    }

    public void LoadSelectPlanet()
    {
        SceneManager.LoadScene("02.SelectPlanet");
    }

    public void LoadSelectLevel()
    {
        SceneManager.LoadScene("03.SelectLevel");
    }
}
