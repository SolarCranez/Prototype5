using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // target's rigidbody, gamemanager reference
    private Rigidbody targetRb;
    private GameManager gameManager;

    // explosion particle
    public ParticleSystem explosionParticle;

    // variables for movement & position of target
    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPos = -2f;
    public int pointValue;


    // Start is called before the first frame update
    void Start()
    {
        // set target's rigidbody, add forces and torques
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        // get current gamemanager in scene
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        // set target's position to random
        transform.position = RandomSpawnPos();
    }

    // method for random force
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // method for random torque
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // method for random spawn position
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // destroy object on click & display explosion, assuming NOT game over
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }

    // bad object goes out of bounds, end game
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
