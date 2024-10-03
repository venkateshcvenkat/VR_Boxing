using System.Collections;
using UltimateXR.Extensions.Unity;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float attackdistance = 1;

    public Animator animator;
    public GameObject Player,particle,loss;
    public ParticleSystem effect;
  //  public static int healthamount;
    float distance;
    public bool block, dis;

    public int maxhealth=30;
    public int currenthealth;
    public health health;
    
    void Start()
    {
        animator.GetComponent<Animator>();
       // healthamount = 10;
        currenthealth = maxhealth;
        health.Setmaxhealth(maxhealth);
    }


    void Update()
    {
       
        distance = Vector3.Distance(transform.position, Player.transform.position);
        transform.LookAt(Player.transform.position);
       if(currenthealth  == 0)
       {
            Player.SetActive(false);
            animator.Play("Stretch");
            particle.SetActive(false);
            loss.SetActive(true);
       }

        if (transform.position.y <= 5.5f )
        {
            transform.position = new Vector3(0,6,0);
        }
      
       
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) 
        {
           
            dis = true;
            if (dis == true)
            {
              //  camerashake.shake(0.5f, 0.5f);
                particle.SetActive(true);
                effect.Play();
                TakeDamage(1);

            }
            animator.SetBool("hit", true);
            
        }
     
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("hit", false);
           
            dis= false;
            effect.Pause();
            particle.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        


        if (collision.gameObject.CompareTag("Hand"))
        {
            block = true;

            if (block == true)
            {
                Debug.Log("colllided");
                animator.SetBool("hit", false);
                animator.SetBool("Block", true);
                particle.SetActive(false);

               // healthamount -= 1;
            }

           
        }
       

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            block = false;
           
            animator.SetBool("Block", false);
            particle.SetActive(true);
            StartCoroutine(blocktime());
        }
           
    }
    IEnumerator blocktime()
    {
        yield return new WaitForSeconds(2);
      
    }

    void TakeDamage(int damage)
    {
        currenthealth -= damage;
        health.Sethealth(currenthealth);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackdistance);
    }
}
