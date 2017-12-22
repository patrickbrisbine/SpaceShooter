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

public class Mover : MonoBehaviour
{

	public float speed = 1;
	Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}
}
