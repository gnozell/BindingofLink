using UnityEngine;
using System.Collections;

public class baseEnemy : MonoBehaviour
{

    public string playerName = "player";
    public float health = 3;
	public Color tint = Color.white;

    protected GameObject player;

    protected bool invulnerable;
    protected bool poisoned;
    protected bool slowed;
    protected bool frozen;
    protected bool burned;

    // Use this for initialization
    public virtual void Start()
    {
        player = GameObject.Find(playerName);
		GetComponent<SpriteRenderer> ().color = tint;

    }

    public virtual void OnDeath()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        if (health <= 0)
        {
            OnDeath();
        }

    }
}
