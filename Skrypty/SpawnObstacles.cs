using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] obstacle = new GameObject[3];
    public GameObject coin;
    public Transform[] lines = new Transform[3];
    public bool isStart = false;
    public GameObject[] spawned = new GameObject[2];
    void Start()
    {
        if (!isStart)
        {
            int randomCoin = Random.Range(0, 3);
            int randomLine = Random.Range(0, 3);
            int randomObstacle = Random.Range(0, 3);
            spawned[0] = Instantiate(obstacle[randomObstacle], lines[randomLine].position, Quaternion.Euler(0, 180, 0));
            if (randomCoin == 1)
            {
                while (randomCoin == randomLine)
                {
                    randomCoin = Random.Range(0, 3);
                }
                spawned[1] = Instantiate(coin, lines[randomCoin].position, Quaternion.Euler(0, 180, 0));
            }
        }
    }
}