using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI distanceText;
    public GameObject pickups;
    private LineRenderer lineRenderer;
    private enum debugMode { Normal, Distance, Vision } //enums act as numbers too
    private debugMode currentMode = debugMode.Distance;

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

            if (pickup.gameObject.activeSelf == true) // dont need true there but discussion online said it
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
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (currentMode == debugMode.Normal)
            {
                currentMode = debugMode.Distance;
            }
            else if (currentMode == debugMode.Distance)
            {
                currentMode = debugMode.Vision;
            }
            else
            {
                currentMode = debugMode.Normal;
            }
        }

        if (currentMode == debugMode.Normal)
        {
            distanceText.text = "";
            lineRenderer.enabled = false; // stuck here atm
        }
    }
}
