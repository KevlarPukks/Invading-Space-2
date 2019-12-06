
    using UnityEngine;

    public class EnemyDamage2:EnemyDamage
    {
          [SerializeField] private SpriteRenderer[] _spriteRenderers;
                        [SerializeField] private Color nearlyDeadColor;
                
                      
                
                        public override void TakeDamage(int amount)
                        {
                            base.TakeDamage(amount);
                            if (enemy.health <= 1)
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
