using UnityEngine;
using UnityEngine.UI;

public class PlanetUIController : MonoBehaviour {

	Controller m_controller;
	public Text m_foodTXT, m_scrapTXT, m_fuelTXT;

	void OnEnable ()
	{
		m_controller = FindObjectOfType(typeof(Controller)) as Controller;
	}
	
	void Update()
	{
		m_foodTXT.text = m_controller.m_currentFoodCost.ToString();
		//m_scrapTXT.text = m_controller.m_currentScrapCost.ToString();
		m_fuelTXT.text = m_controller.m_currentFuelCost.ToString();
	}
	
	public void BuyFood()
	{
		if (m_controller.m_scrap >= m_controller.m_currentFoodCost)
		{
			m_controller.m_scrap -= m_controller.m_currentFoodCost;
			m_controller.m_food += 1;
		}
	}
	
	public void BuyFuel()
	{
		if (m_controller.m_scrap >= m_controller.m_currentFuelCost)
		{
			m_controller.m_scrap -= m_controller.m_currentFuelCost;
			m_controller.m_fuel += 1;
		}
	}
	
	public void CloseUI()
	{
		this.gameObject.SetActive(false);
	}
	
}
