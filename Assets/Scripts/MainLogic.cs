using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainLogic : MonoBehaviour
{
    public static MainLogic Instance { get; private set; }
    
    [SerializeField] private Tilemap placedShapeTileMap;
    [SerializeField] private List<Vector2> placedShapePos;
    [SerializeField] private Tilemap baseTileMap;
    [SerializeField] private Tilemap activeTileMap;
    [SerializeField] private Tile baseTile;
    [SerializeField] private Tile activeTile;
    [SerializeField] private ShapePlacement shapePlacement;
    
    private Vector3 _mouseWorldPos;
    private Vector3Int _mouseCellPos;
    private bool _isPlacementValid = true;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public bool CheckValidPlacement(Tilemap tilemap, Vector3 mousePos)
    {
        _mouseCellPos = baseTileMap.WorldToCell(mousePos);
        placedShapePos = shapePlacement.GetAllTiles(tilemap);
        _isPlacementValid = true;
    
        foreach (Vector2 shapePos in placedShapePos)
        {
            var currentTilePos = new Vector3Int((int)(shapePos.x + _mouseCellPos.x), (int)(shapePos.y + _mouseCellPos.y), 0);

            if (baseTileMap.GetTile(currentTilePos) == baseTile)
            {
                if (activeTileMap.GetTile(currentTilePos) != null)
                {
                    _isPlacementValid = false;
                    break;
                }
            }
            else
            {
                _isPlacementValid = false;
                break;
            }
        }

        if (_isPlacementValid)
        {
            foreach (Vector2 shapePos in placedShapePos)
            {
                var currentTilePos = new Vector3Int((int)(shapePos.x + _mouseCellPos.x), (int)(shapePos.y + _mouseCellPos.y), 0);
                activeTileMap.SetTile(currentTilePos, activeTile);
            }
        }

        return _isPlacementValid;
    }

}