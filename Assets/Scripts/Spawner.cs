using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{

    public GameObject[] objectsToSpawn;
    public Transform[] spawnPlaces;
    public float minWait = .3f;
    public float maxWait = 1f;
    public float minForce = 12;
    public float maxForce = 17;

    private void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject go = null;

            if (Random.Range(0, 100) < 10)
            {
                go = objectsToSpawn[0];
            }
            else
            {
                go = objectsToSpawn[Random.Range(1, objectsToSpawn.Length)];
            }
            
            GameObject fruit = Instantiate(go, t.position, t.rotation);            
            
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
            
            Debug.Log("Fruit get spawned");
            
            Destroy(fruit, 5);
        }
    }
}
