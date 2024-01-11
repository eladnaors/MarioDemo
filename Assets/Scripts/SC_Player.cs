using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Player : MonoBehaviour
{
    private bool isJumping = false;
    private int CoinsAmount = 0;
    private float direction;
    public float speed = 2f;
    public float jumpSpeed = 10f;
    private Rigidbody2D myRigidBody;
    private SpriteRenderer myRenderer;
    private Vector3 startPosition;
    private Camera camera;
    public float Health, MaxHealth;
    [SerializeField]
    private SC_HealthBar healthBar;
    private void Awake()
    {
        camera = Camera.main;
    }

    void Start()
    {

        myRigidBody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        healthBar.SetMaxHealth(MaxHealth);

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        if (Input.GetKeyDown(KeyCode.D))
            SetHealth(-20f);
        if (Input.GetKeyDown(KeyCode.H))
            SetHealth(20f);
        if (Health <= 0)
        {
            ResetPosition();
            SetHealth(100f);
        }

    }

    void FixedUpdate()
    {
        direction = Input.GetAxis("Horizontal");
        if (direction != 0 && myRigidBody != null)
        {
            myRigidBody.velocity = new Vector2(direction * speed, myRigidBody.velocity.y);

            if (myRenderer != null)
            {
                if (direction >= 0)
                    myRenderer.flipX = false;
                else myRenderer.flipX = true;
            }
        }
    }

    public void CoinCollected()
    {

        CoinsAmount++;
        GameObject.Find("Txt_Coins").GetComponent<TMPro.TextMeshProUGUI>().text = "Coins: " + CoinsAmount;
        Debug.Log("Coins" + CoinsAmount);

    }
    public void ResetPosition()
    {
        transform.position = startPosition;
    }

    public void ResetJump()
    {
        isJumping = false;
    }
    private void Jump()
    {
        Debug.Log("Jump");
        if (myRigidBody != null && isJumping == false)
        {
            isJumping = true;
            myRigidBody.AddForce(new Vector2(0, jumpSpeed));
        }
    }

    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        healthBar.SetHealth(Health);
    }



}

