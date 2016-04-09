using UnityEngine;
using System.Collections;

public class GenerateStarfield : MonoBehaviour {

    [SerializeField]
    public Texture[] m_textures;

	void Start ()
    {
		Generate ();
    }
	
	public void Generate ()
    {
		int index = (int)Random.Range(0, m_textures.GetLength(0));
		GetComponent<MeshRenderer>().material.mainTexture = m_textures[index];
		transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
	}
}
