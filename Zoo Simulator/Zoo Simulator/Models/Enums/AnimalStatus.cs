namespace Zoo_Simulator.Models.Enums
{
    /// <summary>
    /// Contains the states for animals
    /// </summary>
    public enum AnimalStatus
    {
        /// <summary>
        /// For when the animal is dead
        /// </summary>
        Dead = 0,

        /// <summary>
        /// For when the animal is dying
        /// </summary>
        Dying = 1,

        /// <summary>
        /// For when the animal is idle
        /// </summary>
        Idle = 2,

        /// <summary>
        /// For when the animal is satisfied
        /// </summary>
        Satisfied = 3,

        /// <summary>
        /// For when the animal is happy
        /// </summary>
        Happy = 4,

        /// <summary>
        /// For when the animal is sad
        /// </summary>
        Sad = 5,

        /// <summary>
        /// For when the animal is hungry
        /// </summary>
        Hungry = 6,

        /// <summary>
        /// For when the animal is starving
        /// </summary>
        Starving = 7,

        /// <summary>
        /// For when the animal is eating
        /// </summary>
        Eating = 8,

        /// <summary>
        /// For when the animal is socialising
        /// </summary>
        Socialising = 9,

        /// <summary>
        /// For when the animal is moving
        /// </summary>
        Moving = 10,

        /// <summary>
        /// For when the animal is unable to move
        /// </summary>
        UnableToMove = 11
    }
}
