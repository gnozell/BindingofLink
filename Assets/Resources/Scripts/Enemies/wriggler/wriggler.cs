using UnityEngine;
using System.Collections;

public class wriggler : baseEnemy
{
    Animator anim;
    Rigidbody2D rb2D;

    public float speed = 5f;

    private Vector2 velocityRight;
    private Vector2 velocityLeft;
    private Vector2 velocityUp;
    private Vector2 velocityDown;

    private Collider2D topCol;
    private Collider2D botCol;
    private Collider2D leftCol;
    private Collider2D rightCol;

    private float going;

    private float turntime = 0.25f;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        going = Random.Range(0, 4);
        velocityRight = new Vector2(speed, speed);
        velocityLeft = new Vector2(-speed, speed);
        velocityUp = new Vector2(speed, -speed);
        velocityDown = new Vector2(-speed, -speed);

        topCol = transform.Find("top").GetComponent<Collider2D>();
        botCol = transform.Find("bottom").GetComponent<Collider2D>();
        leftCol = transform.Find("left").GetComponent<Collider2D>();
        rightCol = transform.Find("right").GetComponent<Collider2D>();

        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

    }

    public void OnCollisionStay2D(Collision2D coll)
    {
        if (turntime < 0)
        {
            if (topCol.IsTouching(coll.collider)){
                Debug.Log("TOP");
                velocityRight = new Vector2(speed, -speed);
                velocityLeft = new Vector2(-speed, -speed);
                velocityUp = new Vector2(speed, -speed);
                velocityDown = new Vector2(-speed, -speed);
            }
            else if (botCol.IsTouching(coll.collider))
            {
                Debug.Log("BOT");
                velocityRight = new Vector2(speed, speed);
                velocityLeft = new Vector2(-speed, speed);
                velocityUp = new Vector2(speed, speed);
                velocityDown = new Vector2(-speed, speed);
            }
            else if (rightCol.IsTouching(coll.collider))
            {
                Debug.Log("RIGHT");
                velocityRight = new Vector2(-speed, speed);
                velocityLeft = new Vector2(-speed, speed);
                velocityUp = new Vector2(-speed, -speed);
                velocityDown = new Vector2(-speed, -speed);
            }
            else if (leftCol.IsTouching(coll.collider))
            {
                Debug.Log("LEFT");
                velocityRight = new Vector2(speed, speed);
                velocityLeft = new Vector2(speed, speed);
                velocityUp = new Vector2(speed, -speed);
                velocityDown = new Vector2(speed, -speed);
            }

            turntime = .25f;
            going = Random.Range(0, 4);

            
        }


    }

    // Update is called once per frame
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        turntime -= Time.deltaTime;

        //Debug.Log(going);


        if (going == 0)
        {
            rb2D.MovePosition(rb2D.position + velocityRight * Time.fixedDeltaTime);
        }

        else if (going == 1)
        {
            rb2D.MovePosition(rb2D.position + velocityLeft * Time.fixedDeltaTime);
        }

        else if (going == 2)
        {
            rb2D.MovePosition(rb2D.position + velocityUp * Time.fixedDeltaTime);

        }

        else if (going == 3)
        {
            rb2D.MovePosition(rb2D.position + velocityDown * Time.fixedDeltaTime);
        }

    }
}
