namespace Lfc.Personas.Usuarios
{
        partial class EditarPermiso
        {
                /// <summary>
                /// Variable del diseñador requerida.
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                /// <summary>
                /// Limpiar los recursos que se estén utilizando.
                /// </summary>
                /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
                protected override void Dispose(bool disposing)
                {
                        if (disposing && (components != null)) {
                                components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                #region Código generado por el Diseñador de Windows Forms

                /// <summary>
                /// Método necesario para admitir el Diseñador. No se puede modificar
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.EntradaObjeto = new Lcc.Entrada.CodigoDetalle();
                        this.Label16 = new Lui.Forms.Label();
                        this.CheckNivelListar = new System.Windows.Forms.CheckBox();
                        this.CheckNivelVer = new System.Windows.Forms.CheckBox();
                        this.CheckNivelImprimir = new System.Windows.Forms.CheckBox();
                        this.CheckNivelCrear = new System.Windows.Forms.CheckBox();
                        this.CheckNivelEditar = new System.Windows.Forms.CheckBox();
                        this.CheckNivelEditarAvanzado = new System.Windows.Forms.CheckBox();
                        this.CheckNivelEliminar = new System.Windows.Forms.CheckBox();
                        this.CheckNivelTotal = new System.Windows.Forms.CheckBox();
                        this.CheckNivelExtra1 = new System.Windows.Forms.CheckBox();
                        this.CheckNivelExtra2 = new System.Windows.Forms.CheckBox();
                        this.CheckNivelExtra3 = new System.Windows.Forms.CheckBox();
                        this.CheckNivelExtraC = new System.Windows.Forms.CheckBox();
                        this.CheckNivelExtraB = new System.Windows.Forms.CheckBox();
                        this.CheckNivelExtraA = new System.Windows.Forms.CheckBox();
                        this.EntradaItems = new Lui.Forms.TextBox();
                        this.Label1 = new Lui.Forms.Label();
                        this.CheckNivelMover = new System.Windows.Forms.CheckBox();
                        this.label2 = new Lui.Forms.Label();
                        this.CheckNivelAdministrar = new System.Windows.Forms.CheckBox();
                        this.SuspendLayout();
                        // 
                        // EntradaObjeto
                        // 
                        this.EntradaObjeto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaObjeto.AutoTab = true;
                        this.EntradaObjeto.CanCreate = true;
                        this.EntradaObjeto.Location = new System.Drawing.Point(120, 20);
                        this.EntradaObjeto.MaxLength = 200;
                        this.EntradaObjeto.Name = "EntradaObjeto";
                        this.EntradaObjeto.NombreTipo = "Lbl.Sys.Permisos.Objeto";
                        this.EntradaObjeto.PlaceholderText = "Ninguno";
                        this.EntradaObjeto.Required = false;
                        this.EntradaObjeto.Size = new System.Drawing.Size(660, 24);
                        this.EntradaObjeto.TabIndex = 1;
                        this.EntradaObjeto.Text = "0";
                        this.EntradaObjeto.TextChanged += new System.EventHandler(this.EntradaObjeto_TextChanged);
                        // 
                        // Label16
                        // 
                        this.Label16.Location = new System.Drawing.Point(24, 20);
                        this.Label16.Name = "Label16";
                        this.Label16.Size = new System.Drawing.Size(96, 24);
                        this.Label16.TabIndex = 0;
                        this.Label16.Text = "Objeto";
                        this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // CheckNivelListar
                        // 
                        this.CheckNivelListar.AutoSize = true;
                        this.CheckNivelListar.Location = new System.Drawing.Point(128, 60);
                        this.CheckNivelListar.Name = "CheckNivelListar";
                        this.CheckNivelListar.Size = new System.Drawing.Size(143, 19);
                        this.CheckNivelListar.TabIndex = 3;
                        this.CheckNivelListar.Tag = "Ver el Listado de %s";
                        this.CheckNivelListar.Text = "Ingresar al Listado";
                        this.CheckNivelListar.UseMnemonic = false;
                        this.CheckNivelListar.UseVisualStyleBackColor = true;
                        // 
                        // CheckNivelVer
                        // 
                        this.CheckNivelVer.AutoSize = true;
                        this.CheckNivelVer.Location = new System.Drawing.Point(128, 80);
                        this.CheckNivelVer.Name = "CheckNivelVer";
                        this.CheckNivelVer.Size = new System.Drawing.Size(220, 19);
                        this.CheckNivelVer.TabIndex = 4;
                        this.CheckNivelVer.Tag = "Ver %s Individuales";
                        this.CheckNivelVer.Text = "Ver los Elementos Individuales";
                        this.CheckNivelVer.UseMnemonic = false;
                        this.CheckNivelVer.UseVisualStyleBackColor = true;
                        // 
                        // CheckNivelImprimir
                        // 
                        this.CheckNivelImprimir.AutoSize = true;
                        this.CheckNivelImprimir.Location = new System.Drawing.Point(128, 100);
                        this.CheckNivelImprimir.Name = "CheckNivelImprimir";
                        this.CheckNivelImprimir.Size = new System.Drawing.Size(79, 19);
                        this.CheckNivelImprimir.TabIndex = 5;
                        this.CheckNivelImprimir.Tag = "Imprimir %s";
                        this.CheckNivelImprimir.Text = "Imprimir";
                        this.CheckNivelImprimir.UseMnemonic = false;
                        this.CheckNivelImprimir.UseVisualStyleBackColor = true;
                        // 
                        // CheckNivelCrear
                        // 
                        this.CheckNivelCrear.AutoSize = true;
                        this.CheckNivelCrear.Location = new System.Drawing.Point(464, 61);
                        this.CheckNivelCrear.Name = "CheckNivelCrear";
                        this.CheckNivelCrear.Size = new System.Drawing.Size(185, 19);
                        this.CheckNivelCrear.TabIndex = 6;
                        this.CheckNivelCrear.Tag = "Crear %s";
                        this.CheckNivelCrear.Text = "Crear Elementos Nuevos";
                        this.CheckNivelCrear.UseMnemonic = false;
                        this.CheckNivelCrear.UseVisualStyleBackColor = true;
                        // 
                        // CheckNivelEditar
                        // 
                        this.CheckNivelEditar.AutoSize = true;
                        this.CheckNivelEditar.Location = new System.Drawing.Point(464, 81);
                        this.CheckNivelEditar.Name = "CheckNivelEditar";
                        this.CheckNivelEditar.Size = new System.Drawing.Size(135, 19);
                        this.CheckNivelEditar.TabIndex = 7;
                        this.CheckNivelEditar.Tag = "Editar %s";
                        this.CheckNivelEditar.Text = "Editar Elementos";
                        this.CheckNivelEditar.UseMnemonic = false;
                        this.CheckNivelEditar.UseVisualStyleBackColor = true;
                        this.CheckNivelEditar.CheckedChanged += new System.EventHandler(this.CheckNivelEditar_CheckedChanged);
                        // 
                        // CheckNivelEditarAvanzado
                        // 
                        this.CheckNivelEditarAvanzado.AutoSize = true;
                        this.CheckNivelEditarAvanzado.Location = new System.Drawing.Point(464, 101);
                        this.CheckNivelEditarAvanzado.Name = "CheckNivelEditarAvanzado";
                        this.CheckNivelEditarAvanzado.Size = new System.Drawing.Size(138, 19);
                        this.CheckNivelEditarAvanzado.TabIndex = 8;
                        this.CheckNivelEditarAvanzado.Tag = "Edición Avanzada";
                        this.CheckNivelEditarAvanzado.Text = "Edición Avanzada";
                        this.CheckNivelEditarAvanzado.UseMnemonic = false;
                        this.CheckNivelEditarAvanzado.UseVisualStyleBackColor = true;
                        // 
                        // CheckNivelEliminar
                        // 
                        this.CheckNivelEliminar.AutoSize = true;
                        this.CheckNivelEliminar.Location = new System.Drawing.Point(128, 156);
                        this.CheckNivelEliminar.Name = "CheckNivelEliminar";
                        this.CheckNivelEliminar.Size = new System.Drawing.Size(149, 19);
                        this.CheckNivelEliminar.TabIndex = 10;
                        this.CheckNivelEliminar.Tag = "Eliminar %s";
                        this.CheckNivelEliminar.Text = "Eliminar elementos";
                        this.CheckNivelEliminar.UseMnemonic = false;
                        this.CheckNivelEliminar.UseVisualStyleBackColor = true;
                        // 
                        // CheckNivelTotal
                        // 
                        this.CheckNivelTotal.AutoSize = true;
                        this.CheckNivelTotal.Location = new System.Drawing.Point(464, 236);
                        this.CheckNivelTotal.Name = "CheckNivelTotal";
                        this.CheckNivelTotal.Size = new System.Drawing.Size(107, 19);
                        this.CheckNivelTotal.TabIndex = 18;
                        this.CheckNivelTotal.Text = "Acceso Total";
                        this.CheckNivelTotal.UseMnemonic = false;
                        this.CheckNivelTotal.UseVisualStyleBackColor = true;
                        // 
                        // CheckNivelExtra1
                        // 
                        this.CheckNivelExtra1.AutoSize = true;
                        this.CheckNivelExtra1.Location = new System.Drawing.Point(128, 200);
                        this.CheckNivelExtra1.Name = "CheckNivelExtra1";
                        this.CheckNivelExtra1.Size = new System.Drawing.Size(71, 19);
                        this.CheckNivelExtra1.TabIndex = 12;
                        this.CheckNivelExtra1.Text = "Extra 1";
                        this.CheckNivelExtra1.UseMnemonic = false;
                        this.CheckNivelExtra1.UseVisualStyleBackColor = true;
                        // 
                        // CheckNivelExtra2
                        // 
                        this.CheckNivelExtra2.AutoSize = true;
                        this.CheckNivelExtra2.Location = new System.Drawing.Point(128, 220);
                        this.CheckNivelExtra2.Name = "CheckNivelExtra2";
                        this.CheckNivelExtra2.Size = new System.Drawing.Size(71, 19);
                        this.CheckNivelExtra2.TabIndex = 13;
                        this.CheckNivelExtra2.Text = "Extra 2";
                        this.CheckNivelExtra2.UseMnemonic = false;
                        this.CheckNivelExtra2.UseVisualStyleBackColor = true;
                        // 
                        // CheckNivelExtra3
                        // 
                        this.CheckNivelExtra3.AutoSize = true;
                        this.CheckNivelExtra3.Location = new System.Drawing.Point(128, 240);
                        this.CheckNivelExtra3.Name = "CheckNivelExtra3";
                        this.CheckNivelExtra3.Size = new System.Drawing.Size(71, 19);
                        this.CheckNivelExtra3.TabIndex = 14;
                        this.CheckNivelExtra3.Text = "Extra 3";
                        this.CheckNivelExtra3.UseMnemonic = false;
                        this.CheckNivelExtra3.UseVisualStyleBackColor = true;
                        // 
                        // CheckNivelExtraC
                        // 
                        this.CheckNivelExtraC.AutoSize = true;
                        this.CheckNivelExtraC.Location = new System.Drawing.Point(316, 240);
                        this.CheckNivelExtraC.Name = "CheckNivelExtraC";
                        this.CheckNivelExtraC.Size = new System.Drawing.Size(72, 19);
                        this.CheckNivelExtraC.TabIndex = 17;
                        this.CheckNivelExtraC.Text = "Extra C";
                        this.CheckNivelExtraC.UseMnemonic = false;
                        this.CheckNivelExtraC.UseVisualStyleBackColor = true;
                        // 
                        // CheckNivelExtraB
                        // 
                        this.CheckNivelExtraB.AutoSize = true;
                        this.CheckNivelExtraB.Location = new System.Drawing.Point(316, 220);
                        this.CheckNivelExtraB.Name = "CheckNivelExtraB";
                        this.CheckNivelExtraB.Size = new System.Drawing.Size(72, 19);
                        this.CheckNivelExtraB.TabIndex = 16;
                        this.CheckNivelExtraB.Text = "Extra B";
                        this.CheckNivelExtraB.UseMnemonic = false;
                        this.CheckNivelExtraB.UseVisualStyleBackColor = true;
                        // 
                        // CheckNivelExtraA
                        // 
                        this.CheckNivelExtraA.AutoSize = true;
                        this.CheckNivelExtraA.Location = new System.Drawing.Point(316, 200);
                        this.CheckNivelExtraA.Name = "CheckNivelExtraA";
                        this.CheckNivelExtraA.Size = new System.Drawing.Size(72, 19);
                        this.CheckNivelExtraA.TabIndex = 15;
                        this.CheckNivelExtraA.Text = "Extra A";
                        this.CheckNivelExtraA.UseMnemonic = false;
                        this.CheckNivelExtraA.UseVisualStyleBackColor = true;
                        // 
                        // EntradaItems
                        // 
                        this.EntradaItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaItems.Location = new System.Drawing.Point(120, 272);
                        this.EntradaItems.Name = "EntradaItems";
                        this.EntradaItems.Size = new System.Drawing.Size(660, 24);
                        this.EntradaItems.TabIndex = 20;
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(24, 272);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(96, 24);
                        this.Label1.TabIndex = 19;
                        this.Label1.Text = "Elementos";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // CheckNivelMover
                        // 
                        this.CheckNivelMover.AutoSize = true;
                        this.CheckNivelMover.Location = new System.Drawing.Point(128, 136);
                        this.CheckNivelMover.Name = "CheckNivelMover";
                        this.CheckNivelMover.Size = new System.Drawing.Size(151, 19);
                        this.CheckNivelMover.TabIndex = 9;
                        this.CheckNivelMover.Tag = "Hacer movimientos";
                        this.CheckNivelMover.Text = "Hacer movimientos";
                        this.CheckNivelMover.UseMnemonic = false;
                        this.CheckNivelMover.UseVisualStyleBackColor = true;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(24, 56);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(96, 24);
                        this.label2.TabIndex = 2;
                        this.label2.Text = "Permisos";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // CheckNivelAdministrar
                        // 
                        this.CheckNivelAdministrar.AutoSize = true;
                        this.CheckNivelAdministrar.Location = new System.Drawing.Point(464, 137);
                        this.CheckNivelAdministrar.Name = "CheckNivelAdministrar";
                        this.CheckNivelAdministrar.Size = new System.Drawing.Size(172, 19);
                        this.CheckNivelAdministrar.TabIndex = 11;
                        this.CheckNivelAdministrar.Tag = "Administrar %s";
                        this.CheckNivelAdministrar.Text = "Administrar elementos";
                        this.CheckNivelAdministrar.UseMnemonic = false;
                        this.CheckNivelAdministrar.UseVisualStyleBackColor = true;
                        // 
                        // EditarPermiso
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(806, 372);
                        this.Controls.Add(this.CheckNivelAdministrar);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.CheckNivelMover);
                        this.Controls.Add(this.EntradaItems);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.CheckNivelExtraC);
                        this.Controls.Add(this.CheckNivelExtraB);
                        this.Controls.Add(this.CheckNivelExtraA);
                        this.Controls.Add(this.CheckNivelExtra3);
                        this.Controls.Add(this.CheckNivelExtra2);
                        this.Controls.Add(this.CheckNivelExtra1);
                        this.Controls.Add(this.CheckNivelTotal);
                        this.Controls.Add(this.CheckNivelEliminar);
                        this.Controls.Add(this.CheckNivelEditarAvanzado);
                        this.Controls.Add(this.CheckNivelEditar);
                        this.Controls.Add(this.CheckNivelCrear);
                        this.Controls.Add(this.CheckNivelImprimir);
                        this.Controls.Add(this.CheckNivelVer);
                        this.Controls.Add(this.CheckNivelListar);
                        this.Controls.Add(this.EntradaObjeto);
                        this.Controls.Add(this.Label16);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "EditarPermiso";
                        this.Text = "Permiso";
                        this.Controls.SetChildIndex(this.Label16, 0);
                        this.Controls.SetChildIndex(this.EntradaObjeto, 0);
                        this.Controls.SetChildIndex(this.CheckNivelListar, 0);
                        this.Controls.SetChildIndex(this.CheckNivelVer, 0);
                        this.Controls.SetChildIndex(this.CheckNivelImprimir, 0);
                        this.Controls.SetChildIndex(this.CheckNivelCrear, 0);
                        this.Controls.SetChildIndex(this.CheckNivelEditar, 0);
                        this.Controls.SetChildIndex(this.CheckNivelEditarAvanzado, 0);
                        this.Controls.SetChildIndex(this.CheckNivelEliminar, 0);
                        this.Controls.SetChildIndex(this.CheckNivelTotal, 0);
                        this.Controls.SetChildIndex(this.CheckNivelExtra1, 0);
                        this.Controls.SetChildIndex(this.CheckNivelExtra2, 0);
                        this.Controls.SetChildIndex(this.CheckNivelExtra3, 0);
                        this.Controls.SetChildIndex(this.CheckNivelExtraA, 0);
                        this.Controls.SetChildIndex(this.CheckNivelExtraB, 0);
                        this.Controls.SetChildIndex(this.CheckNivelExtraC, 0);
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.EntradaItems, 0);
                        this.Controls.SetChildIndex(this.CheckNivelMover, 0);
                        this.Controls.SetChildIndex(this.label2, 0);
                        this.Controls.SetChildIndex(this.CheckNivelAdministrar, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal Lcc.Entrada.CodigoDetalle EntradaObjeto;
                internal Lui.Forms.Label Label16;
                private System.Windows.Forms.CheckBox CheckNivelListar;
                private System.Windows.Forms.CheckBox CheckNivelVer;
                private System.Windows.Forms.CheckBox CheckNivelImprimir;
                private System.Windows.Forms.CheckBox CheckNivelCrear;
                private System.Windows.Forms.CheckBox CheckNivelEditar;
                private System.Windows.Forms.CheckBox CheckNivelEditarAvanzado;
                private System.Windows.Forms.CheckBox CheckNivelEliminar;
                private System.Windows.Forms.CheckBox CheckNivelTotal;
                private System.Windows.Forms.CheckBox CheckNivelExtra1;
                private System.Windows.Forms.CheckBox CheckNivelExtra2;
                private System.Windows.Forms.CheckBox CheckNivelExtra3;
                private System.Windows.Forms.CheckBox CheckNivelExtraC;
                private System.Windows.Forms.CheckBox CheckNivelExtraB;
                private System.Windows.Forms.CheckBox CheckNivelExtraA;
                internal Lui.Forms.TextBox EntradaItems;
                internal Lui.Forms.Label Label1;
                private System.Windows.Forms.CheckBox CheckNivelMover;
                internal Lui.Forms.Label label2;
                private System.Windows.Forms.CheckBox CheckNivelAdministrar;
        }
}
