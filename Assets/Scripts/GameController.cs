using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI distanceText;
    public GameObject pickups;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float closestDistance = 1000;
        GameObject closestPickup = null;
        int pickupCount = pickups.transform.childCount;
        for (int i = 0; i < pickupCount; i++)
        {
            Transform pickup = pickups.transform.GetChild(i);

            if (pickup.gameObject.activeSelf == true) // dont need it there but discussion online said it
            {
                pickup.GetComponent<Renderer>().material.color = Color.white;
                float distance = Vector3.Distance(player.transform.position, pickup.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPickup = pickup.gameObject;
                }
            }



        }
        if (closestPickup != null)
        {
            closestPickup.GetComponent<Renderer>().material.color = Color.blue;
            distanceText.text = "Distance: " + closestDistance.ToString("0");
        }
    }
}
