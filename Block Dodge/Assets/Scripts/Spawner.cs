using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    [SerializeField] private Vector2 secondsBetweenSpawnsMinMax;
    [SerializeField] private float rotationAngleMax;
    [SerializeField] private Vector2 blockSizeMinMax;
    float nextSpawnTime;
    Vector2 screenHaldSizeWorldUnits;

    private void Start()
    {
        screenHaldSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Utility.getDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            float blockSize = Random.Range(blockSizeMinMax.x, blockSizeMinMax.y);
            float blockAngle = Random.Range(-rotationAngleMax, rotationAngleMax);

            Vector2 spawnPosition = new Vector2(Random.Range(-screenHaldSizeWorldUnits.x, screenHaldSizeWorldUnits.x),
                -screenHaldSizeWorldUnits.y - blockSize);

            Block newBlock = Instantiate(blockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * blockAngle)) as Block;
            newBlock.transform.localScale = Vector3.one * blockSize;
        }
    }
}
