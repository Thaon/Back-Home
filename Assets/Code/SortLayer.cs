using UnityEngine;
using System.Collections;

public class SortLayer : MonoBehaviour {

	// Use this for initialization
	void Start ()
    { 
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "foreground";
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = 2;
    }
}
