using UnityEngine;
using System.Collections;

public class ghost : baseEnemy
{
    Animator anim;
    Rigidbody2D rb2D;

    public float speed = 4f;
    public float firingSpeed = 2.5f;
    private float firing;

    private Vector2 velocityRight;
    private Vector2 velocityLeft;
    private Vector2 velocityUp;
    private Vector2 velocityDown;

    private CircleCollider2D inner_circle;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        firing = firingSpeed;
        velocityRight = new Vector2(speed, 0);
        velocityLeft = new Vector2(-speed, 0);
        velocityUp = new Vector2(0, speed);
        velocityDown = new Vector2(0, -speed);

        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        inner_circle = GetComponentInChildren<CircleCollider2D>();

    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    // Update is called once per frame
    public void Update()
    {
        firing -= Time.deltaTime;

        // monsters current position
        Vector3 monsterVector = transform.position;

        //players current postition
        Vector3 playerVector = player.transform.position;

        if (player != null)
        {
            //Debug.Log(player.transform.position);

            velocityRight = new Vector2(speed, player.transform.position.y);
            velocityLeft = new Vector2(-speed, player.transform.position.y);
            velocityUp = new Vector2(player.transform.position.x, speed);
            velocityDown = new Vector2(player.transform.position.x, -speed);

            float x_diff = System.Math.Abs(monsterVector.x - playerVector.x);
            float y_diff = System.Math.Abs(monsterVector.y - playerVector.y);



            if (inner_circle.IsTouching(player.GetComponent<Collider2D>()))
            {
                if (firing < 0)
                {
                    Debug.Log("FIRE!");
                    firing = firingSpeed;
                }

            }


            if ((playerVector.x > monsterVector.x) && (x_diff > y_diff))
            {
                rb2D.MovePosition(rb2D.position + velocityRight * Time.fixedDeltaTime);
            }

            else if ((playerVector.x <= monsterVector.x) && (x_diff >= y_diff))
            {
                rb2D.MovePosition(rb2D.position + velocityLeft * Time.fixedDeltaTime);
            }

            else if ((playerVector.y > monsterVector.y) && (x_diff < y_diff))
            {
                rb2D.MovePosition(rb2D.position + velocityUp * Time.fixedDeltaTime);

            }

            else if ((playerVector.y <= monsterVector.y) && (x_diff <= y_diff))
            {
                rb2D.MovePosition(rb2D.position + velocityDown * Time.fixedDeltaTime);
            }
        }
    }
}
