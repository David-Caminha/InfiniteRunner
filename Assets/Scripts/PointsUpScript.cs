using UnityEngine;
using System.Collections;

public class PointsUpScript : MonoBehaviour {

	HUDScript hud;
	public int amount;

	void OnTringgerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			hud.changeScore(amount);
			Destroy(this.gameObject);
		}
	}
}
