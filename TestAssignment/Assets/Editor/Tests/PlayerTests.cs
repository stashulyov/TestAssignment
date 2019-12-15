﻿using NUnit.Framework;
using Players;

namespace Tests
{
    public class PlayerTests
    {
        [TestCase(0f)]
        [TestCase(1f)]
        [TestCase(2.5637f)]
        [TestCase(999f)]
        public void SetHp_IsNormal_AreEqual(float hp)
        {
            var player = new PlayerModel();

            player.SetHp(hp);

            Assert.AreEqual(player.Hp, hp, float.Epsilon);
        }

        [Test]
        public void SetHp_IsNegative_Zero()
        {
            var player = new PlayerModel();
            var hp = -1f;

            player.SetHp(hp);

            Assert.AreEqual(player.Hp, 0f);
        }

        [TestCase(0.5f)]
        [TestCase(10f)]
        public void Damage_Normal_HpIsTheDifference(float damage)
        {
            var player = new PlayerModel();
            var hp = 100f;
            player.SetHp(hp);

            player.Attack(damage);

            Assert.AreEqual(player.Hp, hp - damage, float.Epsilon);
        }

        [Test]
        public void Damage_DamageMoreThanHp_HpIsZero()
        {
            var player = new PlayerModel();
            var hp = 10f;
            var damage = 100f;
            player.SetHp(hp);

            player.Attack(damage);

            Assert.AreEqual(player.Hp, 0f);
        }

        [Test]
        public void Damage_DamageIsNegative_HpIsTheSame()
        {
            var player = new PlayerModel();
            var hp = 10f;
            var damage = -100f;
            player.SetHp(hp);

            player.Attack(damage);

            Assert.AreEqual(player.Hp, hp);
        }

        [TestCase(0f)]
        [TestCase(1f)]
        [TestCase(2.5637f)]
        [TestCase(999f)]
        public void SetArmor_IsNormal_AreEqual(float armor)
        {
            var player = new PlayerModel();

            player.SetArmor(armor);

            Assert.AreEqual(player.Armor, armor, float.Epsilon);
        }

        [Test]
        public void SetArmor_IsNegative_Zero()
        {
            var player = new PlayerModel();
            var armor = -1f;

            player.SetArmor(armor);

            Assert.AreEqual(player.Armor, 0f);
        }

        [Test]
        public void Armor_SetMaxArmorAndDamage_HpDoesNotChange()
        {
            var player = new PlayerModel();
            var hp = 100f;
            var armor = 100f;
            var damage = 50f;
            player.SetHp(hp);
            player.SetArmor(armor);

            player.Attack(damage);

            Assert.AreEqual(player.Hp, hp);
        }

        [TestCase(80f, 50f, 50f, 55f)]
        [TestCase(80f, 50f, 30f, 65f)]
        [TestCase(80f, 25f, 120f, 0f)]
        public void Armor_SetSomeArmorAndDamage_HpChangesFromPercents(float hp, float armor, float damage, float expectedHp)
        {
            var player = new PlayerModel();
            player.SetHp(hp);
            player.SetArmor(armor);

            player.Attack(damage);

            Assert.AreEqual(player.Hp, expectedHp, float.Epsilon);
        }
    }
}