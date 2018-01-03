using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dictionaryjewelController : MonoBehaviour {
	public Sprite[] jewelsprites;
	public Sprite unknown;
	public Image jewelimage;

	private int id;

	public void init(int id, bool isencountered){

		this.id = id;
		if (!isencountered) {
			jewelimage.sprite = unknown;
			return;
		}
		if (id >= jewelsprites.Length) {
			return;
		}
		jewelimage.sprite = jewelsprites [id];
	}

	/// <summary>
	/// 詳細を表示する
	/// </summary>
	public void Press()
	{
		SceneManager.LoadScene("detail", LoadSceneMode.Additive);

		StartCoroutine (DisplayDetailAndInit ());
	}

	private IEnumerator DisplayDetailAndInit()
	{
		while( !DetailController.instance )
		{
			yield return null; 
		}

		DetailController.instance.Init (this.id);
	}
}
