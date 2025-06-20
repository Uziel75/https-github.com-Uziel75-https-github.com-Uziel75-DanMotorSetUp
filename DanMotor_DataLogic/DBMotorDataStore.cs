using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using DanMotor.Common;

namespace DanMotor.Data
{
    public class DbMotoDataStore : IDataStore
    {
        string conStr = "Data Source=DESKTOP-AB2SS01;Initial Catalog=DanMotorDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";



        public List<string> GetBrands() => GetList("SELECT DISTINCT Brand FROM Motors");
        public List<string> GetModels(string brand) => GetList("SELECT DISTINCT Model FROM Motors WHERE Brand = @Brand", "@Brand", brand);
        public List<string> GetConcepts(string brand, string model) => GetList("SELECT DISTINCT Concept FROM Motors WHERE Brand = @Brand AND Model = @Model", "@Brand", brand, "@Model", model);
        public List<string> GetParts(string brand, string model, string concept) => GetList("SELECT Part FROM Motors WHERE Brand = @Brand AND Model = @Model AND Concept = @Concept", "@Brand", brand, "@Model", model, "@Concept", concept);

        public bool AddPart(string brand, string model, string concept, string part)
        {
            if (Exists(brand, model, concept, part)) return false;
            using var con = new SqlConnection(conStr);
            con.Open();
            var cmd = new SqlCommand("INSERT INTO Motors (Brand, Model, Concept, Part) VALUES (@B,@M,@C,@P)", con);
            cmd.Parameters.AddWithValue("@B", brand);
            cmd.Parameters.AddWithValue("@M", model);
            cmd.Parameters.AddWithValue("@C", concept);
            cmd.Parameters.AddWithValue("@P", part);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool EditPart(string brand, string model, string concept, string oldPart, string newPart)
        {
            using var con = new SqlConnection(conStr);
            con.Open();
            var cmd = new SqlCommand("UPDATE Motors SET Part = @New WHERE Brand = @B AND Model = @M AND Concept = @C AND Part = @Old", con);
            cmd.Parameters.AddWithValue("@New", newPart);
            cmd.Parameters.AddWithValue("@B", brand);
            cmd.Parameters.AddWithValue("@M", model);
            cmd.Parameters.AddWithValue("@C", concept);
            cmd.Parameters.AddWithValue("@Old", oldPart);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool DeletePart(string brand, string model, string concept, string part)
        {
            using var con = new SqlConnection(conStr);
            con.Open();
            var cmd = new SqlCommand("DELETE FROM Motors WHERE Brand=@B AND Model=@M AND Concept=@C AND Part=@P", con);
            cmd.Parameters.AddWithValue("@B", brand);
            cmd.Parameters.AddWithValue("@M", model);
            cmd.Parameters.AddWithValue("@C", concept);
            cmd.Parameters.AddWithValue("@P", part);
            return cmd.ExecuteNonQuery() > 0;
        }

        public List<string> SearchParts(string brand, string model, string concept, string keyword)
        {
            return GetList("SELECT Part FROM Motors WHERE Brand=@B AND Model=@M AND Concept=@C AND Part LIKE @K", "@B", brand, "@M", model, "@C", concept, "@K", "%" + keyword + "%");
        }

        private bool Exists(string brand, string model, string concept, string part)
        {
            using var con = new SqlConnection(conStr);
            con.Open();
            var cmd = new SqlCommand("SELECT COUNT(*) FROM Motors WHERE Brand=@B AND Model=@M AND Concept=@C AND Part=@P", con);
            cmd.Parameters.AddWithValue("@B", brand);
            cmd.Parameters.AddWithValue("@M", model);
            cmd.Parameters.AddWithValue("@C", concept);
            cmd.Parameters.AddWithValue("@P", part);
            return (int)cmd.ExecuteScalar() > 0;
        }

        private List<string> GetList(string query, params string[] args)
        {
            List<string> list = new();
            using var con = new SqlConnection(conStr);
            con.Open();
            var cmd = new SqlCommand(query, con);
            for (int i = 0; i < args.Length; i += 2)
                cmd.Parameters.AddWithValue(args[i], args[i + 1]);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(reader[0].ToString());
            return list;
        }
    }
}
