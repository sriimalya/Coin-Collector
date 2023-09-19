using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerAndroid: MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int count;
    public TextMeshProUGUI countText, winText;

    public VariableJoystick variableJoystick;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = variableJoystick.Horizontal;
        float moveVertical = variableJoystick.Vertical;

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Coins: " + count.ToString();
            if(count>=17)
            {
                winText.gameObject.SetActive(true);
            }
        }
    }

}
