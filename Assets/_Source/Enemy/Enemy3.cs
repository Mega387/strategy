using _Source.Script;
using UnityEngine;

namespace _Source.Enemy
{
    public class MimicEnemy : Enemy
    {
        private Animator anim;
        private AttackPerformer playerAttackperformer;


        private void Awake()
        {


            anim = GetComponent<Animator>();
            playerAttackperformer = FindObjectOfType<AttackPerformer>();
        }

        protected override void PerformAttackPattern()
        {
        
            if (playerAttackperformer != null)
            {

                playerAttackperformer.OnAttackStarted += OnPlayerAttack;
                playerAttackperformer.OnAttackEnded += OnPlayerIdle;
            }
        }
        private void OnPlayerAttack()
        {
            if (anim != null)
            {
                anim.SetTrigger("EnemyAttack3");
            }
        }

        private void OnPlayerIdle()
        {
            if (anim != null)
            {
                anim.SetTrigger("Idle");
            }
        }
        public override void Deactivate()
        {
            if (playerAttackperformer != null)
            {
                playerAttackperformer.OnAttackStarted -= OnPlayerAttack;
                playerAttackperformer.OnAttackEnded -= OnPlayerIdle;

            }
            base.Deactivate();


        }
    }
}
