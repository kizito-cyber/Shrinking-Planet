using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerCollision : MonoBehaviour {

	public GameObject deathEffect;
	

   
    void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag == "Meteor")
		{
			Instantiate(deathEffect, transform.position, transform.rotation);
			GameManager.instance.EndGame();
			CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
			AudioManager.instance.Play("PlayerDeath");

			Destroy(gameObject);
		}
	}

}
