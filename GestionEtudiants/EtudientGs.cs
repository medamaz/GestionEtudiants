using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiants
{
    public class EtudientGs
    {
        static readonly string cinstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moami\source\repos\GestionEtudiants\GestionEtudiants\GestionEtudiants.mdf;Integrated Security=True";

        public static DataTable afficherEtudiant(int idMd)
        {
            //string rq = String.Format("select E.idEt , E.nivaux , E.nom , E.age , Eg.note , Eg.nbrAbs  from EtudiantGs Eg ,Etudiant E  where E.idEt = Eg.idET And Eg.idMd= {0}", idMd);
            string rq = String.Format("select E.idEt, E.nom ,E.nivaux from Etudiant E, Module M where E.idFl = M.idFl And M.idMd = {0} And E.nivaux = M.nivaux", idMd);

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
                return Etudiant.afficherEtudiant();
            }
        }

        public static DataTable afficherEtudiantGsMd(int idMd)
        {
            string rq = String.Format("select E.nom as 'Etudient Nom', M.nom as 'Module Nom', Eg.idEt, Eg.idMd, Eg.note, Eg.nbrAbs from EtudiantGS Eg, Etudiant E, Module M where Eg.idMd ={0} And E.idEt = Eg.idEt And M.idMd = Eg.idMd", idMd);

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
                return Etudiant.afficherEtudiant();
            }
        }

        public static DataTable afficherEtudiantGsET(int idET)
        {
            string rq = String.Format("select E.nom as 'Etudient Nom', M.nom as 'Module Nom', Eg.idEt, Eg.idMd, Eg.note, Eg.nbrAbs from EtudiantGS Eg, Etudiant E, Module M where Eg.idEt ={0} And E.idEt = Eg.idEt And M.idMd = Eg.idMd", idET);

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
                return Etudiant.afficherEtudiant();
            }
        }

        public static void modifierEtudiantGs(int idMd, int idEt, int Abs, double note)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE EtudiantGs Set nbrAbs = @nbrAbs , note = @note where idEt = @idEt, idMd = @idMd";
                cmd.Parameters.AddWithValue("@idEt", idEt);
                cmd.Parameters.AddWithValue("@idMd", idMd);
                cmd.Parameters.AddWithValue("@nbrAbs", Abs);
                cmd.Parameters.AddWithValue("@note", note);
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


        public static void ajouterEtudiantGs(int idMd , int idEt , int Abs ,double note)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO  EtudiantGs (idEt,idMd,nbrAbs,note) VALUES (@idEt,@idMd,@nbrAbs,@note)";
                cmd.Parameters.AddWithValue("@idEt", idEt);
                cmd.Parameters.AddWithValue("@idMd", idMd);
                cmd.Parameters.AddWithValue("@nbrAbs", Abs);
                cmd.Parameters.AddWithValue("@note", note);
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

        public static void supprimerEtudiantGs(int idEt, int idMd)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;


                cmd.CommandText = "DELETE FROM EtudiantGs WHERE idEt = @idEt And idMd = @idMd";
                cmd.Parameters.AddWithValue("@idMd", idMd);
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


    }
}
