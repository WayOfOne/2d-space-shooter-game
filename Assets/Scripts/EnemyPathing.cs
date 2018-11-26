using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    WaveConfig waveConfig;
    List<Transform> spawnPoints;
    int index = 0;

	// Use this for initialization
	void Start () {
        spawnPoints = waveConfig.GetSpawnPoints();
        transform.position = spawnPoints[index].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public void SetWaveConfiguration(WaveConfig config)
    {
        this.waveConfig = config;
    }

    private void Move()
    {
        //move to the spawn points if index isn't at the end
        if (index <= spawnPoints.Count - 1)
        {
            var targetPosition = spawnPoints[index].transform.position;
            var movementThisFrame = Time.deltaTime * waveConfig.GetMoveSpeed();
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                index++;
            }
        }
        else
        {
            Destroy(gameObject);

        }
    }

}
