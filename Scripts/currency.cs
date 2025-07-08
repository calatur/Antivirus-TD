using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currency : MonoBehaviour
{
    public int charge = 100;
    public Text chargecount;
    // Start is called before the first frame update
    void Start()
    {
        //charge = 100;
       
    }

    // Update is called once per frame
    void Update()
    {
        chargecount.text = charge.ToString();
    }
}
