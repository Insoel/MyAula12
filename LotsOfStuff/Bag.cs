using System;
using System.Collections.Generic;

namespace Aula12
{
    /// <summary>
    /// Classe que representa uma mochila ou saco que contem itens
    /// </summary>
    public class Bag : List<IStuff>, IStuff, IHasKarma
    {

        /// <summary> 
        /// Propriedade Weight respeita o contrato com IHasWeight. No caso do
        /// Bag o peso vai corresponder ao peso total dos itens.
        /// </summary>
        public float Weight
        {
            get
            {
                float totalWeight = 0;
                foreach (IStuff aThing in this)
                {
                    totalWeight += aThing.Weight;
                }
                return totalWeight;
            }
        }

        /// <summary> 
        /// Propriedade Value respeita o contrato com IValuable. No caso do
        /// Bag o valor vai corresponder ao valor total dos itens.
        /// </summary>
        public float Value
        {
            get
            {
                float totalValue = 0;
                foreach (IStuff aThing in this)
                {
                    totalValue += aThing.Value;
                }
                return totalValue;
            }
        }

        /// <summary>
        /// Propriedade Karma, respeita o contrato com IHasKarma
        /// </summary>
        public float Karma
        {
            get
            {
                float totalKarma = 0;
                foreach (IStuff aThing in this)
                {
                    if (aThing is IHasKarma)
                    {
                        totalKarma += (aThing as IHasKarma).Karma;
                    }
                }
                return Count > 0 ? totalKarma / Count : 0;
            }
        }

        /// <summary>
        /// Construtor que cria uma nova instância de mochila
        /// </summary>
        /// <param name="bagSize">
        /// Número inicial de itens que é possível colocar na mochila
        /// </param>
        public Bag(int bagSize) : base(bagSize) { }

        /// <summary>
        /// Sobreposição do método ToString() para a classe Bag.
        /// </summary>
        /// <returns>
        /// Uma string contendo informação sobre a mochila e os seus conteúdos.
        /// </returns>
        public override string ToString()
        {
            return $"Mochila com {Count} itens e um peso e valor " +
                $"totais de {Weight:f2} Kg e {Value:c}, respetivamente " +
                $"(karma={Karma:f2})";
        }

        public bool ContainsItemOfType<T>()
            where T : IStuff
        {
            foreach (IStuff cena in this)
            {
                if (cena is T)
                    return true;
            }
            return false;
        }

        public IEnumerable<T> GetItemsOfType<T>()
            where T : class, IStuff
        {
            List<T> items = new List<T>();
            foreach (IStuff cena in this)
            {
                if (cena is T)
                    items.Add(cena as T);
            }
            return items;
        }

        public IEnumerable<T> BetterGetItemsOfType<T>()
            where T : class, IStuff
        {
            foreach (IStuff cena in this)
            {
                if (cena is T)
                {
                    yield return cena as T;
                }
            }
        }

        public void GetHeavier1(out Food food, out Gun gun)
        {
            food = null; gun = null;
            foreach (IStuff stuff in this)
            {
                if (stuff is Food)
                {
                    if ((food == null) || (stuff.Weight > food.Weight))
                    {
                        food = stuff as Food;
                    }
                }
                else if (stuff is Gun)
                {
                    if ((gun == null) || (stuff.Weight > gun.Weight))
                    {
                        gun = stuff as Gun;
                    }
                }
            }
        }

        public FoodAndGun GetHeavier2()
        {
            Food food = null;
            Gun gun = null;

            foreach (IStuff stuff in this)
            {
                if (stuff is Food)
                {
                    if ((food == null) || (stuff.Weight > food.Weight))
                    {
                        food = stuff as Food;
                    }
                }
                else if (stuff is Gun)
                {
                    if ((gun == null) || (stuff.Weight > gun.Weight))
                    {
                        gun = stuff as Gun;
                    }
                }
            }
            return new FoodAndGun(food, gun);
        }

        public Tuple <Food, Gun> GetHeavier3()
        {
            Food food = null;
            Gun gun = null;

            foreach (IStuff stuff in this)
            {
                if (stuff is Food)
                {
                    if ((food == null) || (stuff.Weight > food.Weight))
                    {
                        food = stuff as Food;
                    }
                }
                else if (stuff is Gun)
                {
                    if ((gun == null) || (stuff.Weight > gun.Weight))
                    {
                        gun = stuff as Gun;
                    }
                }
            }
            return new Tuple<Food, Gun>(food, gun);
        }

        public IEnumerable<string> GetStrings()
        {
            foreach (IStuff stuff in this)
            {
                yield return stuff.ToString();
            }
        }
    }
}
