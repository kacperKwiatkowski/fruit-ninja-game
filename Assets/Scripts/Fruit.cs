using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
        public GameObject slicedFruitPrefab;

        private void Update()
        {
                if (Input.GetKey(KeyCode.Space))
                {
                        CreateSlicedFruit(); }
        }
        
        public void CreateSlicedFruit()
        {
                GameObject inst = (GameObject) Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

                Rigidbody[] rbsOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

                foreach (Rigidbody r in rbsOnSliced)
                {
                        r.transform.rotation = Random.rotation;
                        r.AddExplosionForce(Random.Range(100, 500), transform.position, 0.05f);
                }
                
                Destroy(gameObject);
        }
}
