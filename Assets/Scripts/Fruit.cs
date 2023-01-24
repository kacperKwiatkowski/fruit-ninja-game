using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fruit : MonoBehaviour
{
        public GameObject slicedFruitPrefab;

        public void CreateSlicedFruit()
        {
                GameObject inst = (GameObject) Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

                Rigidbody[] rbsOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

                foreach (Rigidbody r in rbsOnSliced)
                {
                        r.transform.rotation = Random.rotation;
                        r.AddExplosionForce(Random.Range(100, 500), transform.position, 0.05f);
                }
                
                FindObjectOfType<GamaManager>().IncreaseScore(3);
                Destroy(inst.gameObject, 5);
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
                Blade b = col.GetComponent<Blade>();

                if (!b)
                {
                        return;
                }
                
                CreateSlicedFruit();
        }
}
