using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickButton( int idx )
	{
		switch( idx )
		{
		case 0:
			SceneManager.LoadScene("Charge");
			break;
			case 1:
			SceneManager.LoadScene("gacha");

			break;
			case 2:
			default:
			SceneManager.LoadScene("dictionary");

			break;
		}
	}
}
