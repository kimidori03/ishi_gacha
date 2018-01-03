using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour {

	private bool inexpression = false;
	public Ishi_button ishi_button;
	public GameObject buttonSet;

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
	}
	
	// Update is called once per frame
	void Update () 
	{				
	}

	public void onclickishibutton()
	{
		Debug.Log ("わあ");
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
