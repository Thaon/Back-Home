using UnityEngine;
using System.Collections.Generic;

public enum GameState {planet, pirates, wreck, trader}; //used to check what will be displayed on arrival

public class Controller : MonoBehaviour {

	enum EndReason {mutiny, noMoreCrew};

	GameState m_state = GameState.planet;

	public int m_scrap;
	public int m_food;
	public int m_fuel;
	
	public int m_currentFoodCost;
	public int m_currentScrapCost;
	public int m_currentFuelCost;
	
	GameObject m_player;
	
	public GameObject m_planetUI;
	
	public GameObject m_planet;
	public GameObject m_pirates;
	public GameObject m_wreck;
	public GameObject m_trader;
	
	[SerializeField]
	List<CrewMember> m_crew;

	void Start ()
    {
		m_crew = new List<CrewMember> ();

		//add 3 members
		for (int i = 0 ; i < 3 ; i++)
		{
			GameObject crew = new GameObject("Crew Member " + i.ToString());
			crew.AddComponent<CrewMember>();
			m_crew.Add(crew.GetComponent<CrewMember>());
		}
		
		m_player = GameObject.FindWithTag("Player");
		
		m_planet.GetComponent<Planet>().Generate();
		m_currentFoodCost = m_planet.GetComponent<Planet>().GetFoodPrice();
		m_currentFuelCost = m_planet.GetComponent<Planet>().GetFuelPrice();
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
	
	public void ShipBTNPressed()
	{
		print ("Ship button pressed");
	}
	
	public void PlanetBTNPressed()
	{
		//print ("Ship button pressed");
		if (m_planetUI.activeInHierarchy == false)
		{
			m_planetUI.SetActive(true);
		}
	}

	public void JumpBTNPressed()
	{
		//first we jump with the ship
		m_player.GetComponent<ShipAnimationHandler> ().PlayJumpAnimation ();
		GameObject.Find ("Starfield").GetComponent<Animator> ().SetBool ("Fly", true);
		
		//then we build the arrival scene
		switch(m_state)
		{
			case GameState.planet:
				if (GameObject.Find ("RetroPlanet").GetComponent<Animator> ().GetBool("Fly") != true)
				{	
					//print ("Jump button pressed");
					//generate resources prices
					m_planet.GetComponent<Planet>().Generate();
					m_currentFoodCost = m_planet.GetComponent<Planet>().GetFoodPrice();
					//m_currentScrapCost = m_planet.GetComponent<Planet>().GetScrapPrice();
					m_currentFuelCost = m_planet.GetComponent<Planet>().GetFuelPrice();

					GameObject.Find ("RetroPlanet").GetComponent<Animator> ().SetBool ("Fly", true);
					
					FeedCrew();
					CheckForMutiny();
				}
			break;
			
			case GameState.pirates:
			
			break;
		}
	}
	
	public void CompleteJump()
	{
		int ran = Random.Range(0, 1); //we decide here the chances to get into a specific state
		print(ran);
		
		m_planet.GetComponent<SpriteRenderer>().enabled = false;
		m_pirates.SetActive(false);
		m_wreck.SetActive(false);
		m_trader.SetActive(false);
		
		switch (ran)
		{
			case 0: //planet
				m_planet.GetComponent<SpriteRenderer>().enabled = true;
				
				//wait for animation to end, then
				m_planet.GetComponent<RetroPlanet>().GenerateAsset();
			break;
			
			case 1: //pirates
				m_pirates.SetActive(true);
			break;
			
			case 2: //wreck
				m_wreck.SetActive(true);
			break;
			
			case 3: //trader
				m_trader.SetActive(true);
			break;
		}
	}

	//getters and setters
	public int GetScrap() { return m_scrap; }
	public int GetFood() { return m_food; }
	public int GetFuel() { return m_fuel; }

	public void SetScrap(int value) { m_scrap = value; }
	public void SetFood(int value) { m_food = value; }
	public void SetFuel(int value) { m_fuel = value; }

}
