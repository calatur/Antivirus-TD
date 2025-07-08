using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeanddemolish : MonoBehaviour
{
    public GameObject upgrade, coinsgained;
    public currency charge;
    public int upgradecost, demolishpay;
    public Animator anim;
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("coin").GetComponent<Animator>();
        charge = FindObjectOfType<currency>();
    }


    void Update()
    {
        
    }

    public void Upgrade()
    {
        if (charge.charge >= upgradecost)
        {
            Instantiate(upgrade, transform.position, Quaternion.Euler(-90f, 0, 0));
            charge.charge -= upgradecost;
            gameObject.SetActive(false);
        }

    }

    public void demolish() {
        Instantiate(coinsgained, transform.position, transform.rotation);
        anim.SetInteger("gain", 1);
        charge.charge += demolishpay;
        StartCoroutine("wait");
      
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetInteger("gain", 0);
        gameObject.SetActive(false);
    }
}
