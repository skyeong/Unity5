using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hw2_3 : MonoBehaviour {
	public InputField myInputField;
	public Text bodyText;
	int num = 0;
	string str = "";


	// Use this for initialization
	void Start () {
		bodyText.text = "몇단을 출력할까요?";
		myInputField.text = "몇단";
	}

	// Update is called once per frame
	void Update () {

	}

	public void valueChanged() {
		// Convert String to Integer
		int.TryParse(myInputField.text, out num);
	}


	public void printGUGU() {
		if (num < 1 | num > 9) {
			str = "1~9 사이의 값을 입력하세요.";
			myInputField.text = "몇단";
		} else {
			str = "";
			int i = 1;
			while (i<10) {
				str = str + num.ToString () + " x " + i.ToString () + " = " + (num * i).ToString () + "\n";
				i++;
			} 
		}
		bodyText.text = str;
	}

	// Go back to main Manu
	public void clickToMain() {
		SceneManager.LoadScene(0);
	}

}
