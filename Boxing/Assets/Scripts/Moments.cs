
using UnityEngine;

public class Moments : MonoBehaviour
{
    public ParticleSystem ps;
    public int maxhealth = 30;
    public int currenthealth;
  
    public healthbar healthbar;
    public Enemy enemyscript;

    public GameObject win;
   
    void Start()
    {
        currenthealth = maxhealth;

        healthbar.Setmaxhealth(maxhealth);
        
    }

    
    void Update()
    {
        if (currenthealth ==0)
        {
           enemyscript.animator.Play("knockout");
            win .SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bag"))
        {
           
            ps.Play();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Attacked");
            ps.Play();
            TakeDamage(1);
        }
     
    }
    void TakeDamage(int damage)
    {
        currenthealth -= damage;
        healthbar.Sethealth(currenthealth);
    }
}
