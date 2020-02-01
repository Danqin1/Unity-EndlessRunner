using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject road;
    public int score = 0;
    public int zOffset=0;
    public bool IsDead = false;
    void Start()
    {
        if(road)
        {
            for(int i = 0;i<30;i++)
            {
                if(i<2)
                {
                    road.GetComponent<SpawnObstacles>().isStart = true;
                }else 
                {
                    road.GetComponent<SpawnObstacles>().isStart = false;
                }
                Instantiate(road, new Vector3(0, 0, zOffset * 9), Quaternion.identity);
                zOffset++;
            }
        }
        IsDead = false;
    }
    void Update()
    {
        if(PlayerPrefs.GetInt("HighScore",0)<score)
        {
            PlayerPrefs.SetInt("HighScore",score);
        }
    }
    public void SpawnRoad(GameObject road0)
    {
        Instantiate(road, new Vector3(0, 0, zOffset * 9), Quaternion.identity);
        zOffset++;
        Destroy(road0.gameObject);
    }
    
}
