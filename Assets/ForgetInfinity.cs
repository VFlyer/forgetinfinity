using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgetInfinity : MonoBehaviour {
	public KMSelectable[] Buttons;
	public KMSelectable SubmitButton;
	public KMSelectable ResetButton;
	public KMBombModule Module;
	public TextMesh Screen;

	public static string[] ignoredModules = null;

	private int[] code = {0, 0, 0, 0, 0};
	private int[] target = {1,2,3,4,5};
	private int codeIndex = 0;

	private static bool solved = false;

	// Use this for initialization
	void Awake() {
		if (ignoredModules == null)
			ignoredModules = GetComponent<KMBossModule>().GetIgnoredModules("Forget Infinity", new string[]{
				"Forget Me Not",     //Mandatory to prevent unsolvable bombs.
				"Forget Everything", //Cruel FMN.
				"Turn The Key",      //TTK is timer based, and stalls the bomb if only it and FMN are left.
				"Souvenir",          //Similar situation to TTK, stalls the bomb.
				"The Time Keeper",   //Again, timilar to TTK.
				"Alchemy",
				"Forget This",
				"Simon's Stages",
				"Timing is Everything",
			});
		updateScreen ();
	}

	void Start () {
		Buttons [0].OnInteract += delegate{Handle1();return false;};
		Buttons [1].OnInteract += delegate{Handle2();return false;};
		Buttons [2].OnInteract += delegate{Handle3();return false;};
		Buttons [3].OnInteract += delegate{Handle4();return false;};
		Buttons [4].OnInteract += delegate{Handle5();return false;};
		SubmitButton.OnInteract += delegate {
			Submit ();
			return false;
		};
		ResetButton.OnInteract += delegate {
			Reset ();
			return false;
		};
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Submit() {
		for (int i = 0; i < 5; i++) {
			if (code [i] != target [i]) {
				Module.HandleStrike ();
				Reset ();
				return;
			}
		}
		solved = true;
		Module.HandlePass ();
		Screen.text = "XXXXX";
	}

	void updateScreen() {
		string b = "";
		for (int i = 0; i < 5; i++) {
			b += this.code[i].ToString();
		}
		Screen.text = b;
	}

	void Number(int button) {
		Debug.Log ("button " + button.ToString () + " pushed");
		if (this.codeIndex == this.code.Length)
			return;
		if (this.codeIndex < 5) {
			this.code [this.codeIndex++] = button;
		}
		updateScreen ();
	}

	void Handle1() {
		Number (1);
	}

	void Handle2() {
		Number (2);
	}

	void Handle3() {
		Number (3);
	}

	void Handle4() {
		Number (4);
	}

	void Handle5() {
		Number (5);
	}

	void Reset() {
		for (int i=0; i<5; i++) this.code [i] = 0;
		this.codeIndex = 0;
		updateScreen ();
	}
}
