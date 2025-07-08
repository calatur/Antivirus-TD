using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class wavespawn : MonoBehaviour
{
    
    public enum spawnstate { spawn, waiting, counting};
    

    [System.Serializable]
    public class wave
    {
        public string name;
        public GameObject ene;
        public int numbers;
        public float spawnrate;
    }

    public wave[] waves;
    public int nextwave = 0;
    public float timebetween = 20f;
    public float wavecountdown, spawnfloat = 0;
    private float checkrate = 1f;
    public bool spawncheck;
    public GameObject spawnbutton, winpanel;
    private spawnstate state = spawnstate.counting;
    public Slider s;
    public int index;
    
    void Start()
    {
        Time.timeScale = 1f;
        winpanel.SetActive(false);
        spawnbutton.SetActive(true);
        wavecountdown = timebetween;
        spawncheck = false;
        s.value = 0.2f;
        
    }
    void Update()
    {
        
        
        if (state == spawnstate.waiting) 
        {
            if (waitforene())
            {
                wavecompleted();
            }

            else
            {
                return;
            }
        }
        if(wavecountdown <= 0) 
        {
            
            spawncheck = false;
            if(state != spawnstate.spawn)
            {
                StartCoroutine(spawnwave(waves[nextwave]));
               
            }
        }
        else if(spawncheck == true)
        {
            spawnbutton.SetActive(false);
            wavecountdown -= Time.deltaTime;
            spawnfloat += Time.deltaTime;
            
        }
    }

    IEnumerator spawnwave(wave _wave)
    {
        Debug.Log("Spawning...");
       
        state = spawnstate.spawn;
        for(int i = 0; i < _wave.numbers; i++)
        {
            SpawnEnemy( _wave.ene);
            yield return new WaitForSeconds(1f / _wave.spawnrate);
        }
        state = spawnstate.waiting;
        yield break;
    }

    void SpawnEnemy(GameObject _ene) 
    {
        Instantiate(_ene, transform.position, transform.rotation);
        
        Debug.Log("sdjdsaf");
    }

    bool waitforene()
    { checkrate -= Time.deltaTime;
        if (checkrate <= 0f)
        {
            checkrate = 1f;

            if (GameObject.FindGameObjectsWithTag("enemy").Length <= 3)
            {    spawnbutton.SetActive(true);
                spawnfloat = 0f;
                return true; }
             
        }

        return false;
    }
    
     public void wavecompleted()
    {
        
        Debug.Log("wave completed");
        state = spawnstate.counting;
        wavecountdown = timebetween;

        if (nextwave + 1 > waves.Length - 1)
        {
            
            if (index > PlayerPrefs.GetInt("unlocked"))
            {
                PlayerPrefs.SetInt("unlocked", index);
            }
            winpanel.SetActive(true);
            //Time.timeScale = 0f;
        }
        nextwave++;
        s.value++;
        
    }
}

