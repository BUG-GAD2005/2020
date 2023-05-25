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
    public List<Transform> shapeSpawnPos;

    [SerializeField] private bool spawnShape;
    
    private List<GameObject> _deckOfShapes;
    private List<GameObject> _dynamicDeck;
    private List<GameObject> _handOfShapes;
    private int _shapeCount;

    private void Start()
    {
        _deckOfShapes = new List<GameObject>();
        _handOfShapes = new List<GameObject>();
        _dynamicDeck = _deckOfShapes;
        _deckOfShapes.AddRange(LoadResources<GameObject>("BlockShapes/"));
        InitializeHand();
        foreach (var shape in _handOfShapes)
        {
            Debug.Log(shape.name);
        }
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

    private void OnShapePlaced()
    {
        _shapeCount--;
        Debug.Log(_shapeCount);
        if (_shapeCount == 0)
        {            
            _deckOfShapes = new List<GameObject>();
            _handOfShapes = new List<GameObject>();
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
            _handOfShapes.Add(Instantiate(_dynamicDeck[index], shapeSpawnPos[i].position, Quaternion.identity));
            _shapeCount++;
        }
        _dynamicDeck = _deckOfShapes;
    }

    public static T[] LoadResources<T>(string Path) where T : class {
        T[] list = Resources.LoadAll(Path, typeof(T)).Cast<T>().ToArray();
        return list;
    } 

    public static T LoadResource<T>(string Path) where T : class {
        T obj = Resources.Load(Path, typeof(T)) as T;
        return obj;
    }
}
