using UnityEngine;
using System.Collections;

public class BoatMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		bool down = Input.GetKey (KeyCode.Space);
		bool up = Input.GetKeyUp (KeyCode.Space);

		if (down) {
			transform.Translate (transform.forward * 10 * Time.deltaTime);
		}

		if (up) {
			transform.Translate (transform.forward * 0);

		}
	}
}
