using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Target : MonoBehaviour
    {
        public float health = 100f;
        //public float damage = 10f;

        public void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            Destroy(gameObject);
        }

    }
}
