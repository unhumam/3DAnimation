using UnityEngine;
using System.Collections;

public class RomanControllerScript : MonoBehaviour {

	private Animator myAnimator;
	private Quaternion newrotation;
	private float smooth = 0.05f;
	public new Transform camera;

	// Use this for initialization
	void Start () {

		myAnimator = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		movement(v,h);
	
	}

	// ****************************************************************************	//
	//																				//
	//	The animator in Unity works with values to transition to different states	//
	// In your animator you _must_ have the following parameters:					//
	//		"speed"		-	float													//
	//		"attack"	-	bool													//
	//		"jump"		-	bool													//
	//																				//
	//	If they are not needed (you dont have an attack animation for example)		//
	//	You can delete the if statements											//
	//																				//
	// ****************************************************************************	//

	void movement (float v, float h) {

		if (h != 0f || v != 0f) {
			
			//checking if the user pressed any keys
			rotate(v,h);

            #region RUN
            //RUN ANIMATION:
            myAnimator.SetFloat ("speed", Input.GetAxis ("Vertical"));

			// When SHIFT is pressed reduce the speed 2 ( multiply by 0.5f )
			if(Input.GetKey(KeyCode.LeftShift))
			{
				myAnimator.SetFloat ("speed",.5f);
			}
			else {myAnimator.SetFloat ("speed", Input.GetAxis ("Vertical"));
			}
            #endregion

          

            //For any additional animation copy for instance the jump animation script above 
            //and replace the input keys to the keys you want to use. Also create a new boolean for your new animation. 


        }
        else {
			myAnimator.SetFloat ("speed",0);
			//Stop the player if user is not pressing any key
		}
		
	}



	// Rotation Player - You don't need to change anything here

	void rotate(float v,float h) {
		
		if (v > 0)
		{
			if (h > 0)
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+45,0);
			}
			else if (h < 0)
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+305,0);
			}
			else
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y,0);
			}
		}
		else if (v < 0)
		{
			if (h > 0)
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+135,0);
			}
			else if (h < 0)
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+225,0);
			}
			else {
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+180,0);
			}
		}
		else
		{
			if (h > 0)
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+90,0);
			}
			else if (h < 0)
			{
				newrotation = Quaternion.Euler(0,camera.eulerAngles.y+270,0);
			}
			else {
				newrotation = transform.rotation;
			}
		}
		
		newrotation.x = 0;
		newrotation.z = 0;
		//We only want player to rotate in y axis
		transform.rotation = Quaternion.Slerp (transform.rotation,newrotation, smooth);
		//Slerp from player's current rotation to the new intended rotaion smoothly 
		
	}


}
