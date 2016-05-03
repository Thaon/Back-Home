using UnityEngine;
using UnityEngine.UI;

public class InfoUIController : MonoBehaviour {

	public Text m_fuel, m_scrap, m_food;
	Controller m_controller;

	void Start()
	{
		m_controller = FindObjectOfType(typeof(Controller)) as Controller;
	}

	void Update ()
	{
		if (m_controller.m_food < 10)
		{
			m_food.text = "0" + m_controller.m_food.ToString();
		}
		else
		{
			m_food.text = m_controller.m_food.ToString();
		}
		
		if (m_controller.m_scrap < 10)
		{
			m_scrap.text = "0" + m_controller.m_scrap.ToString();
		}
		else
		{
			m_scrap.text = m_controller.m_scrap.ToString();
		}
		
		if (m_controller.m_fuel < 10)
		{
			m_fuel.text = "0" + m_controller.m_fuel.ToString();
		}
		else
		{
			m_fuel.text = m_controller.m_fuel.ToString();
		}
	}
}
