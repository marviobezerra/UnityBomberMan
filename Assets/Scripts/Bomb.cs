using UnityEngine;

public class Bomb : MonoBehaviour
{

    public int bombTime = 3;
    public GameObject explosionMidle;
    public GameObject explosionRadio;
    public GameObject explosionRadioEdge;

    void Start()
    {
        Invoke("Explode", bombTime);
    }

    void Explode()
    {
        // Explosion Midle
        Instantiate(explosionMidle, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

        // Explosion Horizontal Right
        Instantiate(explosionRadio, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
        Instantiate(explosionRadioEdge, new Vector3(transform.position.x + 2, transform.position.y, 0), Quaternion.identity);

        // Explosion Horizontal Letf
        Instantiate(explosionRadio, new Vector3(transform.position.x - 1, transform.position.y, 0), Quaternion.Euler(0, 180, 0));
        Instantiate(explosionRadioEdge, new Vector3(transform.position.x - 2, transform.position.y, 0), Quaternion.Euler(0, 180, 0));

        // Explosion Vertical Top
        Instantiate(explosionRadio, new Vector3(transform.position.x, transform.position.y - 1, 0), Quaternion.Euler(0, 0, -90));
        Instantiate(explosionRadioEdge, new Vector3(transform.position.x, transform.position.y - 2, 0), Quaternion.Euler(0, 0, -90));

        // Explosion Vertical Down
        Instantiate(explosionRadio, new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.Euler(0, 0, 90));
        Instantiate(explosionRadioEdge, new Vector3(transform.position.x, transform.position.y + 2, 0), Quaternion.Euler(0, 0, 90));

        Destroy(gameObject);
    }
}
