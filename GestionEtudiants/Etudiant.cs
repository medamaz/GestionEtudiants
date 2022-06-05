using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiants
{
    public class Etudiant
    {
        static readonly string cinstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moami\source\repos\GestionEtudiants\GestionEtudiants\GestionEtudiants.mdf;Integrated Security=True";

        string nom;
        DateTime dateN;
        int niveux;

        public Etudiant()
        {
        }

        public Etudiant(string nom, DateTime dateN, int niveux)
        {
            this.nom = nom;
            this.dateN = dateN;
            this.niveux = niveux;

        }

        public string Nom { get => nom; set => nom = value; }
        public DateTime DateN { get => dateN; set => dateN = value; }
        public int Niveux { get => niveux; set => niveux = value; }

        public static DataTable afficherEtudiant()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("select * from  Etudiant", cinstr)
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

        public static void ajouterEtudiant(int nivaux, string nom,DateTime dateN, int idEns)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO  Etudiant (nivaux,nom,dateN,idFl) VALUES (@nivaux,@nom,@dateN,@idFl)";
                cmd.Parameters.AddWithValue("@nivaux", nivaux);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@dateN", dateN);
                cmd.Parameters.AddWithValue("@idFl", idEns);
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

        public static void ajouterEtudiant(Etudiant e, int idEns)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO  Etudiant (nivaux,nom,dateN,idFl) VALUES (@nivaux,@nom,@dateN,@idFl)";
                cmd.Parameters.AddWithValue("@nivaux", e.Niveux);
                cmd.Parameters.AddWithValue("@nom", e.Nom);
                cmd.Parameters.AddWithValue("@dateN", e.DateN);
                cmd.Parameters.AddWithValue("@idFl", idEns);
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

        public static void supprimerEtudiant(int idEt)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;


                cmd.CommandText = "DELETE FROM Etudiant WHERE idEt = @idEt ";
                cmd.Parameters.AddWithValue("@idEt", idEt);
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

        public static void modifierEtudiant(int nivaux, string nom, DateTime dateN, int idEns)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE Etudiant SET nivaux=@nivaux,nom=@nom,dateN=@dateN where idEt=@idEt";
                cmd.Parameters.AddWithValue("@nivaux", nivaux);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@dateN", dateN);
                cmd.Parameters.AddWithValue("@idEt", idEns);
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

        public static DataTable afficherAbsEtudiant(int idEt)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                string rq = String.Format("select * from EtudiantGs where idEt ={0}",idEt);
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
                return null;
            }
        }

        public static DataTable afficherEtudiant(string rq)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
           
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
                return afficherEtudiant();
            }
        }
    }
}
