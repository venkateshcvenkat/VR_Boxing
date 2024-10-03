using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring : MonoBehaviour
{
    public GameObject ringcolider,wall,steps,cube;
   public bool ringbool;
    void Start()
    {
        wall.SetActive(false);
        steps.SetActive(true);
        cube.SetActive(false);
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ringtimer());
            Debug.Log("e");
        }
    }
    IEnumerator ringtimer()
    {
        yield return new WaitForSeconds(5);
        ringcolider.GetComponent<MeshCollider>().enabled = true;
        ringbool = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            wall.SetActive(true);
            steps.SetActive(false);
            cube.SetActive(true);
        }
    }
}
