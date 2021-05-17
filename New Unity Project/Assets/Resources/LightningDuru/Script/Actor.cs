using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Actor : MonoBehaviour {

	public List<Sprite> Sprites;
	public bool IsChild;
	public bool IsRotating;
	public bool IsSizing;
	public float RotatingTime = 2f;

	void Start () {
		_sr = GetComponent<SpriteRenderer>();
		_frame = 0;
		StartCoroutine( MoveFrame() );
		if( !IsChild ) {
			if( IsRotating ) {
				iTween.RotateBy(gameObject, iTween.Hash("z", 20, "loopType", "loop",
				                                        "easetype", "linear",
				                                        "amount", new Vector3(0, 0, 1),
				                                        "time", RotatingTime));
			} else {
				iTween.MoveBy(gameObject, iTween.Hash("y", 0.5, "easeType", "easeInOutSine",
				                                      "loopType", "pingPong",
				                                      "time", 0.4));
			}
		}
		if( IsSizing ) {
			iTween.ScaleBy(gameObject, iTween.Hash("loopType", "pingPong",
			                                       "easeType", "easeInOutSine",
			                                       "amount", new Vector3(2, 2, 0),
			                                       "time", 0.4f));
		}
	}
	
	IEnumerator MoveFrame() {
		while(true) {
			_sr.sprite = Sprites[_frame];
			_frame=(_frame+1)%Sprites.Count;
			yield return new WaitForSeconds( 0.1f );
		}
	}
	private int _frame;
	private SpriteRenderer _sr;

}
