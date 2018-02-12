using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWorld : MonoBehaviour
{
    public int columns = 18;
    public int lines = 9;
    public GameObject block;

    private void Awake()
    {
        Vector3 worldPosition = new Vector3(-9.5f, 5.5f, 0);

        // First Line
        for (int i = 0; i < columns + 1; i++)
        {
            Instantiate(block, new Vector3(worldPosition.x + i, worldPosition.y, worldPosition.z), Quaternion.identity);
        }

        // Lines
        for (int i = 0; i < lines - 1; i++)
        {
            Instantiate(block, new Vector3(worldPosition.x, worldPosition.y - i - 1, worldPosition.z), Quaternion.identity);
            Instantiate(block, new Vector3(worldPosition.x + columns, worldPosition.y - i - 1, worldPosition.z), Quaternion.identity);
        }

        // Last line
        for (int i = 0; i < columns + 1; i++)
        {
            Instantiate(block, new Vector3(worldPosition.x + i, worldPosition.y - lines, worldPosition.z), Quaternion.identity);
        }

        // Midle blocks
        for (int i = 0; i < columns + 1; i++)
        {
            if (i == 0 || i == columns || i % 2 != 0)
            {
                continue;
            }

            for (int j = 0; j < lines - 1; j++)
            {
                if (j == 0 || j == columns || j % 2 == 0)
                {
                    continue;
                }

                Instantiate(block, new Vector3(worldPosition.x + i, worldPosition.y - j - 1, worldPosition.z), Quaternion.identity);
            }
        }

    }
}
