using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    GameObject[][] cellMap;
    int numRows= 10;
    int numColumns= 10;
    float cellSpace = 1.3f;
    public GameObject cellPrefab;
    Vector3 startingVector;
    void Start()
    {
        startingVector = new Vector3(-(numRows - 1) / 2 * cellSpace, -(numColumns - 1) / 2 * cellSpace, 0);

        GenerateMap();
    }

    void Update()
    {
        
    }

    void GenerateMap()
    {
        cellMap = new GameObject[numRows][];
        for (int row= 0; row < numRows; row++)
        {
            cellMap[row] = new GameObject[numColumns];
            for(int column= 0; column<numColumns; column++)
            {
                Vector3 offset = new Vector3(cellSpace * row, cellSpace * column, 0);
                Vector3 cellVector = startingVector + offset;
                cellMap[row][column] = Instantiate(cellPrefab,cellVector, Quaternion.identity );
                Debug.Log(cellMap[row][column]);
            }
        }
        
    }
}
