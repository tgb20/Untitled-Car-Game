using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCarCollisions : MonoBehaviour {

	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.tag == "Car"){
            Physics.IgnoreCollision(collision.collider, GetComponent<BoxCollider>());
        }
	}
}
