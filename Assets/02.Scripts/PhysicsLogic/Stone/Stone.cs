using UnityEngine;

public class Stone : MonoBehaviour
{
    public enum State { Big = 3, Normal = 2, Small = 1 }    // big: 3, normal: 2, small: 1 <<<< Scale
    public State state;

    void Start()
    {
        transform.localScale = new Vector3((int)state, (int)state, 1);

        if (state == State.Big)
            gameObject.AddComponent<StoneBig>();
        else if (state == State.Normal)
            gameObject.AddComponent<StoneNormal>();
        else if (state == State.Small)
            gameObject.AddComponent<StoneSmall>();
    }
}

public class StoneBig: StoneSelect
{
    protected override void Start()
    {
        stonePrefab = Resources.Load<GameObject>("Stone");
    }
    protected override void OnCollisionEnter2D(Collision2D col)
    {
        if (timeset < timesetLimit)
            return;
        float randomStartAngle = Random.Range(0f, 360f);
        float angleOffset = 120f;

        for (int i = 0; i < 3; i++)
        {
            GameObject normal = Instantiate(stonePrefab);
            normal.GetComponent<Stone>().state = Stone.State.Normal;

            float angle = randomStartAngle + (i * angleOffset);
            Vector2 offset = transform.GetComponent<CircleCollider2D>().radius * transform.localScale.x * GetSpreadDirectionFromAngle(angle) / 1.5f * 2f;
            normal.transform.position = transform.position + (Vector3)offset;

            Vector2 direction = GetSpreadDirectionFromAngle(angle);
            normal.GetComponent<Rigidbody2D>().velocity = direction * 12f;
            normal.GetComponent<GravityFriction>().nowFriction = true;
        }
        GameManage.UI.AddScore(1, 2300);
        Destroy(gameObject);
    }
}

public class StoneNormal : StoneSelect
{
    protected override void Start()
    {
        stonePrefab = Resources.Load<GameObject>("Stone");
    }
    protected override void OnCollisionEnter2D(Collision2D col)
    {        
        if (timeset < timesetLimit)
            return;

        float randomStartAngle = Random.Range(0f, 360f);
        float angleOffset = 120f;

        for (int i = 0; i < 3; i++)
        {
            GameObject small = Instantiate(stonePrefab);
            small.GetComponent<Stone>().state = Stone.State.Small;

            float angle = randomStartAngle + (i * angleOffset);
            Vector2 offset = transform.GetComponent<CircleCollider2D>().radius * transform.localScale.x * GetSpreadDirectionFromAngle(angle);
            small.transform.position = transform.position + (Vector3)offset;

            Vector2 direction = GetSpreadDirectionFromAngle(angle);
            small.GetComponent<Rigidbody2D>().velocity = direction * 6f;
            small.GetComponent<GravityFriction>().nowFriction = true;
        }
        GameManage.UI.AddScore(1, 1300);
        Destroy(gameObject);
    }
}

public class StoneSmall : StoneSelect
{
    protected override void OnCollisionEnter2D(Collision2D col)
    {
        GameManage.UI.AddScore(1, 800);
        Destroy(gameObject);
    }
}