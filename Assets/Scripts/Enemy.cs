using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject deathFx;
	[SerializeField] Transform parent;
	
	void Start()
	{
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
	}

	private void OnParticleCollision(GameObject other)
	{
		GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
		fx.transform.parent = parent;
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
