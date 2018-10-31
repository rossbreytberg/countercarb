using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {
    [SerializeField]
    List<GameObject> food = new List<GameObject>();
    [SerializeField]
    float spawnInterval;
    [SerializeField]
    float spawnIntervalDecrease;
    [SerializeField]
    float spawnIntervalMin;
    [SerializeField]
    float speed;
    [SerializeField]
    float speedIncrease;
    [SerializeField]
    float speedMax;
    [SerializeField]
    Vector3 startMin;
    [SerializeField]
    Vector3 startMax;
    [SerializeField]
    Vector3 endMin;
    [SerializeField]
    Vector3 endMax;
    int spawnIndex = 0;
    float timePassed = 0;

    void Update () {
        timePassed += Time.deltaTime;
        if (timePassed >= spawnInterval)
        {
            GameObject spawnedFood = Instantiate(food[spawnIndex]);
            FlyingObject flyingObject = spawnedFood.AddComponent<FlyingObject>();
            flyingObject.start = GetPosition(startMin, startMax);
            flyingObject.end = GetPosition(endMin, endMax);
            flyingObject.speed = speed;
            spawnIndex = (spawnIndex + 1) % food.Count;
            timePassed = 0;
            spawnInterval = Mathf.Max(spawnInterval - spawnIntervalDecrease, spawnIntervalMin);
            speed = Mathf.Min(speed + speedIncrease, speedMax);
        }
    }

    Vector3 GetPosition(Vector3 min, Vector3 max)
    {
        return new Vector3(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y),
            Random.Range(min.z, max.z)
        );
    }
}
