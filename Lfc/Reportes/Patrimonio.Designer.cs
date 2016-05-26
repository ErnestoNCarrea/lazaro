namespace Lfc.Reportes
{
        public partial class Patrimonio
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
                        this.label1 = new Lui.Forms.Label();
                        this.note1 = new Lui.Forms.Label();
                        this.EntradaActivosCajas = new Lui.Forms.TextBox();
                        this.EntradaFuturosTarjetas = new Lui.Forms.TextBox();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaActivosStock = new Lui.Forms.TextBox();
                        this.label3 = new Lui.Forms.Label();
                        this.EntradaFuturosPedidos = new Lui.Forms.TextBox();
                        this.label4 = new Lui.Forms.Label();
                        this.EntradaPasivosCheques = new Lui.Forms.TextBox();
                        this.label7 = new Lui.Forms.Label();
                        this.EntradaPasivosCajas = new Lui.Forms.TextBox();
                        this.note2 = new Lui.Forms.Label();
                        this.label8 = new Lui.Forms.Label();
                        this.note3 = new Lui.Forms.Label();
                        this.EntradaActivosSubtotal = new Lui.Forms.TextBox();
                        this.label5 = new Lui.Forms.Label();
                        this.EntradaPasivosSubtotal = new Lui.Forms.TextBox();
                        this.label6 = new Lui.Forms.Label();
                        this.EntradaFuturosSubtotal = new Lui.Forms.TextBox();
                        this.label9 = new Lui.Forms.Label();
                        this.EntradaPatrimonioActual = new Lui.Forms.TextBox();
                        this.label10 = new Lui.Forms.Label();
                        this.note4 = new Lui.Forms.Label();
                        this.EntradaPatrimonioFuturo = new Lui.Forms.TextBox();
                        this.label11 = new Lui.Forms.Label();
                        this.EntradaActivosActualesFuturos = new Lui.Forms.TextBox();
                        this.label12 = new Lui.Forms.Label();
                        this.EntradaPasivosStock = new Lui.Forms.TextBox();
                        this.label13 = new Lui.Forms.Label();
                        this.EntradaCC = new Lui.Forms.TextBox();
                        this.label14 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(32, 52);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(232, 24);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "Dinero en cajas";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label1.UseMnemonic = false;
                        // 
                        // note1
                        // 
                        this.note1.Location = new System.Drawing.Point(16, 16);
                        this.note1.Name = "note1";
                        this.note1.Size = new System.Drawing.Size(356, 36);
                        this.note1.TabIndex = 1;
                        this.note1.Text = "Activos";
                        this.note1.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // EntradaActivosCajas
                        // 
                        this.EntradaActivosCajas.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaActivosCajas.Location = new System.Drawing.Point(268, 52);
                        this.EntradaActivosCajas.Name = "EntradaActivosCajas";
                        this.EntradaActivosCajas.Prefijo = "$";
                        this.EntradaActivosCajas.Size = new System.Drawing.Size(100, 24);
                        this.EntradaActivosCajas.TabIndex = 2;
                        // 
                        // EntradaFuturosTarjetas
                        // 
                        this.EntradaFuturosTarjetas.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaFuturosTarjetas.Location = new System.Drawing.Point(640, 52);
                        this.EntradaFuturosTarjetas.Name = "EntradaFuturosTarjetas";
                        this.EntradaFuturosTarjetas.Prefijo = "$";
                        this.EntradaFuturosTarjetas.Size = new System.Drawing.Size(100, 24);
                        this.EntradaFuturosTarjetas.TabIndex = 4;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(404, 52);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(232, 24);
                        this.label2.TabIndex = 3;
                        this.label2.Text = "Presentaciones de cupones";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label2.UseMnemonic = false;
                        // 
                        // EntradaActivosStock
                        // 
                        this.EntradaActivosStock.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaActivosStock.Location = new System.Drawing.Point(268, 80);
                        this.EntradaActivosStock.Name = "EntradaActivosStock";
                        this.EntradaActivosStock.Prefijo = "$";
                        this.EntradaActivosStock.Size = new System.Drawing.Size(100, 24);
                        this.EntradaActivosStock.TabIndex = 6;
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(32, 80);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(232, 24);
                        this.label3.TabIndex = 5;
                        this.label3.Text = "Stock";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label3.UseMnemonic = false;
                        // 
                        // EntradaFuturosPedidos
                        // 
                        this.EntradaFuturosPedidos.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaFuturosPedidos.Location = new System.Drawing.Point(640, 114);
                        this.EntradaFuturosPedidos.Name = "EntradaFuturosPedidos";
                        this.EntradaFuturosPedidos.Prefijo = "$";
                        this.EntradaFuturosPedidos.Size = new System.Drawing.Size(100, 24);
                        this.EntradaFuturosPedidos.TabIndex = 8;
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(404, 114);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(232, 24);
                        this.label4.TabIndex = 7;
                        this.label4.Text = "Mercadería en tránsito";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label4.UseMnemonic = false;
                        // 
                        // EntradaPasivosCheques
                        // 
                        this.EntradaPasivosCheques.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaPasivosCheques.Location = new System.Drawing.Point(268, 260);
                        this.EntradaPasivosCheques.Name = "EntradaPasivosCheques";
                        this.EntradaPasivosCheques.Prefijo = "$";
                        this.EntradaPasivosCheques.Size = new System.Drawing.Size(100, 24);
                        this.EntradaPasivosCheques.TabIndex = 13;
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(32, 260);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(232, 24);
                        this.label7.TabIndex = 12;
                        this.label7.Text = "Cheques emitidos";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label7.UseMnemonic = false;
                        // 
                        // EntradaPasivosCajas
                        // 
                        this.EntradaPasivosCajas.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaPasivosCajas.Location = new System.Drawing.Point(268, 204);
                        this.EntradaPasivosCajas.Name = "EntradaPasivosCajas";
                        this.EntradaPasivosCajas.Prefijo = "$";
                        this.EntradaPasivosCajas.Size = new System.Drawing.Size(100, 24);
                        this.EntradaPasivosCajas.TabIndex = 11;
                        // 
                        // note2
                        // 
                        this.note2.Location = new System.Drawing.Point(16, 168);
                        this.note2.Name = "note2";
                        this.note2.Size = new System.Drawing.Size(356, 36);
                        this.note2.TabIndex = 10;
                        this.note2.Text = "Pasivos";
                        this.note2.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // label8
                        // 
                        this.label8.Location = new System.Drawing.Point(32, 204);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(232, 24);
                        this.label8.TabIndex = 9;
                        this.label8.Text = "Descubiertos en cajas";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label8.UseMnemonic = false;
                        // 
                        // note3
                        // 
                        this.note3.Location = new System.Drawing.Point(388, 16);
                        this.note3.Name = "note3";
                        this.note3.Size = new System.Drawing.Size(356, 36);
                        this.note3.TabIndex = 18;
                        this.note3.Text = "Futuros";
                        this.note3.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // EntradaActivosSubtotal
                        // 
                        this.EntradaActivosSubtotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaActivosSubtotal.Location = new System.Drawing.Point(268, 112);
                        this.EntradaActivosSubtotal.Name = "EntradaActivosSubtotal";
                        this.EntradaActivosSubtotal.Prefijo = "$";
                        this.EntradaActivosSubtotal.Size = new System.Drawing.Size(100, 24);
                        this.EntradaActivosSubtotal.TabIndex = 20;
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(32, 112);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(232, 24);
                        this.label5.TabIndex = 19;
                        this.label5.Text = "Subtotal";
                        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label5.UseMnemonic = false;
                        // 
                        // EntradaPasivosSubtotal
                        // 
                        this.EntradaPasivosSubtotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaPasivosSubtotal.Location = new System.Drawing.Point(268, 292);
                        this.EntradaPasivosSubtotal.Name = "EntradaPasivosSubtotal";
                        this.EntradaPasivosSubtotal.Prefijo = "$";
                        this.EntradaPasivosSubtotal.Size = new System.Drawing.Size(100, 24);
                        this.EntradaPasivosSubtotal.TabIndex = 22;
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(32, 292);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(232, 24);
                        this.label6.TabIndex = 21;
                        this.label6.Text = "Subtotal";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label6.UseMnemonic = false;
                        // 
                        // EntradaFuturosSubtotal
                        // 
                        this.EntradaFuturosSubtotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaFuturosSubtotal.Location = new System.Drawing.Point(640, 146);
                        this.EntradaFuturosSubtotal.Name = "EntradaFuturosSubtotal";
                        this.EntradaFuturosSubtotal.Prefijo = "$";
                        this.EntradaFuturosSubtotal.Size = new System.Drawing.Size(100, 24);
                        this.EntradaFuturosSubtotal.TabIndex = 24;
                        // 
                        // label9
                        // 
                        this.label9.Location = new System.Drawing.Point(404, 146);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(232, 24);
                        this.label9.TabIndex = 23;
                        this.label9.Text = "Subtotal (futuros)";
                        this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label9.UseMnemonic = false;
                        // 
                        // EntradaPatrimonioActual
                        // 
                        this.EntradaPatrimonioActual.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaPatrimonioActual.Location = new System.Drawing.Point(644, 266);
                        this.EntradaPatrimonioActual.Name = "EntradaPatrimonioActual";
                        this.EntradaPatrimonioActual.Prefijo = "$";
                        this.EntradaPatrimonioActual.Size = new System.Drawing.Size(100, 24);
                        this.EntradaPatrimonioActual.TabIndex = 26;
                        // 
                        // label10
                        // 
                        this.label10.Location = new System.Drawing.Point(408, 266);
                        this.label10.Name = "label10";
                        this.label10.Size = new System.Drawing.Size(232, 24);
                        this.label10.TabIndex = 25;
                        this.label10.Text = "Actual";
                        this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label10.UseMnemonic = false;
                        // 
                        // note4
                        // 
                        this.note4.Location = new System.Drawing.Point(392, 230);
                        this.note4.Name = "note4";
                        this.note4.Size = new System.Drawing.Size(356, 36);
                        this.note4.TabIndex = 27;
                        this.note4.Text = "Patrimonio";
                        this.note4.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // EntradaPatrimonioFuturo
                        // 
                        this.EntradaPatrimonioFuturo.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaPatrimonioFuturo.Location = new System.Drawing.Point(644, 294);
                        this.EntradaPatrimonioFuturo.Name = "EntradaPatrimonioFuturo";
                        this.EntradaPatrimonioFuturo.Prefijo = "$";
                        this.EntradaPatrimonioFuturo.Size = new System.Drawing.Size(100, 24);
                        this.EntradaPatrimonioFuturo.TabIndex = 29;
                        // 
                        // label11
                        // 
                        this.label11.Location = new System.Drawing.Point(408, 294);
                        this.label11.Name = "label11";
                        this.label11.Size = new System.Drawing.Size(232, 24);
                        this.label11.TabIndex = 28;
                        this.label11.Text = "Futuro";
                        this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label11.UseMnemonic = false;
                        // 
                        // EntradaActivosActualesFuturos
                        // 
                        this.EntradaActivosActualesFuturos.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaActivosActualesFuturos.Location = new System.Drawing.Point(640, 178);
                        this.EntradaActivosActualesFuturos.Name = "EntradaActivosActualesFuturos";
                        this.EntradaActivosActualesFuturos.Prefijo = "$";
                        this.EntradaActivosActualesFuturos.Size = new System.Drawing.Size(100, 24);
                        this.EntradaActivosActualesFuturos.TabIndex = 33;
                        // 
                        // label12
                        // 
                        this.label12.Location = new System.Drawing.Point(404, 178);
                        this.label12.Name = "label12";
                        this.label12.Size = new System.Drawing.Size(232, 24);
                        this.label12.TabIndex = 32;
                        this.label12.Text = "Subtotal (actuales y futuros)";
                        this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label12.UseMnemonic = false;
                        // 
                        // EntradaPasivosStock
                        // 
                        this.EntradaPasivosStock.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaPasivosStock.Location = new System.Drawing.Point(268, 232);
                        this.EntradaPasivosStock.Name = "EntradaPasivosStock";
                        this.EntradaPasivosStock.Prefijo = "$";
                        this.EntradaPasivosStock.Size = new System.Drawing.Size(100, 24);
                        this.EntradaPasivosStock.TabIndex = 35;
                        // 
                        // label13
                        // 
                        this.label13.Location = new System.Drawing.Point(32, 232);
                        this.label13.Name = "label13";
                        this.label13.Size = new System.Drawing.Size(232, 24);
                        this.label13.TabIndex = 34;
                        this.label13.Text = "Descubiertos en stock";
                        this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label13.UseMnemonic = false;
                        // 
                        // EntradaCC
                        // 
                        this.EntradaCC.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaCC.Location = new System.Drawing.Point(640, 83);
                        this.EntradaCC.Name = "EntradaCC";
                        this.EntradaCC.Prefijo = "$";
                        this.EntradaCC.Size = new System.Drawing.Size(100, 24);
                        this.EntradaCC.TabIndex = 37;
                        // 
                        // label14
                        // 
                        this.label14.Location = new System.Drawing.Point(404, 83);
                        this.label14.Name = "label14";
                        this.label14.Size = new System.Drawing.Size(232, 24);
                        this.label14.TabIndex = 36;
                        this.label14.Text = "Cuentas corrientes";
                        this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label14.UseMnemonic = false;
                        // 
                        // Patrimonio
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(757, 391);
                        this.Controls.Add(this.EntradaCC);
                        this.Controls.Add(this.label14);
                        this.Controls.Add(this.EntradaPasivosStock);
                        this.Controls.Add(this.label13);
                        this.Controls.Add(this.EntradaActivosActualesFuturos);
                        this.Controls.Add(this.label12);
                        this.Controls.Add(this.EntradaPatrimonioFuturo);
                        this.Controls.Add(this.label11);
                        this.Controls.Add(this.EntradaPatrimonioActual);
                        this.Controls.Add(this.label10);
                        this.Controls.Add(this.EntradaFuturosSubtotal);
                        this.Controls.Add(this.label9);
                        this.Controls.Add(this.EntradaPasivosSubtotal);
                        this.Controls.Add(this.label6);
                        this.Controls.Add(this.EntradaActivosSubtotal);
                        this.Controls.Add(this.label5);
                        this.Controls.Add(this.EntradaPasivosCheques);
                        this.Controls.Add(this.label7);
                        this.Controls.Add(this.EntradaPasivosCajas);
                        this.Controls.Add(this.label8);
                        this.Controls.Add(this.EntradaFuturosPedidos);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.EntradaActivosStock);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.EntradaFuturosTarjetas);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EntradaActivosCajas);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.note4);
                        this.Controls.Add(this.note3);
                        this.Controls.Add(this.note2);
                        this.Controls.Add(this.note1);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.Name = "Patrimonio";
                        this.Text = "Patrimonio";
                        this.ResumeLayout(false);

                }

                #endregion

                private Lui.Forms.Label label1;
                private Lui.Forms.Label note1;
                private Lui.Forms.TextBox EntradaActivosCajas;
                private Lui.Forms.TextBox EntradaFuturosTarjetas;
                private Lui.Forms.Label label2;
                private Lui.Forms.TextBox EntradaActivosStock;
                private Lui.Forms.Label label3;
                private Lui.Forms.TextBox EntradaFuturosPedidos;
                private Lui.Forms.Label label4;
                private Lui.Forms.TextBox EntradaPasivosCheques;
                private Lui.Forms.Label label7;
                private Lui.Forms.TextBox EntradaPasivosCajas;
                private Lui.Forms.Label note2;
                private Lui.Forms.Label label8;
                private Lui.Forms.Label note3;
                private Lui.Forms.TextBox EntradaActivosSubtotal;
                private Lui.Forms.Label label5;
                private Lui.Forms.TextBox EntradaPasivosSubtotal;
                private Lui.Forms.Label label6;
                private Lui.Forms.TextBox EntradaFuturosSubtotal;
                private Lui.Forms.Label label9;
                private Lui.Forms.TextBox EntradaPatrimonioActual;
                private Lui.Forms.Label label10;
                private Lui.Forms.Label note4;
                private Lui.Forms.TextBox EntradaPatrimonioFuturo;
                private Lui.Forms.Label label11;
                private Lui.Forms.TextBox EntradaActivosActualesFuturos;
                private Lui.Forms.Label label12;
                private Lui.Forms.TextBox EntradaPasivosStock;
                private Lui.Forms.Label label13;
                private Lui.Forms.TextBox EntradaCC;
                private Lui.Forms.Label label14;
        }
}
