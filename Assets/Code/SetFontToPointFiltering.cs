using UnityEngine;
using UnityEngine.UI;

public class SetFontToPointFiltering : MonoBehaviour {

	void Start () 
	{
		GetComponent<Text>().mainTexture.filterMode = FilterMode.Point;
	}
}
