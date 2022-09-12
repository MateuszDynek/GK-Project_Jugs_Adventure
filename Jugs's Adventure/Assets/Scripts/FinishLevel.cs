using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public GameObject background;
    public GameObject mainText;
    public GameObject scoreText;
    public GameObject button;
    public GameObject button2;
    public Transform player;
    public AudioSource audioSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            background.SetActive(true);
            button.SetActive(true);
            button2.SetActive(true);
            mainText.SetActive(true);
            scoreText.SetActive(true);
            player.gameObject.SetActive(false);
            audioSource.Play();
        }
    }
}
