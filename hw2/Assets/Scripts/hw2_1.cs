using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System;


public class hw2_1 : MonoBehaviour {
	public Text mystr;
	public Text statusText;
	public InputField myInputField;

	public int a,b;
	public int correctAnswer;



	// Use this for initialization
	void Start () {
		myInputField.text = "Answer?";
		statusText.text = "";
	}
		

	// Update is called once per frame
	void Update () {
		
	}


	// Generate Quiz using Random number generation
	public void generateQuiz() {
		a = (int) UnityEngine.Random.Range(1, 99);
		b = (int) UnityEngine.Random.Range(1, 99);
		correctAnswer = a + b;
		mystr.text = a.ToString () + " + " + b.ToString () + " = ";
		Start ();
	}

	public void checkAnswer() {

		// Convert String to Integer
		int myanswer;
		int.TryParse(myInputField.text, out myanswer);

		// Check answer
		if (myanswer == correctAnswer) {
			statusText.text = "Correct!";
		} else {
			statusText.text = "Wrong!";
		}
			
	}
		

	public void clickToMain() {
		SceneManager.LoadScene(0);
	}
}
