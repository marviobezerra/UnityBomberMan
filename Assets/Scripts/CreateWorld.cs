using UnityEngine;

public class CreateWorld : MonoBehaviour
{
    public GameObject tileFixed;
    public GameObject tileDestructable;
    public GameObject grees;

    private System.Random randGen;

    private void Awake()
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

                // Don't create on the start blocks
                if ((line == 1 && column == 1) || (line == 1 && column == 2) || (line == 2 && column == 1))
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
