using UnityEngine;

namespace _Source.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        public virtual void Activate()
        {
            gameObject.SetActive(true);
            DoTemplateBehaviour();
        }
        
        public void DoTemplateBehaviour()
        {
            PlaySpawnAnimation();
            PerformAttackPattern();
            PlayIdleAnimation();
        }
        
        protected virtual void PlaySpawnAnimation()
        {
            Debug.Log($"{gameObject.name} появился");
        }
        
        protected abstract void PerformAttackPattern();
        
        protected virtual void PlayIdleAnimation()
        {
            Debug.Log($"{gameObject.name} стоит");
        }
        
        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}