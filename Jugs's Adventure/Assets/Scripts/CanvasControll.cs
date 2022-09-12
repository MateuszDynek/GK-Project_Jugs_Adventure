using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanvasControll : MonoBehaviour
{
    public Transform player;
    public GameObject background;
    public GameObject mainText;
    public GameObject scoreText;
    public GameObject button;
    public GameObject button2;
   // public Camera mainCam;
    private Vector3 cameraOffset = new Vector3(-1, -0.4f, 92);

    void Start()
    {
        background.SetActive(false);
        button.SetActive(false);
        button2.SetActive(false);
        mainText.SetActive(false);
        scoreText.SetActive(false);
        
    }

    void Update()
    {
        transform.position = player.transform.position + cameraOffset;
       // transform.rotation = Quaternion.Euler(mainCam.transform.rotation.eulerAngles.x,mainCam.transform.rotation.eulerAngles.y,mainCam.transform.rotation.eulerAngles.z);
    }
}
