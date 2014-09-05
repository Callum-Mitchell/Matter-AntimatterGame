using UnityEngine;
using System.Collections;

public class PlayerTriangle : MonoBehaviour {
	
	public int int_subFrame = 1;
	public static int int_frameCount = 0;
	public static float fl_scrollSpeed = 0.5f;
	
	private Vector3 v3_targetPoint;
	private Vector3 v3_lastTargetPoint;

	private int int_upCount = 0;
	private int int_downCount = 0;
	private int int_leftCount = 0;
	private int int_rightCount = 0;

	private float fl_mouseSensitivity = 2f; //adjustible - sets mouse sensitivity for movement

	private float fl_mousePosx;
	private float fl_mousePosy;

	private float fl_newMousePosx;
	private float fl_newMousePosy;

	private float fl_mouseSpeedx;
	private float fl_mouseSpeedy;


	void Start () {
	

		//Spawn point for the player at start of level
		transform.position = new Vector3 (0, -26, 0);

		//sets initial mouse position
		fl_newMousePosx += Input.GetAxis ("Mouse X") * fl_mouseSensitivity;
		fl_newMousePosy += Input.GetAxis ("Mouse Y") * fl_mouseSensitivity;
	}
	
	// Update is called once per frame
	void Update () {
	

		v3_targetPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 50);
		
		v3_targetPoint = Camera.main.ScreenToWorldPoint(v3_targetPoint);

		//transform.position = Vector3.MoveTowards(transform.position, v3_targetPoint, 100);


		if (Input.GetKeyDown("w")) //w key is pressed (on current frame)
			{
			int_upCount = 0; //initiates "up" dash animation
			}

		//animation will stop if triangle approaches screen border
		if (int_upCount < 4 && transform.position.y < 26 + (int_frameCount * fl_scrollSpeed))
			{
			transform.Translate(Vector3.up * 3);
			}


		if (Input.GetKeyDown("s")) //s key is pressed (on current frame)
		{
			int_downCount = 0; //initiates "down" dash animation
		}

		//animation will stop if triangle approaches screen border
		if (int_downCount < 4 && transform.position.y > -26 + (int_frameCount * fl_scrollSpeed))
		{
			transform.Translate(Vector3.down * 3);

		}

		if (Input.GetKeyDown("a")) //a key is pressed (on current frame)
		{
			int_leftCount = 0; //initiates "left" dash animation
		}

		//animation will stop if triangle approaches screen border
		if (int_leftCount < 4 && transform.position.x > -48)
		{
			transform.Translate(Vector3.left * 3);
		}

		if (Input.GetKeyDown("d")) //d key is pressed (on current frame)
		{
			int_rightCount = 0; //initiates "right" dash animation
		}
		
		//animation will stop if triangle approaches screen border
		if (int_rightCount < 4 && transform.position.x < 48)
		{
			transform.Translate(Vector3.right * 3);
		}


		//moves to next frame of any dash direction
		int_upCount++;
		int_downCount++;
		int_leftCount++;
		int_rightCount++;

		//keeps track of frames past (for screen boundary adjustments)
		int_frameCount++;
		
		//moves the player along with the camera
		transform.Translate(Vector3.up * fl_scrollSpeed);



		////////Reserved space for mouse movement script attempt


			fl_mousePosx = fl_newMousePosx;
			fl_mousePosy = fl_newMousePosy;

			fl_newMousePosx += Input.GetAxis ("Mouse X") * fl_mouseSensitivity;
			fl_newMousePosy += Input.GetAxis ("Mouse Y") * fl_mouseSensitivity;

		if (int_downCount > 3 && int_upCount != 0 && int_leftCount == 0 && int_rightCount == 0)
			{
			transform.Translate (Vector3.up * (fl_newMousePosy - fl_mousePosy));
			transform.Translate (Vector3.right * (fl_newMousePosx - fl_mousePosx));
			}
	}
}
