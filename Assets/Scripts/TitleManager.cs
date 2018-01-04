using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

	public Image Logo;
	public float delay = 1f;
	public float duration = 1f;
	private float timer = 0;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (showlogo());
	}
	
	// Update is called once per frame
	void Update () {
	}

	// フェードアウトでロゴを表示する
	private IEnumerator showlogo()
	{
		while(timer < delay){
			timer += Time.deltaTime;
			yield return null;
		}

		var progress = 0f;

		while(progress < 1){
			progress += Time.deltaTime / duration;
			Logo.color = new Color(1f,1f,1f,progress);
			yield return null;
		}

		// メニューシーンを開く
		SceneManager.LoadSceneAsync( "MenuUI", LoadSceneMode.Additive );
	
	}
		
}
