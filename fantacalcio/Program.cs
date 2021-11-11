using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace fantacalcio
{
    public class Giocatore
    {
        //attributi della classe Giocatore
        public string nome, cognome, ruolo, ruoloSostituto;
        public int prezzo, punti, goalSegnati, cartelliniGialli, goalParati;
        //costruttore della classe Giocatore
        public Giocatore(string nome, string cognome, string ruolo, int prezzo)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.ruolo = ruolo;
            this.prezzo = prezzo;
            punti = 0;
            goalSegnati = 0;
            cartelliniGialli = 0;
            goalParati = 0;
        }
        //Metodi per stampare il nome, il cognome, il ruolo e il prezzo del giocatore(stampo gli attributi)
        public string tostring()
        {
            return $"Il giocatore {this.nome}, {this.cognome}, {this.ruolo} prezzo:{this.prezzo}";
        }

        public int punteggio() //metodo per calcolare il punteggio della squadra
        {
            
            Random rnd = new Random(); //Creo il random rnd utile per generare i punteggi dei giocatori
            punti = rnd.Next(1, 15); //Assegno alla int punti un numero tra 1 e 15
            cartelliniGialli = rnd.Next(0, 1);//Assegno alla int cartelliniGialli un numero tra 0 e 1 grazie alla funzione random
            punti = punti - (cartelliniGialli * 4);//Aggiorno i punti tenendo conto dei cartellini gialli presi dai giocatori
            if (ruolo != "Portiere")//se il ruolo dei giocatori è diverso da "Portiere" allora il giocatore può segnare i goal
            {
                goalSegnati = rnd.Next(0, 3);//Assegno alla int goalSegnati un numero tra 0 e 3 grazie alla funzione random
                punti = punti + (goalSegnati * 2);//Aggiorno i punti tenendo conto dei goal fatti dai giocatori
            }
            else if (ruolo == "Portiere")//se il ruolo dei giocatori è "Portiere" allora il giocatore può parare i goal
            {
                goalParati = rnd.Next(0, 2);//Assegno alla int goalParati un numero tra 0 e 2 grazie alla funzione random
                punti = punti + (goalParati * 2);//Aggiorno i punti tenendo conto dei goal parati dai giocatori
            }
            else if (ruoloSostituto != "Portiere")//se il ruoloSostituto dei giocatori è diverso da "Portiere" allora il giocatore può segnare i goal
            {
                goalSegnati = rnd.Next(0, 3);//Assegno alla int goalSegnati un numero tra 0 e 3 grazie alla funzione random
                punti = punti + (goalSegnati * 2);//Aggiorno i punti tenendo conto dei goal fatti dai giocatori
            }
            else if (ruoloSostituto == "Portiere")//se il ruoloSostituto dei giocatori è "Portiere" allora il giocatore può parare i goal
            {
                goalParati = rnd.Next(0, 2);//Assegno alla int goalParati un numero tra 0 e 2 grazie alla funzione random
                punti = punti + (goalParati * 2);//Aggiorno i punti tenendo conto dei goal parati dai giocatori
            }
            return punti;//Faccio ritornare i punti di ogni giocatori per calcolare successivamente il punteggio totale della squadra
        }
    }
    
    public class Player
    {   //attributi della classe player
        public string NickName, NomeSquadra;
        //costruttore della classe player
        public Player()
        {
            NickName = "";
            NomeSquadra = "";
        }
        //Metodi
        public void ottieniNickName()
        {
            NickName = Console.ReadLine(); //metodo per ottenere il NickName dei player inseriti da console
        }
        public void ottieniNomeSquadra()
        {
            NomeSquadra = Console.ReadLine(); //metodo per ottenere il NomeSquadra dei player inseriti da console
        }

    

            public static void Main(string[] args)
            {
                string x = "0"; //Inizializzo la stringa x == "0" utile per ripetere il while della scelta menù
                Player P1 = new Player(); //Inizializzo i due oggetti player P1
                Player P2 = new Player(); //Inizializzo i due oggetti player P2
                int creditiGiocatore1 = 500; //Inizializzo i crediti del player 1 a 500
                int creditiGiocatore2 = 500; //Inizializzo i crediti del player 2 a 500
                int portiere = 0; //inizializzo il contatore portiere a 0
                int difensore = 0; //inizializzo il contatore difensore a 0
                int centrocampista = 0; //inizializzo il contatore centrocampista a 0
                int attacante = 0; //inizializzo il contatore attacante a 0
                int stop = 0; //inizializzo la variabile per fermare il do while della funzione asta a 0
                string confronto = ""; //dichiaro la string confronto utile per la funzione asta
                int propostaGiocatore1 = 0; //dichiaro la variabile propostaGiocatore1 a 0, mi servirà per la funzione asta
                int propostaGiocatore2 = 0; //dichiaro la variabile propostaGiocatore2 a 0, mi servirà per la funzione asta
                string decisione = ""; //dichiaro la string decisione usata per terminare l'asta tra i due player
                int PunteggioSquadra1 = 0; //inizializzo la variabile PunteggioSquadra1 a 0 questa variabile prenderà il valore dei punteggi dei giocatori
                int PunteggioSquadraFinale1 = 0; //inizializzo la variabile PunteggioSquadraFinale1 a 0 questa variabile prenderà il valore dei punteggi finali della squadra 1
                int PunteggioSquadra2 = 0;  //inizializzo la variabile PunteggioSquadra2 a 0 questa variabile prenderà il valore dei punteggi dei giocatori
                int PunteggioSquadraFinale2 = 0; //inizializzo la variabile PunteggioSquadraFinale2 a 0 questa variabile prenderà il valore dei punteggi finali della squadra 2
                Console.WriteLine("Benvenuto su FANTACALCIO");
                while (x == "0") //Ciclo do while che mi permette di tornare alla selezione dei comandi del menu
                {
                    x = "1";// interrompo il ciclo do while
                    Console.WriteLine("Premere il tasto '1' per vedere la lista dei calciatori disponibili.\nPremere il tasto '2' per avviare la partita.\nPremere il tasto '3' per uscire.");
                    string sceltaOpzione = Console.ReadLine(); //Prendo da console il comando per navigare sul menu
                    switch (sceltaOpzione) //Switch che mi permette di navigare sul menù a seconda del tasto premuto
                    {
                        case "1": //se il numero preso da input è 1 mostro la lista dei giocatori del Fanatacalcio
                            List<string> righe = new List<string>();//Creo la lista di stringhe contenenti i nomi, cognomi e ruoli dei Calciatori
                            righe = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "ListaGiocatori.txt").ToList(); //Copio il contenunto del file esterno nella lista righe
                            Console.Clear();
                            Console.WriteLine("Lista Giocatori:"); //stampo a schermo i giocatori della lista
                            foreach (string line in righe)
                            {
                                Console.WriteLine(line);
                            }
                            Console.Write("\npremere '0' per ritornare al menù di scelta: ");
                            x = Console.ReadLine(); //Prendo a input il valore per fare ritornare l'utente nel menù iniziale
                            Console.Clear();
                            break;
                        case "2":   //se il numero preso da input è 2 mostro avvio la partita
                            Console.Clear();
                            Console.Write("\nAvvio partita... \nGiocatore 1 inserisci il tuo NickName: "); //inserisco prendendo da console nickname e nome squadra dei player
                            P1.ottieniNickName();
                            Console.Write("\nGiocatore 1 inserisci il nome della tua Fantasquadra: ");
                            P1.ottieniNomeSquadra();
                            Console.Write("\nGiocatore 2 inserisci il tuo NickName: ");
                            P2.ottieniNickName();
                            Console.Write("\nGiocatore 2 inserisci il nome della tua Fantasquadra: ");
                            P2.ottieniNomeSquadra();
                            Console.Clear();
                            List<Giocatore> GiocatoriPlayer1 = new List<Giocatore>(); //Creao la lista per inseririe i giocatori del Player 1
                            for (int i = 1; i < 15; i++)
                            {
                                Console.WriteLine($"{P1.NickName} inserisci il nome, cognome, ruolo e numero dei crediti del Calciatore numero {i}^: ");
                                Console.Write("\nNome: ");
                                string nome = Console.ReadLine();
                                Console.Write("\nCognome: ");
                                string cognome = Console.ReadLine();
                                Console.Write("\nRuolo ('Portiere' , 'Difensore' , 'Centrocampista' , 'Attaccante'): ");
                                string ruolo = Console.ReadLine();
                                Console.Write("\nCrediti: ");
                                int prezzo = int.Parse(Console.ReadLine()); //prendo da console nome, cognome, ruolo e prezzo del calciatore
                                creditiGiocatore1 = creditiGiocatore1 - prezzo;//aggiorno i crediti del player sottraendo alla somma il prezzo del calciatore
                                Console.Clear();
                                if (creditiGiocatore1 < 0) //se i crediti del giocatore sono esauriti la lista si svuota e il player reinserisci tutti i nomi
                                {
                                    creditiGiocatore1 = 500; //rinizializzo i crediti del giocatore alla somma iniziale
                                    Console.WriteLine("Crediti esauriti, ricomprare tutti i giocatori");
                                    GiocatoriPlayer1.Clear();
                                    i = 0; //rinizializzo a 0 il valore dell int per il ciclo for per inseriri i giocatori
                                }
                                else
                                {
                                    Giocatore calciatore = new Giocatore(nome, cognome, ruolo, prezzo); //altrimenti se i crediti sono maggiori o uguali a 0 aggiungo il calciatore alla lista
                                    GiocatoriPlayer1.Add(calciatore);
                                    switch (ruolo)//a seconda del ruolo aumento i contatori
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
                                    if (i == 15) // quando la int del for è arrivata alla fine controllo se il giocatore ha preso tutti i tipi di giocatori e nel numero corretto
                                    {//altrimenti svuoto la lista e il player dovrà reinseriri i giocatori tutti da capo
                                        if (portiere != 2)
                                        {
                                            Console.WriteLine("Portieri insufficenti, ricomprare tutti i giocatori");
                                            GiocatoriPlayer1.Clear();
                                            i = 0; //rinizializzo a 0 il valore dell int per il ciclo for per inseriri i giocatori
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
                                            Console.WriteLine($"Squadra di {P1.NomeSquadra} composta da:"); //Scrivo i giocatori del player 1 
                                            foreach (Giocatore squadra1 in GiocatoriPlayer1)
                                            {
                                                Console.WriteLine(squadra1.tostring());
                                            }
                                        }
                                    }
                                }
                                Console.WriteLine($"Crediti Rimanenti di {P1.NickName} = {creditiGiocatore1}"); // ad ogni iterazione del ciclo for ricordo al player quanti crediti gli restano
                            }
                            
                            List<Giocatore> GiocatoriPlayer2 = new List<Giocatore>(); //Creao la lista per inseririe i giocatori del Player 2
                            for (int i = 1; i < 15; i++)
                            {
                                Console.WriteLine($"{P2.NickName} inserisci il nome, cognome, ruolo e numero dei crediti del Calciatore numero {i}^: ");
                                Console.Write("\nNome: ");
                                string nome = Console.ReadLine();
                                Console.Write("\nCognome: ");
                                string cognome = Console.ReadLine();
                                Console.Write("\nRuolo ('Portiere' , 'Difensore' , 'Centrocampista' , 'Attaccante'): ");
                                string ruolo = Console.ReadLine();
                                Console.Write("\nCrediti: ");
                                int prezzo = int.Parse(Console.ReadLine()); //prendo da console nome, cognome, ruolo e prezzo del calciatore
                                creditiGiocatore2 = creditiGiocatore2 - prezzo; //aggiorno i crediti del player sottraendo alla somma il prezzo del calciatore
                                Console.Clear();
                                confronto = cognome; // assegno alla stringa confronto il cognome del giocatore
                                for (int j = 0; j < GiocatoriPlayer1.Count; j++) //controllo nella lista 1 se è gia stato inserito un giocatore con lo stesso cognome
                                {
                                    if (GiocatoriPlayer1[j].cognome.Equals(confronto)) //se la stringa confronto risulta uguale al cognome di un giocatore della lista 1 si  apre la mdoalità asta 
                                    {

                                        Console.WriteLine("Giocatore già inserito dal player 1, avvio modalità asta");
                                        creditiGiocatore1 = creditiGiocatore1 + GiocatoriPlayer1[j].prezzo;//vengono restituiti i crediti al giocatore 1
                                        creditiGiocatore2 = creditiGiocatore2 + prezzo; //vengono restituiti i crediti al giocatore 2
                                        do
                                        {
                                            Console.Write($"\n{P1.NickName} quanti crediti vuoi spendere per {confronto}? : ");
                                            propostaGiocatore1 = int.Parse(Console.ReadLine()); //i giocatori propongono un prezzo di acquisto per il calciatore conteso
                                            Console.Write($"\n{P2.NickName} quanti crediti vuoi spendere per {confronto}? : ");
                                            propostaGiocatore2 = int.Parse(Console.ReadLine());
                                            if (propostaGiocatore1 > propostaGiocatore2)//se la proposta del player 1 è più alta di quella del player 2 viene chiesto al player 2 se vuole cedere il giocatore al player 1
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"La proposta più alta è di {P1.NickName}, {P2.NickName} vuoi cedere il giocatore {confronto} a {P1.NickName}? digita 'si' per confermare la tua scelta:");
                                                decisione = Console.ReadLine();
                                                if (decisione == "si")
                                                {
                                                    creditiGiocatore1 = creditiGiocatore1 - propostaGiocatore1; //se la decisione è si viene scalato il prezzo dai crediti del player 1
                                                    if (creditiGiocatore1 < 0)//se i crediti del player 1 sono minori di 0 il giocatore conteso viene assegnato al player 2
                                                    {
                                                        do
                                                        {
                                                            creditiGiocatore1 = creditiGiocatore1 + propostaGiocatore1; //al player 1 vengono riaccrediti i crediti
                                                            Console.WriteLine($"Crediti insufficenti giocatore {confronto} assegnato a {P2.NickName}");
                                                            GiocatoriPlayer1.Remove(GiocatoriPlayer1[j]);//viene rimosso il giocatore conteso dalla lista giocatori di Player1
                                                            Console.WriteLine($"{P1.NickName} inserisci nuovo calciatore avente lo stesso ruolo del precedente: ");
                                                            Console.Write("\nNome: ");
                                                            string nomeSostituto = Console.ReadLine();
                                                            Console.Write("\nCognome: ");
                                                            string cognomeSostituto = Console.ReadLine();
                                                            Console.Write("\nRuolo ('Portiere' , 'Difensore' , 'Centrocampista' , 'Attaccante'): ");
                                                            string ruoloSostituto = Console.ReadLine();
                                                            Console.Write("\nCrediti: ");//player 1 inserisce nome, cognome, ruolo(uguale al giocatore rimosso) e crediti di un nuovo giocatore sostitutivo 
                                                            int prezzoSostituto = int.Parse(Console.ReadLine());
                                                            creditiGiocatore1 = creditiGiocatore1 - prezzoSostituto; //aggiorno i crediti del player sottraendo alla somma il prezzo del calciatore
                                                            Console.Clear();
                                                            if (creditiGiocatore1 < 0) //se i crediti sono di nuovo minori di 0 il player deve cambiare il prezzo di acquisto del giocatore
                                                            {
                                                                do
                                                                {
                                                                    Console.Clear();
                                                                    creditiGiocatore1 = creditiGiocatore1 + prezzoSostituto;//aggiorno i crediti del player sommando ai crediti il prezzo del giocatore
                                                                    Console.WriteLine("Crediti esauriti cambia il costo del giocatore: ");
                                                                    Console.Write("\nCrediti: ");
                                                                    prezzoSostituto = int.Parse(Console.ReadLine());//cambio il costo del giocatore finchè i crediti sono maggiori o uguali a 0
                                                                    creditiGiocatore1 = creditiGiocatore1 - prezzoSostituto;//aggiorno i crediti
                                                                }
                                                                while (creditiGiocatore1 < 0);
                                                            }
                                                            Giocatore calciatore = new Giocatore(nomeSostituto, cognomeSostituto, ruoloSostituto, prezzoSostituto);//aggiungo alla lista il giocatore sotitutivo
                                                            GiocatoriPlayer1.Add(calciatore);
                                                        }
                                                        while (creditiGiocatore1 < 0);
                                                        stop = 1;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine($"{GiocatoriPlayer1[j].cognome} assegnato a {P1.NickName}"); //se i crediti sono maggiori o uguali a 0 assegno al player il giocatore conteso
                                                        stop = 1;//Fermo l'asta
                                                    }
                                                }
                                                else
                                                {
                                                    stop = 0; //se la decisione non è "si" l'asta continua, i player continuano a fare proposte per il calciatore conteso
                                                    Console.Clear();
                                                }
                                            }
                                            if (propostaGiocatore2 > propostaGiocatore1)//se la proposta del player 2 è più alta di quella del player 1 viene chiesto al player 1 se vuole cedere il giocatore al player 2
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"La proposta più alta è di {P2.NickName}, {P1.NickName} vuoi cedere il giocatore {confronto} a {P2.NickName}? digita 'si' per confermare la tua scelta:");
                                                decisione = Console.ReadLine();
                                                if (decisione == "si") //se la decisione è si viene scalato il prezzo dai crediti del player 2
                                                {
                                                    creditiGiocatore2 = creditiGiocatore2 - propostaGiocatore2; //se la decisione è si viene scalato il prezzo dai crediti del player 2
                                                    if (creditiGiocatore2 < 0)//se i crediti del player 2 sono minori di 0 il giocatore conteso viene assegnato al player 1
                                                    {
                                                        Console.Clear();
                                                        creditiGiocatore2 = creditiGiocatore2 + propostaGiocatore2; //aggiorno i crediti del player sommando ai crediti il prezzo del giocatore
                                                        Console.WriteLine($"Crediti insufficenti giocatore {confronto} assegnato a {P1.NickName}");
                                                        Console.WriteLine($"{P2.NickName}, inserisci un nuovo giocatore avente lo stesso ruolo del precedente");
                                                        Console.Write("\nNome: ");
                                                        nome = Console.ReadLine();
                                                        Console.Write("\nCognome: ");
                                                        cognome = Console.ReadLine();
                                                        Console.Write("\nRuolo ('Portiere' , 'Difensore' , 'Centrocampista' , 'Attaccante'): ");
                                                        ruolo = Console.ReadLine();
                                                        Console.Write("\nCrediti: ");
                                                        prezzo = int.Parse(Console.ReadLine()); //player 2 inserisce nome, cognome, ruolo(uguale al giocatore rimosso) e crediti di un nuovo giocatore sostitutivo
                                                        creditiGiocatore2 = creditiGiocatore2 - prezzo; //aggiorno i crediti del player sottraendo alla somma il prezzo del calciatore
                                                        if (creditiGiocatore2 < 0) //se i crediti sono di nuovo minori di 0 il player deve cambiare il prezzo di acquisto del giocatore
                                                        {
                                                            do
                                                            {
                                                                Console.Clear();
                                                                creditiGiocatore2 = creditiGiocatore2 + prezzo;//aggiorno i crediti del player sommando ai crediti il prezzo del giocatore
                                                                Console.WriteLine("Crediti esauriti cambia il costo del giocatore: ");
                                                                Console.Write("\nCrediti: ");
                                                                prezzo = int.Parse(Console.ReadLine());//cambio il costo del giocatore finchè i crediti sono maggiori o uguali a 0
                                                                creditiGiocatore2 = creditiGiocatore2 - prezzo;//aggiorno i crediti
                                                            }
                                                            while (creditiGiocatore2 < 0);
                                                            stop = 1; //stoppo la funzione asta
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine($"{GiocatoriPlayer1[j].cognome} assegnato a {P2.NickName}");
                                                        prezzo = propostaGiocatore2;
                                                        GiocatoriPlayer1.Remove(GiocatoriPlayer1[j]); //viene rimosso il giocatore conteso dalla lista giocatori di Player1
                                                        Console.WriteLine($"{P1.NickName} inserisci nuovo calciatore avente lo stesso ruolo del precedente: ");
                                                        Console.Write("\nNome: ");
                                                        string nomeSostituto = Console.ReadLine();
                                                        Console.Write("\nCognome: ");
                                                        string cognomeSostituto = Console.ReadLine();
                                                        Console.Write("\nRuolo ('Portiere' , 'Difensore' , 'Centrocampista' , 'Attaccante'): ");
                                                        string ruoloSostituto = Console.ReadLine();
                                                        Console.Write("\nCrediti: ");
                                                        int prezzoSostituto = int.Parse(Console.ReadLine()); //player 1 inserisce nome, cognome, ruolo(uguale al giocatore rimosso) e crediti di un nuovo giocatore sostitutivo
                                                        creditiGiocatore1 = creditiGiocatore1 - prezzoSostituto;  //aggiorno i crediti del player sottraendo alla somma il prezzo del calciatore
                                                        if (creditiGiocatore1 < 0) //se i crediti sono minori di 0 il player deve cambiare il prezzo di acquisto del giocatore
                                                        {
                                                            do
                                                            {
                                                                Console.Clear();
                                                                creditiGiocatore1 = creditiGiocatore1 + prezzoSostituto;//aggiorno i crediti del player sommando ai crediti il prezzo del giocatore
                                                                Console.WriteLine("Crediti esauriti cambia il costo del giocatore: ");
                                                                Console.Write("\nCrediti: ");
                                                                prezzoSostituto = int.Parse(Console.ReadLine()); //cambio il costo del giocatore finchè i crediti sono maggiori o uguali a 0
                                                                creditiGiocatore1 = creditiGiocatore1 - prezzoSostituto;//aggiorno i crediti
                                                            }
                                                            while (creditiGiocatore1 < 0);
                                                            stop = 1; //stoppo la funzione asta
                                                            Giocatore calciatore = new Giocatore(nomeSostituto, cognomeSostituto, ruoloSostituto, prezzoSostituto);//aggiungo alla lista il giocatore sotitutivo
                                                            GiocatoriPlayer1.Add(calciatore);
                                                        }
                                                        else
                                                        {
                                                            Giocatore calciatore = new Giocatore(nomeSostituto, cognomeSostituto, ruoloSostituto, prezzoSostituto); //aggiungo alla lista il giocatore sotitutivo
                                                            GiocatoriPlayer1.Add(calciatore);
                                                            stop = 1; //stoppo la funzione asta
                                                            Console.Clear();
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    stop = 0; //se i due player non sono d'accordo faccio continuare l'asta
                                                    Console.Clear();
                                                }
                                            }
                                            else if(propostaGiocatore1 == propostaGiocatore2)
                                            {
                                                Console.WriteLine("Proposte di acquisto uguali, ripetere le proposte");
                                                stop = 0;// se le proposte di acquisto sono uguali faccio ripetere l'asta
                                            }
                                        }
                                        while (stop == 0);
                                    }
                                }
                                if (creditiGiocatore2 < 0) //se i crediti del giocatore sono esauriti la lista si svuota e il player reinserisci tutti i nomi
                                {//altrimenti svuoto la lista e il player dovrà reinseriri i giocatori tutti da capo
                                creditiGiocatore2 = 500;
                                    Console.WriteLine("Crediti esauriti, ricomprare tutti i giocatori");
                                    GiocatoriPlayer2.Clear();
                                    i = 0;//rinizializzo a 0 il valore dell int per il ciclo for per inseriri i giocatori
                                    Console.Clear();
                                }
                                else
                                {
                                    Giocatore calciatore = new Giocatore(nome, cognome, ruolo, prezzo); //altrimenti se i crediti sono maggiori o uguali a 0 aggiungo il calciatore alla lista
                                    GiocatoriPlayer2.Add(calciatore);
                                    switch (ruolo)//a seconda del ruolo aumento i contatori
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
                                    if (i == 15)// quando la int del for è arrivata alla fine controllo se il giocatore ha preso tutti i tipi di giocatori e nel numero corretto
                                    {
                                        if (portiere != 2)
                                        {
                                            Console.WriteLine("Portieri insufficenti, ricomprare tutti i giocatori");
                                            GiocatoriPlayer2.Clear();
                                            i = 0;//rinizializzo a 0 il valore dell int per il ciclo for per inseriri i giocatori
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
                                            Console.WriteLine($"Squadra di {P2.NomeSquadra} composta da:");//stampo a schermo i giocatori della squadra del player 2
                                            foreach (Giocatore squadra2 in GiocatoriPlayer2)
                                            {
                                                Console.WriteLine(squadra2.tostring());
                                            }
                                        }
                                    }
                                }
                                Console.WriteLine($"Crediti Rimanenti di {P2.NickName} = {creditiGiocatore2}"); // ad ogni iterazione del ciclo for ricordo al player quanti crediti gli restano
                            }
                            Console.Clear();
                            for (int i = 1; i < 6; i++) //Con il ciclo for calcolo il punteggio dell 5 giornate di campionato
                            {
                                Console.WriteLine($"avvio {i}° giornata...\n Calcolo punteggio... ");
                                foreach (Giocatore squadra1 in GiocatoriPlayer1) //con il cilco foreach ad ogni iterazione calcolo il punteggio di ogni giocatore nella lista di giocatori del Player1
                            {

                                    PunteggioSquadra1 = squadra1.punteggio();//attrinbuisco all int punteggiosquadra1 il risultato della funzione punteggio
                                    PunteggioSquadraFinale1 = PunteggioSquadraFinale1 + PunteggioSquadra1; //sommo la funzione punteggioSquadra a PunteggioSquadraFinale per ottenre il punteggio finale della squadra

                                }
                                Console.WriteLine($"Squadra {P1.NomeSquadra} punti: {PunteggioSquadraFinale1} ");//scrivo il punteggio finale di squadra 1 ogni giornata
                                foreach (Giocatore squadra2 in GiocatoriPlayer2)//con il cilco foreach ad ogni iterazione calcolo il punteggio di ogni giocatore nella lista di giocatori del Player2
                                {

                                    PunteggioSquadra2 = squadra2.punteggio();//attrinbuisco all int punteggiosquadra2 il risultato della funzione punteggio
                                    PunteggioSquadraFinale2 = PunteggioSquadraFinale2 + PunteggioSquadra2; //sommo la funzione punteggioSquadra a PunteggioSquadraFinale per ottenre il punteggio finale della squadra

                                }
                                Console.WriteLine($"Squadra {P2.NomeSquadra} punti: {PunteggioSquadraFinale2} ");//scrivo il punteggio finale di squadra 2 di ogni giornata
                            }
                            if(PunteggioSquadraFinale1 > PunteggioSquadraFinale2) //Se il punteggio di Player 1 dopo 5 giornate è maggiore di Player 2 assegno la vittoria al Player 1
                            {
                            Console.WriteLine($"Complimenti {P1.NickName}, hai vinto la partita di FantaCalcio!!!");
                            Console.WriteLine("Chiusura Applicazione...");
                            }
                            else if (PunteggioSquadraFinale2 > PunteggioSquadraFinale1) //Se il punteggio di Player 2  dopo 5 giornate è maggiore di Player 1 assegno la vittoria al Player 2
                            {
                            Console.WriteLine($"Complimenti {P2.NickName}, hai vinto la partita di FantaCalcio!!!");
                            Console.WriteLine("Chiusura Applicazione...");
                            }
                            else if (PunteggioSquadraFinale1 == PunteggioSquadraFinale2) //Se il punteggio di Player 1 dopo 5 giornate è uguale a quello di Player 2 assegno il pareggio
                            {
                            Console.WriteLine($"{P1.NickName} e {P2.NickName} avete realizzato gli stessi punti la partita finisce in pareggio!");
                            Console.WriteLine("Chiusura Applicazione...");
                            }
                            break;
                        case "3":
                            Environment.Exit(3);//se la scelta è uguale a "3" chiudo il programma
                            break;
                    }
                }
                Console.ReadKey();
            }
    }
}
