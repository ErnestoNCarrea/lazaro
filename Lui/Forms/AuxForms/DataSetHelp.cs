using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lui.Forms
{
    internal partial class DataSetHelp : Lui.Forms.Form
    {
        private string[] m_SetData = new string[1];
        private string[] m_SetDataText = new string[1];
        private string[] m_SetDataKey = new string[1];
        private int m_SetIndex;
        private string m_TextKey;
        private int IdealHeight = 118, LineHeight = 0;

        [System.ComponentModel.Browsable(false),
                System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public Lui.Forms.ComboBox ControlDestino { get; set; }

        public DataSetHelp()
        {
            InitializeComponent();

            this.BackColor = this.DisplayStyle.SelectionColor;
            Panel1.BackColor = this.DisplayStyle.DataAreaColor;
            Listado.BackColor = this.DisplayStyle.DataAreaColor;
            Listado.ForeColor = this.DisplayStyle.TextColor;
        }

        [System.ComponentModel.Category("Comportamiento")]
        public string[] SetData
        {
            get
            {
                return m_SetData;
            }
            set
            {
                m_SetData = value;

                if (m_SetData == null) {
                    m_SetIndex = -1;
                } else {
                    int TamanoSet = m_SetData.GetUpperBound(0);
                    m_SetDataText = new string[TamanoSet + 1];
                    m_SetDataKey = new string[TamanoSet + 1];

                    for (int i = 0; i <= TamanoSet; i++) {
                        string sItem = m_SetData[i];
                        m_SetDataText[i] = Lfx.Types.Strings.GetNextToken(ref sItem, "|");
                        m_SetDataKey[i] = sItem;
                    }

                    Listado.Items.Clear();
                    for (int i = m_SetDataText.GetLowerBound(0); i <= m_SetDataText.GetUpperBound(0); i++) {
                        if (m_SetDataText[i] == null)
                            Listado.Items.Add("");
                        else
                            Listado.Items.Add(m_SetDataText[i]);
                    }

                    if (LineHeight == 0) {
                        Graphics a = this.CreateGraphics();
                        LineHeight = System.Convert.ToInt32(a.MeasureString("Hj", Listado.Font).Height);
                        a.Dispose();
                        a = null;
                    }
                    this.IdealHeight = LineHeight * (m_SetDataText.GetUpperBound(0) + 1) + (Listado.Top * 2);
                    if (IdealHeight > 240)
                        IdealHeight = 240;

                    DetectarSetIndex();
                }
            }
        }

        [System.ComponentModel.Category("Apariencia")]
        public string TextKey
        {
            get
            {
                if (m_SetIndex >= 0) {
                    return m_SetDataKey[m_SetIndex];
                } else {
                    return "";
                }
            }
            set
            {
                m_TextKey = value;
                DetectarSetIndex();
                TimerOcultar.Stop();
                TimerOcultar.Start();
                this.Mostrar();
            }
        }

        private void DetectarSetIndex()
        {
            // Detecta el SetIndex que le corresponde al TextKey actual
            if (m_SetDataKey.GetLength(0) > 0) {
                bool Found = false;
                for (int i = 0; i <= m_SetDataKey.GetUpperBound(0); i++) {
                    if (m_SetDataKey[i] == m_TextKey) {
                        m_SetIndex = i;
                        Listado.SelectedIndex = i;
                        Found = true;
                        break;
                    }
                }
                if (!Found) {
                    for (int i = 0; i <= m_SetDataKey.GetUpperBound(0); i++) {
                        if (m_SetData != null && m_SetData[i] == m_TextKey) {
                            m_SetIndex = i;
                            Listado.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }


        private void TimerOcultar_Tick(System.Object sender, System.EventArgs e)
        {
            try {
                TimerOcultar.Enabled = false;
                for (int n = 99; n >= 1; n -= 5) {
                    this.Opacity = (double)(n / 100F);
                    this.Refresh();
                    System.Threading.Thread.Sleep(10);
                }
                this.Ocultar();
            } catch (Exception) {
                // Nada
            }
        }


        private void FormAyudaDataSet_VisibleChanged(object sender, System.EventArgs e)
        {
            if (this.Visible)
                TimerOcultar.Start();
        }


        public void Ocultar()
        {
            // Permito procesar un clic
            System.Windows.Forms.Application.DoEvents();
            System.Threading.Thread.Sleep(1);

            TimerOcultar.Stop();
            this.Visible = false;
            this.Size = new Size(0, 0);
            this.Location = new Point(30000, 30000);
            this.ShowInTaskbar = false;
        }


        public void Mostrar()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Ubicar();
            if (this.Visible == false)
                this.Visible = true;
        }


        public void Mostrar(Lui.Forms.ComboBox parentControl)
        {
            this.ControlDestino = parentControl;
            this.Size = new Size(parentControl.Width, IdealHeight);
            this.Mostrar();
        }


        // Ubica la ventana con respecto al ControlDestino
        public void Ubicar()
        {
            if (ControlDestino != null && ControlDestino.Created)
                this.Location = ControlDestino.PointToScreen(new Point(0, ControlDestino.Height - 2));
        }


        private void Listado_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (Listado.SelectedIndex >= 0 && Listado.SelectedIndex < m_SetDataKey.Length) {
                string Key = this.m_SetDataKey[Listado.SelectedIndex];
                if (Key != null && Key.Length > 0 && this.ControlDestino != null)
                    this.ControlDestino.TextKey = Key;
            }
            if (this.ControlDestino != null)
                this.ControlDestino.Select();
        }


        private void Listado_MouseEnter(object sender, EventArgs e)
        {
            this.TimerOcultar.Stop();
        }


        private void Listado_MouseLeave(object sender, EventArgs e)
        {
            if (this.Visible)
                this.TimerOcultar.Start();
        }
    }
}