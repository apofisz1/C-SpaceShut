﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private int powerUpID; // 0 = tripeshot 1 = speed  2 = shild


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collider with:" + other.name);

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (powerUpID == 0)
                {
                    player.TripleShotPowerOn();
                }
                else if (powerUpID == 1)
                {
                    player.SpeedBoostPowerUpOn();
                }
                else if (powerUpID == 2)
                {
                    //shild
                }


            }
            

            Destroy(this.gameObject);

        }



    }

}
