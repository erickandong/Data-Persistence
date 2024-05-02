using System;
using System.Diagnostics.CodeAnalysis;
using System.IO; //permet d'agir sur un fichier
                 //Le système IO (Input/Output) en programmation C# est utilisé pour interagir avec les flux de données, tels que les fichiers, les réseaux, les flux mémoire, etc.
                 //Il fournit des classes et des méthodes pour lire à partir de sources de données (Input) et écrire vers des destinations (Output).
                 //Par exemple, vous pouvez utiliser les classes du namespace System.IO pour lire et écrire des fichiers, créer des répertoires, manipuler des chemins de fichiers, etc.
                 //En résumé, le système IO en C# est essentiel pour gérer les opérations d'entrée/sortie de données dans vos applications.

using System.Text.Json;  //va nous permettre de sérialiser l'objet au format texte dans un fichier Json

namespace Persistance_des_données
{
    internal class Program
    {
        [RequiresUnreferencedCode("Calls System.Text.Json.JsonSerializer.Serialize<TValue>(TValue, JsonSerializerOptions)")]
        [RequiresDynamicCode("Calls System.Text.Json.JsonSerializer.Serialize<TValue>(TValue, JsonSerializerOptions)")]
        static void Main(string[] args)
        {

            // LECON 1 : StreamWriter ET StreanReader


            //   //permet de créeer un fichier et d'écrire à l'interieur
            using (StreamWriter sw = new StreamWriter("c:\\Users\\ndong\\OneDrive\\Documents\\Projets_C#\\Data_VS\\test.txt"))
            {
                sw.WriteLine("Comprendre le Système IO");
            }

            //   //ajoute un texte dans un fichier existant
            using (StreamWriter sw = File.AppendText("c:\\Users\\ndong\\OneDrive\\Documents\\Projets_C#\\Data_VS\\test.txt"))
            {
                sw.WriteLine("Ligne ajoutée");
            }


            //permet de lire ligne par ligne le contenu d'un fichier
            using (StreamReader sr = new StreamReader("c:\\Users\\ndong\\OneDrive\\Documents\\Projets_C#\\Data_VS\\test.txt"))
            {
                string line = null;
                line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
            }

            //   //Lit le fichier de manière globale/intégrale
            using (StreamReader sr = new StreamReader("c:\\Users\\ndong\\OneDrive\\Documents\\Projets_C#\\Data_VS\\test.txt"))
            {
                string file = sr.ReadToEnd();
                Console.WriteLine(file);
            }




            //LECON 2 : SERIALISATION "Json"

            // Json = JavaScript Object Notation . Il permet de représenter un format de données de facon structurée
            //La sérialisation est un processus de conversion d'un objet en flux d'octect pour stocker l'objet vers une base de donnée ou un fichier

            Client c1= new Client("Dupont", "Luc");
            Client c2 = new Client("Gates", "Bill");
            Client c3 = new Client("Musk", "Alon");

            List<Client> listeClient = new List<Client>();
            listeClient.Add(c1);
            listeClient.Add(c2);
            listeClient.Add(c3);


            //Serialisation pour une liste
            string jsonString = JsonSerializer.Serialize(listeClient);
            File.WriteAllText("c:\\Users\\ndong\\OneDrive\\Documents\\Projets_C#\\Data_VS\\data.json", jsonString);

            //Desérialisation de la liste
            string jsonString = File.ReadAllText("c:\\Users\\ndong\\OneDrive\\Documents\\Projets_C#\\Data_VS\\data.json");
            listeClient = JsonSerializer.Deserialize<List<Client>>(jsonString);

            foreach (Client c in listeClient)
            {
                c.Information();
            }

            //Sérialisation d'un objet
            string jsonString = JsonSerializer.Serialize(c1);
            File.WriteAllText("c:\\Users\\ndong\\OneDrive\\Documents\\Projets_C#\\Data_VS\\data.json", jsonString);

            //Désérialisation d'un objet
            string jsonString = File.ReadAllText("c:\\Users\\ndong\\OneDrive\\Documents\\Projets_C#\\Data_VS\\data.json");
            Client c2 = JsonSerializer.Deserialize<Client>(jsonString);
            c2.Information();
            Console.WriteLine();








            Console.ReadKey();
        }
    }
}
