using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 350;

    [SerializeField] private Kunai kunaiPrefab;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private GameObject attackArea;



    private bool isGrounded = true;
    private bool isJumping = false;
    private bool isAttack = false;
    private float horizontal;

    //combo
    private static bool[] isHitting = new bool[3];
    private int attackMove = 0;

    private int coin = 0;
    //private int highcoin = 0;

    private Vector3 savePoint;

    private bool respawn;


    private void Awake()
    {
        //highcoin = PlayerPrefs.GetInt("Highscore", 0);
    }

    //private void Start()
    //{
    //    OnInit();
    //}


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
        //Debug.LogError("Update"); // khong khac gi debug log, chi la thay doi mau log thanh mau do?

        if (IsDead)
        {
            return;
        }

        isGrounded = CheckGrounded();
        // -1 -> 0 -> 1
        horizontal = Input.GetAxisRaw("Horizontal");
        //vertical = Input.GetAxisRaw("Vertical")

        if (isAttack)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if (isGrounded)
        {
            if (isJumping)
            {
                return;
            }

            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                Jump();
            }

            if (Mathf.Abs(horizontal) > 0.1f)
            {
                ChangeAnim("Run");

            }

            if (Input.GetKeyDown(KeyCode.Z) && isGrounded)
            {
                if (base.currentAnimName == "Attack3")
                {
                    // Reset the combo to Attack1
                    attackMove = 1;
                }
                else if (base.currentAnimName == "Attack1" || base.currentAnimName == "Attack2")
                {
                    // Increment the combo
                    attackMove++;
                }
                Attack();
            }

            if (Input.GetKeyUp(KeyCode.Z))
            {
                // Reset the combo and go back to Idle animation
                attackMove = 1;
                ChangeAnim("Idle");
            }

            if (Input.GetKey(KeyCode.X) && isGrounded)
            {
                Throw();
            }

        }

        if (!isGrounded && rb.velocity.y < 0)
        {
            isJumping = false;
            ChangeAnim("Fall");
        }

        //move
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            //ChangeAnim("run");
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            //horizontal > 0 -> tra ve 0 neu horizontal <= 0 -> tra ve 180
            transform.rotation = Quaternion.Euler(new Vector3(0, horizontal > 0 ? 0 : 180, 0));
            //transform.localScale = new Vector3(horizontal, 1, 1);
        }
        else if (isGrounded)
        {
            ChangeAnim("Idle");
            rb.velocity = Vector2.zero;
        }

    }

    public override void OnInit()
    {
        base.OnInit();

        if(respawn == false)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        

        isAttack = false;

        transform.position = savePoint;
        ChangeAnim("Idle");
        DeactiveAttack();

        SavePoint();
        UIManager.instance.SetCoin(coin);
        //UIManager.instance.SetHighScoreCoin(highcoin);
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        respawn = true;
        OnInit();
    }

    public void SetMove(float horizontal)
    {
        this.horizontal = horizontal;
    }

    protected override void OnDeath()
    {
        base.OnDeath();


    }

    private bool CheckGrounded()
    {
        //Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        //if (hit.collider != null)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
        return hit.collider != null;
    }

    public void Attack()
    {
        //
        rb.velocity = Vector2.zero;
        isAttack = true;
        //attackMove = (attackMove % 3) + 1;
        ChangeAnim("Attack1");
        //Debug.Log("Attack 1 !");
        //ChangeAnim("Attack" + attackMove.ToString());
        ActiveAttack();
        Invoke(nameof(ResetAttack), 0.5f);
        //ActiveAttack();
        Invoke(nameof(DeactiveAttack), 0.5f);
    }

    public void Throw()
    {
        rb.velocity = Vector2.zero;
        ChangeAnim("Throw");
        isAttack = true;
        Invoke(nameof(ResetAttack), 0.5f);

        Instantiate(kunaiPrefab, throwPoint.position, throwPoint.rotation);

    }

    private void ResetAttack()
    {
        ChangeAnim("Idle");
        isAttack = false;

    }

    public void Jump()
    {
        isJumping = true;
        ChangeAnim("Jump");
        rb.AddForce(jumpForce * Vector2.up);
    }


    internal void SavePoint()
    {
        savePoint = transform.position;
    }

    private void ActiveAttack()
    {
        attackArea.SetActive(true);
    }

    private void DeactiveAttack()
    {
        attackArea.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coin++;
            //if(highcoin < coin)
            //{
            //    highcoin = coin;
            //    PlayerPrefs.SetInt("Highscore", highcoin);
            //}
            //UIManager.instance.SetHighScoreCoin(highcoin);
            UIManager.instance.SetCoin(coin);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "DeathZone")
        {
            ChangeAnim("Die");
            Invoke(nameof(OnInit), 1f);
        }
    }



}
