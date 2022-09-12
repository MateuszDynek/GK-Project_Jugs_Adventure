using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectItems : MonoBehaviour
{
    private int points = 0;
    public TextMeshProUGUI finalScoreWinUi;
    public TextMeshProUGUI finalScoreLoseUi;
    public TextMeshProUGUI scoreUi;
    public AudioSource audioSource;
    public AudioClip coinCollectSound;
    public AudioClip gemCollectSound;
    public AudioClip winSound;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Coin") //sprawdzenie tagu obiektu
        {
            points += 10; //dodanie punktów
            Destroy(other.gameObject); //usunięcie obiektu
            audioSource.clip = coinCollectSound; //dodanie do źródła odpowiedniego dźwięku 
            audioSource.Play(); //odtworzenie dźwięku
        }
        else if(other.gameObject.tag == "Gem")
        {
            points += 50;
            Destroy(other.gameObject);
            audioSource.clip = gemCollectSound;
            audioSource.Play();
        }
        else if(other.gameObject.tag == "Finish")
        {
            audioSource.clip = winSound;
            audioSource.Play();
        }
    }
    private void Update() {
        scoreUi.text = "Points: "+points.ToString();
        finalScoreWinUi.text = "Final Score: "+points.ToString();
        finalScoreLoseUi.text = finalScoreWinUi.text;
    }
    
}
