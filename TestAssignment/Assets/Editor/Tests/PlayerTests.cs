using NUnit.Framework;
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
            var player = new PlayerModel(0);

            player.Hp = hp;

            Assert.AreEqual(player.Hp, hp, float.Epsilon);
        }

        [Test]
        public void SetHp_IsNegative_Zero()
        {
            var player = new PlayerModel(0);
            var hp = -1f;

            player.Hp = hp;

            Assert.AreEqual(player.Hp, 0f);
        }

        [TestCase(0.5f)]
        [TestCase(10f)]
        public void Damage_Normal_HpIsTheDifference(float damage)
        {
            var player = new PlayerModel(0);
            var hp = 100f;
            player.Hp = hp;

            player.ApplyDamage(damage);

            Assert.AreEqual(player.Hp, hp - damage, float.Epsilon);
        }

        [Test]
        public void Damage_DamageMoreThanHp_HpIsZero()
        {
            var player = new PlayerModel(0);
            var hp = 10f;
            var damage = 100f;
            player.Hp = hp;

            player.ApplyDamage(damage);

            Assert.AreEqual(player.Hp, 0f);
        }

        [Test]
        public void Damage_DamageIsNegative_HpIsTheSame()
        {
            var player = new PlayerModel(0);
            var hp = 10f;
            var damage = -100f;
            player.Hp = hp;

            player.ApplyDamage(damage);

            Assert.AreEqual(player.Hp, hp);
        }

        [TestCase(0f)]
        [TestCase(1f)]
        [TestCase(2.5637f)]
        [TestCase(999f)]
        public void SetArmor_IsNormal_AreEqual(float armor)
        {
            var player = new PlayerModel(0);

            player.Armor = armor;

            Assert.AreEqual(player.Armor, armor, float.Epsilon);
        }

        [Test]
        public void SetArmor_IsNegative_Zero()
        {
            var player = new PlayerModel(0);
            var armor = -1f;

            player.Armor = armor;

            Assert.AreEqual(player.Armor, 0f);
        }

        [Test]
        public void Armor_SetMaxArmorAndDamage_HpDoesNotChange()
        {
            var player = new PlayerModel(0);
            var hp = 100f;
            var armor = 100f;
            var damage = 50f;
            player.Hp = hp;
            player.Armor = armor;

            player.ApplyDamage(damage);

            Assert.AreEqual(player.Hp, hp);
        }

        [TestCase(80f, 50f, 50f, 55f)]
        [TestCase(80f, 50f, 30f, 65f)]
        [TestCase(80f, 25f, 120f, 0f)]
        public void Armor_SetSomeArmorAndDamage_HpChangesFromPercents(float hp, float armor, float damage, float expectedHp)
        {
            var player = new PlayerModel(0);
            player.Hp = hp;
            player.Armor = armor;

            player.ApplyDamage(damage);

            Assert.AreEqual(player.Hp, expectedHp, float.Epsilon);
        }

        [Test]
        public void Hp_PlusMinusHp_HpDeducted()
        {
            var player = new PlayerModel(0);
            player.Hp = 10f;

            player.Hp += -5f;

            Assert.AreEqual(player.Hp, 5f, float.Epsilon);
        }
    }
}