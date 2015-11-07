using UnityEngine;
using System.Collections;

public class octorok : baseEnemy{
    Animator anim;
    Rigidbody2D rb2D;

    public float speed = 2f;

    private Vector2 velocityRight;
    private Vector2 velocityLeft;
    private Vector2 velocityUp;
    private Vector2 velocityDown;

    // Use this for initialization
    public override void Start () {
        base.Start();

        velocityRight = new Vector2(speed, 0);
        velocityLeft = new Vector2(-speed, 0);
        velocityUp = new Vector2(0, speed);
        velocityDown = new Vector2(0,-speed);

        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	public override void FixedUpdate() {
        base.FixedUpdate();

        // monsters current position
        Vector3 monsterVector = transform.position;

        //players current postition
        Vector3 playerVector = player.transform.position;

        if (player != null)
        {
            anim.SetBool("going_right", false);
            anim.SetBool("going_left", false);
            anim.SetBool("going_up", false);
            anim.SetBool("going_down", false);

            float x_diff = System.Math.Abs(monsterVector.x - playerVector.x);
            float y_diff = System.Math.Abs(monsterVector.y - playerVector.y);

            if ((playerVector.x > monsterVector.x) && (x_diff > y_diff))
            {
                anim.SetBool("going_right", true);
                rb2D.MovePosition( rb2D.position + velocityRight * Time.fixedDeltaTime);
            }

            else if ((playerVector.x <= monsterVector.x) && (x_diff >= y_diff))
            {
                anim.SetBool("going_left", true);
                rb2D.MovePosition(rb2D.position + velocityLeft * Time.fixedDeltaTime);
            }

            else if ((playerVector.y > monsterVector.y) && (x_diff < y_diff))
            {
                anim.SetBool("going_up", true);
                rb2D.MovePosition(rb2D.position + velocityUp * Time.fixedDeltaTime);

            }

            else if ((playerVector.y <= monsterVector.y) && (x_diff <= y_diff))
            {
                anim.SetBool("going_down", true);
                rb2D.MovePosition(rb2D.position + velocityDown * Time.fixedDeltaTime);
            }
        }
    }
}
