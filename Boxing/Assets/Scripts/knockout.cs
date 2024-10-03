using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class knockout : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timertext;
    [SerializeField] float remainingtime;

    public GameObject timeout,enemy_health,player_health,playerwintxt,Enenmywintxt,Draw,audiosource,player,maincamera;
    public Enemy enemyscript;
    public ring ringscript;
    void Start()
    {
       maincamera.SetActive(false);
    }

   
    void Update()
    {
        if (ringscript.ringbool == true)
        {

            if (remainingtime > 0)
            {
                remainingtime -= Time.deltaTime;
            }
            else if (remainingtime < 0)
            {
                remainingtime = 0;
                timertext.color = Color.red;
                Debug.Log("GameOver");


                if (enemy_health.GetComponent<Slider>().value > player_health.GetComponent<Slider>().value)
                {
                    Debug.Log("enemywin");
                    timeout.SetActive(true);
                    Enenmywintxt.SetActive(true);
                    enemyscript.animator.Play("Stretch");
                    audiosource.GetComponent<AudioSource>().Pause();
                    player.SetActive(false);
                    maincamera.SetActive(true);

                }

                if (enemy_health.GetComponent<Slider>().value < player_health.GetComponent<Slider>().value)
                {
                    Debug.Log("playerwin");
                    timeout.SetActive(true);
                    playerwintxt.SetActive(true);
                    enemyscript.animator.Play("loose");
                }
                if (enemy_health.GetComponent<Slider>().value == player_health.GetComponent<Slider>().value)
                {
                    Debug.Log("Draw");
                    timeout.SetActive(true);
                    Draw.SetActive(true);

                }
            }


            int minutes = Mathf.FloorToInt(remainingtime / 60);
            int seconds = Mathf.FloorToInt(remainingtime % 60);

            timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
   
}
