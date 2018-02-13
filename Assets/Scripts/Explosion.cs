using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        Invoke("Remove", 2);
    }

    void Remove()
    {
        Destroy(gameObject);
    }
}
