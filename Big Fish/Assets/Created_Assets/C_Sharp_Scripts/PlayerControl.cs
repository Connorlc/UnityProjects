using UnityEngine;

// NOTE: For desired movement, set player's rigidbody2d component's linear drag to 2, and gravity scale to 0.
public class PlayerControl : MonoBehaviour
{
  public int playerSpeed = 35; // determines magnitude of user input
	private Vector2 move; // the direction of movement for the player
  private Rigidbody2D player; // reference to the Player
	private SpriteRenderer sprite;  // reference to this game object's sprite renderer


	// Called when this script's game object is activated 
	private void Awake()
  {
    player = GetComponent<Rigidbody2D>(); // initialize player rigidbody2d reference
		sprite = GetComponentInChildren<SpriteRenderer>();
	} // Awake()



  private void Update()
  {
	} // Update()



  private void FixedUpdate()
  {
		float h = Input.GetAxis("Horizontal"); // get left/right user input
		float v = Input.GetAxis("Vertical"); // get up/down user input

		if (h < 0) // user inputs left
			sprite.flipX = true; // sets the sprite renderer's variable for x-axis reflection to true

		else if (h > 0) // user inputs right
			sprite.flipX = false; // sets the sprite renderer's variable for x-axis reflection to false

		move = (h * Vector2.right + v * Vector2.up).normalized; // assigns user input to a 2 component unit vector
 		move *= playerSpeed; // makes magnitude of move adjustable through inspector bc playerSpeed is public
		player.AddForce(move); // applies a force to the player to move
	} // FixedUpdate()
} // class PlayerUserControl