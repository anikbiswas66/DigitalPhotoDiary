﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalPhotoDiary
{
    public partial class PhotoDiary : Form
    {
        public PhotoDiary()
        {
            InitializeComponent();
        }

        private void PhotoDiary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
