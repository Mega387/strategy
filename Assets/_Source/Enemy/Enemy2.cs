using UnityEngine;

namespace _Source.Enemy
{
    public class RangedEnemy : Enemy
    {

        private Animator anim;
        private bool _isAttacking = false;
    

        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float rateAttack = 1f;



        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        protected override void PerformAttackPattern()
        {
            Debug.Log("Ranged Enemy starts spamming attacks.");
            _isAttacking = true;
            if (gameObject.activeSelf == true)
            {
                InvokeRepeating(nameof(Shoot), 0f, rateAttack);
            }
        }
        private void Shoot()
        {
            if (!gameObject.activeSelf) return;
            
            if (!_isAttacking) return;
            if (projectilePrefab != null && firePoint != null)
            {
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            }
        }

        public override void Deactivate()
        {
            _isAttacking = false;
            CancelInvoke(nameof(Shoot));
            base.Deactivate();

        }
    }
}