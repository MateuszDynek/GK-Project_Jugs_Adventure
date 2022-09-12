using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishButton : MonoBehaviour
{
    //public Transform player = GameObject.FindWithTag("Player").transform;
    //public Transform respawn_point = GameObject.FindWithTag("Respawn").transform;
    //public GameObject button = GameObject.FindWithTag("Button");
    void Start()
    {
        //player.transform.position = respawn_point.transform.position;
        //button.SetActive(false);
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
