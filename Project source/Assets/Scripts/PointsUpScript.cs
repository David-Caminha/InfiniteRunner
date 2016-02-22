using UnityEngine;
using System.Collections;

public class PointsUpScript : MonoBehaviour {

	public HUDScript hud;
	public int amount;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{

			if(hud.coinsCombo>0){
				hud.audioCoin.pitch += 0.3f;
			}
			if(hud.audioCoin.pitch > 2.1){
				hud.audioCoin.pitch=2.1f;
			}
			if(hud.coinsCombo <= 0){
				hud.audioCoin.pitch = 1;
			}
			hud.audioCoin.Play();
			hud.coinsCombo+=1.5f;
			hud.changeScore(amount);
			Destroy(this.gameObject);
		}
	}
}
