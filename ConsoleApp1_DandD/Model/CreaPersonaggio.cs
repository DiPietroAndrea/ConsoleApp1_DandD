﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_DandD.Model
{
    public class CreaPersonaggio
    {
        #region ---> Dichiarazioni
        private String nome;
        private String cognome;
        private int eta;
        private String sesso;
        private String luogoNascita;
        #endregion

        #region ---> Costruttori
        public CreaPersonaggio() : this(string.Empty, string.Empty, 0, string.Empty, string.Empty)
        {
        }

        public CreaPersonaggio(string n, string c, int e, string s, string ln)
        {
            nome = n;
            cognome = c;
            eta = e;
            sesso = s;
            luogoNascita = ln;
        }
        #endregion

        #region ---> Proprietà
        public string Nome
        { get { return nome; } set { nome = value; } }
        public string Cognome
        { get { return cognome; } set { cognome = value; } }
        public int Eta
        { get { return eta; } set { eta = value; } }
        public String Sesso
        { get { return sesso; } set { sesso = value; } }
        public String LuogoNascita
        { get { return luogoNascita; } set { luogoNascita = value; } }
        #endregion

        #region ---> Metodi
        public virtual string stampaScheda()
        {
            return ("Nome: " + nome + "\r\n" + "Cognome: " + cognome + "\r\n" + "Età: " + eta + "\r\n" + "Sesso: " + sesso + "\r\n" + "Luogo di nascita: " + luogoNascita + "\r\n");
        }
        #endregion
    }
}