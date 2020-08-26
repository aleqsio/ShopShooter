using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDisable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
    }
 IEnumerator Disappear()
    {
        //Print the time of when the function is first called.

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
