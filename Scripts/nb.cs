using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class nb : MonoBehaviour
{
    public Transform target;
    public float nbspeed = 100f;
    public Rigidbody b;
    public GameObject particles, dp;
    public int damage;
    public AudioSource shoot;

    void Start()
    {
       shoot.Play();
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

          
        }
        
    }

     void LateUpdate()
    {
        StartCoroutine(bulletwait());
        
    }

    public void track(Transform _target)
    {
       target = _target;
        
    }

    public void HitTarget()
    {
       Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
        pathfinding h = target.GetComponent<pathfinding>();
        h.health = h.health - damage;
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
