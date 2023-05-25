using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Observer;
using GlobalVariables;

public class TileMapManager : ObserverBase
{
    #region Private Variables

    private Tilemap _tilemap;

    #endregion

    #region Monobehaviour Methods

    private void Start()
    {
        _tilemap = MainLogic.Instance.ActiveTileMap;
    }

    private void OnEnable()
    {
        Register(CustomEvents.OnShapePlaced, CheckFullLine);
    }

    private void OnDisable()
    {
        Unregister(CustomEvents.OnShapePlaced, CheckFullLine);
    }

    #endregion

    #region Private Methods

    private void CheckFullLine()
    {
        var bounds = _tilemap.cellBounds;

        for (int row = bounds.yMin; row < bounds.yMax; row++)
        {
            if (IsRowFull(row))
            {
                Debug.Log("Row is full: " + row);
                EmptyRow(row);
            }
        }

        for (int column = bounds.xMin; column < bounds.xMax; column++)
        {
            if (IsColumnFull(column))
            {
                Debug.Log("Column is full: " + column);
                EmptyColumn(column);
            }
        }
    }

    private bool IsRowFull(int row)
    {
        var bounds = _tilemap.cellBounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            var cellPos = new Vector3Int(col, row, 0);
            var tile = _tilemap.GetTile(cellPos);
            
            if (tile == null)
            {
                return false; // Found an empty cell, row is not full
            }
        }

        return true; // All cells in the row are filled, row is full
    }

    private bool IsColumnFull(int column)
    {
        var bounds = _tilemap.cellBounds;

        for (int row = bounds.yMin; row < bounds.yMax; row++)
        {
            var cellPos = new Vector3Int(column, row, 0);
            var tile = _tilemap.GetTile(cellPos);

            if (tile == null)
            {
                return false; // Found an empty cell, column is not full
            }
        }

        return true; // All cells in the column are filled, column is full
    }

    private void EmptyRow(int row)
    {
        var bounds = _tilemap.cellBounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            var cellPos = new Vector3Int(col, row, 0);
            _tilemap.SetTile(cellPos, null);
        }
    }

    private void EmptyColumn(int column)
    {
        var bounds = _tilemap.cellBounds;

        for (int row = bounds.yMin; row < bounds.yMax; row++)
        {
            var cellPos = new Vector3Int(column, row, 0);
            _tilemap.SetTile(cellPos, null);
        }
    }

    #endregion
}