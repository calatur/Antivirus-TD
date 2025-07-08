using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnbutton : MonoBehaviour
{

    public GameObject[] spawners;
    public GameObject sound;
   

    void Start()
    {  
        spawners = GameObject.FindGameObjectsWithTag("spawner");
}

    private void Update()
    {
       
    }

    public void spawnenemies()
    {
        
        StartCoroutine(soundwait());

        foreach (GameObject spawn in spawners)
        {
           wavespawn e = spawn.GetComponent<wavespawn>();
            e.spawncheck = true;
            
        }
    }

    IEnumerator soundwait()
    {
        sound.GetComponent<leevelselectionn>().buttonclick.Play();

        yield return new WaitForSeconds(1.0f);
       
    }
}
