using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChargeSceneManager : MonoBehaviour 
{
	public static ChargeSceneManager instance;

	int count;

	[SerializeField]
	public Text countValue;

	[SerializeField]
	private int maxChargeItemCount;

	[SerializeField]
	private GameObject chargeItemPrefab;

	private List<GameObject> chargeItemPool;

	private float timer = 0;

	[SerializeField]
	private float spawnInterval = 10f;

	[SerializeField]
	private RectTransform chargeItemParent;

	[SerializeField]
	private Image gauge;

	/// <summary>
	/// キラキラ発生時の効果音
	/// </summary>
	[SerializeField]
	private AudioClip kira2Sound;

	/// <summary>
	/// 音源
	/// </summary>
	[SerializeField]
	private AudioSource audioSource;

	// Use this for initialization
	void Start () 
	{
		instance = this;

		count = PlayerPrefs.GetInt("Charge");

		Debug.Log("読み込み ->" + count.ToString() );

	//	SceneManager.LoadSceneAsync("MenuUI", LoadSceneMode.Additive);
	}
	
	// Update is called once per frame
	void Update () {
		countValue.text = count.ToString();

		timer += Time.deltaTime;

		if( timer >= spawnInterval )
		{
			timer = 0;
			SpawnChargeItem();
		}
	}

	public void OnClickButton( GameObject item )
	{
		count++;

		var parGacha = 10;
		var surplus = count % parGacha;
		var percent = (float)surplus / parGacha;

		Debug.Log( percent );

		gauge.fillAmount = percent;

		item.SetActive( false );
	}

	void OnDestroy()
	{
		Debug.Log("保存 ->" + count.ToString() );

		PlayerPrefs.SetInt("Charge", count);
	}

	private void SpawnChargeItem()
	{
		if( chargeItemPool == null )
		{
			chargeItemPool = new List<GameObject>();
		}

		var activeCount = chargeItemPool.FindAll( a => a.activeInHierarchy).Count; 
		if( activeCount >= maxChargeItemCount )
		{
			Debug.Log( "生成済み数最大" );
			return;
		}

		Debug.Log( Screen.width );

		var maxWidth = Screen.width / 2;
		var maxHeight = Screen.height / 2;
		var marginSideAndTop = 20f;
		var marginBottom = 100f;

		var pos = new Vector2( Random.Range( -maxWidth + marginSideAndTop, maxWidth - marginSideAndTop ), Random.Range( -maxHeight + marginBottom, maxHeight - marginSideAndTop ) );

		GameObject obj = null;

		foreach( GameObject o in chargeItemPool )
		{
			if( !o.activeInHierarchy )
			{
				obj = o;
				obj.SetActive( true );
				break;
			}
		}

		if( !obj )
		{
			obj = Instantiate(chargeItemPrefab, chargeItemParent);
			chargeItemPool.Add( obj );
		}

		obj.transform.localPosition = pos;

		// 効果音
		audioSource.PlayOneShot( kira2Sound );
	}
}
