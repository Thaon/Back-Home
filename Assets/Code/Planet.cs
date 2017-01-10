using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

	///
	/// the planet will have a randomly generated name, race and political system
	/// it will also provide prices for fuel, food and scrap, to buy and sell
	/// it can be of three types, based on te size of the planet:
	/// 	high resources, medium and low, prices will vary accordingly
	///

	#region member variables

	RetroPlanet m_associatedPlanet;
	string m_name;
	string m_race;
	string m_politycalSystem;

	//value 0 is buying price, 1 is selling price
	int[] m_fuelPrice = new int[2];
	int[] m_scrapPrice = new int[2];
	int[] m_foodPrice = new int[2];


	#endregion

	public void Generate ()
	{
		m_associatedPlanet = FindObjectOfType (typeof(RetroPlanet)) as RetroPlanet;

		int resouresAmount = m_associatedPlanet.radius;
		//print(m_associatedPlanet.radius);

		if (resouresAmount >= 32 && resouresAmount < 63) //low resources planet
		{
			m_fuelPrice[0] = Random.Range(3,7);
			//m_fuelPrice[1] = Random.Range(0,m_fuelPrice[0]); //max amount for selling is always lower than the buying

			//m_scrapPrice[0] = Random.Range(0,0);
			//m_scrapPrice[1] = Random.Range(0,m_scrapPrice[0]); //max amount for selling is always lower than the buying

			m_foodPrice[0] = Random.Range(3,6);
			//m_foodPrice[1] = Random.Range(0,m_foodPrice[0]); //max amount for selling is always lower than the buying
		}
		else if (resouresAmount >= 64 && resouresAmount <= 95) //medium resources planet
		{
			m_fuelPrice[0] = Random.Range(2,6);
			//m_fuelPrice[1] = Random.Range(0,m_fuelPrice[0]); //max amount for selling is always lower than the buying

			//m_scrapPrice[0] = Random.Range(0,0);
			//m_scrapPrice[1] = Random.Range(0,m_scrapPrice[0]); //max amount for selling is always lower than the buying

			m_foodPrice[0] = Random.Range(2,5);
			//m_foodPrice[1] = Random.Range(0,m_foodPrice[0]); //max amount for selling is always lower than the buying
		}
		else if (resouresAmount > 96 && resouresAmount <= 128) //high resources planet
		{
			m_fuelPrice[0] = Random.Range(1,5);
			//m_fuelPrice[1] = Random.Range(0,m_fuelPrice[0]); //max amount for selling is always lower than the buying

			//m_scrapPrice[0] = Random.Range(0,0);
			//m_scrapPrice[1] = Random.Range(0,m_scrapPrice[0]); //max amount for selling is always lower than the buying

			m_foodPrice[0] = Random.Range(1,4);
			//m_foodPrice[1] = Random.Range(0,m_foodPrice[0]); //max amount for selling is always lower than the buying
		}
	}

	//getters and setters
	public int GetFuelPrice() { return m_fuelPrice[0]; }
	public int GetScrapPrice() { return m_scrapPrice[0]; }
	public int GetFoodPrice() { return m_foodPrice[0]; }

}
