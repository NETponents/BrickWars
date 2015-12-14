using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockWars
{
    /// <summary>
    /// Base class for player weapons.
    /// </summary>
    public abstract class Weapon
    {
        protected string name;
        protected float damage;

        /// <summary>
        /// Default constructor for weapon class.
        /// </summary>
        public Weapon()
        {

        }
        /// <summary>
        /// Gets amount of damage dealt by weapon in a single shot.
        /// </summary>
        /// <returns>Raw damage dealt.</returns>
        public float getDamage()
        {
            return damage;
        }
        /// <summary>
        /// Gets name of weapon.
        /// </summary>
        /// <returns>Weapon name.</returns>
        public string getName()
        {
            return name;
        }
    }
}
