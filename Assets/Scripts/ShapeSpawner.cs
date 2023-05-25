using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using GlobalVariables;
using Observer;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShapeSpawner : ObserverBase
{
    #region Public Variables

    public List<Transform> shapeSpawnPos;

    #endregion

    #region Serialized Variables

    [SerializeField] private bool spawnShape;

    #endregion

    #region Private Variables

    private List<GameObject> _deckOfShapes;
    private List<GameObject> _dynamicDeck;
    private int _shapeCount;

    #endregion

    #region Monobehavious Methods

    private void Start()
    {
        _deckOfShapes = new List<GameObject>();
        _dynamicDeck = _deckOfShapes;
        _deckOfShapes.AddRange(LoadResources<GameObject>("BlockShapes/"));
        InitializeHand();
    }

    private void Update()
    {
        if (spawnShape)
        {
            spawnShape = false;

        }
    }
    
    private void OnEnable()
    {
        Register(CustomEvents.OnShapePlaced, OnShapePlaced);
    }

    private void OnDisable()
    {
        Unregister(CustomEvents.OnShapePlaced, OnShapePlaced);
    }

    #endregion
    
    #region Public Methods

    public static T[] LoadResources<T>(string Path) where T : class {
        T[] list = Resources.LoadAll(Path, typeof(T)).Cast<T>().ToArray();
        return list;
    } 

    public static T LoadResource<T>(string Path) where T : class {
        T obj = Resources.Load(Path, typeof(T)) as T;
        return obj;
    }

    #endregion

    #region Private Methods

    private void OnShapePlaced()
    {
        _shapeCount--;
        if (_shapeCount == 0)
        {            
            _deckOfShapes = new List<GameObject>();
            _dynamicDeck = _deckOfShapes;
            _deckOfShapes.AddRange(LoadResources<GameObject>("BlockShapes/"));
            InitializeHand();
        }
    }

    private void InitializeHand(){
        for(int i = 0; i < 3; i++)
        {
            var index = Random.Range(0, _deckOfShapes.Count - 1);
            _dynamicDeck.RemoveAt(index);
            _shapeCount++;
        }
        _dynamicDeck = _deckOfShapes;
    }

    #endregion
    
}
