using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    [SerializeField] private Image HealthBarImage;
   [SerializeField] private GameObject monster;

    private Animator an;
    float value = 1f;
    

    
    public  void SetHealthBarValue()
    {
        HealthBarImage.fillAmount -= 0.2f;
        if (HealthBarImage.fillAmount <= 0.0f)
        {

            an.SetTrigger("death");
            an.SetBool("canMove",false);
            StartCoroutine(we());

        }
            if (HealthBarImage.fillAmount < 0.2f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (HealthBarImage.fillAmount < 0.4f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);

        }

    }

    public  float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }


    public  void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    private void Start()
    {
        //HealthBarImage = GetComponent<Image>();
        an = GetComponent<Animator>();
        
    }
    private void Update()
    {
    
    }
    //when the weapon collides with the enemy health will be dicreased 
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject==monster)
        {
            SetHealthBarValue();

            an.SetTrigger("damage");

        }

     
    }


    IEnumerator we()
    {
        yield  return new WaitForSeconds(5f);
        SceneManager.LoadScene("EndScene");
    }

}

