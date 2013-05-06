using UnityEngine;
using System.Collections;

public class PlanetObjectScript : MonoBehaviour 
{
	public float orbitRadius = 10.0f;
	public float orbitSpeed = 10.0f;

	public float rotationCounter;
	public float rotationDirection = 1.0f;

	public Vector3 velocity;
	Vector3 oldPosition;

	public Vector3 initialVelocity;

	// Use this for initialization
	void Start () 
	{
		renderer.material.color = Color.cyan;
		velocity = initialVelocity;
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

			rotationCounter += orbitSpeed * Time.deltaTime * rotationDirection;
			Vector3 targetPosition = new Vector3( orbitRadius * Mathf.Cos(rotationCounter), orbitRadius * Mathf.Sin(rotationCounter), 0);
			transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 1.50f * Time.deltaTime);
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

		if(transform.position.x < -180 || transform.position.x > 180 || transform.position.y > 100 || transform.position.y < -100)
			Application.LoadLevel(Application.loadedLevel);


	
	}
/*
	void OnBecameInvisible()
	{
		Debug.Log("Offscreen!");
		Application.LoadLevel(Application.loadedLevel);
	}
*/

}
