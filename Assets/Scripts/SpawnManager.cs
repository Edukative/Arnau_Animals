using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;
    public int animalIndex;

    private float spawnRangeX = 20;
    private float spawnPosZ = 30;

    private float startDelay = 2.0f;
    private float spawnInterval = 2;

    private PlayerControler PlayerContorlerScript;

    public int animalsDestroyedCount;

    public float repeatRateMin = 1;
    public float repeatRateMax = 5;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomAnimals", startDelay, spawnInterval);

        PlayerContorlerScript = GameObject.Find("Player").GetComponent<PlayerControler>();

        Invoke("SpawnRandomAnimal", (Random.Range(repeatRateMin, repeatRateMax)));
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerContorlerScript.restart)
        {
            Invoke("SpawnObstacle", (Random.Range(repeatRateMin, repeatRateMax)));
            PlayerContorlerScript.restart = false;
        }
    }

    void SpawnRandomAnimals()
    {
        if (!PlayerContorlerScript.isGameOver)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int animalIndex = Random.Range(0, animals.Length);
            GameObject animal = Instantiate(animals[animalIndex], spawnPos,
            animals[animalIndex].transform.rotation);

            FlyFoward animScript = animal.GetComponent<FlyFoward>();
            animScript.speed = animScript.speed + (float)animalsDestroyedCount;

            float randomDelay = Random.Range(repeatRateMin, repeatRateMax);
            Debug.Log("Random interval" + randomDelay);
            Invoke("SpawnRandomAnimal", randomDelay);
        }
    }
}
