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
    public struct Settings
    {
        public int win_width;
        public int win_height;

        public int maze_width;
        public int maze_height;
        public int maze_time;

        public int bot_number;
        public double bot_radius;
        public int bot_eyes;
        public double bot_speed;

        public bool learn_distance;

        public bool think_velocity;
        public bool think_distance;
        public bool think_path;

        public Settings(int window_width, int window_height,
                        int maze_width, int maze_height, int maze_cutoff_time,
                        int number_of_bots, double bot_radius,
                        int number_of_eyes, double bot_speed,
                        bool learn_distance, bool think_distance, bool think_velocity, bool think_path)
        {
            this.win_width = window_width;
            this.win_height = window_height;

            this.maze_width = maze_width;
            this.maze_height = maze_height;
            this.maze_time = maze_cutoff_time;

            this.bot_number = number_of_bots;
            this.bot_radius = bot_radius;
            this.bot_eyes = number_of_eyes;
            this.bot_speed = bot_speed;

            this.learn_distance = learn_distance;

            this.think_distance = think_distance;
            this.think_path = think_path;
            this.think_velocity = think_velocity;
        }
    }

    public partial class Menu : Form
    {
        public Settings settings;
        public static Settings minimums = new Settings(300, 300, 4, 4, 200, 0, 2.0, 1, 1.0, false, false, false, false);
        public static Settings maximums = new Settings(2000, 2000, 80, 80, 20000, 900, 20.0, 180, 16.0, true, true, true, true);

        public Menu()
        {
            InitializeComponent();
        }

        private int in_bounds(int num, int min, int max)
        {
            return Math.Max(min, Math.Min(max, num));
        }

        private double in_bounds(double num, double min, double max)
        {
            return Math.Max(min, Math.Min(max, num));
        }

        private void go_Click(object sender, EventArgs e)
        {
            bool significant = false;
            Settings old = Program.settings;
            Program.settings = new Settings();

            Program.settings.win_width = in_bounds(Convert.ToInt32(tbox_win_width.Text), minimums.win_width, maximums.win_width);
            Program.settings.win_height = in_bounds(Convert.ToInt32(tbox_win_height.Text), minimums.win_height, maximums.win_height);

            Program.settings.maze_width = in_bounds(Convert.ToInt32(tbox_maze_width.Text), minimums.maze_width, maximums.maze_width);
            Program.settings.maze_height = in_bounds(Convert.ToInt32(tbox_maze_height.Text), minimums.maze_height, maximums.maze_height);
            Program.settings.maze_time = in_bounds(Convert.ToInt32(tbox_maze_time.Text), minimums.maze_time, maximums.maze_time);

            Program.settings.bot_number = in_bounds(Convert.ToInt32(tbox_bot_num.Text), minimums.bot_number, maximums.bot_number);
            Program.settings.bot_radius = in_bounds(Convert.ToDouble(tbox_bot_radius.Text), minimums.bot_radius, maximums.bot_radius);
            Program.settings.bot_eyes = in_bounds(Convert.ToInt32(tbox_bot_eyes.Text), minimums.bot_eyes, maximums.bot_eyes);
            Program.settings.bot_speed = in_bounds(Convert.ToDouble(tbox_bot_speed.Text), minimums.bot_speed, maximums.bot_speed);

            Program.settings.learn_distance = check_learn_distance.Checked;

            Program.settings.think_distance = check_thinking_distance.Checked;
            Program.settings.think_path = check_thinking_path.Checked;
            Program.settings.think_velocity = check_thinking_velocity.Checked;

            significant |= old.bot_number != Program.settings.bot_number;
            significant |= old.bot_eyes != Program.settings.bot_eyes;
            significant |= old.learn_distance != Program.settings.learn_distance;
            significant |= old.think_distance != Program.settings.think_distance;
            significant |= old.think_path != Program.settings.think_path;
            significant |= old.think_velocity != Program.settings.think_velocity;

            Program.maze_form = new Maze_Form();

            if (Program.genalg == null || significant)
                Program.genalg = new GeneticAlg(Program.maze_form.ClientSize.Width - 1, Program.maze_form.ClientSize.Height - 1);

            Hide();
            Program.maze_form.Show();
        }
    }
}
