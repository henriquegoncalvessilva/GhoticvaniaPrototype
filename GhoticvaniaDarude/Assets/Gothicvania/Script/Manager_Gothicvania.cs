using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Gothicvania : MonoBehaviour
{
    //Singleton
    static public Manager_Gothicvania _instance;

    [SerializeField] float speedCamFollow;
    [SerializeField] Transform mainCam;
    [SerializeField] bool followPlayer;
    [SerializeField] Transform player;
    [SerializeField] GameObject cinematicGO;
    [SerializeField] GameObject bossLevel;

    private void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
        }

        

    }

    private void Start()
    {
        Player_Gothicvania._instance.ActionPlayer(false);
    }

    public void StartGame()
    {
        Player_Gothicvania._instance.ActionPlayer(true);

    }

    public void PlayCinematic(bool value)
    {
        cinematicGO.SetActive(value);
        Player_Gothicvania._instance.ActionPlayer(false);
        followPlayer = false;

    }

    void FixedUpdate()
    {

        CamFollow(followPlayer);

        //Play Cinematic
        if (!followPlayer)
        {
            this.gameObject.transform.position = Vector3.Lerp(this.transform.position, new Vector3(10f, transform.position.y, transform.position.z), speedCamFollow * Time.deltaTime);
            bossLevel.SetActive(true);

        }

    }

    public void RestartGame(int value)
    {
        SceneManager.LoadScene(value);
    }

    private void CamFollow(bool value)
    {

        if (value)
        {
            mainCam.gameObject.transform.position = Vector3.Lerp(new Vector3(mainCam.position.x, 0.44f, -7.27f), new Vector3(player.position.x, 0.44f, -7.27f), speedCamFollow * Time.deltaTime);
        }
    }
}
