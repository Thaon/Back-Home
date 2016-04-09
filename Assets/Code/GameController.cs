using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject m_player;

	void Start ()
	{
	
	}
	
	void Update ()
	{
	
	}

	public void ShipBTNPressed()
	{
		print ("Ship button pressed");
	}

	public void JumpBTNPressed()
	{
		print ("Jump button pressed");

		m_player.GetComponent<ShipAnimationHandler> ().PlayJumpAnimation ();
		GameObject.Find ("RetroPlanet").GetComponent<Animator> ().SetBool ("Fly", true);
		GameObject.Find ("Starfield").GetComponent<Animator> ().SetBool ("Fly", true);
	}
}
