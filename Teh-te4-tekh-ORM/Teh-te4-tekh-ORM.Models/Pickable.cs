namespace Teh_te4_tekh_ORM.Models
{
    public enum EffectType
    {
        Health,
        Sight,
        Strength,
        Speed
    }

    /// <summary>
    /// Class for game objects that can be "picked" up and can provide some bonus.
    /// </summary>
    public class Collectable
    {
        public int Id { get; set; }

        /// <summary>
        /// The value which will be used to apply an effect (bonus).
        /// </summary>
        public float Value { get; set; }

        /// <summary>
        /// Type of effect (bonus) to be applied.
        /// </summary>
        public EffectType Type { get; set; }
    }
}
