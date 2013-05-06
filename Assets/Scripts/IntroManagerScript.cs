using UnityEngine;
using System.Collections;

public class IntroManagerScript : MonoBehaviour 
{

	GameObject TOJamBanner;
	GameObject goat;
	GameObject title;

	public Vector3 targetPosition = new Vector3(0,0,0);
	public float scrollTargetTime;
	public float TOJamBannerTimeCounter = 0;
	public float GoatTimeCounter = 0;
	public float TitleTimeCounter = 0;

	Vector3 startPosition;

	Quaternion targetRotation;

	// Use this for initialization
	void Start () 
	{
		goat = GameObject.Find("GoatOnAPole");
		TOJamBanner = GameObject.Find("TOJamBanner");
		title = GameObject.Find("Title");

		startPosition = TOJamBanner.transform.position;

		targetRotation = Quaternion.Euler(90,180,0);
	}
	
	// Update is called once per frame
	void Update () 
	{	

		if(TOJamBannerTimeCounter == 0)
			StartCoroutine(HandleTOJamBannerCoroutine());
		
		if( Input.GetButton("Jump") )
			Application.LoadLevel(1);
	}


	IEnumerator HandleTOJamBannerCoroutine()
	{
		// scroll
		while( TOJamBannerTimeCounter < scrollTargetTime )
		{
			TOJamBanner.transform.position = Vector3.Lerp(startPosition, targetPosition, TOJamBannerTimeCounter/scrollTargetTime );
			TOJamBannerTimeCounter += Time.deltaTime;
			yield return null;
		}
		// activate next scrolling
		StartCoroutine(HandleGoatPictureCoroutine());
		// set upright
		while(true)
		{
			TOJamBanner.transform.rotation = Quaternion.Slerp(TOJamBanner.transform.rotation, targetRotation, 0.5f *Time.deltaTime);
			TOJamBanner.transform.position = Vector3.Lerp( TOJamBanner.transform.position, new Vector3(-40,20,50), 0.5f * Time.deltaTime);
			yield return null;
		}


	}

	IEnumerator HandleGoatPictureCoroutine()
	{
		while( GoatTimeCounter < scrollTargetTime )
		{
			goat.transform.position = Vector3.Lerp(startPosition, targetPosition, GoatTimeCounter/scrollTargetTime );
			GoatTimeCounter += Time.deltaTime;
			yield return null;
		}
		// activate next part
		StartCoroutine(HandleTitleCoroutine());

		// set upright
		while(true)
		{
			goat.transform.rotation = Quaternion.Slerp(goat.transform.rotation, targetRotation, 0.5f *Time.deltaTime);
			goat.transform.position = Vector3.Lerp( goat.transform.position, new Vector3(40,10,50), 0.5f * Time.deltaTime);
			yield return null;
		}
	}

	IEnumerator HandleTitleCoroutine()
	{
		
		while( TitleTimeCounter < scrollTargetTime )
		{
			title.transform.position = Vector3.Lerp(startPosition, new Vector3(0,-5,5), TitleTimeCounter/scrollTargetTime );
			TitleTimeCounter += 0.2f * Time.deltaTime;
			yield return null;
		}
		
		//title.transform.position = new Vector3(0,0,0);
		//yield return null;
	}


}
