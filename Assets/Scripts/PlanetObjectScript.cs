using UnityEngine;
using System.Collections;

public class PlanetObjectScript : MonoBehaviour 
{
	public float orbitRadius = 10.0f;
	public float orbitSpeed = 10.0f;

	float timeCounter;

	public Vector3 velocity;
	Vector3 oldPosition;

	// Use this for initialization
	void Start () 
	{
		renderer.material.color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetButton("Jump") )
			transform.parent = null;

		if(transform.parent != null) // if attached to a body
		{	
			if(GetComponent("Rigidbody") != null)
			{
				Object.Destroy(GetComponent<Rigidbody>());
			}

			timeCounter += orbitSpeed * Time.deltaTime;
			transform.localPosition = new Vector3( orbitRadius * Mathf.Cos(timeCounter), orbitRadius * Mathf.Sin(timeCounter), 0);
			velocity = (transform.position - oldPosition)/Time.deltaTime;
			oldPosition = transform.position;
		}
		else
		{
			transform.position += velocity * Time.deltaTime;
			if(GetComponent("Rigidbody") == null)
			{
				gameObject.AddComponent("Rigidbody");
				GetComponent<Rigidbody>().useGravity = false;
				GetComponent<Rigidbody>().isKinematic = true;
			}
		}


	
	}


}
