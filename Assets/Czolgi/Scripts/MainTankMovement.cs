using UnityEngine;
using System.Collections;

public class MainTankMovement : MonoBehaviour {
	
	KeyboardControl TankControl;
	TankMovement TankMovement;

	// Use this for initialization
	void Start () {
		TankControl = GetComponent<KeyboardControl>();
		TankMovement = GetComponent<TankMovement>();
	}
		
	// Update is called once per frame
	void Update () {
		print (TankControl.isControlPressed ());
		if (TankControl.isControlPressed() == true) {
			
			if (Input.GetKey(TankControl.MoveControl[0]) == true) 
					TankMovement.SetDirection (TankMovement.direction.up);

			if (Input.GetKey (TankControl.MoveControl[1]) == true) 	
				
					TankMovement.SetDirection (TankMovement.direction.down);

			if (Input.GetKey (TankControl.MoveControl[2]) == true) 			
					TankMovement.SetDirection (TankMovement.direction.left);

			if (Input.GetKey (TankControl.MoveControl[3]) == true) 		
					TankMovement.SetDirection (TankMovement.direction.right);

			TankMovement.Move();
		}
			
	}
}
