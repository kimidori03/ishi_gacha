using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dictionaryjewelController : MonoBehaviour {
	public GameObject[] jewels;
	public GameObject unknwon;
	public float scale = 0.1f;
	public float unknwonScale = 0.4f;
	public Transform parent;
	private bool isEncounted;

	private int id;

	public void init(int id, bool isEncounted, float itemScale){

		this.id = id;

		GameObject stone = null;

		if (!isEncounted) {
			stone = Instantiate(unknwon);
			stone.transform.localScale = Vector2.one * unknwonScale * itemScale;
		}
		else if( id < jewels.Length )
		{
			stone = Instantiate(jewels[id]);
			stone.transform.localScale = Vector2.one * scale * itemScale;
		}

		if( stone == null ) return;

		stone.transform.SetParent( parent );
		stone.transform.localPosition = Vector2.zero;

		this.isEncounted = isEncounted;
//		jewelimage.sprite = jewelsprites [id];

	}

	/// <summary>
	/// 詳細を表示する
	/// </summary>
	public void Press()
	{
		// 未遭遇は詳細表示しない
		if( !isEncounted ) return;

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
