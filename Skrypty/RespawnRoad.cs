using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnRoad : MonoBehaviour
{
    private GameController gameController;
    private SpawnObstacles spawnObstacles;
    void Start()
    {
        gameController = Object.FindObjectOfType<GameController>();
        spawnObstacles = GetComponentInParent<SpawnObstacles>();
    }
   void OnTriggerEnter()
    {
        Destroy(spawnObstacles.spawned[0].gameObject);
        Destroy(spawnObstacles.spawned[1].gameObject);
        gameController.SpawnRoad(this.transform.parent.gameObject);
    }
    
}
