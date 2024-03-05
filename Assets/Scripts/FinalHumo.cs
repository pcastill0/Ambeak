using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalHumo : MonoBehaviour
{
    public Animator animation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
