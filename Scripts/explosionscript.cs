using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class explosionscript : MonoBehaviour
{
    public Transform target;
    public float nbspeed = 100f;
    public Rigidbody b;
    public int range = 7, damage;
    public GameObject particles, dp, edp;
    public AudioSource explosion;

    private void Start()
    {
       
    }

    void Update()
    {
       
        {
            float distancethisframe = nbspeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, distancethisframe);
          


            if ((Vector3.Distance(transform.position, target.transform.position)) <= distancethisframe)
            {   
                HitTarget();

            }

            StartCoroutine(bulletwait());

          
        }
        
    }

    public void track(Transform _target)
    {
       target = _target;
        
    }

    public void HitTarget()
    {
      
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        Instantiate(particles, transform.position, Quaternion.identity);
        foreach (GameObject enemy in enemies)
        {
            float tdistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (tdistance <= range)
            {   Instantiate(edp, enemy.transform.position, Quaternion.identity);
               pathfinding he = enemy.GetComponent<pathfinding>();
                he.health = he.health - damage;
            }

        }

        Destroy(gameObject);
    }

    IEnumerator bulletwait()
    {
        yield return new WaitForSeconds(0.5f);
        if (b.linearVelocity.magnitude <= 0)
        {
            Instantiate(dp, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
