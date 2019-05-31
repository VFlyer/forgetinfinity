using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgetInfinity : MonoBehaviour {
	public KMSelectable[] Buttons;
	public KMSelectable SubmitButton;
	public KMBombModule Module;
	public TextMesh Screen;

	// Use this for initialization
	void Start () {
		SubmitButton.OnInteract += delegate { Submit(); return false; };
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Submit() {
		Module.HandlePass ();
		Screen.text = "SOLVED!";
	}
}
