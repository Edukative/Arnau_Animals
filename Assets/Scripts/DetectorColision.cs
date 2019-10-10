using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorColision : MonoBehaviour
{
    public PlayerControler player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(other.tag != "Player")
        {
            Destroy(other.gameObject);
        }

        else
        {
            player.health--;
            Debug.Log(player.health);
        }
    }
}