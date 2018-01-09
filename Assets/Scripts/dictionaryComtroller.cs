using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dictionaryComtroller : MonoBehaviour {
	public dictionaryjewelController ishiprefab;
	public Transform ishibase;
	public Vector2 originposition;
	public Vector2 offset = Vector2.one * 150f;
	public int linenumber = 5;
	public int row1 = 4;
	public int row2 = 3;

	// Use this for initialization
	void Start () {
		int id = 0;
		for(int line = 0; line < linenumber; ++line){
			bool isoddline = line % 2 == 0;
			int rownumber = isoddline ? row1 : row2;
			int add = isoddline?0:(int)(offset.x/2);
			for (int i = 0; i < rownumber; ++i) {
				var obj = Instantiate (ishiprefab).GetComponent < dictionaryjewelController >();
			obj.transform.SetParent (ishibase);
				obj.transform.localPosition = originposition + new Vector2 ((offset.x * i)+add, offset.y * line);
				obj.init (id, checkisencountered(id));
				id++;

				
			}
		}

		SceneManager.LoadSceneAsync( "MenuUI", LoadSceneMode.Additive );

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private bool checkisencountered(int id){
		var data = PlayerPrefs.GetString ("jewel");
		if (string.IsNullOrEmpty (data)) {
			return false;
		}
		var ids = data.Split (',');
		foreach (string s in ids) {
			if (id.ToString () == s) {
				return true;
			}
		}
		return false;
	}
	public void button() {
		
		SceneManager.LoadScene ("gacha");
	
	}




}
