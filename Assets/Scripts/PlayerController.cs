using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 6;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI playerPositionText;
    public TextMeshProUGUI playerVelocityText;
    private Vector3 lastPosition;

    void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
        lastPosition = transform.position;
    }
    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);

    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
        if (count >= numPickups)
        {
            winText.text = "You win!";
        }
    }

    void Update()
    {
        Vector3 v = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
        playerPositionText.text = "Pos: " + transform.position.ToString("0.00");
        playerVelocityText.text = "Speed: " + v.magnitude.ToString("0.00");
    }
}
