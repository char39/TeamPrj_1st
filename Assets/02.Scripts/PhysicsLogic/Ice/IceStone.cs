using UnityEngine;

public class IceStone : MonoBehaviour
{
    public enum State { Big = 3, Normal = 2, Small = 1 }    // big: 3, normal: 2, small: 1 <<<< Scale
    public State state;

    void Start()
    {
        transform.localScale = new Vector3((int)state, (int)state, 1);

        if (state == State.Big)
            gameObject.AddComponent<IceStoneBig>();
        else if (state == State.Normal)
            gameObject.AddComponent<IceStoneNormal>();
        else if (state == State.Small)
            gameObject.AddComponent<IceStoneSmall>();
    }
}

public class IceStoneSelect : MonoBehaviour
{
    protected GameObject IceStonePrefab;
    protected float timeset = 0;
    protected float timesetLimit = 0.2f;
    
    void Start()
    {
        IceStonePrefab = Resources.Load<GameObject>("IceStone");
    }

    void Update()
    {
        if (timeset >= timesetLimit)
            return;
        timeset += Time.deltaTime;
    }

    protected virtual void OnTriggerStay2D(Collider2D col) { }

    protected Vector2 GetSpreadDirectionFromAngle(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
    }
}

public class IceStoneBig : IceStoneSelect
{
    protected override void OnTriggerStay2D(Collider2D col)
    {
        if (timeset < timesetLimit)
            return;
        float randomStartAngle = Random.Range(0f, 360f);
        float angleOffset = 120f;

        for (int i = 0; i < 3; i++)
        {
            GameObject normal = Instantiate(IceStonePrefab);
            normal.GetComponent<IceStone>().state = IceStone.State.Normal;

            float angle = randomStartAngle + (i * angleOffset);
            Vector2 offset = transform.GetComponent<CircleCollider2D>().radius * transform.localScale.x * GetSpreadDirectionFromAngle(angle) / 1.5f * 2f;
            normal.transform.position = transform.position + (Vector3)offset;

            Vector2 direction = GetSpreadDirectionFromAngle(angle);
            normal.GetComponent<Rigidbody2D>().velocity = direction * 6f;
        }
        LevelManage.AddScore(1, 2300);
        Destroy(gameObject);
    }
}

public class IceStoneNormal : IceStoneSelect
{
    protected override void OnTriggerStay2D(Collider2D col)
    {        
        if (timeset < timesetLimit)
            return;

        float randomStartAngle = Random.Range(0f, 360f);
        float angleOffset = 120f;

        for (int i = 0; i < 3; i++)
        {
            GameObject small = Instantiate(IceStonePrefab);
            small.GetComponent<IceStone>().state = IceStone.State.Small;

            float angle = randomStartAngle + (i * angleOffset);
            Vector2 offset = transform.GetComponent<CircleCollider2D>().radius * transform.localScale.x * GetSpreadDirectionFromAngle(angle);
            small.transform.position = transform.position + (Vector3)offset;

            Vector2 direction = GetSpreadDirectionFromAngle(angle);
            small.GetComponent<Rigidbody2D>().velocity = direction * 3f;
        }
        LevelManage.AddScore(1, 1300);
        Destroy(gameObject);
    }
}

public class IceStoneSmall : IceStoneSelect
{
    protected override void OnTriggerStay2D(Collider2D col)
    {
        LevelManage.AddScore(1, 800);
        Destroy(gameObject);
    }
}