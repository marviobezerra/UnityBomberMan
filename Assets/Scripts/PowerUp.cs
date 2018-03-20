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
            var player = collision.GetComponent<Player>();

            switch (powerUp)
            {
                case PowerUpType.Skull:
                    player.powerUps.PowerSkull();
                    break;
                case PowerUpType.ExtraBomb:
                    player.powerUps.PowerExtraBomb();
                    break;
                case PowerUpType.ExplosionExpander:
                    player.powerUps.PowerExplosionExpander();
                    break;
                case PowerUpType.Accelerator:
                    player.powerUps.PowerUpAccelerator();
                    break;
                default:
                    break;
            }

            Destroy(gameObject);
        }

        //if (collision.gameObject.tag == "Explosion")
        //{
        //    Destroy(gameObject);

        //}
    }
}
