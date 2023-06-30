using Aplicacion.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Data
{
    public class SQLiteHelper
    {

        readonly SQLiteAsyncConnection db;

        /// <summary>
        /// Método para crear Tablas
        /// </summary>
        /// <param name="dbPath"></param>
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<UsuariosModels>().Wait();
            db.CreateTableAsync<TipoPreguntaModels>().Wait();
            db.CreateTableAsync<CursosModels>().Wait();
            db.CreateTableAsync<PreguntasModels>().Wait();
            db.CreateTableAsync<AdministradorModels>().Wait();
        }

        /// <summary>
        /// Método para guardar registros de usuarios o actualizarlos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Task<int> SaveUsuarioAsync(UsuariosModels usuario)
        {
            if (usuario.Id_usuario != 0)
            {
                return db.UpdateAsync(usuario);
            }
            else
            {
                return db.InsertAsync(usuario);
            }
        }

        /// <summary>
        /// Método para obtener registros de usuarios
        /// </summary>
        /// <returns></returns>
        public Task<List<UsuariosModels>> GetUsuariosAsync()
        {
            return db.Table<UsuariosModels>().ToListAsync();
        }

        /// <summary>
        /// Método para guardar registros de administradores o editarlos
        /// </summary>
        /// <param name="administrador"></param>
        /// <returns></returns>
        public Task<int> SaveOfAdministradorAsync(AdministradorModels administrador)
        {
            if (administrador.Id_administrador != 0)
            {
                return db.UpdateAsync(administrador);
            }
            else
            {
                return db.InsertAsync(administrador);
            }
        }

        /// <summary>
        /// Método para obtener registros de administradores
        /// </summary>
        /// <returns></returns>
        public Task<List<AdministradorModels>> GetOfAdministradorAsync()
        {
            return db.Table<AdministradorModels>().ToListAsync();
        }

    }
}
