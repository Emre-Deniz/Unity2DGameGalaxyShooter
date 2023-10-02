using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    EnemySpawn enemySpawner;
    [SerializeField] WaveConfig waveConfig; // object referance
    List<Transform> waypoints; //waypoint list

    int waypointIndex = 0 ; //starting index

    void Awake() //monobehavior awake funtion
    {
        enemySpawner = FindAnyObjectByType<EnemySpawn>();
    }
    // Start is called before the first frame update
    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints(); //getting waypoints
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath(); // enemy path
    }

    void FollowPath(){ 

        if (waypointIndex < waypoints.Count){

            Vector3 targetPosition = waypoints[waypointIndex].position; // for target position

            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime; // move speed

            transform.position = Vector2.MoveTowards(transform.position , targetPosition , delta); // for actual move

            if(transform.position == targetPosition ){  // is ending reached ?
                
                waypointIndex++; // to next waypoint

            }
        }
        else
        Destroy(gameObject); // we are at end so we can destroy enemy object

    }
}
