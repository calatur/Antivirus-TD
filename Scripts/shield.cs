using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
   public int shieldhealth = 20;
    public Material shieldMaterial, damaged;
    public GameObject shieldgo, particles;
    bool dmgcheck = false;
    float redcountdown = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (shieldhealth <= 0)
        {
            Destroy(gameObject);
        }

        if( dmgcheck == true) {
            

            redcountdown -= Time.deltaTime;
            if(redcountdown <= 0)
            {   
                shieldgo.GetComponent<MeshRenderer>().material = shieldMaterial;
                dmgcheck = false;
                redcountdown = 1f;
            }

        
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Instantiate(particles, transform.position, transform.rotation);
            shieldgo.GetComponent<MeshRenderer>().material = damaged;
            shieldhealth = shieldhealth - 1;
            dmgcheck = true;
           

        }
    }
}
