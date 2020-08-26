using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayZone : MonoBehaviour
{
    public bool playerInside = false;
    public GameObject light;
    private Light _light;
    public Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        _light = light.GetComponent<Light>();
    }
void OnTriggerEnter(Collider collision)
    {
        Debug.Log("wtf");
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Player")
        {
            playerInside=true;
            animation.Play();
        }
         _light.color = playerInside ? new Color(0,1,0) : new Color(1,0,0);
        }
void OnTriggerExit(Collider collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Player")
        {
            playerInside=false;
            animation.Stop();
            animation.Rewind();
        }
         _light.color = playerInside ? new Color(0,1,0) : new Color(1,0,0);
    }
   
}
