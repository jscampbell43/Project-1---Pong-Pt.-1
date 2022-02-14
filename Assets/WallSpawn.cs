using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    public GameObject wallPrefab;

    public Transform[] wallSpawnTransforms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// Power Up 1 Wall Spawn
        if (PowerUps.leftPowerUp1)
        {
			// Wall instantiated in front of Left Paddle
            Transform transform = wallSpawnTransforms[0];
            GameObject instance = Instantiate(wallPrefab);
            instance.transform.position = transform.position;
            PowerUps.leftPowerUp1 = false;
			Destroy(instance, 10);
        }
        else if (PowerUps.rightPowerUp1)
        {
			// Wall instantiated in front of Right Paddle
            Transform transform = wallSpawnTransforms[1];
            GameObject instance = Instantiate(wallPrefab);
            instance.transform.position = transform.position;
            PowerUps.rightPowerUp1 = false;
			Destroy(instance, 10);
        }
    }
}
