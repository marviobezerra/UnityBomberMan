using UnityEngine;

public class Bomb : MonoBehaviour {

    public int bombTime = 3;

	void Start () {
        Invoke("Explode", bombTime);
	}

    void Explode()
    {
        Destroy(gameObject);
    }
}
