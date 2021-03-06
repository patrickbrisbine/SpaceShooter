﻿/* 
 * Space Shooter Copyright (C) Patrick Brisbine - All Rights Reserved
 *
 * Space Shooter is licensed under a Creative Commons Attribution-NonCommercial-NoDerivs 3.0 Unported License.
 *
 * You should have received a copy of the license along with this
 * work.  If not, see <http://creativecommons.org/licenses/by-nc-nd/3.0/>.
 *  
 * Written by Patrick Brisbine December 2017
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class AirSpeederController : MonoBehaviour
{
	private Rigidbody rb;

	public float speed = 1;
	public float tilt = 1;
	public float fireRate = 0.5f;

	public GameObject shot;
	public Transform shotSpawn;

	private float nextFire = 0.5f;
	private float myTime = 0.5f;

	public Boundary boundary = new Boundary ();

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		myTime = myTime + Time.deltaTime;

		if (Input.GetButton ("Fire1") && myTime > nextFire) {
			nextFire = myTime + fireRate;

			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		rb.velocity = new Vector3 (horizontal, 0.0f, vertical) * speed;
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * (-tilt));
	}
}