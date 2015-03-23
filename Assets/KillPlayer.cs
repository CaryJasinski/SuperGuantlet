using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D hitCollider)
	{
		if (hitCollider.tag == "Player")
			Destroy (hitCollider.gameObject);
	}
}
