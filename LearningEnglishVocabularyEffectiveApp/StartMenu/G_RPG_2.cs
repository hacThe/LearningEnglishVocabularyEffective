﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Guna.UI2.WinForms;
namespace StartMenu
{
	public partial class G_RPG_2 : Form
	{
		List<string> Words = new List<string>();
		List<string> Means = new List<string>();
		List<string> LinkPic = new List<string>();
		List<Guna2Button> rtbList = new List<Guna2Button>();
		Random r = new Random();
		List<int> answer = new List<int>();
		public G_RPG_2()
		{
			InitializeComponent();
			rtbList.Add(richTextBox2);
			rtbList.Add(richTextBox3);
			rtbList.Add(richTextBox4);
			//FormLoad();
			AddToRichTextBox();
			AddToCombobox();
			this.DoubleBuffered = true;
		}
		public G_RPG_2(List<string> _Words, List<string> _Means, List<string> _LinkPic)
		{
			InitializeComponent();
			rtbList.Add(richTextBox2);
			rtbList.Add(richTextBox3);
			rtbList.Add(richTextBox4);
			Words = new List<string>(_Words);
			Means = new List<string>(_Means);
			LinkPic = new List<string>(_LinkPic);
			AddToRichTextBox();
			AddToCombobox();
		}
		//<Page 1>
		void AddToCombobox()
		{
			comboBox1.DataSource = new List<string>(Words);
			comboBox2.DataSource = new List<string>(Words);
			comboBox3.DataSource = new List<string>(Words);
		}
		void AddToRichTextBox()
		{
			answer.Clear();
			for (int i = 0; i < 3; i++)
			{
				int k = r.Next(0, Words.Count);
				while (answer.IndexOf(k) != -1)
				{
					k = r.Next(0, Words.Count);
				}
				answer.Add(k);
				rtbList[i].Text = Means[k];
			}
		}
		void FormLoad()
		{
			string line;
			StreamReader file = new StreamReader("Data.txt");
			while ((line = file.ReadLine()) != null)
			{
				Words.Add(line.Substring(0, line.IndexOf(":")));
				Means.Add(line.Substring(line.IndexOf(":") + 2));
			}
		}

        private void btnSubmit_Click(object sender, EventArgs e)
        {
			if (comboBox1.SelectedIndex == answer[0] && comboBox2.SelectedIndex == answer[1]
				&& comboBox3.SelectedIndex == answer[2])
			{
				lblCorrect.Text = "Correct";
				lblCorrect.Visible = true;
			}
			else
			{
				lblCorrect.Text = "Incorrect";
				lblCorrect.Visible = true;
			}
			timerCorrect.Start();
		}

        private void timerCorrect_Tick(object sender, EventArgs e)
        {
			timerCorrect.Stop();
			if (lblCorrect.Text == "Correct")
            {
				G_RPG_3 game = new G_RPG_3(Words, LinkPic);
				game.AutoScroll = true;
				game.TopLevel = false;
				pnlLoad.Controls.Clear();
				pnlLoad.Controls.Add(game);

				game.FormBorderStyle = FormBorderStyle.None;
				game.Show();
				pnlLoad.Dock = DockStyle.Fill;
				pnlLoad.Visible = true;
			}
			else if (lblCorrect.Text == "Incorrect")
			{ 
			}
			lblCorrect.Visible = false;
        }
    }
}
