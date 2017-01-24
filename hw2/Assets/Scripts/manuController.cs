using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class manuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GotoHW2_1() {
		SceneManager.LoadScene (1);
	}

	public void GotoHW2_2() {
		SceneManager.LoadScene (2);
	}

	public void GotoHW2_3() {
		SceneManager.LoadScene (3);
	}
}
