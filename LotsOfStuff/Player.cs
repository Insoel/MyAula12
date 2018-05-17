namespace Aula12
{
    /// <summary>
    /// Esta classe representa um jogador num jogo
    /// </summary>
    public class Player : IHasWeight
    {

        /// <summary>
        /// Máximo de items na mochila (variável de classe, constante,
        /// implicitamente static)
        /// </summary>
        private const int maxBagItems = 10;

        /// <summary>
        /// Peso base do jogador (variável de instância, read-only)
        /// </summary>
        private readonly float baseWeight;

        /// <summary>
        /// Mochila de itens do jogador (variável de instância)
        /// </summary>
        public Bag BagOfStuff { get; }

        /// <summary>
        /// Propriedade Weight respeita o contrato com IHasWeight
        /// </summary>
        public float Weight {
            get
            {
                // Seria porreiro adicionar o peso de todas as coisas no saco
                return baseWeight + BagOfStuff.Weight;
            }
        }

        /// <summary>
        /// Propriedade Karma, respeita o contrato com IHasKarma
        /// </summary>
        public float Karma
        {
            get
            {
                return BagOfStuff.Karma;
            }
        }

        /// <summary>Construtor, cria nova instância de jogador</summary>
        /// <param name="baseWeight">Peso base do jogador</param>
        public Player(float baseWeight)
        {
            this.baseWeight = baseWeight;
            BagOfStuff = new Bag(maxBagItems);
        }

        /// <summary>
        /// Sobreposição do método ToString() para a classe Player.
        /// </summary>
        /// <returns>
        /// Uma string contendo informação acerca do Player.
        /// </returns>
        public override string ToString()
        {
            return $"Player tem peso total de {Weight:f2} Kg, incluindo uma " + 
                $"mochila com {BagOfStuff.Count} itens, responsável por " +
                $"{(BagOfStuff.Weight / Weight):p} do peso total " +
                $"(karma={Karma:f2})";
        }
    }
}
