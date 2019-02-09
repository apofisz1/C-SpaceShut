﻿using System;
using System.Collections;
using System.Windows.Input;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject LaserPrefab;
    [SerializeField]
    private float fireRate = 0.10F;
    [SerializeField]
    private float canFire = 0.0f;



    [SerializeField]
    private float speed = 8.0f;

   
  private void Start()
    {
        transform.position = new Vector3(0, 0, 0); 
    }

   private void Update()
    {
        
        Movement();

        
         if  (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
           
        }

    }
    private void Shoot()
    {
        if (Time.time > canFire)
        {
            Instantiate(LaserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            canFire = Time.time + fireRate;
        }
    }


private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

        if (transform.position.y > 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, 0);
        }

        else if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }


        if (transform.position.x > 8.5f)
        {
            transform.position = new Vector3(-8.5f, transform.position.y, 0);
        }

        else if (transform.position.x < -8.5f)
        {
            transform.position = new Vector3(8.5f, transform.position.y, 0);
        }
    }

}
