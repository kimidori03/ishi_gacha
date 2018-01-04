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

	public void onclickretrybutton()
	{
		Debug.Log ("まああああ");
		ishi_button.cleanup ();
		buttonSet.gameObject.SetActive (false);
	}
		
	// Use this for initialization
	void Start () {
		Debug.Log (gameObject.name);
		buttonSet.gameObject.SetActive (false);

		count = PlayerPrefs.GetInt("Charge");
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

			SceneManager.LoadSceneAsync("MenuUI", LoadSceneMode.Additive);

			return;
		}

		count -= chargePerGacha;

		PlayerPrefs.SetInt("Charge", count);


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

	}
	public void button() 
	{
		SceneManager.LoadScene ("dictionary");
	}
}
