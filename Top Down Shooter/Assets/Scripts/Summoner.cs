using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy {

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public float timeBetweenSummons;
    public Enemy enemyToSummon;
    public float attackSpeed;
    public float stopDistance;
    public float attackTime;

    private float timer;
    private float summonTime;
    private Vector2 targetPosition;
    private Animator anim;

	// Use this for initialization
	public override void Start () {
        base.Start();
        float RandomX = Random.Range(minX, maxX);
        float RandomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(RandomX, RandomY);
        anim = GetComponent<Animator>();
        Debug.Log("Start");
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null)
        {
            if(Vector2.Distance(transform.position, targetPosition) > .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
                if(Time.time > summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    anim.SetTrigger("Summon");
                }
            }
            if (Vector2.Distance(transform.position, player.position) < stopDistance)
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
	}
    public void Summon()
    {
        if(player != null)
        {
            Vector2 newPos = new Vector2(transform.position.x - 1.5f, transform.position.y - 1.5f);
            if(player.transform.position.y > transform.position.y)
            {
                newPos = new Vector2(transform.position.x + 1.5f, transform.position.y + 1.5f);
            }
            Instantiate(enemyToSummon, newPos, transform.rotation);
        }
    }
    IEnumerator Attack()
    {
        player.GetComponent<Player>().TakeDamage(damage);
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.position;

        float percent = 0;
        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }
    }
}
