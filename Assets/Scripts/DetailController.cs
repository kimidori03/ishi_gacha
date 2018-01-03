using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetailController : MonoBehaviour {

	public Sprite[] stoneImage;

	public Image stoneImageObj;

	public string[] titleTempates;
	public Text title;

	public string[] descTemplates;
	public Text desc;

	public static DetailController instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// 詳細画面を閉じる関数
	/// </summary>
	public void Close()
	{
		Debug.Log ("詳細画面を閉じます");
		SceneManager.UnloadSceneAsync ("detail");
		instance = null;
	}

	/// <summary>
	/// 詳細画面を初期化する関数
	/// </summary>
	public void Init(int stone_id)
	{
		Debug.Log (stone_id.ToString() + "の詳細画面を初期化します");

		// 画像
		if (stoneImage.Length <= stone_id) {
			Debug.LogError ("該当IDの石なし");
			Close ();
			return;
		}
		stoneImageObj.sprite = stoneImage[ stone_id ];

		// タイトル
		title.text = stoneImage [stone_id].name ;

		// 説明文
		desc.text = stoneImage [stone_id].name + "の説明";
	}
}
