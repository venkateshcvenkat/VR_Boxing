using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    public GameObject career, settings;
    public AudioSource sound;
    public AudioClip clip1,clip2,clip3,clip4;
    public Slider slider1,slider2,slider3;
    void Start()
    {
        career.SetActive(false);
        settings.SetActive(false);
    }

   
    void Update()
    {
        
    }
    public void playbutton()
    {
        sound.PlayOneShot(clip1);
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        sound.PlayOneShot(clip1);
        Application.Quit();
    }
    public void carer()
    {
        sound.PlayOneShot(clip1);
        career.SetActive(true);
        settings.SetActive(false);
    }
    public void setg()
    {
        sound.PlayOneShot(clip1);
        career.SetActive(false);
        settings.SetActive(true);
    }
    public void close1()
    {
        sound.PlayOneShot(clip2);
        career.SetActive(false);
    }
    public void close2()
    {
        sound.PlayOneShot(clip2);
        settings.SetActive(false);
    }
    public void slider()
    {
       
            sound.PlayOneShot(clip3);
       
    }
}
