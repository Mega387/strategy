using UnityEngine;

namespace _Source.Enemy
{
    public class MeleeEnemy : Enemy
    {
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }
        protected override void PerformAttackPattern()
        {
            if (anim != null)
            {

                anim.SetTrigger("EnemyAttack1");
            }
        }
        protected override void PlayIdleAnimation()
        {
            base.PlayIdleAnimation();
            if (anim != null)
            {
                anim.SetBool("Idle", true);
            }
        }

        public override void Deactivate()
        {
            if (anim != null)
            {
                anim.SetBool("Idle", false);
            }


            base.Deactivate();
        }
    }
}
