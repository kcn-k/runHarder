using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerMovement player;
    private Vector3 playerStartpoint;

    private PlatformRemover[] platformList;

    private ScoreManager scoreMan;

    public DeathMenu deathMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartpoint = player.transform.position;

        scoreMan = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartGame(){
        scoreMan.scoreRise = false;
        player.gameObject.SetActive(false);

        deathMenu.gameObject.SetActive(true);
        //StartCoroutine("restartGameCo");
    }

    public void reset(){
        deathMenu.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformRemover>();
        for (int i = 0; i<platformList.Length; i++){
            platformList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartpoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);
        scoreMan.scoreCount = 0;
        scoreMan.scoreRise = true;
    }

    /*public IEnumerator restartGameCo(){
        scoreMan.scoreRise = false;
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformRemover>();
        for (int i = 0; i<platformList.Length; i++){
            platformList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartpoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);
        scoreMan.scoreCount = 0;
        scoreMan.scoreRise = true;
    }*/
}
