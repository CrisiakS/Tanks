using UnityEngine;
using System.Collections;

public class Jezdzenie : MonoBehaviour {

	public GameObject czolg;  // Deklaracja obiektu czolgu
	Vector2 tiling;           // obiekt z punktami x i y - do obslugi "mainTextureOffset" bo przyjmuje tylko wektory

	// Use this for initialization
	void Start () {
		czolg = this.gameObject;  // Przypisuje do czolgu aktualny obiekt do ktorego podpiety jest skrypt
		tiling.x = 0.5f;    // poczatkowe przesuniecie tekstury x
		tiling.y = 0.16f;   // i przesuniecie y
		InvokeRepeating ("animacja", 0, 0.05f);   // Powtarzam funkcje "animacja" co 0.05 sekundy
	}
	

	void animacja()   // 
	{
		czolg.GetComponent<Renderer>().material.mainTextureOffset = tiling; // Przesuwam teksture na obiekcie 
		if (tiling.x == 0.5f)   // jesli przesunalem juz teksture to wroc do poprzedniego przesuniecia
			tiling.x = 0f;      // a jak nie to przesun
		else
			tiling.x = 0.5f;
	}

	// Update is called once per frame
	void Update () {
		czolg.transform.Rotate(0f, 1f, 0f);  // Obracanie po osi y
	}
}
