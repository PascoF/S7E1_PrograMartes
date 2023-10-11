using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool puedeSpawnear;
    public GameObject[] PrefabsEnemigos;
    public Transform[] pos_spawnPoints;
    public float tiempoSpawn;
    private bool isSpawning;

    void Start()
    {
        if (puedeSpawnear)
        {
            puedeSpawnear = true;
            StartCoroutine(SpawnEnemigos());
        }
    }


    void Update()
    {
        if (puedeSpawnear && !isSpawning)
        {
            foreach (Transform spawnPoint in pos_spawnPoints)
            {
                int randomIndex = Random.Range(0, PrefabsEnemigos.Length);
                GameObject prefabEnemigo = PrefabsEnemigos[randomIndex];

                Instantiate(prefabEnemigo, spawnPoint.position, spawnPoint.rotation);
            }

            isSpawning = true;
        }

    }

    IEnumerator SpawnEnemigos()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoSpawn);

            if (puedeSpawnear)
            {
                foreach (Transform spawnPoint in pos_spawnPoints)
                {
                    int randomIndex = Random.Range(0, PrefabsEnemigos.Length);
                    GameObject prefabEnemigo = PrefabsEnemigos[randomIndex];

                    Instantiate(prefabEnemigo, spawnPoint.position, spawnPoint.rotation);
                }

                isSpawning = false;
            }
        }
    }

}
