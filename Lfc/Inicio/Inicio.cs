using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Inicio
{
        public partial class Inicio : Lui.Forms.ChildForm
        {
                public Inicio()
                {
                        InitializeComponent();
                        this.StockImage = "inicio";
                }


                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        MostrarConsejo();
                }

                private void BotonForoWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        Help.ShowHelp(this, "http://foro.lazarogestion.com/");
                }

                private void BotonWebInicio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        Help.ShowHelp(this, "http://www.lazarogestion.com");
                }


                protected override void OnFormClosing(FormClosingEventArgs e)
                {
                        if (e.CloseReason == CloseReason.UserClosing)
                                e.Cancel = true;
                        base.OnFormClosing(e);
                }

                private void BotonWebPrimerosPasos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        Help.ShowHelp(this, "http://www.lazarogestion.com/soporte/primeros-pasos");
                }

                private void BotonWebAyudaWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        Help.ShowHelp(this, "http://www.lazarogestion.com/soporte");
                }

                private void BotonWebComoFactura_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        Help.ShowHelp(this, "http://www.lazarogestion.com/soporte/primeros-pasos/facturar");
                }

                private void PanelConsejo_DoubleClick(object sender, EventArgs e)
                {
                        MostrarConsejo();
                }

                private void MostrarConsejo()
                {
                        int Rnd = new Random().Next(0, 10);

                        switch (Rnd) {
                                case 0:
                                case 1:
                                case 2:
                                        PanelConsejo.Descripcion = "Puede hacer cuentas al escribir números en Lázaro. Al ingresar datos en cualquier campo numérico puede hacer cálculos como 2+2 o 7*5 y Lázaro calculará automáticamente el resultado cuando se desplace al campo siguiente.";
                                        break;
                                case 3:
                                case 4:
                                case 5:
                                        PanelConsejo.Descripcion = "Al buscar no necesita recordar el nombre completo. Cuando selecciona de una lista de clientes o artículos puede escribir cualquier parte del nombre y Lázaro mostrará una lista de sugerencias. Por ejemplo escriba 'mar fer' para encontrar 'Marcelo Fernández'.";
                                        break;
                                case 6:
                                        PanelConsejo.Descripcion = "Puede navegar todos los formularios usando sólo el teclado. Utilice las teclas 'Arriba' y 'Abajo' para moverse al campo anterior o siguiente, la tecla 'Esc' para cerrar un formulario o la tecla 'Entrar' para seleccionar un elemento de una lista.";
                                        break;
                                case 7:
                                        PanelConsejo.Descripcion = "Lázaro recibe actualizaciones y mejoras frecuentemente. Si no cuenta con una conexión a Internet en este equipo, le recomendamos que descargue e instale las actualizaciones de Lázaro frecuentemente desde la página web.";
                                        break;
                                case 8:
                                case 9:
                                case 10:
                                        PanelConsejo.Descripcion = "Lázaro tiene un sistema de gestión de tareas pendientes. Puede ser útil para gestionar trabajos pendientes con los clientes o para el control de quehaceres internos de su empresa. Para más información vea el menú 'Tareas'.";
                                        break;
                        }
                }
        }
}
