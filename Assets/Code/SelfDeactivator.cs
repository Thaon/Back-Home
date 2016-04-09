using UnityEngine;
using System.Collections;

public class SelfDeactivator : MonoBehaviour {

	public float m_timeToDeactivate = 1;

	void OnEnable ()
	{
		StartCoroutine (Deactivate ());
	}

	public IEnumerator Deactivate()
	{
		yield return new WaitForSeconds (m_timeToDeactivate);
		gameObject.SetActive (false);
	}
}
