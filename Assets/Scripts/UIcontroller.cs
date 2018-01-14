using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour {

	private bool inexpression = false;
	public Ishi_button ishi_button;
	public GameObject buttonSet;

	private int count;
	public int chargePerGacha = 10;
	public GameObject tapObj;

	public void onclickretrybutton()
	{
		Debug.Log ("まああああ");
		ishi_button.cleanup ();
		buttonSet.gameObject.SetActive (false);
		tapObj.SetActive( true );

	//	SceneManager.UnloadSceneAsync("MenuUI");
		MenuUIController.instance.enableButtons = false;
	}
		
	// Use this for initialization
	void Start () 
	{
		buttonSet.gameObject.SetActive (false);
		tapObj.SetActive( true );

		count = PlayerPrefs.GetInt("Charge");

		MenuUIController.instance.enableButtons = false;

		var scene = SceneManager.GetSceneByName("gacha");
		SceneManager.SetActiveScene(scene);
			 
	}
	
	// Update is called once per frame
	void Update () 
	{				
	}

	public void onclickishibutton()
	{
		Debug.Log ("わあ");

		// スタミナ不足の時は演出見せずにメニュー出す
		if( count <  chargePerGacha )
		{
			Debug.LogWarning ("石不足");

		//	SceneManager.LoadSceneAsync("MenuUI", LoadSceneMode.Additive);

			MenuUIController.instance.enableButtons = true;

			return;
		}

		count -= chargePerGacha;

		PlayerPrefs.SetInt("Charge", count);

		tapObj.SetActive(false);

		StartCoroutine (waitanddisplaybutton());
	}

	IEnumerator waitanddisplaybutton()
	{
		if (inexpression) {
			yield break;
		}
		inexpression = true;
		yield return StartCoroutine(ishi_button.showgachaexpression());
		buttonSet.gameObject.SetActive (true);
		inexpression = false;

		// メニューUI表示
		// SceneManager.LoadScene( "MenuUI", LoadSceneMode.Additive );

		MenuUIController.instance.enableButtons = true;


	}
}
