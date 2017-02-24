using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour {

	public Color defaultColor = new Color (1f, 1f, 1f, 1f);
	public Color flashColor   = new Color (1f, 0f, 0f, 0.5f);
	public float selectheight = 5f;
	List<GameObject> SelectedPlayers;

	void Start() 
	{
		SelectedPlayers = new List<GameObject> ();
	}


	void FixedUpdate()
	{
		// Mobile Touchpad input
		HandleTouchInput();

		// PC or Unity Mouse input
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER
		HandleMouseInput();
#endif
	}


	void HandleTouchInput ()
	{
		// 터치 입력은 한 번에 여러개가 들어올 수 있습니다. 터치가 하나 이상 입력되면 실행되도록 합니다.
		if(Input.touchCount > 0)
		{
			// 각각의 터치 입력을 하나씩 조회합니다.
			foreach(Touch touch in Input.touches)
			{
				// 현재 터치 입력의 x,y 좌표를 구합니다.
				Vector3 touchPos = new Vector3(touch.position.x, touch.position.y);
	
				// Select Player
				SelectPlayer(touchPos);
			}
		}
	}


	// For Mouse Input
	void HandleMouseInput()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			// Select Player
			SelectPlayer (Input.mousePosition);
		}
	}


	void SelectPlayer(Vector3 inputPos)
	{
		RaycastHit hit;
		GameObject targetPlayer; 
		Vector3 newposition;

		// 마우스 포인트 근처 좌표를 만든다. 
		Ray ray = Camera.main.ScreenPointToRay(inputPos); 

		//마우스 근처에 오브젝트가 있는지 확인
		if (Physics.Raycast (ray.origin, ray.direction * 2, out hit) == true) {

			//Player가 있으면 오브젝트를 저장한다.
			targetPlayer = hit.collider.gameObject;
			if (targetPlayer.tag == "Player") {
				if (SelectedPlayers.Count > 0) {
					foreach (var player in SelectedPlayers) {
						player.GetComponent<Renderer> ().material.shader = Shader.Find ("Standard (Specular setup)");
					}
					SelectedPlayers.Clear ();
				} 
				SelectedPlayers.Add (targetPlayer);

				if (SelectedPlayers.Count > 0) {
					foreach (var player in SelectedPlayers) {
						player.GetComponent<Renderer> ().material.shader = Shader.Find ("Diffuse");
						newposition = new Vector3 (player.transform.position.x, player.transform.position.y + selectheight, player.transform.position.z);
						player.transform.position = newposition;
						Debug.Log (player.name);
					}
				} 
			}
		}
	}
//
//	if(damaged) {
//		transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_OutlineColor", flashColour);
//	}  else {
//		transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_OutlineColor", Color.Lerp (transform.GetChild(0).GetComponent<Renderer>().material.GetColor("_OutlineColor"), Color.black, flashSpeed * Time.deltaTime));
//	}
//	damaged = false;




}
