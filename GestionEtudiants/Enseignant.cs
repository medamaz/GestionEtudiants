using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiants
{
    public class Enseignant
    {
        static readonly string cinstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moami\source\repos\GestionEtudiants\GestionEtudiants\GestionEtudiants.mdf;Integrated Security=True";
        string nom;
        string spesialite;

        public Enseignant()
        {
        }

        public Enseignant(string nom, string spesialite)
        {
            this.Nom = nom;
            this.Spesialite = spesialite;
        }

        public string Nom { get => nom; set => nom = value; }

        public string Spesialite { get => spesialite; set => spesialite = value; }

        public static DataTable afficherEnseignnant()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("select * from Enseignnant", cinstr)
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

        public static void ajouterEnseignant(string nom , string Sp)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO  Enseignnant (nom,spesialite) VALUES (@nom,@spesialite)";
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@spesialite", Sp);
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

        public static void ajouterEnseignant(Enseignant es)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO  Enseignnant (nom,spesialite) VALUES (@nom,@spesialite)";
                cmd.Parameters.AddWithValue("@nom", es.Nom);
                cmd.Parameters.AddWithValue("@spesialite", es.Spesialite);
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

        public static void supprimerEnseignant(int idEns)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;


                cmd.CommandText = "DELETE FROM Enseignnant WHERE idEns = @idEns ";
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

        public static void modifierEnseignant(int idEns, Enseignant es)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE Enseignnant SET nom = @nom,  spesialite= @spesialite where idEns=@idEns";
                cmd.Parameters.AddWithValue("@idEns", idEns);
                cmd.Parameters.AddWithValue("@nom", es.Nom);
                cmd.Parameters.AddWithValue("@spesialite", es.Spesialite);
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

        public static DataTable afficherEnseignnant(string nom ,string spes)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            string rq = "select * from Enseignnant where ";
            if (nom != "" && spes != "")
                rq = String.Format("{0} nom = '{1}' And spesialite = '{2}'", rq, nom,spes);
            else
            {
                if (spes != "")
                    rq = String.Format("{0} spesialite = '{1}'", rq, spes);
                if (nom != "")
                    rq = String.Format("{0} nom = '{1}'", rq, nom);
            }
            
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
                return Enseignant.afficherEnseignnant();
            }
        }

    }
}
