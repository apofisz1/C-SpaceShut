using System;
using System.Collections;
using System.Windows.Input;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public bool canTripleShot = false;



    [SerializeField]
    private GameObject LaserPrefab;
    [SerializeField]
    private GameObject threeLeserPrefab;
    [SerializeField]
    private float fireRate = 0.25f;
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
        Shoot();

        if  (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //New dont need push the button, alwasy fire
        {
            Shoot();          
        }
    }
    private void Shoot()
    {
        if (Time.time > canFire)
        {
            if (canTripleShot == true)
            {
                Instantiate(threeLeserPrefab, transform.position, Quaternion.identity);

            }
            else
            {
                Instantiate(LaserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
                canFire = Time.time + fireRate;
        }
    }


private void Movement()  // mobil tuchsreen ???!!!!
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
    public void TripleShotPowerOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;

            
    }
}
