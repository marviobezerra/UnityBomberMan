using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;
    public GameObject[] powerUps;
    private System.Random randGen;


    void Start()
    {
        Invoke("Remove", 2);
    }

    void Remove()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Constants.canMove = false;
            Instantiate(lose);
            return;
        }

        if (collision.gameObject.tag == "TileDestructable")
        {
            Constants.tiles--;

            if (Constants.tiles <= 0)
            {
                Constants.canMove = false;
                Instantiate(win);
                return;
            }

            if (randGen == null)
            {
                randGen = new System.Random();
            }

            if (randGen.Next(0, 100) < Constants.dificultLevel * 2)
            {
                var index = randGen.Next(0, powerUps.Length);
                var item = powerUps[index];
                var x = Mathf.RoundToInt(collision.gameObject.transform.position.x);
                var y = Mathf.RoundToInt(collision.gameObject.transform.position.y);

                Instantiate(item, new Vector3(x, y, 0), Quaternion.identity);
            }

            Destroy(collision.gameObject);
        }
    }
}
