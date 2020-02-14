using System;
using System.IO;

namespace Coolshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean result = false;
            //Chiamo funzione CheckArguments per controllare se il file indicato esista e che siano stati inseriti correttamente i parametri
            if(!CheckArgumets(args))
            {
                return;
            }

            int column = Int32.Parse(args[1]);
            //Chiamo funzione CheckColumn per controllare quante colonne siano presenti e che la colonna indicata come parametro sia accettabile
            int MaxColumn= CheckColumn(args[0],column);
            if(MaxColumn==-1)
            {
                Console.WriteLine("Indice fuori dai limiti");
                return;
            }
  
            using (var streamReader = new StreamReader(args[0]))
            {
                while (!streamReader.EndOfStream && result==false)
                {
                    var splittedLine = streamReader.ReadLine().Split(',',';');
                    if(String.Equals(splittedLine[column],args[2]))
                    {
                        foreach (string element in splittedLine)
                        {
                    
                            Console.Write($"{element} ");
                        }
                        Console.Write("\n");
                        result = true;
                    }
                }
                if(result==false)
                {
                    Console.WriteLine("Nessun risultato trovato");
        
                }
            }
        }
        private static Boolean CheckArgumets(string[] arguments)
        {
            int column = Int32.Parse(arguments[1]);
            if (arguments.Length!=3)
            {
                Console.WriteLine("Numero di parametri errato!");
                return false;
            }
            if(!File.Exists(arguments[0]))
            {
                Console.WriteLine("Il file specificato non esiste");
                return false;
            }
         
            return true;
        }
        private static int CheckColumn(string PathFile, int Column)
        {
            using (var streamReader = new StreamReader(PathFile))
            {
                var splittedLine = streamReader.ReadLine().Split(',');
                int dim = splittedLine.Length;
                if (dim-1 < Column || Column < 0)
                {
                    
                    return -1;
                }
                streamReader.Close();
                return dim;
            }

        }
    }
}
