using UnityEngine;
using System.Collections;

public class PersistentData : MonoBehaviour {

    #region member variables

    #endregion

    void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
	}
	
	void Update ()
    {
	
	}
}
