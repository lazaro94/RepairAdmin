﻿using ManagePhones.DataAccess.Repositories;
using ManagePhones.Entities.Entidades;
using ManagePhones.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ManagePhones.Logic.Logic
{
    public class LogicClient
    {
        private ClientRepository _clientRepository;

        public async Task InsertNewCliente(Cliente cliente)
        {
            _clientRepository = new ClientRepository();
            try
            {
                await _clientRepository.Insert(cliente);
            }
            catch(SqlException sqlex)
            {
                throw new LoggedException("Error al actualizar la tabla de clientes.", Util.Enums.ExType.Error, sqlex);
            }
            catch(Exception ex)
            {
                throw new LoggedException("Se produjo un error al intentar insertar el nuevo cliente.", Util.Enums.ExType.Fatal, ex);
            }
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            _clientRepository = new ClientRepository();
            try
            {
                await _clientRepository.Update(cliente);
            }
            catch (SqlException sqlex)
            {
                throw new LoggedException("Error al actualizar la tabla de clientes.", Util.Enums.ExType.Error, sqlex);
            }
            catch (Exception ex)
            {
                throw new LoggedException("Se produjo un error al intentar modificar el cliente.", Util.Enums.ExType.Fatal, ex);
            }
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            _clientRepository = new ClientRepository();
            try
            {
                return await _clientRepository.GetAll();
            }
            catch (SqlException sqlex)
            {
                throw new LoggedException("Error al consultar la tabla de clientes.", Util.Enums.ExType.Error, sqlex);
            }
            catch (Exception ex)
            {
                throw new LoggedException("Se produjo un error al intentar obtener los clientes.", Util.Enums.ExType.Fatal, ex);
            }
        }
    }
}
