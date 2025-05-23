﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GestioneStudenti.ClsStudenti;
using static GestioneStudenti.ClsValutazioni;

namespace GestioneStudenti
{
    public class ClsValutazioni
    {
        static string[] _datiValutazioni =
        {
            "Inglese 7 O 1",
            "Informatica 5 L 2",
            "Informatica 4 S 3",
            "Sistemi 9 O 4",
            "Inglese 5 S 5",
            "Sistemi 3 L 6",
            "Sistemi 8 O 7",
            "Italiano 6 S 8",
            "Sistemi 8 O 8"
        };

        public struct Valutazione
        {
            public string materia;
            public int voto;
            public string tipo;
            public int matricola;
        }

        public static Valutazione[] Valutazioni;
        static int _nValutazioni = 0;

        public static List<string> CaricaDatiValutazioni()
        {
            List<string> listMaterie = new List<string>();
            string[] dati = new string[3];

            for (int i = 0; i < _datiValutazioni.Length; i++)
            {
                _nValutazioni++;
                Array.Resize(ref Valutazioni, _nValutazioni);
                dati = _datiValutazioni[i].Split(' ');
                Valutazioni[_nValutazioni - 1].materia = dati[0];
                Valutazioni[_nValutazioni - 1].voto = Convert.ToInt32(dati[1]);
                Valutazioni[_nValutazioni - 1].tipo = dati[2];
                Valutazioni[_nValutazioni - 1].matricola = Convert.ToInt32(dati[3]);
                // Popolo anche listMaterie
                // Meglio farlo fisso da desiner
                if (!listMaterie.Contains(dati[0]))
                    listMaterie.Add(dati[0]);
            }
            return listMaterie;
        }

        public static Valutazione InserisciVoto(string materia, string tipo, int voto, int matricola)
        {
            _nValutazioni++;
            Array.Resize(ref Valutazioni, _nValutazioni);
            Valutazione val = new Valutazione
            {
                materia = materia,
                tipo = tipo,
                voto = voto,
                matricola = matricola
            };
            Valutazioni[_nValutazioni - 1] = val;
            return val;
        }


        public static double MediaPerMateria(string materia)
        {
            int somma = 0, contatore = 0;
            for(int i = 0; i < _nValutazioni; i++)
            {
                if (Valutazioni[i].materia == materia)
                {
                    somma += Valutazioni[i].voto;
                    contatore++;
                }
            }

            if(contatore > 0)
                return somma / contatore;
            else
                return -1;
        }

        public static int ContaVotiPerTipoPerStudente(int matricola, string tipo)
        {
            int contatore = 0;
            for (int i = 0; i < _nValutazioni; i++)
            {
                if (Valutazioni[i].matricola == matricola && Valutazioni[i].tipo == tipo)
                {
                    contatore++;
                }
            }

            /*if (contatore > 0)
                return contatore;
            else
                return -1;*/
            return contatore;
        }

        internal static int ContaVotiPerOgniStudente(ClsStudenti.Studente studente)
        {
            int contatore = 0;

            for (int i = 0; i < _nValutazioni; i++)
            {
                if (Valutazioni[i].matricola == studente.matricola)
                {
                    contatore++;
                }
            }

            return contatore;
        }

        public static double CalcolaMediaPerStudente(ClsStudenti.Studente studente)
        {
            double mediaStud = 0;
            int contatore = 0;
            for(int i = 0; i < _nValutazioni; i++)
            {
                if (studente.matricola == Valutazioni[i].matricola)
                {
                    mediaStud += Valutazioni[i].voto;
                    contatore++;
                }
            }
            return mediaStud/contatore;
        }

        public static int CalcolaNumValutazioni(ClsStudenti.Studente studente)
        {
            int contatore = 0;
            for (int i = 0; i < _nValutazioni; i++)
            {
                if (studente.matricola == Valutazioni[i].matricola)
                {
                    contatore++;
                }
            }
            return contatore;
        }

        public static void OrdinaPerMatricola()
        {
            int posMin;
            Valutazione aus;

            for(int i = 0; i < _nValutazioni; i++)
            {
                posMin = i;
                for(int j = i + 1; j < _nValutazioni; j++)
                {
                    if (Valutazioni[posMin].matricola > Valutazioni[j].matricola)
                        posMin = j;
                }

                if(posMin != i)
                {
                    aus = Valutazioni[posMin];
                    Valutazioni[posMin] = Valutazioni[i];
                    Valutazioni[i] = aus;
                }
            }
        }

        public static string RotturaMatricolaValutazioni()
        {
            int cont = 1;
            string ciao = "";
            for(int i = 0; i < _nValutazioni; i++)
            {
                if (Valutazioni[i].matricola == Valutazioni[i + 1].matricola)
                {
                    cont++;
                }
            }
            return ciao;
        }

        public static bool MaterieSenzaVoti(string materia)
        {
            int contatore = 0;
            for (int i = 0; i < _nValutazioni; i++)
            {
                if (Valutazioni[i].materia == materia)
                {
                    contatore++;
                }
            }
            return contatore == 0 ? true : false;
        }
    }
}
