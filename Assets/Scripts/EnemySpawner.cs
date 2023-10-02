using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfig> WaveConfigs; //waveconfig list
    [SerializeField] float timeBetweenWaves = 0f; // time variable
    [SerializeField] bool isLooping; // to loop waves
    WaveConfig currentWave;

    

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine( SpawnEnemyWaves()); //coroutine
    }
    public WaveConfig GetCurrentWave() //get present wave
    {

        return currentWave;
    }

    IEnumerator SpawnEnemyWaves() //wave spawnings
    {
        do 
        {
            foreach(WaveConfig wave in WaveConfigs)
    {
            currentWave = wave;
        
        for(int i = 0; i < currentWave.GetEnemyCount(); i++ )
            {
        Instantiate(currentWave.GetEnemyPrefab(i) , 
            currentWave.GetStartingWaypoint().position ,
            Quaternion.Euler(0 , 0 , 180) ,  // euler for rotate 180 degree on object creation
            transform); //creating object waves
            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime()); //coroutine for object time
            }
    }
        yield return new WaitForSeconds(timeBetweenWaves); //coroutine for wave time
        
        }
        while (isLooping); //wave continues
    }
    
    
}
