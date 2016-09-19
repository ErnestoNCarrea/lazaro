using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Tareas
{
        public partial class Novedad
        {

                #region Código generado por el Diseñador de Windows Forms

                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }


                private System.ComponentModel.IContainer components = null;

                internal Lui.Forms.Label Label1;
                internal Lcc.Entrada.CodigoDetalle EntradaEncargado;
                internal Lui.Forms.TextBox EntradaDescripcion;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.TextBox EntradaMinutos;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.ComboBox EntradaCondicion;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.Label Label5;
                internal Lcc.Entrada.CodigoDetalle EntradaTicket;

                private void InitializeComponent()
                {
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaEncargado = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaDescripcion = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaMinutos = new Lui.Forms.TextBox();
                        this.EntradaCondicion = new Lui.Forms.ComboBox();
                        this.Label3 = new Lui.Forms.Label();
                        this.Label4 = new Lui.Forms.Label();
                        this.EntradaTicket = new Lcc.Entrada.CodigoDetalle();
                        this.Label5 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(24, 240);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(88, 24);
                        this.Label1.TabIndex = 8;
                        this.Label1.Text = "Vendedor";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaEncargado
                        // 
                        this.EntradaEncargado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaEncargado.AutoTab = true;
                        this.EntradaEncargado.CanCreate = true;
                        this.EntradaEncargado.Filter = "(tipo&4)=4";
                        this.EntradaEncargado.Location = new System.Drawing.Point(112, 240);
                        this.EntradaEncargado.MaxLength = 200;
                        this.EntradaEncargado.Name = "EntradaEncargado";
                        this.EntradaEncargado.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaEncargado.Required = true;
                        this.EntradaEncargado.Size = new System.Drawing.Size(496, 24);
                        this.EntradaEncargado.TabIndex = 9;
                        this.EntradaEncargado.Text = "0";
                        // 
                        // EntradaDescripcion
                        // 
                        this.EntradaDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaDescripcion.Location = new System.Drawing.Point(112, 56);
                        this.EntradaDescripcion.MultiLine = true;
                        this.EntradaDescripcion.Name = "EntradaDescripcion";
                        this.EntradaDescripcion.Size = new System.Drawing.Size(496, 124);
                        this.EntradaDescripcion.TabIndex = 3;
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(280, 192);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(68, 24);
                        this.Label2.TabIndex = 6;
                        this.Label2.Text = "Tiempo";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaMinutos
                        // 
                        this.EntradaMinutos.Location = new System.Drawing.Point(348, 192);
                        this.EntradaMinutos.Name = "EntradaMinutos";
                        this.EntradaMinutos.Size = new System.Drawing.Size(76, 24);
                        this.EntradaMinutos.TabIndex = 7;
                        // 
                        // EntradaCondicion
                        // 
                        this.EntradaCondicion.AlwaysExpanded = true;
                        this.EntradaCondicion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCondicion.AutoSize = true;
                        this.EntradaCondicion.Location = new System.Drawing.Point(112, 192);
                        this.EntradaCondicion.Name = "EntradaCondicion";
                        this.EntradaCondicion.SetData = new string[] {
        "Publica|0",
        "Interna|1"};
                        this.EntradaCondicion.Size = new System.Drawing.Size(152, 40);
                        this.EntradaCondicion.TabIndex = 5;
                        this.EntradaCondicion.TextKey = "0";
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(24, 192);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(88, 24);
                        this.Label3.TabIndex = 4;
                        this.Label3.Text = "Visibilidad";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(24, 56);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(88, 24);
                        this.Label4.TabIndex = 2;
                        this.Label4.Text = "Asunto";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaTicket
                        // 
                        this.EntradaTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaTicket.AutoTab = true;
                        this.EntradaTicket.CanCreate = true;
                        this.EntradaTicket.Location = new System.Drawing.Point(112, 24);
                        this.EntradaTicket.MaxLength = 200;
                        this.EntradaTicket.Name = "EntradaTicket";
                        this.EntradaTicket.NombreTipo = "Lbl.Tareas.Tarea";
                        this.EntradaTicket.Required = true;
                        this.EntradaTicket.Size = new System.Drawing.Size(496, 24);
                        this.EntradaTicket.TabIndex = 1;
                        this.EntradaTicket.Text = "0";
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(24, 24);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(88, 24);
                        this.Label5.TabIndex = 0;
                        this.Label5.Text = "Tarea";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Novedad
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(634, 374);
                        this.Controls.Add(this.EntradaMinutos);
                        this.Controls.Add(this.EntradaTicket);
                        this.Controls.Add(this.EntradaCondicion);
                        this.Controls.Add(this.EntradaDescripcion);
                        this.Controls.Add(this.EntradaEncargado);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.Label1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Novedad";
                        this.Text = "Novedad: Cargar";
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.Label3, 0);
                        this.Controls.SetChildIndex(this.Label4, 0);
                        this.Controls.SetChildIndex(this.Label5, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.EntradaEncargado, 0);
                        this.Controls.SetChildIndex(this.EntradaDescripcion, 0);
                        this.Controls.SetChildIndex(this.EntradaCondicion, 0);
                        this.Controls.SetChildIndex(this.EntradaTicket, 0);
                        this.Controls.SetChildIndex(this.EntradaMinutos, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion
        }
}
