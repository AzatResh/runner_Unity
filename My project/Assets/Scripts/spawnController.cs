using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;

    [SerializeField] Vector2 MaxMinfireRate;
    [SerializeField] float fireRate = 2;
    private float currentTime;

    private void Start(){
        fireRate = Mathf.Lerp(MaxMinfireRate.x, MaxMinfireRate.y, Difficulty.GetDifficulty());
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime<fireRate){
            currentTime+=Time.deltaTime;
            return;
        }
        currentTime = 0;
        fireRate = Mathf.Lerp(MaxMinfireRate.x, MaxMinfireRate.y, Difficulty.GetDifficulty());

        int randObstacleIndex = Random.Range(0, obstacles.Length); 
        GameObject currentObstacle = Instantiate(obstacles[randObstacleIndex], transform.position, Quaternion.identity);
    }

    
}
