﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartMenu
{
	public partial class StartMenu : Form
	{
		string username;
		public StartMenu()
		{
			InitializeComponent();

		}
        public StartMenu(string username)
		{
			InitializeComponent();
			this.username = username;

		}

		private void btnLNW_Click(object sender, EventArgs e)
        {
			FPreviewNewWord f = new FPreviewNewWord();
			this.Hide();
			f.ShowDialog();
			this.Show();
			
        }

        private void btnPractice_Click(object sender, EventArgs e)
        {
			FPractice f = new FPractice();
			this.Hide();
			f.ShowDialog();
			this.Show();
		}

        private void btnRevision_Click(object sender, EventArgs e)
        {
			FRevision f = new FRevision();
			this.Hide();			
			f.ShowDialog();
			this.Show();
		}

        private void btnYourWords_Click(object sender, EventArgs e)
        {
			Dictionary f = new Dictionary();
			this.Hide();
			f.ShowDialog();
			this.Show();
        }

        private void btnIntroducetions_Click(object sender, EventArgs e)
        {
			FIntroduction f = new FIntroduction();
			this.Hide();
			f.ShowDialog();
			this.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
			this.Hide();
			this.Close();
        }
    }
}
