using UnityEngine;
using System.Collections;

/// <summary>
/// Klasa obslugujaca klawiature dla bohatera
/// </summary>
/// 
public class KeyboardControl: MonoBehaviour{
	public string[] MoveControl=new string[4];         				   // Sterowanie
	public bool[] MoveControlPressed;								   // tablica do sprawdzanai czy klawisz zostanie zwolniony

	int i;

	void Start () {
		MoveControlPressed = new bool[MoveControl.Length];
	}

	void Update()	{
		for (i = 0; i < MoveControl.Length; i++) {
			if(Input.GetKey(MoveControl[i])==true)
				MoveControlPressed[i]=true;
			else
				MoveControlPressed[i]=false;
		}
	}

	public bool isDriving()
	{
		for(int i=0;i<4;i++)
			if(MoveControlPressed[i]==true)
				return true;

		return false;
	}

	public bool isStopped()
	{
		for(int i=0;i<4;i++)
			if(MoveControlPressed[i]==true)
				return false;

		return true;
	}

	public bool isShooting()
	{
		return true;
	}

	public bool isControlPressed()
	{
		foreach (bool element in MoveControlPressed)
			if (element == true)
				return true;

		return false;
	}
}
	