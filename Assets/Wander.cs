using UnityEngine;
using System.Collections;

public class Wander : MonoBehaviour {

	public enum AIMoveState { moveLeft, moreRight, idel, disabled }
	public AIMoveState currentMoveState = AIMoveState.idel;

	public float moveSpeed = 0f;

	void Update () 
	{
		SetMovementState ();
	}

	void SetMovementState()
	{
		int randomNumber = Random.Range (0, 1000);
		switch (currentMoveState) 
		{
		case AIMoveState.moreRight:
			if(randomNumber <= 30)
				currentMoveState = AIMoveState.idel;
			else
			{
				transform.position = new Vector2 (transform.position.x + moveSpeed*Time.deltaTime, transform.position.y);
				if(transform.rotation.eulerAngles.y != 0)	
					transform.localEulerAngles = new Vector3(0, 0, 0);
			}
			break;
		case AIMoveState.moveLeft:
			if(randomNumber <= 30)
				currentMoveState = AIMoveState.idel;
			else
			{
				transform.position = new Vector2 (transform.position.x - moveSpeed*Time.deltaTime, transform.position.y);
				if(transform.rotation.eulerAngles.y != 180)	
					transform.localEulerAngles = new Vector3(0, 180, 0);
			}
			break;
		case AIMoveState.idel:
			if(randomNumber <= 100)
				currentMoveState = AIMoveState.moveLeft;
			if(randomNumber >= 900)
				currentMoveState = AIMoveState.moreRight;
			break;
		case AIMoveState.disabled:
		default:
			break;
		}
	}
}
