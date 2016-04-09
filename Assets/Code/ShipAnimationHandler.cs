using UnityEngine;
using System.Collections;

public class ShipAnimationHandler : MonoBehaviour {

	public GameObject m_effect;
	public GameObject m_effect2;

	public void PlayJumpAnimation ()
	{
		GetComponent<Animator> ().SetBool("Fly", true);
		m_effect.SetActive (true);
	}

	public void PlayArrivalAnimation()
	{
		RetroPlanet planet = FindObjectOfType (typeof(RetroPlanet)) as RetroPlanet;
		planet.GenerateAsset ();
		GetComponent<Animator> ().SetBool("Fly", false);
		GameObject.Find ("Starfield").GetComponent<Animator> ().SetBool ("Fly", false);
	}

	public void Xplosion()
	{
		//also, generate a new starfield
		GameObject.Find("Starfield").GetComponent<GenerateStarfield>().Generate();

		m_effect2.SetActive (true);
	}
}
