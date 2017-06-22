using UnityEngine;
using System.Collections;

public class TankAnimation : MonoBehaviour {

	// Use this for initialization
	public float AnimationSpeed;

	GameObject tank;
	KeyboardControl TankControl;
	Vector2 tiling;
	float peroid=0.0f;

	void Start () {
		tank = this.gameObject;
		TankControl = GetComponent<KeyboardControl> ();	

		tiling.x = 0.5f;    // poczatkowe przesuniecie tekstury x
		tiling.y = 0.16f;
	}

	void animation()   //  Animacja czolgu
	{ 
		if (Time.time > peroid)         // Ten fragment odpowiada za zmiane animacji 
		{                               //
			peroid += AnimationSpeed;  //

			tank.GetComponent<Renderer> ().material.mainTextureOffset = tiling; // Przesuwam teksture na obiekcie 
			if (tiling.x == 0.5f)   // jesli przesunalem juz teksture to wroc do poprzedniego przesuniecia
				tiling.x = 0f;      // a jak nie to przesun
			else
				tiling.x = 0.5f;
		}
	}

	// Update is called once per frame
	void Update () {
		if (TankControl.isDriving () == true)
			animation ();
	}
}
