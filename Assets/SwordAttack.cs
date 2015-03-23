using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour {

	public enum AttackState	{Initialized, Swinging, Complete, Idel}
	public AttackState attackState = AttackState.Idel;

	public float swingSpeed = 0f;
	public float swingReach = 0f;
	//public Quaternion startRotation = Quaternion.identity;
	public Vector2 colliderPosition = Vector2.zero;
	
	void Start () 
	{
		//startRotation = transform.rotation;
		colliderPosition = transform.GetComponent<BoxCollider2D> ().offset;
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.E) && attackState == AttackState.Idel) 
		{
			attackState = AttackState.Initialized;
		}

		SetAttackState ();
	}

	void SetAttackState()
	{
		switch (attackState) 
		{
		case AttackState.Initialized:
			attackState = AttackState.Swinging;
			break;
		case AttackState.Swinging:
			if(transform.GetComponent<BoxCollider2D>().offset.x <= swingReach)
				transform.GetComponent<BoxCollider2D>().offset = new Vector2(
					transform.GetComponent<BoxCollider2D>().offset.x + (swingSpeed * Time.deltaTime), 
					colliderPosition.y);
			else
				attackState = AttackState.Complete;
			break;
		case AttackState.Complete:
			transform.GetComponent<BoxCollider2D>().offset = colliderPosition;
			attackState = AttackState.Idel;
			break;
		case AttackState.Idel:
		default:
			break;
		}
	}

//	void SetAttackState()
//	{
//		switch (attackState) 
//		{
//		case AttackState.Initialized:
//			Debug.Log ("Swing!");
//			transform.Rotate(new Vector3(0, 0, 90f));
//			attackState = AttackState.Swinging;
//			break;
//		case AttackState.Swinging:
//			if(transform.rotation.eulerAngles.z > 10f)
//				transform.Rotate (new Vector3 (0, 0, swingSpeed * Time.deltaTime));
//			else
//				attackState = AttackState.Complete;
//			break;
//		case AttackState.Complete:
//			transform.rotation = startRotation;
//			attackState = AttackState.Idel;
//			break;
//		case AttackState.Idel:
//		default:
//			break;
//		}
//	}

	void OnTriggerEnter2D(Collider2D hitCollider)
	{
		if(attackState == AttackState.Swinging && hitCollider.gameObject.layer != 8)
			Destroy (hitCollider.gameObject);
	}
}
