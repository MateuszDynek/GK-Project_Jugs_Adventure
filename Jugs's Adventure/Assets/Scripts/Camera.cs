using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    private Vector3 cameraOffset = new Vector3(20, 5, 0);
    private const float rightRotate = -105;
    private const float leftRotate = -75;
    private const float normalRotate = -90;
    private bool changeState=false;
    private float tempDir = 0;
    private float tempRotate = -90;
    private float t = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        var direction = Input.GetAxis("Horizontal");
        if(direction>0)
        {
            if(tempDir<0)
            {
                t =0.0f;
                tempRotate = transform.eulerAngles.y - 360;
                Debug.Log(tempRotate);
            }
            transform.position = player.transform.position + cameraOffset;
            transform.localRotation = Quaternion.Euler(new Vector3(0,Mathf.Lerp(tempRotate,leftRotate,t),0));
            t += 1.5f * Time.deltaTime;
            tempDir=direction;
            
        }
        else if(direction<0)
        {
            if(tempDir>0)
            {
                t =0.0f;
                tempRotate = transform.eulerAngles.y - 360;
                Debug.Log(tempRotate);
            }
            transform.position = player.transform.position + cameraOffset;
            transform.localRotation = Quaternion.Euler(new Vector3(0,Mathf.Lerp(tempRotate,rightRotate,t),0));
            t += 1.5f * Time.deltaTime;
            tempDir = direction;
            
        }
        else
        {
            transform.position = player.transform.position + cameraOffset;
        }
        
    }
}

