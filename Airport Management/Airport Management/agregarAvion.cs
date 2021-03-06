﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Airport_Management.Clases;

namespace Airport_Management
{
    public partial class agregarAvion : Form
    {
        public agregarAvion()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            GestionAviones ga = new GestionAviones();

            try
            {
                ga.insertarAvion("Aviones", txtCodigo.Text, txtTipo.Text);
                MessageBox.Show("Avión agregado!");
                txtCodigo.Clear();
                txtTipo.Clear();
                txtCodigo.Select();
            }
            catch(SyntaxErrorException re)
            {
                MessageBox.Show(re.ToString());
            }
        }
    }
}
