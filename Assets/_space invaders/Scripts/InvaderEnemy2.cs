
    using System;
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class InvaderEnemy2:InvaderEnemy
    {
        [SerializeField] private SpriteRenderer[] _spriteRenderers;
        [SerializeField] private Color nearlyDeadColor;

      

        public override void Damage(int amount)
        {
            base.Damage(amount);
            if (health <= 1)
            {
                foreach (var spriteRenderer in _spriteRenderers)
                {
                    spriteRenderer.color = nearlyDeadColor;
                }
            }
            else
            {
                foreach (var spriteRenderer in _spriteRenderers)
                {
                    spriteRenderer.color =Color.white;
                }
            }
        }
    }
