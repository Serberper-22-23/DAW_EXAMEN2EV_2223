using System;

namespace LotoClassNS
{
    // Clase que almacena una combinación de la lotería
    //
    public class LotoSBP2223
    {
        // definición de constantes
        public const int MAX_NUMEROS = 6;
        public const int NUMERO_MENOR = 1;
        public const int NUMERO_MAYOR = 49;
        
        private int[] _nums = new int[MAX_NUMEROS];   // numeros de la combinación
        public bool ok = false;      // combinación válida (si es aleatoria, siempre es válida, si no, no tiene porqué)

        public int[] Nums { 
            get => _nums; 
            set => _nums = value; 
        }

        /// <summary> Método Loto primero </summary>
        /// <remarks>  En el caso de que el constructor sea vacío, se genera una combinación aleatoria correcta </remarks>
        //
        public Loto()
        {
            /// <param name="Aleatorio"> Clase generadora de números aleatorios </param>
            Random Aleatorio = new Random();    

            int i=0, j, num;

            do             /// <remarks> Generamos la combinación </remarks>
            {                       
                num = Aleatorio.Next(NUMERO_MENOR, NUMERO_MAYOR + 1);     ///<summary> generamos un número aleatorio del 1 al 49 </summary>
                    if (Nums[j]==num)
                        break;
                if (i==j)               ///<summary> Si i==j, el número no se ha encontrado en la lista, lo añadimos </summary>
                {
                    Nums[i]=num;
                    i++;
                }
            } while (i<MAX_NUMEROS);

            ok=true;
        }

        // La segunda forma de crear una combinación es pasando el conjunto de números
        // misNumeros es un array de enteros con la combinación que quiero crear (no tiene porqué ser válida)
        public Loto(int[] misNumeros)  // misNumeros: combinación con la que queremos inicializar la clase
        {
            for (int i=0; i<MAX_NUMEROS; i++)
                if (misNumeros[i]>=NUMERO_MENOR && misNumeros[i]<=NUMERO_MAYOR) {
                    int j;
                    for (j=0; j<i; j++) 
                        if (misNumeros[i]==Nums[j])
                            break;
                    if (i==j)
                        Nums[i]=misNumeros[i]; // validamos la combinación
                    else {
                        ok=false;
                        return;
                    }
                }
                else
                {
                    ok=false;     // La combinación no es válida, terminamos
                    return;
                }
	    ok=true;
        }

        // Método que comprueba el número de aciertos
        // premi es un array con la combinación ganadora
        // se devuelve el número de aciertos
        public int Comprobar(int[] premi)
        {
            int aciertos=0;                    // número de aciertos
            for (int i=0; i<MAX_NUMEROS; i++)
                for (int j=0; j<MAX_NUMEROS; j++)
                    if (premi[i]==Nums[j]) aciertos++;
            return aciertos;
        }
    }

}
