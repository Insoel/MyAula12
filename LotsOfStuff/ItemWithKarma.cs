using System;

namespace Aula12
{
    /// <summary>
    /// Classe abstrata que representa um item com karma
    /// </summary>
    public abstract class ItemWithKarma : IHasKarma
    {

        /// <summary>
        /// Gerador de números aleatórios que pertence à classe ItemWithKarma.
        /// Todas as instâncias desta classe vão usar este gerador.
        /// </summary>
        private static Random rng = new Random();

        /// <summary>
        /// O karma, positivo ou negativo, do item.
        /// </summary>
        public virtual float Karma { get; }

        /// <summary>
        /// Construtor que inicializa o Karma com um valor entre -10.0f e 10.0f
        /// </summary>
        public ItemWithKarma()
        {
            Karma = (float)(10 * (rng.NextDouble() - 0.5));
        }

        /// <summary>
        /// Construtor que inicializa o Karma com um valor específico
        /// </summary>
        /// <param name="karma">Karma do item</param>
        public ItemWithKarma(float karma)
        {
            Karma = karma;
        }
    }
}
