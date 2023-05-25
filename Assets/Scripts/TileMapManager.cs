using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using Observer;
using GlobalVariables;

public class TileMapManager : ObserverBase
{
    public Tilemap tilemap;

    private void OnEnable()
    {
        Register(CustomEvents.OnShapePlaced, CheckFullLine);
    }

    private void OnDisable()
    {
        Unregister(CustomEvents.OnShapePlaced, CheckFullLine);
    }
    public void CheckFullLine()
    {
        Debug.Log("entered checkfullline");
        for (int row= 0; row<10; row++)
        {
            CheckAndEmptyRow(row);
           
        }
        for (int column = 0; column < 10; column++)
        {
            CheckAndEmptyColumn(column);
            
        }
    }
    public void CheckAndEmptyRow(int row)
    {
        if (IsRowFull(row))
        {
            Debug.Log("row is emptied");
            EmptyRow(row);
        }
    }

    public void CheckAndEmptyColumn(int column)
    {
        if (IsColumnFull(column))
        {
            Debug.Log("column is emptied");
            EmptyColumn(column);
        }
    }

    private bool IsRowFull(int row)
    {
        bool isfull = true;
        BoundsInt bounds = tilemap.cellBounds;
        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {

            Debug.Log(bounds.xMin);
            Debug.Log(bounds.xMax);
            Vector3Int cellPos = new Vector3Int(col, row, 0);
            TileBase tile = tilemap.GetTile(cellPos);
            Debug.Log("col" + col + "is being checked");
            if (tile == null)
            {
                isfull = false;
                Debug.Log(tile);
            }
            else
            {
                isfull = true;
            }
        }

        return isfull; // All cells in the row are filled, row is full
    }

    private bool IsColumnFull(int column)
    {
        BoundsInt bounds = tilemap.cellBounds;

        for (int row = bounds.yMin; row < bounds.yMax; row++)
        {
            Vector3Int cellPos = new Vector3Int(column, row, 0);
            TileBase tile = tilemap.GetTile(cellPos);
            Debug.Log("row" + row + "is being checked");

            if (tile == null)
            {
                return false; // Found an empty cell, column is not full
            }
        }

        return true; // All cells in the column are filled, column is full
    }

    private void EmptyRow(int row)
    {
        BoundsInt bounds = tilemap.cellBounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int cellPos = new Vector3Int(col, row, 0);
            tilemap.SetTile(cellPos, null);
        }
    }

    private void EmptyColumn(int column)
    {
        BoundsInt bounds = tilemap.cellBounds;

        for (int row = bounds.yMin; row < bounds.yMax; row++)
        {
            Vector3Int cellPos = new Vector3Int(column, row, 0);
            tilemap.SetTile(cellPos, null);
        }
    }
}