using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class HealthSystem {

        public event EventHandler OnHealthChanged;
        public event EventHandler OnDead;

        private float healthMax;
        private float health;

        public HealthSystem(float healthMax) {
            this.healthMax = healthMax;
            health = healthMax;
        }
        
        public float GetHealthPercent() {
            return (float)health / healthMax;
        }

        public void Damage(float amount) {
            health -= amount;
            if (health < 0) {
                health = 0;
            }
            if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);

            if (health <= 0) {
                Die();
            }
        }

        public void Die() {
            if (OnDead != null) OnDead(this, EventArgs.Empty);
        }

        public void Heal(float amount) {
            health += amount;
            if (health > healthMax) {
                health = healthMax;
            }
            if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
        }

    }

