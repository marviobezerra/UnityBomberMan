using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    Skull = 0,
    ExtraBomb = 1,
    ExplosionExpander = 2,
    Accelerator = 3
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (powerUp)
            {
                case PowerUpType.Skull:
                    Constants.PowerSkull();
                    break;
                case PowerUpType.ExtraBomb:
                    Constants.PowerExtraBomb();
                    break;
                case PowerUpType.ExplosionExpander:
                    Constants.PowerExplosionExpander();
                    break;
                case PowerUpType.Accelerator:
                    Constants.PowerUpAccelerator();
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }
    }
}
