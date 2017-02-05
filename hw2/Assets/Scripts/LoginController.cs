using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Facebook.Unity;

public class LoginController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void LoginFacebook () {
		FB.Init (delegate() { 

			// 1. Init
			Debug.Log ("FB.Init() delegate!");

			// 2. Login!
			FB.LogInWithPublishPermissions (new List<string> () {
				"public_profile", "email", "user_friends"
			},
				// 3. Permissions
				delegate(ILoginResult result) {
					Debug.Log (result.RawResult);
					SceneManager.LoadScene ("Main");
				});
		});
	}


	public void OnInitComplete() {
		Debug.Log ("FB.Init Complete");
	}
}
