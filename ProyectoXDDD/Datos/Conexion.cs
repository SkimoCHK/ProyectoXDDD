using System.Data.SqlClient;
namespace ProyectoXDDD.Datos
{
    public class Conexion
    {
        private string cadenaSql = string.Empty;

        public Conexion()
        {
            var Builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile
                ("" + "appsettings.json").Build();
            cadenaSql = Builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSql()
        {
            return cadenaSql;
        }

    }
}
