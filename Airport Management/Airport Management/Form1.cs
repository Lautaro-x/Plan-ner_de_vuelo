﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airport_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void borrarVentanaAnterior ()
        {
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                this.MdiChildren[i].Close();
            }
        }

       public void abrirVentana (Form frm)
        {
            frm.MdiParent = this;
            frm.Show();
        }
        private void agregarAviónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            borrarVentanaAnterior();
            agregarAvion agreAvion = new agregarAvion();
            abrirVentana(agreAvion);
           
        }

        private void modificarAviónToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            borrarVentanaAnterior();
            modificarAvionn modAvion = new modificarAvionn();
            abrirVentana(modAvion);
        }

        private void eliminarAviónToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            borrarVentanaAnterior();
            eliminarAvion elimAvion = new eliminarAvion();
            abrirVentana(elimAvion);
        }

        private void agregarVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            borrarVentanaAnterior();
            agregarVuelo agregVuelo = new agregarVuelo();
            abrirVentana(agregVuelo);
        }

        private void modificarVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            borrarVentanaAnterior();
            modificarVuelo modVuelo = new modificarVuelo();
            abrirVentana(modVuelo);
        }

        private void eliminarVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            borrarVentanaAnterior();
            eliminarVuelo elimVuelo = new eliminarVuelo();
            abrirVentana(elimVuelo);
        }

        private void listarAvionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            borrarVentanaAnterior();
            listarAviones listarAviones = new listarAviones();
            abrirVentana(listarAviones);
        }

        private void listarVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            borrarVentanaAnterior();
            listarVuelos listarVuelos = new listarVuelos();
            abrirVentana(listarVuelos);
        }
    }
}
