using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UIElements;

public class target : MonoBehaviour
{
    private Rigidbody targetRb;
    private  GameManager gameManager;
    public ParticleSystem explosionParticle;
    private float minSpeed = 15;
    private float maxSpeed = 18;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    public int pointValue;

    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();;
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
        if (gameManager.isGameActive)
        {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        if (gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);
    }
}
