using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f; //total health
    public float repeatDamage = 2f; //how long until player can be damaged again
    public float knockback = 10f;   //force of enemy attacks
    public float damage = 10f; //amount of damage from enemies, CONSULT WITH DAMON

    private float hitTime; //how long since player was hit
    private PlayerControl playerControl; //reference
    private Animator animate; //reference

    void Awake()
    {
        playerControl = GetComponent<PlayerControl>();
        animate = GetComponent<Animator>();
    }
    //function to tell if player is colliding with enemy
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" //if colliding with enemy
            && Time.time > hitTime + repeatDamage)    //if not in invuln period
        {
            if (health > 0f)
            {

            }
            //player has no health, let fall
            else {
                //set each collider in player to trigger
                Collider2D[] cols = GetComponents<Collider2D>();
                foreach (Collider2D c in cols) {
                    c.isTrigger = true;
                }
                //move player to front
                SpriteRenderer[] Spr = GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer s in Spr) {
                    s.sortingLayerName = "UI";
                }

                //disable player control
                GetComponent<PlayerControl>().enabled = false;
                //trigger death
                animate.SetTrigger("Die");
                 
            }
        }
    }
    public float GetStat() 
    {
        return health;
    }
}
