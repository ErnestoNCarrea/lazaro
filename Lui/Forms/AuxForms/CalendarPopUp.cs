using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lui.Forms
{
        internal partial class CalendarPopUp : Lui.Forms.DialogForm
        {

                public CalendarPopUp()
                {
                        InitializeComponent();

                        this.Calendar1.CurrentDate = System.DateTime.Now;
                }

                private void Calendar1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
                {
                        if (e.KeyChar == Lfx.Types.ControlChars.Cr) {
                                this.OkButton.PerformClick();
                        } else if (e.KeyChar == Lfx.Types.ControlChars.Escape) {
                                this.CancelCommandButton.PerformClick();
                        }
                }

                public DateTime CurrentDate
                {
                        get
                        {
                                return this.Calendar1.CurrentDate;
                        }
                        set
                        {
                                this.Calendar1.CurrentDate = value;
                        }
                }

                public int CurrentMonth
                {
                        get
                        {
                                return this.CurrentDate.Month;
                        }
                        set
                        {
                                this.CurrentDate = new DateTime(this.CurrentDate.Year, value, this.CurrentDate.Day);
                        }
                }

                public int CurrentYear
                {
                        get
                        {
                                return this.CurrentDate.Year;
                        }
                        set
                        {
                                this.CurrentDate = new DateTime(value, this.CurrentDate.Month, this.CurrentDate.Day);
                        }
                }


                private void Calendar1_DoubleClick(object sender, System.EventArgs e)
                {
                        this.OkButton.PerformClick();
                }

                private void BotonMes1_Click(object sender, EventArgs e)
                {
                        this.CurrentMonth = 1;
                }

                private void BotonMes2_Click(object sender, EventArgs e)
                {
                        this.CurrentMonth = 2;
                }

                private void BotonMes3_Click(object sender, EventArgs e)
                {
                        this.CurrentMonth = 3;
                }

                private void BotonMes4_Click(object sender, EventArgs e)
                {
                        this.CurrentMonth = 4;
                }

                private void BotonMes5_Click(object sender, EventArgs e)
                {
                        this.CurrentMonth = 5;
                }

                private void BotonMes6_Click(object sender, EventArgs e)
                {
                        this.CurrentMonth = 6;
                }

                private void BotonMes7_Click(object sender, EventArgs e)
                {
                        this.CurrentMonth = 7;
                }

                private void BotonMes8_Click(object sender, EventArgs e)
                {
                        this.CurrentMonth = 8;
                }

                private void BotonMes9_Click(object sender, EventArgs e)
                {
                        this.CurrentMonth = 9;
                }

                private void BotonMes10_Click(object sender, EventArgs e)
                {
                        this.CurrentMonth = 10;
                }

                private void BotonMes11_Click(object sender, EventArgs e)
                {
                        this.CurrentMonth = 11;
                }

                private void BotonMes12_Click(object sender, EventArgs e)
                {
                        this.CurrentMonth = 12;
                }

                private void BotonAnioAnterior_Click(object sender, EventArgs e)
                {
                        this.CurrentYear = this.CurrentYear - 1;
                }

                private void BotonAnioSiguiente_Click(object sender, EventArgs e)
                {
                        this.CurrentYear = this.CurrentYear + 1;
                }

                private void BotonHoy_Click(object sender, EventArgs e)
                {
                        this.CurrentDate = System.DateTime.Now;
                }

                private void Calendar1_CurrentDateChanged(object sender, EventArgs e)
                {
                        BotonAnioAnterior.Text = "< " + (this.CurrentYear - 1).ToString();
                        BotonAnioSiguiente.Text = (this.CurrentYear + 1).ToString() + " >";
                }
        }
}