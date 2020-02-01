using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnRoad : MonoBehaviour
{
    private GameController gameController;
    private SpawnObstacles spawnObstacles;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        spawnObstacles = GetComponentInParent<SpawnObstacles>();
    }
   void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            /*
            Destroy(spawnObstacles.spawned[0].gameObject);
            Destroy(spawnObstacles.spawned[1].gameObject);
            gameController.SpawnRoad(this.transform.parent.gameObject);*/
            Instantiate(gameController.road, new Vector3(0, 0, gameController.zOffset * 9), Quaternion.identity);
            gameController.zOffset++;
            Destroy(this.gameObject);
        }
    }
    
}
