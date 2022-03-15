using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character2Dcontroller : MonoBehaviour
{
    public float MovementSpeed = 1;
    public int keyCount;
    public GameObject door;
    public GameObject invisibleDoor;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3 (movement, 0, 0) * Time.deltaTime * MovementSpeed;
        if (keyCount >= 1)
        {
            invisibleDoor.SetActive(false);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedUp"))
        {
            MovementSpeed = 5;
        }
        else if (collision.CompareTag("SlowDown"))
        {
            MovementSpeed = 1;
        }
        else if (collision.CompareTag("keyCount")) 
        {
            keyCount++;
        }
        else if (collision.CompareTag("door"))
        {
                door.SetActive(false);
        }
    }
}
