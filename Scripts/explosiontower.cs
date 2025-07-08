using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiontower : MonoBehaviour
{

    public Transform t1;
    public GameObject nbpfb, marker, updem;
    public Transform nbspawn, particles;
    bool rcheck;
    public Animator anim;

    [Header("Attributes")]
    public float range;
    public float atkrate;
    private float atkoffset = 0f;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        updem.SetActive(false);
        rcheck = false;
        marker.SetActive(false);
        InvokeRepeating("tlock", 0f, 0.5f);
    }


    void Update()
    {
        anim.SetInteger("attack", 0);
        if (t1 == null)
            return;

        if (atkoffset <= 0f)
        {
            atk();
            atkoffset = 1 / atkrate;
        }

        atkoffset -= Time.deltaTime;
    }

    void tlock()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float shtd = Mathf.Infinity;
        GameObject tnear = null;
        foreach (GameObject enemy in enemies)
        {
            float tdistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (tdistance < shtd)
            {
                shtd = tdistance;
                tnear = enemy;

            }

        }

        if (tnear != null && shtd <= range)
        {
            t1 = tnear.transform;
        }
        else
        {
            t1 = null;
        }
    }

    private void atk()
    {
        {
            anim.SetInteger("attack", 1);
            GameObject bulletgo = (GameObject)Instantiate(nbpfb, nbspawn.position, nbspawn.rotation);
            Instantiate(particles, nbspawn.position, nbspawn.rotation);
            explosionscript bullet = bulletgo.GetComponent<explosionscript>();

            if (bullet != null)
            {
                bullet.track(t1);
            }
        }
    }

    private void OnMouseDown()
    {
        if(rcheck == false)
        {
            GameObject[] portui = GameObject.FindGameObjectsWithTag("buildui");
            foreach (GameObject port in portui)
            {
                port.SetActive(false);
            }
            updem.SetActive(true);
            marker.SetActive(true);
            rcheck = true;
        }

        else if(rcheck == true)
        {   updem.SetActive(false); 
            marker.SetActive(false);
            rcheck = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
