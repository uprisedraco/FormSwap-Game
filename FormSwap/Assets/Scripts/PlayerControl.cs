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
    
    public bool playerAlive;

    [SerializeField]
    private GameObject deadMenu;

    [SerializeField]
    private GameObject button;

    void Awake()
    {
        playerType = Type.High;
        playerAlive = true;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (playerAlive)
        {
            PlayerMove();

            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeForm();
            }
        }
        else
        {
            deadMenu.SetActive(true);
            button.SetActive(false);
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
        rb.velocity = new Vector3(forceSpeed, 0, 0);
        forceSpeed += 0.01f;
        if(forceSpeed > 25f)
        {
            forceSpeed = 25f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            playerAlive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
