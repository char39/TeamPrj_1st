using UnityEngine;

public class BirdID : MonoBehaviour
{
    private static int instanceCount = 0;
    public int ID { get; private set; }

    void Start()
    {
        ID = instanceCount++;
    }
}
