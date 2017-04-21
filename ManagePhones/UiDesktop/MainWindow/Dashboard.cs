﻿using System;
using System.Windows.Forms;
using MetroFramework.Controls;
using UiDesktop.Panels;

namespace UiDesktop
{
    public partial class Dashboard : MetroUserControl
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void mtModelos_Click(object sender, EventArgs e)
        {
            if (!Main.Instancia.Panel.Controls.ContainsKey(ManageModels.Instancia.Key))
            {
                ManageModels.Instancia.Dock = DockStyle.Fill;
                Main.Instancia.Panel.Controls.Add(ManageModels.Instancia);               
            }
            ManageModels.Instancia.LoadData();
            Main.Instancia.Panel.Controls[ManageModels.Instancia.Key].BringToFront();
            Main.Instancia.LinkBack.Visible = true;
        }

        private void mtClientes_Click(object sender, EventArgs e)
        {
            if (!Main.Instancia.Panel.Controls.ContainsKey(ManageClients.Instancia.Key))
            {
                ManageClients.Instancia.Dock = DockStyle.Fill;
                Main.Instancia.Panel.Controls.Add(ManageClients.Instancia);
            }
            ManageClients.Instancia.LoadData();
            Main.Instancia.Panel.Controls[ManageClients.Instancia.Key].BringToFront();
            Main.Instancia.LinkBack.Visible = true;
        }
    }
}
