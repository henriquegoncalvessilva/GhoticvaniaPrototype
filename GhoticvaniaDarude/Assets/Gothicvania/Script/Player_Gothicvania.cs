using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Gothicvania : MonoBehaviour
{
    static public Player_Gothicvania _instance;

    #region Private Variables

    [SerializeField] float speed;

    [SerializeField] float jumpForce;

    [SerializeField] bool action;

    [SerializeField] bool isGrounded;

    [SerializeField] Rigidbody rigd;

    [SerializeField] Animator anim;

    [SerializeField] SpriteRenderer spriteR;

    [SerializeField] int life;

    [SerializeField] int damage;

    [SerializeField] bool canShoot;

    [SerializeField] bool fire;

    public Vector3 weapon_Pos;

    [SerializeField] GameObject weapon;

    #endregion

    void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
        }

        isGrounded = true;

    }

    void FixedUpdate()
    {

        Movement(speed);

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump(jumpForce);
            }
        }



        Shoot();
    }

    void Movement(float value)
    {


        float h = Input.GetAxisRaw("Horizontal");

        if (action)
        {

            if (h > 0)
            {

                anim.SetBool("Shoot", false);

                canShoot = false;


                anim.SetBool("Run", true);

                spriteR.flipX = false;

                if (!spriteR.flipX)
                {
                    weapon.transform.localPosition = weapon_Pos;
                    weapon.transform.localEulerAngles = new Vector3(0, 0, 0);

                }

                transform.Translate(h * Time.fixedDeltaTime * value, 0, 0);


                Debug.LogWarning("Walk: Right ");

            }

            else if (h < 0)
            {

                anim.SetBool("Shoot", false);

                canShoot = false;


                anim.SetBool("Run", true);

                spriteR.flipX = true;

                transform.Translate(-h * Time.fixedDeltaTime * -value, 0, 0);

                Debug.LogWarning("Walk: Left ");

                if (spriteR.flipX)
                {

                    weapon.transform.localPosition = new Vector3(-weapon_Pos.x, weapon_Pos.y, weapon_Pos.z);

                    weapon.transform.localEulerAngles = new Vector3(0, 0, 0);

                }

            }

            else
            {
                anim.SetBool("Run", false);

                Debug.LogWarning("Stoped");

            }
        }
    }

    void Jump(float value)
    {

        anim.SetBool("Jump", true);
        rigd.AddForce(Vector3.up * value);


    }

    public bool PlayerFlip()
    {

        return spriteR.flipX;


    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(1) && Input.GetAxisRaw("Horizontal") == 0 && isGrounded)
        {



            anim.SetBool("Shoot", true);

            canShoot = true;

            jumpForce = 0;


        }



        else if (Input.GetMouseButtonUp(1))
        {

            canShoot = false;

            anim.SetBool("Jump", false);

            anim.SetBool("Shoot", false);

            jumpForce = 200;
        }
    }

    public int Damage_Player()

    {
        return damage;

    }

    public bool CanShoot()
    {
        return canShoot;
    }

    public void ActionPlayer(bool value)
    {

        this.GetComponent<Player_Gothicvania>().enabled = value;


    }

    #region Collision
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Plataform")
        {

            isGrounded = true;
            anim.SetBool("Jump", false);


        }

        if (collision.gameObject.tag == "Plataform")
        {
            this.transform.parent = collision.gameObject.transform;
            anim.SetBool("Jump", false);

        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            isGrounded = false;

        }

        if (collision.gameObject.tag == "Plataform")
        {
            this.transform.parent = null;
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {

            life -= other.gameObject.GetComponent<Enemy_Gothicvania>().Damage_Enemy();
            Debug.LogWarning(life);

        }

        if (other.gameObject.tag == "Enemy_Spider_Gothicvania" && transform.position.y > other.gameObject.transform.root.position.y)
        {

            other.gameObject.transform.root.GetChild(1).GetComponent<Enemy_Gothicvania>().Get_Life(Damage_Player());

        }

        if (other.gameObject.tag == "Cinematic")
        {

            Manager_Gothicvania._instance.PlayCinematic(true);
            anim.SetBool("Run", false);
            anim.SetBool("Jump", false);
            anim.SetBool("Shoot", false);


        }

    }


    #endregion


}
