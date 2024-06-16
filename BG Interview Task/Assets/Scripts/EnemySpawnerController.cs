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

    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilNextSpawn();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerController.isInSafeZone)
        {
            timeUntilNextSpawn -= Time.deltaTime;

            if(timeUntilNextSpawn <= 0)
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
