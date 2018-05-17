using System;
using System.Text;

namespace Aula12
{
    /// <summary>
    /// Programa para testar o projeto
    /// </summary>
    public class Program
    {
        /// <summary>O programa começa aqui no Main</summary>
        /// <param name="args">
        /// Argumentos de linha de comandos (são ignorados neste programa)
        /// </param>
        public static void Main(string[] args)
        {
            // Criar uma nova instância de Program e
            // invocar o método TestProjet na instância criada
            Program prog = new Program();

            // Especificar UTF-8 como codificação de saída
            Console.OutputEncoding = Encoding.UTF8;

            // Testar o projeto
            prog.TestProject();
        }

        /// <summary>Método que testa este projeto</summary>
        private void TestProject()
        {
            // Variáveis usadas neste método
            Player p;
            Bag extraBag;

            //
            // Instanciar um jogador com 70 quilos e adicionar
            // vários itens à sua mochila
            //
            p = new Player(70.0f);

            // Ver informação sobre jogador antes de serem adicionados itens à
            // mochila
            Console.WriteLine(p);

            // Pão com 2 dias, 500 gramas
            p.BagOfStuff.Add(new Food(FoodType.Bread, 2, 0.500f));
            // 300 gramas de vegetais com 5 dias
            p.BagOfStuff.Add(new Food(FoodType.Vegetables, 5, 0.300f));
            // Pistola com 1.5kg + 50 gramas por bala, carregada com 10 balas,
            // com um custo de 250€
            p.BagOfStuff.Add(new Gun(1.5f, 0.050f, 10, 250f));
            // 200 gramas de fruta fresca
            p.BagOfStuff.Add(new Food(FoodType.Fruit, 0, 0.200f));
            // Mais uma arma
            p.BagOfStuff.Add(new Gun(2f, 0.09f, 25, 325f));

            // Instanciar mochila extra (não é a mesma do Player) com
            // espaço para dois itens, e adicionar dois itens à mesma
            extraBag = new Bag(2)
            {
                new Gun(1.1f, 0.03f, 12, 62f),
                new Food(FoodType.Eggs, 4, 0.150f)
            };

            // Adicionar mochila extra à mochila do Player
            p.BagOfStuff.Add(extraBag);

            // Mostrar informação acerca dos conteúdos da mochila do Player
            Console.WriteLine(p.BagOfStuff);

            // Percorrer itens na mochila e tentar "imprimir" cada um
            foreach (IStuff aThing in p.BagOfStuff)
            {
                Console.WriteLine($"\t=> {aThing}");

                // Se item atual for uma arma, disparar a mesma
                if (aThing is Gun)
                {
                    (aThing as Gun).Shoot();
                }
            }

            // Mostrar de novo informação sobre a mochila
            Console.WriteLine(p.BagOfStuff);

            // Ver informação sobre jogador após serem adicionados itens à
            // mochila
            Console.WriteLine(p);
        }
    }
}
