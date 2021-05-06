using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gewinnspiel.Forms
{
    public partial class frmTeilnehmer : Form
    {
        public frmTeilnehmer()
        {
            InitializeComponent();
        }

        #region Variablen
        ListViewItem lvItem;
        #endregion

        #region Form
        private void frmTeilnehmer_Load(object sender, EventArgs e)
        {
            lvAktiveGewinnspiele.FullRowSelect = true;
            lvMeineGewinnspiele.FullRowSelect = true;
            einlesenAktiveGewinnspiele();
            einlesenMeineGewinnspiele();
        }

        private void frmTeilnehmer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Wollen Sie sich wirklich ausloggen?", "Achtung!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                frmLogin.frmLog.activeUser = null;
            }
            else if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Methoden
        private void einlesenAktiveGewinnspiele()
        {
            frmLogin.frmLog.showImages();
            lvAktiveGewinnspiele.Items.Clear();
            for (int i = 0; i < frmLogin.frmLog.gewinnspielListe.Count; i++)
            {
                if (!frmLogin.frmLog.gewinnspielListe[i].Ausgelost)
                {
                    lvItem = new ListViewItem();
                    lvItem.ImageIndex = i;
                    lvItem.SubItems.Add(frmLogin.frmLog.gewinnspielListe[i].SpielID.ToString());
                    lvItem.SubItems.Add(frmLogin.frmLog.gewinnspielListe[i].Bezeichnung);
                    lvItem.SubItems.Add(frmLogin.frmLog.gewinnspielListe[i].Gewinn);
                    lvItem.SubItems.Add(frmLogin.frmLog.gewinnspielListe[i].Wert.ToString());
                    lvItem.SubItems.Add(frmLogin.frmLog.gewinnspielListe[i].Ausgelost.ToString());
                    lvItem.SubItems.Add(frmLogin.frmLog.gewinnspielListe[i].Bildpfad);
                    lvAktiveGewinnspiele.Items.Add(lvItem);
                }
            }
            lvAktiveGewinnspiele.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvAktiveGewinnspiele.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void einlesenMeineGewinnspiele()
        {

        }
        #endregion

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
