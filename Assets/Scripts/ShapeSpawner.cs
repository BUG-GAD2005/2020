using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShapeSpawner : MonoBehaviour
{
    public List<Transform> shapeSpawnPos;

    [SerializeField] private bool spawnShape;
    
    private List<GameObject> _deckOfShapes;
    private List<GameObject> _dynamicDeck;
    private List<GameObject> _handOfShapes;
    

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
            _deckOfShapes = new List<GameObject>();
            _handOfShapes = new List<GameObject>();
            _dynamicDeck = _deckOfShapes;
            _deckOfShapes.AddRange(LoadResources<GameObject>("BlockShapes/"));
            InitializeHand();
        }
    }

    private void InitializeHand(){
        for(int i = 0; i < 3; i++){
            var index = Random.Range(0, _deckOfShapes.Count - 1);
            _dynamicDeck.RemoveAt(index);
            _handOfShapes.Add(Instantiate(_dynamicDeck[index], shapeSpawnPos[i].position, Quaternion.identity));
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
