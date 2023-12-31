﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Event
    {
        public string title = "nome non disponibile";
        public DateTime date;
        public int maxCapacity;
        public int reservedSeats;

        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Il titolo non può essere vuoto");
                }

                title = value.ToString();
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("La data inserita è errata, non può essere passata");
                }

                date = value;
            }
        }

        public int MaxCapacity
        {
            get { return maxCapacity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(maxCapacity), "La capienza massima dell'evento deve essere un numero positivo");
                }

                maxCapacity = value;
            }
        }

        public int ReservedSeats
        {
            get { return reservedSeats; }
        }

        // COSTRUTTORE
        public Event(string title, DateTime date, int maxCapacity)
        {
            this.Title = title;
            this.Date = date;
            this.MaxCapacity = maxCapacity;
            this.reservedSeats = 0;
        }


        // METODI
        public int ReserveSeats(int placesToReserve)
        {
            if (date < DateTime.Now)
            {
                throw new Exception("Evento non disponibile, evento già passato");
            }
            if (placesToReserve <= 0 )
            {
                throw new Exception("Il numero dei posti da prenotare deve essere maggiore di zero");
            }
            if (ReservedSeats + placesToReserve > maxCapacity)
            {
                throw new Exception("Numero di posti disponibili insufficente");
            }

            return reservedSeats += placesToReserve;
        }

        public int CancelSeats(int placesToCancel)
        {
            if (date < DateTime.Now)
            {
                throw new Exception("Evento non disponibile, evento già passato");
            }

            if (placesToCancel > reservedSeats)
            {
                throw new Exception("Il numero dei posti da disdire è superiore ai posti prenotati");
            }

            return reservedSeats -= placesToCancel;
        }

        public override string ToString()
        {
            string formattedDate = this.Date.ToString("dd/MM/yyyy");
            return formattedDate + this.Title;
        }

        public void PrintReservedAndAvailableSeats()
        {
            Console.WriteLine("Numero di posti prenotati = " + reservedSeats);
            Console.WriteLine("Numero di posti disponibili = " + (this.MaxCapacity - this.reservedSeats));
        }
    }
}
