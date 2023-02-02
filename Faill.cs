using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Faill : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
   
    public float shake_intensity;

    public bool isShaking;

    
    Vector2 startingPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {
            transform.position = transform.localPosition + Random.insideUnitSphere * shake_intensity;
        }
    }

    IEnumerator fall()
    {
        yield return new WaitForSeconds(1f);
        rb.isKinematic = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isShaking = true;
            StartCoroutine(fall());
        }
    }
}
