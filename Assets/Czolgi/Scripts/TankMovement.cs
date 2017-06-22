using UnityEngine;
using System.Collections;

	/// <summary>
	/// Klasa odpowiadajaca za poruszanie sie obiektow ktore sa uznawane jako czolgi
	/// </summary>
public class TankMovement : MonoBehaviour {
	
	public float speed=30; 
	public enum direction{up=180,down=0,left=90,right=270};
	public direction InitAngle;

	GameObject tank;
	// Use this for initialization
	void Start () {
		tank = this.gameObject;
	}

	public void SetDirection(direction angle)
	{
		tank.transform.Rotate (0f, (((float)angle) - (float)InitAngle), 0f);
		InitAngle = angle;
		print (InitAngle);
	}
		
	public direction getDirection()
	{
		return InitAngle;
	}
		
	public void Move()
	{
		tank.transform.Translate (0f, 0f, -speed * Time.deltaTime);	
	}

	// Update is called once per frame
	void Update () {
		print ((float)InitAngle);
	}
}
