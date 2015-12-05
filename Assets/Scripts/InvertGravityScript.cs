﻿using UnityEngine;
using System.Collections;

public class InvertGravityScript : MonoBehaviour {

	float increment = 0.07f;
	bool inverted = false;

	void FixedUpdate () {
		if(inverted && increment > 0 && rigidbody2D.gravityScale > -0.3)
			Flip ();
		else if(!inverted && increment < 0 && rigidbody2D.gravityScale < 0.3)
			Flip ();
		if((rigidbody2D.gravityScale < 1 && increment > 0)|| (rigidbody2D.gravityScale > -1 && increment <0))
			rigidbody2D.gravityScale += increment;
		if(increment > 0 && rigidbody2D.velocity.y > 13f)
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,  13f);
		else if(increment > 0 && rigidbody2D.velocity.y < -13f)
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,  -13f);
	}

	void Flip()
	{
		inverted = !inverted;
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;
		PlayerControllerScript script = GetComponent<PlayerControllerScript> ();
		script.jumpForce *= -1;
	}

	public void activate(){
		increment *= -1;
		Debug.Log ("activate : " + increment);
	}
}
