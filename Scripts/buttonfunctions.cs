using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class buttonfunctions : MonoBehaviour
{
    public GameObject normal, explode, turret, port, coingo;
    public Animator coin;
    public currency charges;
    public GameObject chargego, sound;
    public TextMeshProUGUI[] text;
   
    void Start()
    {
        coingo = GameObject.FindGameObjectWithTag("coin");
        coin = coingo.GetComponent<Animator>();
        charges = chargego.GetComponent<currency>();
    }

    private void Update()
    {
        


        if (charges.charge >= 30)
        {
            text[0].color = Color.green;
            text[1].color = Color.green;
        }

    else
        {
            text[0].color = Color.red;
            text[1].color = Color.red;
        }



    if(charges.charge >= 45)
        {
            text[2].color = Color.green;
        }

        else
        {
            text[2].color= Color.red;
        }

       // coin.SetInteger("spend", 0);
    }

    public void buildNormal()
    { if (charges.charge >= 30)
        {
            
            coin.SetInteger("spend", 1);
            sound.GetComponent<leevelselectionn>().buttonclick.Play();
            Instantiate(normal, transform.position, transform.rotation);
            StartCoroutine(soundwait());
            port.SetActive(false);
            charges.charge -= 30;
        }
    }

    public void buildexplode()
    {   if (charges.charge >= 45)
        {
            coin.SetInteger("spend", 1);
            sound.GetComponent<leevelselectionn>().buttonclick.Play();
            Instantiate(explode, transform.position, transform.rotation);
            StartCoroutine(soundwait());
            port.SetActive(false);
           // coin.SetInteger("spend", 0);
            charges.charge -= 45;
        }
    }

    public void buildturret()
    { if (charges.charge >= 30)
        {
            coin.SetInteger("spend", 1);
            sound.GetComponent<leevelselectionn>().buttonclick.Play();
            Instantiate(turret, transform.position, transform.rotation);
            StartCoroutine(soundwait());
            port.SetActive(false);
            //coin.SetInteger("spend", 0);
            charges.charge -= 30;
        }
    }

    IEnumerator soundwait()
    {
       
        yield return new WaitForSeconds(0.7f);
        coin.SetInteger("spend", 0);
    }
}
