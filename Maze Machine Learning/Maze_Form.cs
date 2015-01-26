using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_Machine_Learning
{
    public partial class Maze_Form : Form
    {
        public Maze_Form()
        {
            InitializeComponent();
            this.Size = new Size(Program.settings.win_width, Program.settings.win_height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.mouse_tracker = new Eye_Tester(360, 200.0);
            this.MouseWheel += Form1_MouseWheel;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Program.mouse_tracker.move(e.X, e.Y);
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            Program.mouse_tracker.adjust(e.Delta * SystemInformation.MouseWheelScrollLines / 30);
        }

        private void Form1_LeftClick(object sender, MouseEventArgs e)
        {
            Program.mouse_tracker.visible = !Program.mouse_tracker.visible;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                Program.mouse_tracker.radius = 3.0 - Program.mouse_tracker.radius;
                e.Handled = true;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (Program.genalg != null)
                Program.genalg.update(e);

            Program.mouse_tracker.update_eyes(Program.genalg.maze);
            Program.mouse_tracker.draw(e);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (Program.genalg != null)
                Program.genalg.maze.scale(control.ClientSize.Width - 1, control.ClientSize.Height - 1);
        }

        private void tmrApp_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Maze_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.menu_form.Show();
        }
    }
}
