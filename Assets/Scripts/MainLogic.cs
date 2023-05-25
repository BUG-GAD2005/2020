using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MainLogic : MonoBehaviour
{
    #region Public Variables

    public static MainLogic Instance { get; private set; }
    public Tilemap ActiveTileMap => activeTileMap;

    #endregion

    #region Serialized Fields

    [SerializeField] private Tilemap placedShapeTileMap;
    [SerializeField] private List<Vector2> placedShapePos;
    [SerializeField] private Tilemap baseTileMap;
    [SerializeField] private Tilemap activeTileMap;
    [SerializeField] private Tile baseTile;
    [SerializeField] private Tile activeTile;
    [SerializeField] private ShapePlacement shapePlacement;

    #endregion

    #region Private Variables

    private Vector3 _mouseWorldPos;
    private Vector3Int _mouseCellPos;
    private bool _isPlacementValid = true;

    #endregion

    #region Monobehavious Methods

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

    #endregion

    #region Public Methods

    public bool CheckValidPlacement(Tilemap tilemap, Vector3 mousePos){
        _mouseCellPos = baseTileMap.WorldToCell(mousePos);
        placedShapePos = shapePlacement.GetAllTiles(tilemap);
        _isPlacementValid = true;
        foreach (var currentTilePos in placedShapePos.Select(shapePos => new Vector3Int((int)(shapePos.x + _mouseCellPos.x), (int)(shapePos.y + _mouseCellPos.y), 0)))
        {
            if(baseTileMap.GetTile(currentTilePos) == baseTile){
                if(activeTileMap.GetTile(currentTilePos) != null){
                    _isPlacementValid = false;
                }
            }
            else{
                _isPlacementValid = false;
            }
        }
        if(_isPlacementValid)
        {
            foreach (var currentTilePos in placedShapePos.Select(shapePos => new Vector3Int((int)(shapePos.x + _mouseCellPos.x), (int)(shapePos.y + _mouseCellPos.y), 0)))
            {
                activeTileMap.SetTile(currentTilePos, activeTile);
            }
        }
        return _isPlacementValid;
    }

    #endregion
}