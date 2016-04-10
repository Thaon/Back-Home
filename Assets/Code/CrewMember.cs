using UnityEngine;
using System.Collections;

public class CrewMember : MonoBehaviour
{

	#region member variables

	int m_happiness; //goes from 5 to 0; if this is 0, this guy will mutiny
	string m_name;
	Controller controller;
	bool m_mutining = false;

	#endregion

	void Start ()
	{
		//get a random name
		string[] randomNames = {"Barry", "Philip", "David", "Ava", "Sandy", "Janet", "Chris", "Daria"};
		m_name = randomNames[Random.Range(0, randomNames.Length)];
		controller = FindObjectOfType (typeof(Controller)) as Controller;
	}
	
	public void UpdateTurn ()
	{
		//decrease happiness
		m_happiness--;
		//eat
		if (controller.GetFood () > 0)
		{
			m_happiness++;
			controller.SetFood (controller.GetFood () - 1);
		}
		//decide what to do
		if (m_happiness <= 0)
		{
			m_mutining = true;
		}
		else
		{
			m_mutining = false;
		}
	}

	//getters and setters
	public bool IsMutining() { return m_mutining; }

	public void IncreaseHappiness() { m_happiness++; }
}
