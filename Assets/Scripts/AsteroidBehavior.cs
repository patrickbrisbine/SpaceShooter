/* 
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

public class AsteroidBehavior : MonoBehaviour
{
	private Rigidbody rb;

	private const float zMax = 9.5f;
	private const float zMin = -9.5f;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		/*
		float x = rb.velocity.x, y = rb.velocity.y, z = rb.velocity.z;
		if (rb.position.z >= zMax || rb.position.z <= zMin)
		{
			Debug.Log("Asteroid Behavior Update " + rb.position.z);
			x = -x;
			z = -z;
			rb.AddForce(new Vector3(x, y, z) * 10.0f);
		}
		*/
	}
}
