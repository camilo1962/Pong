using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour 
{
	public float ballSpeed;

	public float acceleration;

	public float maxSpeed;

	int hitCounter;


	// Use this for initialization
	void Start () 
	{
		StartCoroutine(this.StartBall());
	}


	void PositionBall(bool isStartingPlayer1 = true)
	{
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

		if (isStartingPlayer1) 
		{
			this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
		}
		else
		{
			this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
		}
	}


	public IEnumerator StartBall(bool isStartingPlayer1 = true)
	{
		this.PositionBall (isStartingPlayer1);

		this.hitCounter = 0;
		yield return new WaitForSeconds(2);

		if (isStartingPlayer1) {
			this.MoveBall (new Vector2 (-1, 0));
		} 
		else 
		{
			this.MoveBall(new Vector2(1, 0));
		}
	
	}

	
	// Method to move our ball
	public void MoveBall(Vector2 dir)
	{
		dir = dir.normalized;

		float speed = this.ballSpeed + this.hitCounter * this.acceleration;

		Rigidbody2D rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();

		rigidBody2D.velocity = dir * speed;
	}


	// Increase the hit counter
	public void IncreaseHitCounter()
	{
		if (this.hitCounter * this.acceleration <= this.maxSpeed) 
		{
			this.hitCounter++;
		}
	}
}
