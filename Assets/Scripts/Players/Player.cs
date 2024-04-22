
    using System;
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        protected MovingPlayers _movingPlayers;
        
        protected bool _run;
        protected bool _dead;

        protected Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public virtual void SetPlayerToGroup()
        {
        }

        public void SetMovingPlayer(MovingPlayers movingPlayers)
        {
            _movingPlayers = movingPlayers;
        }
    }
