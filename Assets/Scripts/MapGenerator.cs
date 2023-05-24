using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    Cell[][] cellMap;
    int numRows= 10;
    int numColumns= 10;
    void Start()
    {
        GenerateMap();
    }

    void Update()
    {
        
    }

    void GenerateMap()
    {
        cellMap = new Cell[numRows][];
        for (int row= 0; row < numRows; row++)
        {
            cellMap[row] = new Cell[numColumns];
            for(int column= 0; column<numColumns; column++)
            {
                cellMap[row][column] = new Cell(row, column);
                Debug.Log(cellMap[row][column].x);
            }
        }
        
    }
}
