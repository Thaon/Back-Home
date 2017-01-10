using UnityEngine;

public class PersistentData : MonoBehaviour {

    #region member variables

    private GameObject m_player;
    private GameObject m_planet;
    private int m_counter = 0;

    public GameObject[] m_flowcharts;

    #endregion

    void Start ()
    {
        m_player = GameObject.FindWithTag("Player");
        m_planet = GameObject.FindWithTag("Planet");

        m_planet.GetComponent<Planet>().Generate();

        m_flowcharts[m_counter].SetActive(true);
    }

    void Update ()
    {
	
	}

    void AdvanceStory()
    {
        m_flowcharts[m_counter].SetActive(false);
        m_counter++;
        m_flowcharts[m_counter].SetActive(true);
    }

    public void JumpBTNPressed()
    {
        //first we jump with the ship
        m_player.GetComponent<ShipAnimationHandler>().PlayJumpAnimation();
        GameObject.Find("Starfield").GetComponent<Animator>().SetBool("Fly", true);

        //then we build the arrival scene

        m_planet.GetComponent<Planet>().Generate();
        m_planet.GetComponent<Animator>().SetBool("Fly", true);
    }

    public void CompleteJump()
    {
        if (m_counter < m_flowcharts.Length)
        {
            m_planet.GetComponent<SpriteRenderer>().enabled = false;
            m_planet.GetComponent<SpriteRenderer>().enabled = true;
            AdvanceStory();
        }
        //else, we finished the game
    }
}
