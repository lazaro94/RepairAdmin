﻿using System;
using System.Collections.Generic;
using UiDesktop.ABMWindows;
using ManagePhones.Logic.Logic;
using ManagePhones.Util.Exceptions;
using ManagePhones.Util.Enums;
using ManagePhones.Entities.Entidades;

namespace UiDesktop.Panels
{
    public partial class ManageModels : MiddleUC
    {
        private const string KEYNAME = "ManageModels";
        public string Key
        {
            get
            {
                return KEYNAME;
            }
        }

        #region Singleton
        private static ManageModels _instancia;

        public static ManageModels Instancia
        {
            get
            {
                if (_instancia == null)
                {                   
                    _instancia = new ManageModels();
                }
                return _instancia;
            }
        }

        private ManageModels()
        {
            InitializeComponent();
        }
        #endregion

        private LogicModel logicModel;
        private Modelo currentModel;

        public async override void LoadData()
        {
            logicModel = new LogicModel();
            gridModelos.Rows.Clear();
            try
            {
                IEnumerable<Modelo> listModelos = await logicModel.GetAll();
                foreach(Modelo m in listModelos)
                {
                    // IdModelo | IdMarca | Marca | Nombre | Descripcion //
                    gridModelos.Rows.Add(m.Id, m.Marca.Id, m.Marca.Name, m.Nombre, m.Descripcion);
                }
            }
            catch(LoggedException logex)
            {
                base.ShowError(logex.Message, "Cargar Modelos");
            }
            catch(Exception ex)
            {
                base.ShowError(ex.Message, "Cargar Modelos");
            }            
        }

        protected override void linkEdit_Click(object sender, System.EventArgs e)
        {
            MapFromGrid();
            ABMModel abmWin = new ABMModel();
            abmWin.Caller = CallerType.Panel;
            abmWin.MapToForm(currentModel);
            abmWin.Show();
        }

        protected override void linkNew_Click(object sender, System.EventArgs e)
        {
            currentModel = new Modelo();
            currentModel.Id = 0;
            ABMModel abmWin = new ABMModel();
            abmWin.Caller = CallerType.Panel;
            abmWin.MapToForm(currentModel);
            abmWin.Show();
        }

        protected void MapFromGrid()
        {
            currentModel = new Modelo();
            currentModel.Marca = new Marca();
            try
            {
                currentModel.Id = int.Parse(gridModelos.CurrentRow.Cells["Id"].Value.ToString());
                currentModel.Marca.Id = int.Parse(gridModelos.CurrentRow.Cells["IdMarca"].Value.ToString());
                currentModel.Descripcion = gridModelos.CurrentRow.Cells["Descripcion"].Value.ToString();
                currentModel.Nombre = gridModelos.CurrentRow.Cells["Modelo"].Value.ToString();
                currentModel.Marca.Name = gridModelos.CurrentRow.Cells["Marca"].Value.ToString();
            }
            catch(Exception ex)
            {
                base.ShowError(ex.Message, "Editar Modelo");
            } 
        }
    }
}
