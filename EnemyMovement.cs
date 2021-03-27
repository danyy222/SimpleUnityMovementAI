using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public Transform AgroPos;
    public float speed;
    public float AgroRange;
    public float StopRange;
    public Rigidbody2D rg;
    public LayerMask WhatIsPlayer;
    public LayerMask corner;
    //Trail maker
    public GameObject landFX;
    public Transform groundCheck;
    public float timebtwTrail;
    public float startTrail;
    void Update()
    {
        
        Collider2D[] Agro = Physics2D.OverlapCircleAll(AgroPos.position, AgroRange, WhatIsPlayer);
        for (int i = 0; i < Agro.Length; i++)
        {
            bool damaged = GetComponent<Enemy>().damaged;
            bool right = GetComponent<Enemy>().right;
            if (right==true)
            {
                rg.velocity = Vector2.right * speed;
                Trail();
            }
            else
            {
                rg.velocity = Vector2.left * speed;
                Trail();
            }
        }
        Collider2D[] Stop = Physics2D.OverlapCircleAll(AgroPos.position, StopRange, WhatIsPlayer);
        for (int e = 0; e < Stop.Length; e++)
        {
            rg.velocity = Vector2.zero *0;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(AgroPos.position, AgroRange);
        Gizmos.DrawWireSphere(AgroPos.position, StopRange);
    }
    public void Trail()
    {
        if (timebtwTrail <= 0)
        {
            Instantiate(landFX, groundCheck.position, Quaternion.identity);
            timebtwTrail = startTrail;
        }
        else
        {
            timebtwTrail -= Time.deltaTime;
        }
    }
}
