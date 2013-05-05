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
        
        PlanetObjectScript planetScript = (PlanetObjectScript)(other.GetComponent<PlanetObjectScript>());
        planetScript.orbitRadius = colliderRadius;

        // chose appropriate rotation direction
        float direction = 1.0f; 
        if(other.transform.position.y > transform.position.y)
        {
        	if( planetScript.velocity.x > 0)
        		direction = -1.0f;
        	else
        		direction = 1.0f;
        }
        else
        {
        	if( planetScript.velocity.x > 0)
        		direction = 1.0f;
        	else
        		direction = -1.0f;
        }

        // apply direction
        planetScript.rotationDirection = direction;

        other.transform.parent = transform;
    }
}
