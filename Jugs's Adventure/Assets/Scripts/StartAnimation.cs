using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public Animator animator;
    private string anim = "UpPlatform";
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag =="Player"){
            animator.Play(anim,0,0.0f);
        }
        
    }
}
