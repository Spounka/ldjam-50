using Spounka.Core.DataTypes;
using UnityEngine;

namespace Spounka
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Weapons/Bullet")]
    public class BulletSO : ScriptableObject
    {
        public Sprite bulletSprite;
        public VariableReference<float> bulletSpeed;
        public VariableReference<float> bulletDamage;
        public VariableReference<float> bulletLifeTime;
    }
}