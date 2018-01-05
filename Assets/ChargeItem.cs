using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChargeItem : MonoBehaviour {

	[SerializeField]
	private float maxKira2Offset;

	[SerializeField]
	RectTransform kira2;

	private float scale = 1f;

	[SerializeField]
	private float duration = 1f;

	// Use this for initialization
	void Start () {
		Glitter();
	}

	public float val = 1f;

	// Update is called once per frame
	void Update () {
	}

	public void OnClick()
	{
		Debug.Log(System.Reflection.MethodBase.GetCurrentMethod());
	}

	private void Glitter()
	{
		var newPos = new Vector2( Random.Range( -maxKira2Offset, maxKira2Offset ), Random.Range( -maxKira2Offset, maxKira2Offset ) );
		kira2.localPosition = newPos;

		kira2.localScale =  Vector3.zero;

		kira2.DOPunchScale( Vector3.one * val, duration, 0, 0 ).OnComplete( () => {Glitter();} );
	}

}
