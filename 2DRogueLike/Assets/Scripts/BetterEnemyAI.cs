using UnityEngine;
using System.Collections;

public class BetterEnemyAI : MonoBehaviour {

	private Vector3 moveDirection;
	public Transform target;
	public float moveSpeed;
	public float turnSpeed;

	public SpriteRenderer spriteRenderer;
	public Sprite[] sprites;
	public float framesPerSecond;
	public float enemyHP = 1;
	public float currentEnemyHP;

	public float distance = 3;
	private bool isPatroling;
	private Vector3 patrol;
	public Vector2 patrolSpeed = new Vector2 (1.0f, 1.0f);


	// Use this for initialization
	void Start () {
		moveDirection = Vector3.right;
		spriteRenderer = renderer as SpriteRenderer;

	}
	

	void Update () {

		//Set enemy's hp
		enemyHP = currentEnemyHP;

		if(Vector2.Distance(target.transform.position,this.transform.position) < distance)
			isPatroling=false;
		else
			isPatroling=true;

		if (!isPatroling) {
						//Set's enemy's current position and target's position
						target = GameObject.FindWithTag ("Player").transform;
						Vector3 currentPosition = transform.position;
						Vector3 moveToward = target.position;

						//Find where to move to move t
						moveDirection = moveToward - currentPosition;
						moveDirection.z = 0; 
						moveDirection.Normalize ();


						//Move to target's location
						Vector3 movetoTarget = moveDirection * moveSpeed + currentPosition;
						transform.position = Vector3.Lerp (currentPosition, movetoTarget, Time.deltaTime);

						//Rotate sprite towards target's position
						float targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
						transform.rotation = 
						Quaternion.Slerp (transform.rotation, 
			                 Quaternion.Euler (0, 0, targetAngle), 
			                 turnSpeed * Time.deltaTime);

						//Play animation for sprite for moving
						int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
						index = index % sprites.Length;
						spriteRenderer.sprite = sprites [index];
				}
		else if (isPatroling) { 
			/*
			patrol = new Vector3(patrolSpeed.x * 3, patrolSpeed.y * 0, 0);
			Vector3 currentPosition = transform.position;
			Vector3 moveToward = patrol;


			moveDirection = patrol - currentPosition;
			moveDirection.z = 0; 
			moveDirection.Normalize ();
			Vector3 movetoTarget = moveDirection * moveSpeed + currentPosition;


			transform.position = Vector3.Lerp (currentPosition, movetoTarget, Time.deltaTime);
			float targetAngle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = 
				Quaternion.Slerp (transform.rotation, 
				                  Quaternion.Euler (0, 0, targetAngle), 
				                  turnSpeed * Time.deltaTime);

			*/
			int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
			index = index % sprites.Length;
			spriteRenderer.sprite = sprites [index];
		





		}

		}
}

