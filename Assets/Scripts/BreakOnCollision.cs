using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnCollision : MonoBehaviour {

	private void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.tag == "Car"){
            Destroy(gameObject);
        }
	}
}
