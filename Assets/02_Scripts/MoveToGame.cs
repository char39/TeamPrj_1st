using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MoveToGame : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("SampleScene");
    }
}
