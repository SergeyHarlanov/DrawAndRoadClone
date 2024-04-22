using DG.Tweening;
using UnityEngine;

namespace Players
{
    public class WhitePlayer : Player
    {
           [SerializeField] private GameObject effect;
            [SerializeField] private GameObject effectToGroup;
            [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;

            private bool _inGroup;
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
            }
        
            public override void SetPlayerToGroup()
            {
                if (_inGroup)
                {
                    return;
                }
                _skinnedMeshRenderer.materials[0].DOColor(Color.green, 0.2f);
                
                _movingPlayers.AddPlayer(this);
                effectToGroup.gameObject.SetActive(true);
                Destroy(GetComponent<Rigidbody>());
                _inGroup = true;
            }
           
    }
}