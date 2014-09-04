using UnityEngine;
using System.Collections;

public class PlayerTriangle : MonoBehaviour {
	
	public int int_subFrame = 1;
	public static int int_frameCount = 0;
	public static float fl_scrollSpeed = 0.5f;
	private Vector3 v3_targetPoint;

	private int int_xMoveCount = 0;
	private int int_yMoveCount = 0;

	private int int_upFrameCount = 0;
	private int int_downFrameCount = 0;
	private int int_leftFrameCount = 0;
	private int int_rightFrameCount = 0;

	private float fl_xTarget;
	private float fl_yTarget;

	void Start () {
	
		//Spawn point for the player at start of level

		transform.position = new Vector3 (0, -26, 0);
		v3_targetPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	

		//makes the player follow the mouse
		v3_targetPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 50);
		
		v3_targetPoint = Camera.main.ScreenToWorldPoint(v3_targetPoint);
		
		transform.position = Vector3.MoveTowards(transform.position, v3_targetPoint, 1);


		//for (int_subFrame = 1; int_subFrame <= 4; int_subFrame++)
		//{
		//	if (Input.GetKeyDown("w") && transform.position.y < 26 + (int_frameCount * fl_scrollSpeed))
		//	{
		//		int_yMoveCount += 1;
		//		int_upFrameCount = 4;
		//	}
		//
		//	if (Input.GetKeyDown("s") && transform.position.y > -26 + (int_frameCount * fl_scrollSpeed))
		//	{	
		//		int_yMoveCount -= 1;
		//		int_downFrameCount = 4;
		//	}
		//	
		//	if (Input.GetKeyDown("a") && transform.position.x > -48)
		//	{
		//		int_xMoveCount -= 1;
		//		int_leftFrameCount = 4;
		//	}
		//
		//	if (Input.GetKeyDown("d") && transform.position.x < 48)
		//	{
		//		int_xMoveCount += 1;
		//		int_rightFrameCount = 4;
		//	}
		//}

		//keeps track of frames past (for screen boundary adjustments)
		int_frameCount++;
		
		//moves the player along with the camera
		transform.Translate(Vector3.up * fl_scrollSpeed);

		//moves player to adjust for tap-dashes
		//if (transform.position.y + (8 * int_yMoveCount) - (2 * int_upFrameCount) + (2 * int_downFrameCount) < 26 && transform.position.x + (8 * int_yMoveCount) - (2 * int_upFrameCount) + (2 * int_downFrameCount) > -26)
		//{
		//	transform.Translate(Vector3.up * ((8 * int_yMoveCount) - (2 * int_upFrameCount) + (2 * int_downFrameCount)));
		//}

		//if (transform.position.x + (8 * int_xMoveCount) - (2 * int_rightFrameCount) + (2 * int_leftFrameCount) < 48 && transform.position.x + (8 * int_xMoveCount) - (2 * int_rightFrameCount) + (2 * int_leftFrameCount) > -48)
		//{
		//	transform.Translate(Vector3.right * ((8 * int_xMoveCount) - (2 * int_rightFrameCount) + (2 * int_leftFrameCount)));
		//}

		//reduces frames left until current tap-dash(es) stop
		if (int_upFrameCount >= 1)
		{
			int_upFrameCount--;
		}

		if (int_downFrameCount >= 1)
		{
			int_downFrameCount--;
		}

		if (int_leftFrameCount >= 1)
		{
			int_leftFrameCount--;
		}

		if (int_rightFrameCount >= 1)
		{
			int_rightFrameCount--;
		}
	}
}
