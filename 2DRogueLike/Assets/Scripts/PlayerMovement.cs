using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Vector2 movement;
	public Vector2 speed = new Vector2 (1.0f, 1.0f);
	private float inputX, inputY;
	private SpriteRenderer spriteRenderer;
	public Sprite[] sprites;

	//Method for performing character movement
 	void Movement(){

		//Find movement direction of player
		inputX = Input.GetAxis ("Horizontal");
		inputY = Input.GetAxis ("Vertical");
	
		//Turn sprite to proper position realtive to input direct
		if (inputX > 0){
			int index = 2;
			spriteRenderer.sprite = sprites[index];
		
		}
		
		else if(inputX < 0 ) {
			transform.localScale = new Vector3 (1, 1, 1 );
			int index = 1;
			spriteRenderer.sprite = sprites[index];

		}

		if (inputY > 0) {
			int index = 3;
			spriteRenderer.sprite = sprites[index];
		}

		else if (inputY < 0) {
			int index = 0;
			spriteRenderer.sprite = sprites[index];
		}

		//Move character to new position.
		movement = new Vector2 (speed.x * inputX, speed.y * inputY);
		rigidbody2D.velocity = movement;

		}




	void Start () {
	
		spriteRenderer = renderer as SpriteRenderer;

	}
	
	// Update is called once per frame
	void FixedUpdate () {


		Movement ();
		transform.rotation = Quaternion.identity;
	
	}
}
