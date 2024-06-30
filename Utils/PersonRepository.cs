using cGuambaS5.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cGuambaS5.Utils
{
    public class PersonRepository
    {
        string _dbPath; //Ruta
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();
        }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string nombre)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre requerido");
                Persona person = new()
                {
                    Nombre = nombre
                };

                result = conn.Insert(person);
                StatusMessage = string.Format("Datos añadidos correctamente: {0} registros añadidos (Nombre: {1})", result, nombre);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al añadir persona: {0}", ex.Message);
            }

        }

        public void UpdatePerson(Persona person)
        {
            try
            {
                if (person != null)
                {
                    conn.Update(person);
                }
                else
                {
                    throw new Exception("Persona null");
                }
                StatusMessage = $"Persona actualizada correctamente: {person.Nombre}";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

        }

        public void DeletePerson(Persona person)
        {
            try
            {
                if (person != null)
                {
                    conn.Delete(person);
                    StatusMessage = $"Persona eliminada correctamente: {person.Nombre}";
                }
                else
                {
                    throw new Exception("Persona no encontrada");
                }
            }catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public List<Persona> GetAllPeople()
        {

            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = String.Format("Error al listar personas: {0}", ex.Message);
            }
            return new List<Persona>();
        }
    }
}
