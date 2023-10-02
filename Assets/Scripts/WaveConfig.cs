using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Wave Config" , fileName = "New Wave Config")] //create menu for create new file named wave Config
public class WaveConfig : ScriptableObject // this file is  is command script
{
    //waveconfig serialized fields 
    [SerializeField] List<GameObject> enemyPrefabs; //prefab 
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeedEnemy = 5f ; //enemy move speed
    [SerializeField] float timeBetweenEnemySpawns = 1f ;
    [SerializeField] float spawnTimeVariance = 0 ;
    [SerializeField] float minimunSpawnTime = 0.2f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index) 
    {
        return enemyPrefabs[index];
    }
    public Transform GetStartingWaypoint() //stating waypoint
    { 

        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints() //move to next waypoint
    {

        List<Transform> waypoints = new List<Transform>();

        foreach(Transform child in pathPrefab)
        {

            waypoints.Add(child);
        }

        return waypoints;
    }

    public float GetMoveSpeed() // movespeed getter
    {


        return moveSpeedEnemy;
    }
    public float GetRandomSpawnTime() //  
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance);

        return Mathf.Clamp(spawnTime , minimunSpawnTime , float.MaxValue); // error catching;
                                    
    }
        
    
}
