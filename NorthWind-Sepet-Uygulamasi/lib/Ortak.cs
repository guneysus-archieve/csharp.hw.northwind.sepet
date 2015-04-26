﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind_Sepet_Uygulamasi
{

    public static class Ortak
    {
        public static List<Musteri> musteriler = new List<Musteri>();
        public static List<Urun> urunler = new List<Urun>();
        public static List<Siparis> siparisler = new List<Siparis>();
        public static SqlConnection conn;

        public static class cek
        {
            public static void connect()
            {
                string baglanti = @"server=.; database={0}; Integrated Security = sspi;";
                try
                {
                    conn = new SqlConnection(connectionString: String.Format(baglanti, "Northwind"));
                    conn.Open();
                }
                catch
                {
                    conn = new SqlConnection(connectionString: String.Format(baglanti, "Northwnd"));
                    conn.Open();
                }
            }
            public static void disconnect()
            {
                conn.Close();
            }
            public static void musteri()
            {
                connect();
                SqlDataReader kafa = new SqlCommand(
                    cmdText: "select CustomerID, ContactName from Customers", connection: conn).ExecuteReader();

                while (kafa.Read())
                {
                    musteriler.Add(new Musteri()
                    {
                        id = (string)kafa["CustomerID"],
                        name = (string)kafa["ContactName"]
                    });
                    System.Diagnostics.Trace.WriteLine(kafa["CustomerID"]);
                }
                disconnect();
            }

            public static void urun()
            {
                connect();
                SqlDataReader kafa = new SqlCommand(
                    cmdText: "select ProductID, ProductName from Products", connection: conn).ExecuteReader();

                while (kafa.Read())
                {
                    urunler.Add(new Urun()
                    {
                        id = (int)kafa["ProductID"],
                        name = (string)kafa["ProductName"]
                    });
                }
                disconnect();
            }

            public static void siparis()
            {
                connect();
                disconnect();
            }
        }
    }
}
