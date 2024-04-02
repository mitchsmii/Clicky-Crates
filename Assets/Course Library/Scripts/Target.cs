using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 15;
    private float maxSpeed = 18;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    UnityEngine.Vector3 RandomForce()
    {
        return UnityEngine.Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    UnityEngine.Vector3 RandomSpawnPos()
    {
        return new UnityEngine.Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);
    }
}
