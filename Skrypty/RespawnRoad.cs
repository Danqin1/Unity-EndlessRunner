using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnRoad : MonoBehaviour
{
    public GameController gameController;
    void Start()
    {
        gameController = Object.FindObjectOfType<GameController>();
    }
   void OnTriggerEnter()
    {
        gameController.SpawnRoad(this.transform.parent.gameObject);
        Debug.Log("trigger0");
    }
    
}
