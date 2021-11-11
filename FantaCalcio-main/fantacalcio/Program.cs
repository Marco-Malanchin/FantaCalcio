using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace fantacalcio
{   
    class Giocatore
    {
        //attributi
        string nome, cognome, ruolo;
        int prezzo, goalSegnati, RigoriParati;
        //costruttore
        public Giocatore(string nome, string cognome, string ruolo, int prezzo)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.ruolo = ruolo;
            this.prezzo = prezzo;
            goalSegnati = 0;
            RigoriParati = 0;
        }
            //Metodi
            string tostring()
            {
            return $"Il giocatore {this.nome}, {this.cognome}, {this.ruolo} prezzo:{this.prezzo}"; 
            }

        class Player
        {   //attributi
            string NickName, NomeSquadra;
            //costruttore
            public Player()
            {
                NickName = "";
                NomeSquadra = "";
            }
            //Metodi
            void ottieniNickName()
            {
                NickName = Console.ReadLine();
            }
            void ottieniNomeSquadra()
            {
                NomeSquadra = Console.ReadLine();
            }
            static void Main(string[] args)
            {
                string x = "0";
                Player P1 = new Player();
                Player P2 = new Player();
                int creditiGiocatore1 = 500;
                int creditiGiocatore2 = 500;
                int portiere = 0;
                int difensore = 0;
                int centrocampista = 0;
                int attacante = 0;
                int stop = 0;
                string confronto = "";
                int propostaGiocatore1 = 0;
                int propostaGiocatore2 = 0;
                string decisione = "";
                Console.WriteLine("Benvenuto su FANTACALCIO");
                while (x == "0")
                {
                    x = "1";
                    Console.WriteLine("Premere il tasto '1' per vedere la lista dei calciatori disponibili.\nPremere il tasto '2' per avviare la partita.\nPremere il tasto '3' per uscire.");
                    string sceltaOpzione = Console.ReadLine();
                    switch (sceltaOpzione)
                    {
                        case "1":
                            List<string> righe = new List<string>();
                            righe = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "ListaGiocatori.txt").ToList();
                            Console.Clear();
                            Console.WriteLine("Lista Giocatori:");
                            foreach (string line in righe)
                            {
                                Console.WriteLine(line);
                            }
                            Console.Write("\npremere '0' per ritornare al menù di scelta: ");
                            x = Console.ReadLine();
                            Console.Clear();
                            break;
                        case "2":
                            Console.Clear();
                            Console.Write("\nAvvio partita... \nGiocatore 1 inserisci il tuo NickName: ");
                            P1.ottieniNickName();
                            Console.Write("\nGiocatore 1 inserisci il nome della tua Fantasquadra: ");
                            P1.ottieniNomeSquadra();
                            Console.Write("\nGiocatore 2 inserisci il tuo NickName: ");
                            P2.ottieniNickName();
                            Console.Write("\nGiocatore 2 inserisci il nome della tua Fantasquadra: ");
                            P2.ottieniNomeSquadra();
                            Console.Clear();
                            List<Giocatore> GiocatoriPlayer1 = new List<Giocatore>();
                            for (int i = 1; i < 3; i++)
                            {
                                Console.WriteLine($"{P1.NickName} inserisci il nome, cognome, ruolo e numero dei crediti del Calciatore numero {i}^: ");
                                Console.Write("\nNome: ");
                                string nome = Console.ReadLine();
                                Console.Write("\nCognome: ");
                                string cognome = Console.ReadLine();
                                Console.Write("\nRuolo ('portiere' , 'difensore' , 'centrocampista' , 'attaccante'): ");
                                string ruolo = Console.ReadLine();
                                Console.Write("\nCrediti: ");
                                int prezzo = int.Parse(Console.ReadLine());
                                creditiGiocatore1 = creditiGiocatore1 - prezzo;
                                if (creditiGiocatore1 < 0)
                                {
                                    creditiGiocatore1 = 500;
                                    Console.WriteLine("Crediti esauriti, ricomprare tutti i giocatori");
                                    GiocatoriPlayer1.Clear();
                                    i = 0;
                                }
                                else
                                {
                                    Giocatore calciatore = new Giocatore(nome, cognome, ruolo, prezzo);
                                    GiocatoriPlayer1.Add(calciatore);
                                    switch (ruolo)
                                    {
                                        case "Portiere":
                                            portiere++;
                                            break;
                                        case "Difensore":
                                            difensore++;
                                            break;
                                        case "Centrocampista":
                                            centrocampista++;
                                            break;
                                        case "Attaccante":
                                            attacante++;
                                            break;
                                    }
                                    /*if (i == 14)
                                    {
                                        if (portiere != 2)
                                        {
                                            Console.WriteLine("Portieri insufficenti, ricomprare tutti i giocatori");
                                            GiocatoriPlayer1.Clear();
                                            i = 0;
                                        }
                                        else if (difensore != 3)
                                        {
                                            Console.WriteLine("difensori insufficenti, ricomprare tutti i giocatori");
                                            GiocatoriPlayer1.Clear();
                                            i = 0;
                                        }
                                        else if (centrocampista != 5)
                                        {
                                            Console.WriteLine("centrocampisti insufficenti, ricomprare tutti i giocatori");
                                            GiocatoriPlayer1.Clear();
                                            i = 0;
                                        }
                                        else if (attacante != 4)
                                        {
                                            Console.WriteLine("attacanti insufficenti, ricomprare tutti i giocatori");
                                            GiocatoriPlayer1.Clear();
                                            i = 0;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Squadra di {P1.NomeSquadra} composta da:");
                                            foreach (Giocatore squadra1 in GiocatoriPlayer1)
                                            {
                                                Console.WriteLine(squadra1.tostring());
                                            }
                                        }
                                    }*/
                                }
                                Console.WriteLine($"Crediti Rimanenti di {P1.NickName} = {creditiGiocatore1}");
                            }
                            
                            List<Giocatore> GiocatoriPlayer2 = new List<Giocatore>();
                            for (int i = 1; i < 4; i++)
                            {
                                Console.WriteLine($"{P2.NickName} inserisci il nome, cognome, ruolo e numero dei crediti del Calciatore numero {i}^: ");
                                Console.Write("\nNome: ");
                                string nome = Console.ReadLine();
                                Console.Write("\nCognome: ");
                                string cognome = Console.ReadLine();
                                Console.Write("\nRuolo ('portiere' , 'difensore' , 'centrocampista' , 'attaccante'): ");
                                string ruolo = Console.ReadLine();
                                Console.Write("\nCrediti: ");
                                int prezzo = int.Parse(Console.ReadLine());
                                creditiGiocatore2 = creditiGiocatore2 - prezzo;
                                confronto = cognome;
                                for (int j = 0; j < GiocatoriPlayer1.Count; j++)
                                {
                                    if (GiocatoriPlayer1[j].cognome.Equals(confronto))
                                    {

                                        Console.WriteLine("Giocatore già inserito dal player 1, avvio modalità asta");
                                        creditiGiocatore1 = creditiGiocatore1 + GiocatoriPlayer1[j].prezzo;
                                        creditiGiocatore2 = creditiGiocatore2 + prezzo;
                                        do
                                        {
                                            Console.Write($"\n{P1.NickName} quanti crediti vuoi spendere per {confronto}? : ");
                                            propostaGiocatore1 = int.Parse(Console.ReadLine());
                                            Console.Write($"\n{P2.NickName} quanti crediti vuoi spendere per {confronto}? : ");
                                            propostaGiocatore2 = int.Parse(Console.ReadLine());
                                            if (propostaGiocatore1 > propostaGiocatore2)
                                            {
                                                Console.WriteLine($"La proposta più alta è di {P1.NickName}, {P2.NickName} vuoi cedere il giocatore {confronto} a {P1.NickName}? digita 'si' per confermare la tua scelta:");
                                                decisione = Console.ReadLine();
                                                if (decisione == "si")
                                                {
                                                    creditiGiocatore1 = creditiGiocatore1 - propostaGiocatore1;
                                                    if (creditiGiocatore1 < 0)
                                                    {
                                                        do
                                                        {
                                                            creditiGiocatore1 = creditiGiocatore1 + propostaGiocatore1;
                                                            Console.WriteLine($"Crediti insufficenti giocatore {confronto} assegnato a {P2.NickName}");
                                                            GiocatoriPlayer1.Remove(GiocatoriPlayer1[j]);
                                                            Console.WriteLine($"{P1.NickName} inserisci nuovo calciatore avente lo stesso ruolo del precedente: ");
                                                            Console.Write("\nNome: ");
                                                            string nomeSostituto = Console.ReadLine();
                                                            Console.Write("\nCognome: ");
                                                            string cognomeSostituto = Console.ReadLine();
                                                            Console.Write("\nRuolo ('portiere' , 'difensore' , 'centrocampista' , 'attaccante'): ");
                                                            string ruoloSostituto = Console.ReadLine();
                                                            Console.Write("\nCrediti: ");
                                                            int prezzoSostituto = int.Parse(Console.ReadLine());
                                                            creditiGiocatore1 = creditiGiocatore1 - prezzoSostituto;
                                                            if (creditiGiocatore1 < 0)
                                                            {
                                                                do
                                                                {
                                                                    creditiGiocatore1 = creditiGiocatore1 + prezzoSostituto;
                                                                    Console.WriteLine("Crediti esauriti cambia il costo del giocatore: ");
                                                                    Console.Write("\nCrediti: ");
                                                                    prezzoSostituto = int.Parse(Console.ReadLine());
                                                                    creditiGiocatore1 = creditiGiocatore1 - prezzoSostituto;
                                                                }
                                                                while (creditiGiocatore1 < 0);
                                                            }
                                                            Giocatore calciatore = new Giocatore(nomeSostituto, cognomeSostituto, ruoloSostituto, prezzoSostituto);
                                                            GiocatoriPlayer1.Add(calciatore);
                                                        }
                                                        while (creditiGiocatore1 < 0);
                                                        stop = 1;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"{GiocatoriPlayer1[j].cognome} assegnato a {P1.NickName}");
                                                        stop = 1;
                                                    }
                                                }
                                                else
                                                {
                                                    stop = 0;
                                                }
                                            }
                                            if (propostaGiocatore2 > propostaGiocatore1)
                                            {
                                                Console.WriteLine($"La proposta più alta è di {P2.NickName}, {P1.NickName} vuoi cedere il giocatore {confronto} a {P2.NickName}? digita 'si' per confermare la tua scelta:");
                                                decisione = Console.ReadLine();
                                                if (decisione == "si")
                                                {
                                                    creditiGiocatore2 = creditiGiocatore2 - propostaGiocatore2;
                                                    if (creditiGiocatore2 < 0)
                                                    {
                                                        creditiGiocatore2 = creditiGiocatore2 + propostaGiocatore2;
                                                        Console.WriteLine($"Crediti insufficenti giocatore {confronto} assegnato a {P1.NickName}");
                                                        Console.WriteLine($"{P2.NickName}, inserisci un nuovo giocatore avente lo stesso ruolo del precedente");
                                                        Console.Write("\nNome: ");
                                                        nome = Console.ReadLine();
                                                        Console.Write("\nCognome: ");
                                                        cognome = Console.ReadLine();
                                                        Console.Write("\nRuolo ('portiere' , 'difensore' , 'centrocampista' , 'attaccante'): ");
                                                        ruolo = Console.ReadLine();
                                                        Console.Write("\nCrediti: ");
                                                        prezzo = int.Parse(Console.ReadLine());
                                                        creditiGiocatore2 = creditiGiocatore2 - prezzo;
                                                        if (creditiGiocatore2 < 0)
                                                        {
                                                            do
                                                            {
                                                                creditiGiocatore2 = creditiGiocatore2 + prezzo;
                                                                Console.WriteLine("Crediti esauriti cambia il costo del giocatore: ");
                                                                Console.Write("\nCrediti: ");
                                                                prezzo = int.Parse(Console.ReadLine());
                                                                creditiGiocatore2 = creditiGiocatore2 - prezzo;
                                                            }
                                                            while (creditiGiocatore2 < 0);
                                                            stop = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"{GiocatoriPlayer1[j].cognome} assegnato a {P2.NickName}");
                                                        prezzo = propostaGiocatore2;
                                                        GiocatoriPlayer1.Remove(GiocatoriPlayer1[j]);
                                                        Console.WriteLine($"{P1.NickName} inserisci nuovo calciatore avente lo stesso ruolo del precedente: ");
                                                        Console.Write("\nNome: ");
                                                        string nomeSostituto = Console.ReadLine();
                                                        Console.Write("\nCognome: ");
                                                        string cognomeSostituto = Console.ReadLine();
                                                        Console.Write("\nRuolo ('portiere' , 'difensore' , 'centrocampista' , 'attaccante'): ");
                                                        string ruoloSostituto = Console.ReadLine();
                                                        Console.Write("\nCrediti: ");
                                                        int prezzoSostituto = int.Parse(Console.ReadLine());
                                                        creditiGiocatore1 = creditiGiocatore1 - prezzoSostituto;
                                                        if (creditiGiocatore1 < 0)
                                                        {
                                                            do
                                                            {
                                                                creditiGiocatore1 = creditiGiocatore1 + prezzoSostituto;
                                                                Console.WriteLine("Crediti esauriti cambia il costo del giocatore: ");
                                                                Console.Write("\nCrediti: ");
                                                                prezzoSostituto = int.Parse(Console.ReadLine());
                                                                creditiGiocatore1 = creditiGiocatore1 - prezzoSostituto;
                                                            }
                                                            while (creditiGiocatore1 < 0);
                                                            stop = 1;
                                                            Giocatore calciatore = new Giocatore(nomeSostituto, cognomeSostituto, ruoloSostituto, prezzoSostituto);
                                                            GiocatoriPlayer1.Add(calciatore);
                                                        }
                                                        else
                                                        {
                                                            Giocatore calciatore = new Giocatore(nomeSostituto, cognomeSostituto, ruoloSostituto, prezzoSostituto);
                                                            GiocatoriPlayer1.Add(calciatore);
                                                            stop = 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    stop = 0;
                                                }
                                            }
                                            else if(propostaGiocatore1 == propostaGiocatore2)
                                            {
                                                Console.WriteLine("Proposte di acquisto uguali, ripetere le proposte");
                                                stop = 0;
                                            }
                                        }
                                        while (stop == 0);
                                    }
                                }
                                if (creditiGiocatore2 < 0)
                                {
                                    creditiGiocatore2 = 500;
                                    Console.WriteLine("Crediti esauriti, ricomprare tutti i giocatori");
                                    GiocatoriPlayer2.Clear();
                                    i = 0;
                                    Console.Clear();
                                }
                                else
                                {
                                    Giocatore calciatore = new Giocatore(nome, cognome, ruolo, prezzo);
                                    GiocatoriPlayer2.Add(calciatore);
                                    switch (ruolo)
                                    {
                                        case "Portiere":
                                            portiere++;
                                            break;
                                        case "Difensore":
                                            difensore++;
                                            break;
                                        case "Centrocampista":
                                            centrocampista++;
                                            break;
                                        case "Attaccante":
                                            attacante++;
                                            break;
                                    }
                                    foreach (Giocatore squadra2 in GiocatoriPlayer2)
                                    {
                                        Console.WriteLine(squadra2.tostring());
                                    }
                                    foreach (Giocatore squadra1 in GiocatoriPlayer1)
                                    {
                                        Console.WriteLine(squadra1.tostring());
                                    }
                                    /*
                                    if (i == 14)
                                    {
                                        if (portiere != 2)
                                        {
                                            Console.WriteLine("Portieri insufficenti, ricomprare tutti i giocatori");
                                            GiocatoriPlayer2.Clear();
                                            i = 0;
                                            Console.Clear();
                                        }
                                        else if (difensore != 3)
                                        {
                                            Console.WriteLine("difensori insufficenti, ricomprare tutti i giocatori");
                                            GiocatoriPlayer2.Clear();
                                            i = 0;
                                            Console.Clear();
                                        }
                                        else if (centrocampista != 5)
                                        {
                                            Console.WriteLine("centrocampisti insufficenti, ricomprare tutti i giocatori");
                                            GiocatoriPlayer2.Clear();
                                            i = 0;
                                            Console.Clear();
                                        }
                                        else if (attacante != 4)
                                        {
                                            Console.WriteLine("attacanti insufficenti, ricomprare tutti i giocatori");
                                            GiocatoriPlayer2.Clear();
                                            i = 0;
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Squadra di {P2.NomeSquadra} composta da:");
                                            foreach (Giocatore squadra2 in GiocatoriPlayer2)
                                            {
                                                Console.WriteLine(squadra2.tostring());
                                            }
                                        }
                                    }*/
                                }
                                Console.WriteLine($"Crediti Rimanenti di {P2.NickName} = {creditiGiocatore2}");
                            }
                            
                            break;
                        case "3":
                            Environment.Exit(0);
                            break;
                    }
                }


                Console.ReadKey();

            }


        }
    }
}
