using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private enum Type
    {
        Low,
        Mid,
        High
    }

    private Type playerType;

    [SerializeField]
    private Vector3 lowScale = new Vector3(1f, 1f, 1f);

    [SerializeField]
    private Vector3 midScale = new Vector3(1f, 1f, 1f);

    [SerializeField]
    private Vector3 highScale = new Vector3(1f, 1f, 1f);

    [SerializeField]
    private float forceSpeed = 100f;

    private Rigidbody rb;
    
    private bool playerAlive;

    void Awake()
    {
        playerType = Type.High;
        playerAlive = true;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (playerAlive)
        {
            PlayerMove();

            if (Input.GetMouseButtonDown(0))
            {
                ChangeForm();
            }
        }
    }

    private void ChangeForm()
    {
        switch (playerType)
        {
            case Type.Low:
                transform.localScale = lowScale;
                playerType = Type.Mid;
                break;
            case Type.Mid:
                transform.localScale = midScale;
                playerType = Type.High;
                break;
            case Type.High:
                transform.localScale = highScale;
                playerType = Type.Low;
                break;
        }
    }

    private void PlayerMove()
    {
        rb.AddForce(Vector3.right * forceSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            playerAlive = false;
        }
    }
}
