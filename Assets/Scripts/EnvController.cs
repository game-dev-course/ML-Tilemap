using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class EnvController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject warrior;
    [SerializeField] private Vector3 warriorStartPoint;
    [SerializeField] private Vector3 targetStartPoint;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase[] allowedTiles;
    
    // private Vector3Int GetRandomTile()
    // {
    //     BoundsInt bounds = tilemap.cellBounds;
    //     Vector3Int randomPosition = new Vector3Int(
    //         Random.Range(bounds.min.x, bounds.max.x),
    //         Random.Range(bounds.min.y, bounds.max.y),
    //         bounds.min.z
    //     );
    //     return randomPosition;
    // }
    //
    // private Vector3Int GetAllowedRandomTile()
    // {
    //     for (;;)
    //     {
    //         Vector3Int currBase = GetRandomTile();
    //         TileBase currTileBase = tilemap.GetTile(currBase);
    //         if (allowedTiles.Contains(currTileBase))
    //         {
    //             return currBase;
    //         }
    //     }
    // }
    //
    // private void Start()
    // {
    //     Vector3Int randomTileTargetSpawn = GetAllowedRandomTile();
    //     Vector3Int randomTileWarriorSpawn = GetAllowedRandomTile();
    //     targetStartPoint = randomTileTargetSpawn;
    //     warriorStartPoint = randomTileWarriorSpawn;
    //     
    //     Debug.Log("Current base 1 " + randomTileTargetSpawn);
    //     Debug.Log("Current base 2 " + randomTileWarriorSpawn);
    //
    // }

    // Start is called before the first frame update
    void Awake()
    {
        ResetEnv();
    }

    public void ResetEnv()
    {
        Debug.Log("PNT TARGET " + targetStartPoint);
        Debug.Log("PNT WARRIOR " + warriorStartPoint);
        target.gameObject.transform.position = targetStartPoint;
        warrior.gameObject.transform.position = warriorStartPoint;
    }
}