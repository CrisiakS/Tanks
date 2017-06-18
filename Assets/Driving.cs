using UnityEngine;
using System.Collections;

public class Driving : MonoBehaviour {

	public GameObject czolg;  // Deklaracja obiektu czolgu
	public GameObject cam;
	Vector2 tiling;           // obiekt z punktami x i y - do obslugi "mainTextureOffset" bo przyjmuje tylko wektory
	Vector3 tankPos;
	public float animation_speed;

	float peroid=0.0f;
	float rotation_init=0,rotation=0;
	public float speed;
	float direction=0,move=0;
	public string key_up="w";
	public string key_down="s";
	public string key_left="a";
	public string key_right="d";

	// Use this for initialization
	void Start () {
		czolg = this.gameObject;  // Przypisuje do czolgu aktualny obiekt do ktorego podpiety jest skrypt
		cam = GameObject.Find("Glowna kamera");
		tankPos = czolg.transform.position;
		tiling.x = 0.5f;    // poczatkowe przesuniecie tekstury x
		tiling.y = 0.16f;   // i przesuniecie y

		tankPos.z -= 40;
		cam.transform.position = tankPos;
	}
	

	void animation()   //  Animacja czolgu
	{ 
		if (Time.time > peroid)         // Ten fragment odpowiada za zmiane animacji 
		{                               //
			peroid += animation_speed;  //
		
			czolg.GetComponent<Renderer> ().material.mainTextureOffset = tiling; // Przesuwam teksture na obiekcie 
			if (tiling.x == 0.5f)   // jesli przesunalem juz teksture to wroc do poprzedniego przesuniecia
				tiling.x = 0f;      // a jak nie to przesun
			else
				tiling.x = 0.5f;
		}
	}


	bool KeysReleased()
	{
		if(Input.GetKey (key_up)==false)
			if (Input.GetKey(key_down)==false)
				if ((Input.GetKey(key_left)==false)) 
					if((Input.GetKey (key_right)==false))
			return true;

			return false;
	}

	// Update is called once per frame
	int pressed=0;
	void Update () {
		if (KeysReleased () == false) {
			if (rotation != 180) {
				if (Input.GetKey (key_up) == true) {
						
					rotation = 180;
					czolg.transform.Rotate (0f, rotation - rotation_init, 0f);
					rotation_init = rotation;
					pressed++;
					direction = 1;
					move = -speed;
				}
			} 

			if (rotation != 0) {
				if (Input.GetKey (key_down) == true) {
						
					rotation = 0;
					czolg.transform.Rotate (0f, rotation - rotation_init, 0f);
					rotation_init = rotation;
					pressed++;
					direction = 2;
					move = speed;
				}
			} 
			if (rotation != 90) {
				if (Input.GetKey (key_left) == true) {
								
					rotation = 90;
					czolg.transform.Rotate (0f, rotation - rotation_init, 0f);
					rotation_init = rotation;
					pressed++;
					direction = 3;
					move = speed;
		
				}
			}
			if (rotation != 270) {
				if (Input.GetKey (key_right) == true) {
							
					rotation = 270;
					czolg.transform.Rotate (0f, rotation - rotation_init, 0f);
					rotation_init = rotation;
					pressed++;
					direction = 4;
					move = -speed;
				} 
			}
			if (direction == 3) {
				czolg.transform.Translate (0f, 0f, -move * Time.deltaTime);
				cam.transform.position = tankPos;
			}
			
			if (direction == 4) {
				czolg.transform.Translate (0f, 0f, move * Time.deltaTime);
				cam.transform.position = tankPos;
			}

			if (direction == 2) {
				czolg.transform.Translate (0f, 0f, -move * Time.deltaTime);
				cam.transform.position = tankPos;
			}

			if (direction == 1) {
				czolg.transform.Translate (0f, 0f, move * Time.deltaTime);
				cam.transform.position = tankPos;
			}

			animation ();
		}

		if (KeysReleased () == true) {
		//	czolg.transform.Translate (0f, 0f, 2f);
			direction = 0;
			move = 0;
		}
		tankPos=czolg.transform.position;
		tankPos.z -= 40;
	}
}
