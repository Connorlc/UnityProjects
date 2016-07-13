using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

// NOTE: For desired movement, set player's rigidbody2d component's linear drag to 2, and gravity scale to 0.
public class PlayerCameraControl : MonoBehaviour
{
  public int playerSpeed = 35; // determines magnitude of user input
	private Vector2 move; // the direction of movement for the player
  private Rigidbody2D player; // reference to the Player
  private Transform cam; // reference to the main camera
	private Transform playerTrans; // reference to transform of player
	private GameObject rightAnim; // reference to this game object's child game object
	private GameObject leftAnim; // reference to this game object's child game object



	private void Awake()
  {
    player = GetComponent<Rigidbody2D>(); // initialize player rigidbody2d reference
		cam = Camera.main.transform; // initialize camera transform reference
    playerTrans = GetComponent<Transform>(); // initialize player transform reference
		rightAnim = playerTrans.GetChild(0).gameObject; // initialize this gameobject's child-gameobject reference
		leftAnim = playerTrans.GetChild(1).gameObject; // initialize this gameobject's child gameobject reference
	} // Awake()



  private void Update()
  {
    float h = CrossPlatformInputManager.GetAxis("Horizontal"); // get left/right user input
    float v = CrossPlatformInputManager.GetAxis("Vertical"); // get up/down user input

		if (h < 0) // user inputs left
		{
			rightAnim.SetActive(false); // disable object containing right-facing sprite
			leftAnim.SetActive(true); // enable object containing left-facing sprite
		}

		else if (h > 0) // user inputs right
		{
			rightAnim.SetActive(true); // enable object containing right-facing sprite
			leftAnim.SetActive(false); // disable object containing left-facing sprite
		}

		move = (h * Vector2.right + v * Vector2.up).normalized; // assigns user input to a 2 component unit vector
		move *= playerSpeed; // makes magnitude of move adjustable through inspector bc playerSpeed is public
    cam.position = new Vector3(playerTrans.position.x, playerTrans.position.y, -10); // force camera to center on player
	} // Update()



  private void FixedUpdate()
  {
    player.AddForce(move);
  } // FixedUpdate()
} // class PlayerUserControl
