using UnityEngine;

public class ObjTouch : MonoBehaviour
{
    [Range(0f, 1f)]
    public float reboundForce = 0.75f;
    [Range(0, 10)]
    public int reboundCountTemp = 3;
    private int reboundCount;
    public bool infiniteRebound = false;

    void Start()
    {
        reboundCount = reboundCountTemp;
    }

    public void ResetCount() => reboundCount = reboundCountTemp;    // 호출용 함수

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Bird.birdTag))
        {
            col.gameObject.TryGetComponent(out Bird bird);
            if (infiniteRebound)            // 무한 반발
                bird.setVelocity = Vector2.Reflect(bird.setVelocity, col.contacts[0].normal) * reboundForce;
            else if (reboundCount > 0)
            {
                reboundCount--;
                bird.setVelocity = Vector2.Reflect(bird.setVelocity, col.contacts[0].normal) * reboundForce;
            }
        }
    }
}