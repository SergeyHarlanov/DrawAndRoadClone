using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider))]
public class GreenPlayer : Player
{
    [SerializeField] private GameObject effect;
  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _run = true;
           _animator.Play("Run");
           _animator.SetFloat("RunCycle", Random.Range(0.0f, 0.1f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacles")&& !_dead)
        {
            _dead = true;
            
            _movingPlayers.RemovePlayer(this);
            effect.gameObject.SetActive(true);
        }

        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            
            player.enabled = true;
            player.SetMovingPlayer(_movingPlayers);
            player.SetPlayerToGroup();
        }
    }


  
  
}
