using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEtudiants
{
    public class Module
    {
        static readonly string cinstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\moami\source\repos\GestionEtudiants\GestionEtudiants\GestionEtudiants.mdf;Integrated Security=True";
        string nom;
        int nv;

        public Module(string nom, int nv)
        {
            this.nom = nom;
            this.nv = nv;
        }

        public Module()
        {
        }

        public string Nom { get => nom; set => nom = value; }
        public int Nv { get => nv; set => nv = value; }

        public static DataTable afficherModule()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("select M.idMd , M.nom , M.nivaux ,M.idFl , M.idEns , F.nomFl , E.nom from Module M ,Filier F , Enseignnant E where M.idEns=E.idEns And M.idFl = F.IdFilier", cinstr)
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

        public static void ajouterModule(string nom,int nv, int idEns,int idFl)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO  Module (nom,nivaux,idEns,idFl) VALUES (@nom,@nv,@idEns,@idFl)";
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@nv", nv);
                cmd.Parameters.AddWithValue("@idEns", idEns);
                cmd.Parameters.AddWithValue("@idFl", idFl);
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

        public static void ajouterModule(Module m, int idEns, int idFl)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO  Module (nom,nivaux,idEns,idFl) VALUES (@nom,@nv,@idEns,@idFl)";
                cmd.Parameters.AddWithValue("@nom", m.Nom);
                cmd.Parameters.AddWithValue("@nv", m.Nv);
                cmd.Parameters.AddWithValue("@idEns", idEns);
                cmd.Parameters.AddWithValue("@idFl", idFl);
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

        public static void supprimerModule(int idMd)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;


                cmd.CommandText = "DELETE FROM Module WHERE idMd = @idMd ";
                cmd.Parameters.AddWithValue("@idMd", idMd);
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

        public static void modifierModule(string nom, int nv, int idEns,int idMd)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = cinstr;
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE Module SET nom = @nom , nivaux = @nv , idEns = idEns where idMd=@idMd";
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@nv", nv);
                cmd.Parameters.AddWithValue("@idEns", idEns);
                cmd.Parameters.AddWithValue("@idMd", idMd);
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

        public static DataTable afficherModule(string rq)
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
                return afficherModule();
            }
        }
        public static DataTable afficherModule(int idEns)
        {
            string rq = String.Format("select * from Module where idEns = {0}", idEns);

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
                return afficherModule();
            }
        }
    }
}
