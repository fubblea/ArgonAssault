using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject deathFx;
	[SerializeField] Transform parent;
	[SerializeField] int scorePerHit = 10;
	[SerializeField] int hits = 10;

	ScoreBoard scoreBoard;

	private void AddBoxCollider()
	{
		Collider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
	}

	void Start()
	{
		AddBoxCollider();
		scoreBoard = FindObjectOfType<ScoreBoard>();

	}

	private void KillEnemy()
	{
		GameObject fx = Instantiate(deathFx, transform.position, Quaternion.identity);
		fx.transform.parent = parent;
		Destroy(gameObject);
	}

	private void ProcessHit()
	{
		scoreBoard.ScoreHit(scorePerHit);
		hits--;
		//TODO Add sound FX
	}

	private void OnParticleCollision(GameObject other)
	{
		ProcessHit();

		if (hits <= 0)
		{
			KillEnemy();
		}
		

	}
}
