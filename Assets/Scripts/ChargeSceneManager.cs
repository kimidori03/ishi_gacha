using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChargeSceneManager : MonoBehaviour {

	int count;

	public Text countValue;

	// Use this for initialization
	void Start () 
	{
		count = PlayerPrefs.GetInt("Charge");

		Debug.Log("読み込み ->" + count.ToString() );

		SceneManager.LoadSceneAsync("MenuUI", LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () {
		countValue.text = count.ToString();
	}

	public void OnClickButton()
	{
		count++;
	}

	void OnDestroy()
	{
		Debug.Log("保存 ->" + count.ToString() );

		PlayerPrefs.SetInt("Charge", count);
	}
}
