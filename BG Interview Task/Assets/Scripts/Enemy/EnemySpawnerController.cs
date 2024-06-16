using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private float minimumSpawnTime;

    [SerializeField] private float maxmimumspawnTime;

    private float timeUntilNextSpawn;

    [SerializeField] private PlayerController playerController;
    private int maxEnemies = 5;

    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilNextSpawn();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerController.isInSafeZone && !playerController.isDead)
        {
            timeUntilNextSpawn -= Time.deltaTime;

            if(timeUntilNextSpawn <= 0 && FindObjectsOfType<EnemyController>().Length < maxEnemies && !playerController.isInSafeZone)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                SetTimeUntilNextSpawn();
            }
        }
    }

    private void SetTimeUntilNextSpawn()
    {
        timeUntilNextSpawn = Random.Range(minimumSpawnTime, maxmimumspawnTime);
    }
}
