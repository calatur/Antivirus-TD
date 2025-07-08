using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

public class pathfinding : MonoBehaviour
{ public currency chargeplus;
    public GameObject chargegain,coinparticles, coingo;
    public int speed = 10, slowcheck = 0;
    public NavMeshAgent enemy;
    public Transform proc;
    public int health = 150;
    public healthbarsc h;
    public Animator anim, coin;
    bool currencycheck;
    void Start()
    {
        coinparticles.SetActive(false);
        currencycheck = true;
        chargeplus = chargegain.GetComponent<currency>();
        h.maxHealth(health);
        enemy = GetComponent<NavMeshAgent>();
        enemy.speed = speed;
        enemy.SetDestination(proc.position);
        coingo = GameObject.FindGameObjectWithTag("coin");
        coin = coingo.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {   
       // enemy.SetDestination(proc.position);
        h.health(health);
        if(health <= 0)
        {
            gameObject.tag = "Untagged";
            enemy.isStopped = true;
            if (currencycheck == true)
            {
                coin.SetInteger("gain", 1);
                coinparticles.SetActive(true);
                chargeplus.charge += 4;
                StartCoroutine("coinspend");
               
                currencycheck = false;
            }
            anim.SetBool("New Bool", true);
            



            Destroy(gameObject, 1.7f);
            
        }
    }

    private void OnDestroy()
    {
        coin.SetInteger("gain", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "slow" && slowcheck == 0)
        {
            speed = 5;
            slowcheck = 1;
        }

      if(other.gameObject.tag == "shield" || other.gameObject.tag == "processor") 
           {
           
            Destroy(gameObject);
           }
      }

    IEnumerator coinspend()
    {
        yield return new WaitForSeconds(1);
       
    }

   }

