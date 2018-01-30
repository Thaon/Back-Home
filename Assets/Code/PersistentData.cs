using UnityEngine;
using System.Collections.Generic;

public class PersistentData : MonoBehaviour {

    #region member variables

    private GameObject m_player;
    private GameObject m_planet;
    private int m_counter = 0;

    public List<string> m_stories;

    #endregion

    void Start ()
    {
        m_player = GameObject.FindWithTag("Player");
        m_planet = GameObject.FindWithTag("Planet");

        m_planet.GetComponent<Planet>().Generate();
    }

    void Update ()
    {
	
	}

    void AdvanceStory()
    {
        m_counter++;
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
        if (m_counter < m_stories.Count)
        {
            m_planet.GetComponent<SpriteRenderer>().enabled = false;
            m_planet.GetComponent<SpriteRenderer>().enabled = true;
            AdvanceStory();
        }
        //else, we finished the game
    }
}
