using UnityEngine;
using UnityEngine.UI;

public class SelectableFadeInOut : MonoBehaviour {

	float m_target = 0.1f;
	float m_current = 0;
	Transform[] m_children;
	bool m_hovering = false;
	
	public GameObject m_marketUI;

	void Start ()
	{
		m_children = GetComponentsInChildren<Transform>();
	}
	
	void Update ()
	{
		if(m_marketUI.activeInHierarchy) //if the market is open, the ui should be always visible;
		{
			m_target = 0.7f;
			m_current = m_target;
		}
		else if (!m_marketUI.activeInHierarchy && !m_hovering)
		{
			m_target = 0.1f;
		}
		
		if (m_target > m_current)
		{
			m_current += Time.deltaTime * 1.3f;
		}
		
		if (m_target < m_current)
		{
			m_current -= Time.deltaTime * 1.3f;
		}
		
		
		foreach(Transform child in m_children)
		{
			if (child.GetComponent<Image>() != null)
			{
				Color newCol = new Color(child.GetComponent<Image>().color.r, child.GetComponent<Image>().color.g, child.GetComponent<Image>().color.b, m_current);
				child.GetComponent<Image>().color = newCol;
			}
			if (child.GetComponent<Text>() != null)
			{
				Color newCol = new Color(child.GetComponent<Text>().color.r, child.GetComponent<Text>().color.g, child.GetComponent<Text>().color.b, m_current);
				child.GetComponent<Text>().color = newCol;
			}
		}
	}
	
	public void HoveringStart ()
	{
		//print("Mouse entered");
		m_target = 0.7f;
		m_hovering = true;
	}
	
	public void HoveringEnd()
	{
		//print("Mouse exited");
		m_target = 0.1f;
		m_hovering = false;
	}
}
