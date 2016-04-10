using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

	enum EndReason {mutiny, noMoreCrew};

	public int m_money;
	public int m_scrap;
	public int m_food;
	public int m_fuel;

	List<CrewMember> m_crew;

	void Start ()
    {
		m_crew = new List<CrewMember> ();
	}
	
	void CheckForMutiny ()
    {
		int mutinees = 0;
		foreach (CrewMember member in m_crew)
		{
			if (member.IsMutining ())
			{
				mutinees++;
			}
		}
		if (mutinees > m_crew.Count / 2) //if more than half the crew is mutining, the game is over
		{
			EndGame(EndReason.mutiny);
		}
	}

	public void FeedCrew()
	{
		foreach (CrewMember member in m_crew)
		{
			member.UpdateTurn ();
		}
	}

	public void EjectCrewMember()
	{
		//eject a crew member that wants to mutiny
		List<CrewMember> mutinees = new List<CrewMember>();
		foreach (CrewMember member in m_crew)
		{
			if (member.IsMutining ())
			{
				mutinees.Add (member);
			}
		}
		//eject a mutinee, if there is none, eject a random member
		if (mutinees.Count > 0)
		{
			CrewMember ejected = mutinees [Random.Range (0, mutinees.Count)];
			m_crew.Remove (ejected);
		}
		else
		{
			CrewMember ejected = m_crew [Random.Range (0, m_crew.Count)];
			m_crew.Remove (ejected);
		}
		//if you have no more crew members, the game is over
		if (m_crew.Count == 0)
		{
			EndGame (EndReason.noMoreCrew);
		}
		else //terrorise the rest of the crew, all of them get "happier" to please you
		{
			foreach (CrewMember member in m_crew)
			{
				member.IncreaseHappiness ();
			}
		}
	}

	void EndGame (EndReason reason)
	{
		switch (reason)
		{
			case EndReason.mutiny:
				print ("Mutiny ended your journey");
				Application.LoadLevel ("Mainmenu");
			break;

		case EndReason.noMoreCrew:
				print ("You have no more crew members :/");
				Application.LoadLevel ("Mainmenu");
			break;
		}
	}

	//getters and setters
	public int GetMoney() { return m_money; }
	public int GetScrap() { return m_scrap; }
	public int GetFood() { return m_food; }
	public int GetFuel() { return m_fuel; }

	public void SetMoney(int value) { m_money = value; }
	public void SetScrap(int value) { m_scrap = value; }
	public void SetFood(int value) { m_food = value; }
	public void SetFuel(int value) { m_fuel = value; }

}
