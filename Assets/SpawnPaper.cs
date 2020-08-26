using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPaper : MonoBehaviour
{
    public GameObject myPrefab;
    public int count;
    public int countdown;
    public int everyNFrames;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {

        countdown--;
        if(countdown<0){
            countdown=everyNFrames;
            if(count>0){
            count--;
            Instantiate(myPrefab, this.transform.position, Quaternion.identity);
            }
        }
    }
}
