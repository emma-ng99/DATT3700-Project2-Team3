using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public GameObject block;
    public bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        block = GameObject.FindGameObjectWithTag("block");
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange) 
        {
            if (isOn == true)
            {
                block.SetActive(false);
            }
            else 
            { 
                block.SetActive(true); 
            }
                

        }
        else block.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
