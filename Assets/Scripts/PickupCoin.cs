using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    public int scoreToGive;

    private ScoreManager scoreMan;

    private AudioSource coinsfx;

    // Start is called before the first frame update
    void Start()
    {
        scoreMan = FindObjectOfType<ScoreManager>();
        coinsfx = GameObject.Find("Coinsfx").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Character"){
            scoreMan.addScore(scoreToGive);
            gameObject.SetActive(false);
            if(coinsfx.isPlaying){
                coinsfx.Stop();
                coinsfx.Play();
            }else{
                coinsfx.Play();
            }
        }
    }
}
