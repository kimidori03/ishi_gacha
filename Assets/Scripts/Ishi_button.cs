using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Ishi_button : MonoBehaviour {


	public Transform parent;
	public List<GameObject> Stoneprefab;
	public List<GameObject> StoneNameaPrefab;
	public Image white;
	public GameObject tap;
	public GameObject Kirakira;
	private GameObject stone;
	private GameObject stoneName;
	private GameObject kira;
	public GirlController girl;
	public float wait_girl = 3f;
	public GameObject cave;
	public GameObject focus;
	public float cavescale_focused = 2.5f;
	public float zoomspeed = 1f;
	public GameObject flash;
	public Vector2 stoneNameOffset;

	[SerializeField]
	private AudioSource audioSource;

	public float stoneNameScale = 0.6f;

	public void cleanup(){
		Destroy (stone);
		Destroy (stoneName);
		Destroy (kira);
		tap.SetActive (true);
		GetComponent <Image> ().enabled = true;

	//	girl.gameObject.SetActive (false);

		cave.SetActive (true);
		Start();
	}

	// Use this for initialization
	void Start () {
		girl.gameObject.SetActive (false);
		cave.transform.localScale = Vector3.one;
		flash.SetActive (false);
		focus.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public IEnumerator showgachaexpression()
	{
		//tap画面から女の子
		{
			//集中線表示
			focus.SetActive(true);

			// 徐々にホワイトアウト
			float alpha = 0;
			while (alpha < 1) {
				alpha += Time.deltaTime * zoomspeed;
				var newcolor = new Color (1f, 1f, 1f, alpha);
				white.color = newcolor;
				var newscale = Mathf.Lerp (1f, cavescale_focused, alpha);
				cave.transform.localScale = newscale * Vector3.one;
				yield return null;
			}
		
			// 女の子表示
			girl.gameObject.SetActive (true);
			girl.animating = true;
			cave.SetActive (false);
			focus.SetActive (false);
			// TAP! ボタンを無効
			tap.SetActive (false);

			// 石ボタンを無効
			GetComponent <Image> ().enabled = false;

			// １秒待つ
			yield return new WaitForSeconds (1);

			// ホワイトアウトを徐々に薄くする
			while (alpha > 0) {
				alpha -= Time.deltaTime * 0.25f;
				var newcolor = new Color (1f, 1f, 1f, alpha);
				white.color = newcolor;
				yield return null;
			}
		}

		//一定時間女の子表示
		yield return new WaitForSeconds (wait_girl);

		//女の子からガチャ結果
		{
			//女の子のアニメ停止
			girl.animating = false;
			// 徐々にホワイトアウト
			float alpha = 0;
			while (alpha < 1) {
				alpha += Time.deltaTime * 0.5f;
				var newcolor = new Color (1f, 1f, 1f, alpha);
				white.color = newcolor;
				yield return null;
			}

			// 女の子非表示
			girl.gameObject.SetActive (false);

			// 出現する石インデックスを選ぶ
			int index;
			int seed = Random.Range (0, 100);
			if (seed >= 95) {
				index = 4;
			} else if (seed >= 90) {
				index = 3;
			} else if (seed >= 65) {
				index = 2;
			} else if (seed >= 35) {
				index = 1;
			} else {
				index = 0;
			}

			// 選ばれた石のインデックスをセーブ
			{
				var current = PlayerPrefs.GetString("jewel");
				var strs = new List<string>( current.Split(',') );
				strs.Add( ( index.ToString() + "," ) );
				strs = strs.Distinct().ToList();

				string newString = "";
				strs.ForEach( s => newString += (s + ",") );

				PlayerPrefs.SetString ("jewel", newString);
			}
	//		int index = Random.Range (0, Stoneprefab.Count);

			// 石プレハブを生成
			stone = Instantiate (Stoneprefab [index])as GameObject;
			stone.transform.SetParent( parent );
			stone.transform.localPosition = Vector2.zero;
			stone.transform.localScale = Vector2.one * 0.4f;

			stoneName = Instantiate (StoneNameaPrefab [index])as GameObject;
			stoneName.transform.SetParent( parent );
			stoneName.transform.localPosition = Vector2.zero + stoneNameOffset;
			stoneName.transform.localScale = Vector2.one * stoneNameScale;

			// キラキラエフェクトを生成
			kira = Instantiate (Kirakira)as GameObject;
			flash.SetActive (true);

			// １秒待つ
			yield return new WaitForSeconds (1);

			audioSource.Play();

			// ホワイトアウトを徐々に薄くする
			while (alpha > 0) {
				alpha -= Time.deltaTime * 0.25f;
				var newcolor = new Color (1f, 1f, 1f, alpha);
				white.color = newcolor;
				yield return null;
			}
		}
	}
}
