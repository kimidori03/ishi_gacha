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
	private List<Kira2InTitle> kira2Pool;
	public Kira2InTitle kira2Prefab;
	public int maxKira2Count = 10;
	public float minKira2SpawnInterval = 1f;
	public float maxKira2SpawnInterval = 3f;
	private float kira2Timer = 0;
	private float currentInterval = 1f;
	public Transform kira2Parent;
	public float minKira2MoveSpeed = 1f;
	public float maxKira2MoveSpeed = 5f;
	public Vector2 moveDirection = Vector2.down;

	public GameObject[] buttonTitles;

	// Use this for initialization
	void Start ()
	{
		// メニューシーンの上の文字を非表示
		foreach( GameObject g in buttonTitles )
		{
			g.SetActive( false );
		}
		StartCoroutine (showlogo());
	}
	
	// Update is called once per frame
	void Update () {
		SpawnKira2();
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
	
		// メニューシーンの上の文字を表示
		foreach( GameObject g in buttonTitles )
		{
			g.SetActive( true );
		}

	}

	private void SpawnKira2()
	{
		timer += Time.deltaTime;
		if( timer < currentInterval )
		{
			return;
		}

		timer = 0;
		currentInterval = Random.Range( minKira2SpawnInterval, maxKira2SpawnInterval);


		Kira2InTitle obj = null;

		  
		if( kira2Pool != null )
		{
			foreach( Kira2InTitle o in kira2Pool )
			{
				if( !o.gameObject.activeSelf )
				{
					obj = o;
					obj.gameObject.SetActive( true );
					break;
				}
			}
		}
		else
		{
			kira2Pool = new List<Kira2InTitle>();
		}

		if( obj == null  )
		{
			obj = Instantiate( kira2Prefab, kira2Parent ).GetComponent<Kira2InTitle>();
			kira2Pool.Add( obj );
		}

		obj.transform.localPosition = new Vector3(Random.Range( -Screen.width / 2, Screen.width /2 ), Screen.height / 2, 0);
		obj.Init( moveDirection, Random.Range( minKira2MoveSpeed, maxKira2MoveSpeed ) );
	}		
}
