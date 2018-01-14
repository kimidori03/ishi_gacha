using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour {

	public static MenuUIController instance;
	public string currentSceneName;

	public Transform buttonParent;
	private Image[] buttons;

	private string[] sceneNames = new string[]{"Charge", "gacha", "dictionary"};

	// Use this for initialization
	void Start () 
	{
		instance = this;	
		currentSceneName = "title";

		buttons = buttonParent.GetComponentsInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickButton( int idx )
	{
		if( string.IsNullOrEmpty( currentSceneName ) )
		{
			return;
		}

		var newSceneName = sceneNames[ idx ];

		if( currentSceneName.Equals( newSceneName ) ) return;

		SceneManager.LoadScene(newSceneName, LoadSceneMode.Additive);

			//SceneManager.UnloadSceneAsync(currentSceneName);
		SceneManager.UnloadScene( currentSceneName );

		currentSceneName = newSceneName;
	}

	public bool enableButtons{
		get
		{
			return buttons[0].enabled;
		}
		set
		{
			foreach( Image i in buttons )
			{
				i.enabled = value;
			}
		}
	}
}
