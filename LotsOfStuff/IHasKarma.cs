namespace Aula12
{
    /// <summary>
    /// Esta interface define algo que tem karma
    /// </summary>
    public interface IHasKarma
    {
        /// <summary>
        /// O karma, positivo ou negativo
        /// </summary>
        float Karma { get; }
    }
}
