using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{

	public GameObject asteroid;

	private const float zMax = 9.5f;
	private const float zMin = -9.5f;

	private const float zOffset = 5.0f;

	public Transform asteroidSpawn;
	public float spawnRate = 2.0f;
	private float nextSpawn = 0.0f;
	private float myTime = 0.0f;

	private float thrust;
	private float tilt;
	//private float speed;
	private float xStart, yStart, zStart,
		xEnd, yEnd, zEnd;

	// Update is called once per frame
	void Update()
	{
		if (asteroid == null)
		{ 
			return;
		}

		myTime = myTime + Time.deltaTime;
		if (myTime > nextSpawn)
		{
			nextSpawn = 100000.0f;// myTime + spawnRate;

			xStart = Random.Range(-7.0f, 7.0f); 
			yStart = 0;
			zStart = 9.5f;

			xEnd = Random.Range(-7.0f, 7.0f); 
			yEnd = 0;
			zEnd = -9.5f;

			//speed = Random.Range (2.0f, 15.0f);
			tilt = Random.Range(0.0f, 360.0f);
			thrust = Random.Range(30.0f, 60.0f);

			//GameObject newAsteroid = Instantiate(asteroid, new Vector3(xStart, yStart, zStart), Quaternion.Euler(0.0f, 0.0f, 0.0f)) as GameObject;
			GameObject newAsteroid = Instantiate(asteroid, asteroidSpawn.position, asteroidSpawn.rotation) as GameObject;
			newAsteroid.transform.parent = GameObject.FindGameObjectWithTag("Boundary").transform;

			Rigidbody rb = newAsteroid.GetComponent<Rigidbody>();
			rb.AddForce(new Vector3(xEnd, yEnd, zEnd) * thrust);
			//rb.velocity = new Vector3 ( xEnd, yEnd, zEnd ) * speed;
			rb.rotation = Quaternion.Euler(Random.Range(0.0f, 360.0f),
				Random.Range(0.0f, 360.0f),
				rb.velocity.x * (-tilt));
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Asteroid"))
		{
			Debug.Log(other.gameObject.tag + " entered the trigger.");
			Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
			float x = -rb.velocity.x;
			float y = rb.velocity.y;
			float z = rb.velocity.z;

			float zPos = rb.position.z;

			Debug.Log("Current zPos=" + zPos + ", current z=" + z);
			if (z >= zMax)
			{
				Debug.Log("z larger than zMax");
				z = -z;
			}
			else if (z <= zMin)
			{
				Debug.Log("z smaller than zMin");
				z = -z;
			}

			thrust = Random.Range(30.0f, 60.0f);
			Vector3 bounceVelocity = new Vector3(x, y, z) * thrust;

			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;

			Debug.Log(bounceVelocity + " exit velocity.");
			Debug.Log(thrust + " exit thrust.");

			Time.timeScale = 1;
			rb.AddForce(bounceVelocity);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (!other.gameObject.CompareTag("Asteroid"))
		{
			Debug.Log("Destroying " + other.gameObject.tag);
			Destroy(other.gameObject);
		}
	}
}
