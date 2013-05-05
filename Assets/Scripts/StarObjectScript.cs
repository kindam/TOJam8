using UnityEngine;
using System.Collections;

public class StarObjectScript : MonoBehaviour 
{
	float colliderRadius = 1.0f;

	// Use this for initialization
	void Start () 
	{
		renderer.material.color = Color.yellow;
		colliderRadius = GetComponent<SphereCollider>().radius;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	 void OnTriggerEnter(Collider other) 
	 {
        Debug.Log("TriggerEntered!");
        other.transform.parent = transform;
        PlanetObjectScript planetScript = (PlanetObjectScript)(other.GetComponent<PlanetObjectScript>());
        planetScript.orbitRadius = colliderRadius;
    }
}
