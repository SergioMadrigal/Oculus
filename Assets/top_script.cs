using UnityEngine;
using System.Collections;

public class top_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

void Update()
{
	//Use keys to ratchet rotation
	if (Input.GetKeyDown(KeyCode.Q))
		GetComponent<Animation>().Play("top_lid");

	if (Input.GetKeyDown(KeyCode.E))
		GetComponent<Animation>().Play("top_lid");

		if (Input.GetKeyDown(KeyCode.W))
			GetComponent<Animation>().Play("top_lid");

		if (Input.GetKeyUp(KeyCode.W))
			GetComponent<Animation>().Play("top_lid");

		if (Input.GetKeyDown(KeyCode.S))
			GetComponent<Animation>().Play("top_lid");

		if (Input.GetKeyUp(KeyCode.S))
			GetComponent<Animation>().Play("top_lid");
}
}
