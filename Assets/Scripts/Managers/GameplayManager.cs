using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameplayManager : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject overScreen;
    private float timer = 0f;
    private float endTime = 5f;
    private bool countingDown = false;
    public void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) EndGame();
        
    }

    public void EndGame()
    {
        endScreen.SetActive(true);
        countingDown = true;
    }

    public void OnDeath()
    {
        overScreen.SetActive(true);
        countingDown = true;
    }
    public void Update()
    {
        //if chamber is active,
        //MonitorChamber();
        //else, do nothing (that I can think of...)

        if(countingDown)
        {
            timer += Time.deltaTime;
            if(timer > endTime)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void sessionStart(int floor, int chamber)
    {
        //if floor, chamber == 0, start new game and load first floor
        //else, load specified floor.
        //LoadFloor(floor); //Loads current floor scene.

        //LoadCharacter(); //Will create blank character if no character save exists
        //GenerateChamber(); //Generates chamber based on current floor and chamber. 
        //ChamberStart(); //Enables gameplay in the current chamber.
    }

    public void ChamberStart()
    {
        //Places character in chamber via animation, then starts combat.
    }

    public void MonitorChamber()
    {
        //Monitor player progress of objective, updating UI via UI manager as needed.
        //When Objective completed, open exit.
        //On entering exit trigger:
        //ChamberEnd();

        //TODO This is bad, implement observer pattern.
    }

    public void ChamberEnd()
    {
        //Removes player from room, checks if last chamber finished. If so,
        //LoadFloor(floor + 1);
        //if not, generates new chamber, and cycles to it via animation.
        //GenerateChamber()
        //ChamberStart()
    }
}
