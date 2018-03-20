using System.Collections.Generic;
using UnityEngine;

public class CreateWorld : MonoBehaviour
{
    public GameObject tileFixed;
    public GameObject tileDestructable;
    public GameObject grees;
    public GameObject player;
    public List<GameObject> players;

    private System.Random randGen;

    private void createUser()
    {
        if (players.Count >= 4)
        {
            return;
        }

        var newPlayerId = players.Count;
        Vector3 newPosition = new Vector3(-9, 6, 0);
        Color color = Color.white;

        switch (newPlayerId)
        {
            case 0:
                newPosition = new Vector3(-9, 6, 0);
                color = Color.white;
                break;
            case 1:
                newPosition = new Vector3(9, 6, 0);
                color = Color.yellow;
                break;
            case 2:
                newPosition = new Vector3(-9, -5, 0);
                color = Color.red;
                break;
            case 3:
                newPosition = new Vector3(9, -5, 0);
                color = Color.green;
                break;
            default:
                break;
        }

        var newPlayer = Instantiate(player, newPosition, Quaternion.identity);

        newPlayer.GetComponent<SpriteRenderer>().color = color;
        newPlayer.GetComponent<Player>().powerUps.playerId = newPlayerId;

        if (players == null)
        {
            players = new List<GameObject>();
        }

        players.Add(newPlayer);

    }

    private void Update()
    {
        if (Input.GetKeyDown("+") || Input.GetKeyDown("="))
        {
            createUser();
        }
    }

    private void Awake()
    {
        if (players.Count == 0)
        {
            createUser();
        }
    }

    private void Start()
    {
        randGen = new System.Random();

        for (int line = 0; line < Constants.GridLines + 1; line++)
        {
            for (int column = 0; column < Constants.GridColumns + 1; column++)
            {
                // First and Last Line
                if (line == 0 || line == Constants.GridLines)
                {
                    Instantiate(tileFixed, new Vector3(Constants.WorldBeginX + column, Constants.WorldBeginY - line, 0), Quaternion.identity);
                    continue;
                }

                // First and Last Column
                if (column == 0 || column == Constants.GridColumns)
                {
                    Instantiate(tileFixed, new Vector3(Constants.WorldBeginX + column, Constants.WorldBeginY - line, 0), Quaternion.identity);
                    continue;
                }

                // Fixed Tiles
                if (line > 1 && column > 1 && line % 2 == 0 && column % 2 == 0)
                {
                    Instantiate(tileFixed, new Vector3(Constants.WorldBeginX + column, Constants.WorldBeginY - line, 0), Quaternion.identity);
                    continue;
                }

                // Gress
                Instantiate(grees, new Vector3(Constants.WorldBeginX + column, Constants.WorldBeginY - line, 0), Quaternion.identity);

                // Don't create on the start blocks for player 1
                if ((line == 1 && column == 1) || (line == 1 && column == 2) || (line == 2 && column == 1))
                {
                    continue;
                }

                // Don't create on the start blocks for player 2
                if ((line == 1 && column == Constants.GridColumns - 1) || (line == 1 && column == Constants.GridColumns - 2) || (line == 2 && column == Constants.GridColumns - 1))
                {
                    continue;
                }

                // Don't create on the start blocks for player 3
                if ((line == Constants.GridLines - 1 && column == 1) || (line == Constants.GridLines - 1 && column == 2) || (line == Constants.GridLines - 2 && column == 1))
                {
                    continue;
                }

                // Don't create on the start blocks for player 4
                if ((line == Constants.GridLines - 1 && column == Constants.GridColumns - 1) || (line == Constants.GridLines - 1 && column == Constants.GridColumns - 2) || (line == Constants.GridLines - 2 && column == Constants.GridColumns - 1))
                {
                    continue;
                }

                // Destructible tiles
                if (randGen.Next(0, 100) < Constants.dificultLevel)
                {
                    Constants.tiles++;
                    Instantiate(tileDestructable, new Vector3(Constants.WorldBeginX + column, Constants.WorldBeginY - line, 0), Quaternion.identity);
                }
            }
        }

        Constants.canMove = true;
    }
}
