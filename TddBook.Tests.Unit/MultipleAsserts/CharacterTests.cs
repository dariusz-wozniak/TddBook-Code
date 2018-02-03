using NUnit.Framework;
using TddBook.FantasyWorld;

namespace TddBook.Tests.Unit.MultipleAsserts
{
    public class CharacterTests
    {
        #region Scenario 1: Single expected output:

        [Test]
        public void when_character_is_dead_then_the_is_alive_flag_is_false_and_death_year_is_assigned()
        {
            var gollum = new Character();

            gollum.Death(inYear: 3019);

            Assert.That(gollum.IsAlive, Is.False);
            Assert.That(gollum.DeathYear, Is.EqualTo(3019));
        }

        [Test]
        public void when_character_is_dead_then_the_is_alive_flag_is_false()
        {
            var gollum = new Character();

            gollum.Death(inYear: 3019);

            Assert.That(gollum.IsAlive, Is.False);
        }

        [Test]
        public void when_character_is_dead_then_death_year_is_assigned()
        {
            var gollum = new Character();

            gollum.Death(inYear: 3019);

            Assert.That(gollum.DeathYear, Is.EqualTo(3019));
        }

        #endregion

        #region Scenario 2: Indirect asserts:

        [Test]
        public void when_character_had_two_items_and_dropped_one_then_it_is_removed_from_items()
        {
            var gollum = new Character();

            gollum.PickUp("ring");
            gollum.PickUp("stick");
            gollum.Drop("ring");

            Assert.That(gollum.Items, Has.Count.EqualTo(1).And.Exactly(1).Matches<Item>(item => item.Name == "stick"));
        }

        [Test]
        public void when_character_had_two_items_and_dropped_one_then_it_is_removed_from_items__indirect_assertions()
        {
            var gollum = new Character();

            Assert.That(gollum.Items, Is.Not.Null.And.Empty);

            gollum.PickUp("ring");

            Assert.That(gollum.Items, Has.Count.EqualTo(1).And.Exactly(1).Matches<Item>(item => item.Name == "ring"));

            gollum.PickUp("stick");

            Assert.That(gollum.Items, Has.Count.EqualTo(2).
                And.Exactly(1).Matches<Item>(item => item.Name == "ring").
                And.Exactly(1).Matches<Item>(item => item.Name == "stick"));

            gollum.Drop("ring");

            Assert.That(gollum.Items, Has.Count.EqualTo(1).And.Exactly(1).Matches<Item>(item => item.Name == "stick"));
        }

        [Test]
        public void when_character_is_initialised_then_the_items_collection_is_empty()
        {
            var gollum = new Character();

            Assert.That(gollum.Items, Is.Not.Null.And.Empty);
        }

        [Test]
        public void when_character_picked_up_item_then_it_is_in_items_collection()
        {
            var gollum = new Character();

            gollum.PickUp("ring");

            Assert.That(gollum.Items, Has.Count.EqualTo(1).And.Exactly(1).Matches<Item>(item => item.Name == "ring"));
        }

        [Test]
        public void when_character_picked_up_two_items_then_both_of_them_are_in_items()
        {
            var gollum = new Character();
            gollum.PickUp("ring");
            gollum.PickUp("stick");

            Assert.That(gollum.Items, Has.Count.EqualTo(2).
                And.Exactly(1).Matches<Item>(item => item.Name == "ring").
                And.Exactly(1).Matches<Item>(item => item.Name == "stick"));
        }

        [Test]
        public void when_character_had_two_items_and_dropped_one_then_it_is_removed_from_items__with_single_assertion()
        {
            var gollum = new Character();

            gollum.PickUp("ring");
            gollum.PickUp("stick");
            gollum.Drop("ring");

            Assert.That(gollum.Items, Has.Count.EqualTo(1).And.Exactly(1).Matches<Item>(item => item.Name == "stick"));
        }

        #endregion

        #region Scenario 3: Multiple.Assert:

        [Test]
        public void when_character_had_two_items_and_dropped_one_then_it_is_removed_from_items__assert_multiple()
        {
            var gollum = new Character();

            gollum.PickUp("ring");
            gollum.PickUp("stick");
            gollum.Drop("ring");

            Assert.Multiple(() =>
            {
                Assert.That(gollum.Items, Has.Count.EqualTo(1));
                Assert.That(gollum.Items, Has.Exactly(1).Matches<Item>(item => item.Name == "stick"));
            });
        }

        [Test]
        [Explicit("The test was created to demonstrate Assert.Multiple functionality on multiple failed assertions")]
        public void when_character_had_two_items_and_dropped_one_then_it_is_removed_from_items__assert_multiple_and_failing_one()
        {
            var gollum = new Character();

            gollum.PickUp("ring");
            gollum.PickUp("stick");
            gollum.Drop("ring");

            // These are all red:
            Assert.Multiple(() =>
            {
                Assert.That(gollum.Items, Is.Null);
                Assert.That(gollum.Items, Is.Empty);
                Assert.That(gollum.Items, Has.Count.EqualTo(2));
            });
        }


        #endregion
    }
}
