using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiants
{
    public class Filier
    {
        static readonly string cinstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moami\source\repos\GestionEtudiants\GestionEtudiants\GestionEtudiants.mdf;Integrated Security=True";
        string nom;

        public Filier()
        {
        }

        public Filier(string nom)
        {
            this.Nom = nom;
        }

        public string Nom { get => nom; set => nom = value; }

        public static DataTable afficherFilier()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("select F.idFilier , F.nomFl , E.nom ,E.idEns from Filier F , Enseignnant E where F.idEns = E.idEns", cinstr)
                {
                    MissingSchemaAction = MissingSchemaAction.AddWithKey
                };
                adapter.Fill(dt);
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static void ajouterFilier(string nom,int idEns)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO  Filier (nomFL,idEns) VALUES (@nom,@idEns)";
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@idEns", idEns);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch
            {
                return;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void ajouterFilier(Enseignant es,int idEns)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO  Filier (nom,idEns) VALUES (@nom,@idEns)";
                cmd.Parameters.AddWithValue("@nom", es.Nom);
                cmd.Parameters.AddWithValue("@idEns", idEns);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch
            {
                return;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void supprimerFilier(int idFlilier)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;


                cmd.CommandText = "DELETE FROM Filier WHERE idFilier = @idFilier ";
                cmd.Parameters.AddWithValue("@idFilier", idFlilier);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch
            {
                return;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void modifierFilier(int idFilier, string nom)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE Filier SET nomFl = @nom where idFilier=@idFilier";
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@idFilier", idFilier);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch
            {
                return;
            }
            finally
            {
                cn.Close();
            }
        }

        public static DataTable afficherFilier(string name , int idEns)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            string rq = "select * from Filier where ";
            if(name != "" && idEns > 0)
                rq = String.Format("{0}nomFl = {1} And idEns ={2} ", rq, name,idEns);
            else if (name !="")
                rq =String.Format("{0}nomFl = {1} ",rq,name);
            else if(idEns>0)
                rq = String.Format("{0}idEns = {1}", rq, idEns);
            DataTable dt = new DataTable();
            try
            {
                adapter = new SqlDataAdapter(rq, cinstr)
                {
                    MissingSchemaAction = MissingSchemaAction.AddWithKey
                };
                adapter.Fill(dt);
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                return dt;
            }
            catch
            {
                return afficherFilier();
            }
        }


    }
}
