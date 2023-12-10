using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    private int openingDirection;
    // 1 need botdoor
    // 2 need topdoor
    // 3 need leftdoor
    // 4 need rightdoor

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    void start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("SpawnRooms", 0.1f);
    }

    void SpawnRooms()
    {
        if(spawned == false)
        {
            if(openingDirection == 1)
            {
                // need to spawn a room with a bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                // need to spawn a room with a topdoor
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                // need to spawn a room with a leftdoor
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                // need to spawn a room with a rightdoor
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }  
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawn>().spawned == true)
        {
            Destroy(gameObject);
        }
    }
}
