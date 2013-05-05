using UnityEngine;
using System.Collections;

public class StarObjectScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		renderer.material.color = Color.yellow;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	 void OnTriggerEnter(Collider other) 
	 {
        Debug.Log("TriggerEntered!");
        other.transform.parent = transform;
    }
}
