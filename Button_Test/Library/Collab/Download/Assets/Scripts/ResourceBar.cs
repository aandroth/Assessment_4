using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour {

    public GameObject m_slider;
    public GameObject m_player;
	// Use this for initialization
	void Start ()
    {
        m_slider.GetComponent<Slider>().minValue = 0;
        m_slider.GetComponent<Slider>().maxValue = 3700000;
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_slider.GetComponent<Slider>().value = m_player.GetComponent<PlayerStuff>().money;
	}
}
