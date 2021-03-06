﻿using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int bombTime = 3;
    public GameObject explosionMidle;
    public GameObject explosionRadio;
    public GameObject explosionRadioEdge;
    public Player player;

    public void setPlayer(Player player)
    {
        this.player = player;
        this.player.powerUps.bombCurrentCount++;
    }

    void Start()
    {
        Invoke("Explode", bombTime);
    }

    void Explode()
    {
        player.powerUps.bombCurrentCount--;
        
        // Explosion Midle
        Instantiate(explosionMidle, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

        var blockHorizontal = (transform.position.x + 1) % 2 == 0 && (transform.position.y) % 2 == 0;
        var blockVertical = (transform.position.x) % 2 == 0 && (transform.position.y + 1) % 2 == 0;

        // Explosion Horizontal Right
        if (transform.position.x + 1 < Constants.WorldEndX && !blockHorizontal)
        {
            Instantiate(player.powerUps.hasBombExpander ? explosionRadio : explosionRadioEdge, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);

            if (player.powerUps.hasBombExpander && transform.position.x + 2 < Constants.WorldEndX)
                Instantiate(explosionRadioEdge, new Vector3(transform.position.x + 2, transform.position.y, 0), Quaternion.identity);
        }

        // Explosion Horizontal Letf
        if (transform.position.x - 1 > Constants.WorldBeginX && !blockHorizontal)
        {
            Instantiate(player.powerUps.hasBombExpander ? explosionRadio : explosionRadioEdge, new Vector3(transform.position.x - 1, transform.position.y, 0), Quaternion.Euler(0, 0, 180));

            if (player.powerUps.hasBombExpander && transform.position.x - 2 > Constants.WorldBeginX)
                Instantiate(explosionRadioEdge, new Vector3(transform.position.x - 2, transform.position.y, 0), Quaternion.Euler(0, 0, 180));
        }

        // Explosion Vertical Top
        if (transform.position.y + 1 < Constants.WorldBeginY && !blockVertical)
        {
            Instantiate(player.powerUps.hasBombExpander ? explosionRadio : explosionRadioEdge, new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.Euler(0, 0, 90));

            if (player.powerUps.hasBombExpander && transform.position.y + 2 < Constants.WorldBeginY)
                Instantiate(explosionRadioEdge, new Vector3(transform.position.x, transform.position.y + 2, 0), Quaternion.Euler(0, 0, 90));
        }

        // Explosion Vertical Down
        if (transform.position.y - 1 > Constants.WorldEndY && !blockVertical)
        {
            Instantiate(player.powerUps.hasBombExpander ? explosionRadio : explosionRadioEdge, new Vector3(transform.position.x, transform.position.y - 1, 0), Quaternion.Euler(0, 0, -90));

            if (player.powerUps.hasBombExpander && transform.position.y - 2 > Constants.WorldEndY)
                Instantiate(explosionRadioEdge, new Vector3(transform.position.x, transform.position.y - 2, 0), Quaternion.Euler(0, 0, -90));
        }

        Destroy(gameObject);
    }
}
