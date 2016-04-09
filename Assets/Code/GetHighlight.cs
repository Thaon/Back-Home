using UnityEngine;
using System.Collections;

public class GetHighlight : MonoBehaviour {

    public Color m_lightColor;

    public void ChangeColor ()
    {
        GetComponent<Light>().color = m_lightColor;
	}
}
