using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}
	
public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public float fireRate = 0.5f;
	float nextFire = 0f;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpwan;

	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpwan.position, shotSpwan.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}

	// Update for Each Physics Step
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
	
		GetComponent<Rigidbody>().position = new Vector3 (
			Mathf.Clamp (transform.position.x, boundary.xMin, boundary.xMax),
			0f,
			Mathf.Clamp (transform.position.z, boundary.zMin, boundary.zMax)
		);

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0f, 0f, GetComponent<Rigidbody> ().velocity.x * -tilt);

	}


}
