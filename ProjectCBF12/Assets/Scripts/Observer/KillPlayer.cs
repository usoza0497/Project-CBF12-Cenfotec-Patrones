using ReflectionFactory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class KillPlayer : MonoBehaviour //Es el Observador del Sujeto TimerLeft
{
    [SerializeField] private GameObject player;
    [SerializeField] public TimerLeft timer{get; private set;}
    public void Start(){
        Awake();
    }
    private void Awake(){
    timer = FindObjectOfType<TimerLeft>();
    Debug.Log(timer);
    if(timer != null){
        timer.TimeOut += PlayerKill;
    }
    }
    private void PlayerKill(){
       player.GetComponent<PlayerController>().playerDead();
    }
}


