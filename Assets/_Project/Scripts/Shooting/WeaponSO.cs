using Spounka.Core.DataTypes;
using UnityEngine;

namespace Spounka.Shooting
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Weapon")]
    public class WeaponSO : ScriptableObject
    {
        public BulletSO bulletSo;
        public Sprite weaponSprite;
        public VariableReference<float> fireRate;
        public VariableReference<float> spread;
        public VariableReference<int> bulletsShot;
        public AudioClip shootingSound;
    }
}