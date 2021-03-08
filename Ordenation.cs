using System;
namespace teste
{
    public class Ordenation
    {

        public int[] Vector;
        private int Size = 10;

        public Ordenation()
        {
            Incluir();
        }

        public int GetSize()
        {
            return Size;
        }

        public void SetSize(int size)
        {
            Size = size;
            Incluir();
        }

        public void Incluir()
        {
            Vector = new int[Size];

            Random random = new Random();

            for (int i = 0; i < Size; i++)
            {
                Vector[i] = random.Next();
            }
        }

        public void BoobleSort()
        {
            for (int i = 0; i < Vector.Length - 1; i++)
            {
                for (int j = 0; j < Vector.Length - 1 - i; j++)
                {
                    if (Vector[j] > Vector[j + 1])
                    {
                        int aux = Vector[j];

                        Vector[j] = Vector[j + 1];

                        Vector[j + 1] = aux;
                    }
                }
            }
        }

        public void MergeSort()
        {
            int elementos = 1;

            int inicio, meio, fim;

            while (elementos < Size)
            {
                inicio = 0;
                while (inicio + elementos < Size)
                {
                    meio = inicio + elementos;
                    fim = inicio + 2 * elementos;
                    if (fim > Size)
                    {
                        fim = Size;
                    }

                    Intercala(Vector, inicio, meio, fim);

                    inicio = fim;
                }
                elementos = elementos * 2;
            }
        }

        private void Intercala(int[] vector, int inicio, int meio, int fim)
        {
            /* Vector utilizado para guardar os valors ordenados. */
            int[] novoVector = new int[fim - inicio];
            /* Variavel utilizada para guardar a posicao do inicio do Vector. */
            int i = inicio;
            /* Variavel utilizada para guardar a posição do meio do Vector. */
            int m = meio;
            /* Variavel utilizada para guarda a posição onde os
              valores serão inseridos no novo Vector. */
            int pos = 0;

            /* Enquanto o inicio não chegar até o meio do Vector, ou o meio do Vector
              não chegar até seu fim, compara os valores entre o inicio e o meio,
              verificando em qual ordem vai guarda-los ordenado.*/
            while (i < meio && m < fim)
            {
                /* Se o Vector[i] for menor que o Vector[m], então guarda o valor do
                  Vector[i] pois este é menor. */
                if (vector[i] <= vector[m])
                {
                    novoVector[pos] = vector[i];
                    pos = pos + 1;
                    i = i + 1;
                    // Senão guarda o valor do Vector[m] pois este é o menor.
                }
                else
                {
                    novoVector[pos] = vector[m];
                    pos = pos + 1;
                    m = m + 1;
                }
            }

            // Adicionar no Vector os elementos que estão entre o inicio e meio,
            // que ainda não foram adicionados no Vector.
            while (i < meio)
            {
                novoVector[pos] = vector[i];
                pos = pos + 1;
                i = i + 1;
            }

            // Adicionar no Vector os elementos que estão entre o meio e o fim,
            // que ainda não foram adicionados no Vector.
            while (m < fim)
            {
                novoVector[pos] = vector[m];
                pos = pos + 1;
                m = m + 1;
            }

            // Coloca no Vector os valores já ordenados.
            for (pos = 0, i = inicio; i < fim; i++, pos++)
            {
                vector[i] = novoVector[pos];
            }

        }

        public void MergeSortRecursivo(int inicio, int fim)
        {
            /* Se o inicio for menor que o fim menos 1, significa que tem elementos
                  dentro do Vector. */
            if (inicio < fim - 1)
            {
                // Guarda a posição do meio do Vector.
                int meio = (inicio + fim) / 2;

                /* Chama este método recursivamente, indicando novas posições do
                        inicio e fim do Vector. */
                MergeSortRecursivo(inicio, meio);

                /* Chama este método recursivamente, indicando novas posições do
                        inicio e fim do Vector. */
                MergeSortRecursivo(meio, fim);

                // Chama o método que intercala os elementos do Vector.
                Intercala(Vector, inicio, meio, fim);

            }

        }
        public void QuickSort(int inicio, int fim)
        {
            if (fim > inicio)
            {
                //Chamada da rotina que ira dividir o Vector em 3 partes.
                int indexPivo = Dividir(Vector, inicio, fim);
                /* Chamada recursiva para redivisao do Vector de elementos menores
                  que o pivô. */
                QuickSort(inicio, indexPivo - 1);
                /* Chamada recursiva para redivisao do Vector de elementos maiores
                  que o pivô. */
                QuickSort(indexPivo + 1, fim);
            }

        }

        private int Dividir(int[] Vector, int inicio, int fim)
        {

            int pivo, pontEsq, pontDir = fim;
            pontEsq = inicio + 1;
            pivo = Vector[inicio];

            while (pontEsq <= pontDir)
            {
                /* Vai correr o Vector ate que ultrapasse o outro ponteiro
                  ou ate que o elemento em questão seja menor que o pivô. */
                while (pontEsq <= pontDir && Vector[pontEsq] <= pivo)
                {
                    pontEsq++;
                }

                /* Vai correr o Vector ate que ultrapasse o outro ponteiro
                  que o elemento em questão seja maior que o pivô. */
                while (pontDir >= pontEsq && Vector[pontDir] > pivo)
                {
                    pontDir--;
                }

                /* Caso os ponteiros ainda nao tenham se cruzado, significa que valores
                  menores e maiores que o pivô foram localizados em ambos os lados.
                  Trocar estes elementos de lado. */
                if (pontEsq < pontDir)
                {
                    Trocar(Vector, pontDir, pontEsq);
                    pontEsq++;
                    pontDir--;
                }

            }

            Trocar(Vector, inicio, pontDir);
            return pontDir;
        }

        private void Trocar(int[] Vector, int i, int j)
        {
            int temp = Vector[i];
            Vector[i] = Vector[j];
            Vector[j] = temp;
        }

        public void Display()
        {
            int i = 1;

            foreach (var position in Vector)
            {
                Console.WriteLine($"[{i.ToString()}] {position}");
                i++;
            }

        }

        public int MinSizeVector()
        {
            return 0;
        }

        public int MaxSizeVector()
        {
            return Vector.Length - 1;
        }

    }
}