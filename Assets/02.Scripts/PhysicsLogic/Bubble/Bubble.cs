using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bubble : ColliderDetection
{
    private CircleCollider2D col;
    private Pig pig;
    private StoneSelect _stone;

    protected override void Start()
    {
        base.Start();
        score = 1000;
        requireForce = 0.1f;

        Task.Delay(10);

        TryGetComponent(out col);
        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).TryGetComponent(out pig)) { }
            else if (transform.GetChild(0).TryGetComponent(out _stone))
            {
                _stone.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                _stone.gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    protected override void Update()
    {
        base.Update();

        if (isTouched && canExplode)
            Detection();
    }

    protected override void Detection(int roomidx = 1)
    {
        if (!col.enabled) return;

        if (pig != null)
        {
            // rb.simulated = false;
            col.enabled = false;
            pig.Initialize();
            pig.Frozon();
        }

        else if(_stone != null)
        {
            col.enabled = false;
            _stone.gameObject.GetComponent<Rigidbody2D>().simulated = true;
            _stone.gameObject.GetComponent<Collider2D>().enabled = true;
        }

        AddScore();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        enabled = false;
    }

    public void SetDetection() => Detection();
}