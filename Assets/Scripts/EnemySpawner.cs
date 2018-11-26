using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int index = 0;
    [SerializeField] bool isLooping = false;

	// Use this for initialization
	IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (isLooping);
        
	}

    private IEnumerator SpawnAllWaves()
    {
        for(int i = index; index < waveConfigs.Count -1; i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnEnemiesInWave(currentWave));

        }
    }
	
    private IEnumerator SpawnEnemiesInWave(WaveConfig waveConfig)
    {
        for(int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            var newEnemy= Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetSpawnPoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfiguration(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetSpawnRate());
        }
        
    }
	

}
