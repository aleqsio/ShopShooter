using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPaper : MonoBehaviour
{
    public GameObject myPrefab;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
        if(count>0){
            count--;
            if(count%2==0){

            
            Instantiate(myPrefab, this.transform.position, Quaternion.identity);
            }
        }

    }
}
