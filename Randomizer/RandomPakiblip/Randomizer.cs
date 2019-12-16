using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RandomPakiblip
{
    class Randomizer
    {

        private readonly Random aleatoire = new Random();
        private int MAX_X; // with of Map
        private int MAX_Y; // Height of Map
        private int percent; // possible block in Map in percent
        public double[,] table; // Main Table (Map)
        public int MAX_CASES; // Number of Block in Map
        public int NB_CASES; // Number of Reacheable Block by player
        private int pos_x; // player in X position
        private int pos_y; // player in Y position
        public double Time; // time in ms of generation map
        public IniFile Settings = new IniFile("config.ini"); //Settings file in same folder of executable or dll

        public void Progmain()
        {

            //set default values if not set in ./config.ini file
            if (Settings.Read("X", "Map") == "")
                Settings.Write("X", "20", "Map");
            if (Settings.Read("Y", "Map") == "")
                Settings.Write("Y", "20", "Map");
            if (Settings.Read("perscent", "Map") == "")
                Settings.Write("perscent", "20", "Map");
            if (Settings.Read("output", "HTML") == "")
                Settings.Write("output", "./", "HTML");
            if (Settings.Read("background", "HTML") == "")
                Settings.Write("background", "#fa6b6b", "HTML");

            //Define Config Map
            MAX_X = Int32.Parse(Settings.Read("X", "Map"));
            MAX_Y = Int32.Parse(Settings.Read("Y", "Map"));
            percent = Int32.Parse(Settings.Read("perscent", "Map"));

            if (percent > 61)
            {
                Console.WriteLine("percent is too hight change to 60%");
                percent = 60;
                Settings.Write("perscent", "60", "Map");
                Thread.Sleep(2000);
            }
            if ((MAX_X * MAX_Y) > 1000000)
            {
                Console.WriteLine(" Whow you realy think you can create a level more than 100 000 blocks ??? ");
                MAX_X = 100;
                MAX_Y = 100;
                Settings.Write("X", "100", "Map");
                Settings.Write("Y", "100", "Map");
                Thread.Sleep(2000);
            }

            table = new double[MAX_X, MAX_Y];
            MAX_CASES = MAX_X * MAX_Y;
            NB_CASES = (MAX_CASES * percent) / 100;


            while (true)
            {
                Console.Clear();
                TabToZero();

                PlacePlayer(aleatoire.Next(MAX_CASES));
                Console.WriteLine("player.x : " + pos_x);
                Console.WriteLine("player.y : " + pos_y);
                table[pos_x, pos_y] = MAX_CASES + 5;

                Time = 0;
                Console.WriteLine("Lenght : " + MAX_X + "x" + MAX_Y);
                Console.WriteLine("Max Cases : " + MAX_CASES);
                Console.WriteLine("Cases to reach : " + NB_CASES);
                Console.WriteLine("");
                Console.WriteLine("Loading...");
                Console.WriteLine("");
                TraceRoute();
                Console.Clear();
                if (NB_CASES < 100000)
                    Drawtab();
                Console.WriteLine("Save map ? (y/n)");
                var dofile = Console.ReadLine();
                Console.WriteLine("");
                if (dofile == "y" || dofile == "Y")
                    ConvertHTML();
                else
                    Console.WriteLine("No file created");
                Console.WriteLine("Done.");
                Console.ReadLine();

            }
        }

        void TabToZero()
        {
            //tout à 0
            for (int j = 0; j < MAX_Y; j++)
            {
                for (int i = 0; i < MAX_X; i++)
                {
                    table[i, j] = 0;
                }
            }
        }

        void Drawtab()
        {
            //affichage du tableau
            Console.WriteLine("player.x : " + pos_x);
            Console.WriteLine("player.y : " + pos_y);
            Console.WriteLine("Lenght : " + MAX_X + "x" + MAX_Y);
            Console.WriteLine("Max Cases : " + MAX_CASES + " (" + percent + "%)");
            Console.WriteLine("Cases to reach : " + NB_CASES);
            Console.WriteLine("");
            var line = "";
            for (int j = 0; j < MAX_Y; j++)
            {
                for (int i = 0; i < MAX_X; i++)
                {
                    //Why i decide to make this option :(
                    if (NB_CASES < 10)
                    {
                        if (table[i, j] == 0)
                            line += "█|";
                        else if (table[i, j] == MAX_CASES + 5)
                            line += "I|";
                        else if (table[i, j] > MAX_CASES)
                            line += "█|";
                        else
                            line += table[i, j] + "|";
                    }
                    else if (NB_CASES < 100)
                    {
                        if (table[i, j] == 0)
                            line += "██|";
                        else if (table[i, j] == MAX_CASES + 5)
                            line += "IN|";
                        else if (table[i, j] > MAX_CASES)
                            line += "██|";
                        else if (table[i, j] < 10)
                            line += table[i, j] + " |";
                        else
                            line += table[i, j] + "|";
                    }
                    else if (NB_CASES < 1000)
                    {
                        if (table[i, j] == 0)
                            line += "███|";
                        else if (table[i, j] == MAX_CASES + 5)
                            line += "INI|";
                        else if (table[i, j] > MAX_CASES)
                            line += "███|";
                        else if (table[i, j] < 10)
                            line += table[i, j] + "  |";
                        else if (table[i, j] < 100)
                            line += table[i, j] + " |";
                        else
                            line += table[i, j] + "|";
                    }
                    else if (NB_CASES < 10000)
                    {
                        if (table[i, j] == 0)
                            line += "████|";
                        else if (table[i, j] == MAX_CASES + 5)
                            line += "INIT|";
                        else if (table[i, j] > MAX_CASES)
                            line += "████|";
                        else if (table[i, j] < 10)
                            line += table[i, j] + "   |";
                        else if (table[i, j] < 100)
                            line += table[i, j] + "  |";
                        else if (table[i, j] < 1000)
                            line += table[i, j] + " |";
                        else
                            line += table[i, j] + "|";
                    }
                    else if (NB_CASES < 100000)
                    {
                        if (table[i, j] == 0)
                            line += "█████|";
                        else if (table[i, j] == MAX_CASES + 5)
                            line += "INIT!|";
                        else if (table[i, j] > MAX_CASES)
                            line += "█████|";
                        else if (table[i, j] < 10)
                            line += table[i, j] + "     |";
                        else if (table[i, j] < 100)
                            line += table[i, j] + "    |";
                        else if (table[i, j] < 1000)
                            line += table[i, j] + "   |";
                        else if (table[i, j] < 10000)
                            line += table[i, j] + "  |";
                        else if (table[i, j] < 100000)
                            line += table[i, j] + " |";
                        else
                            line += table[i, j] + "|";
                    }
                    else
                    {
                        if (table[i, j] == 0)
                            line += "██████|";
                        else if (table[i, j] == MAX_CASES + 5)
                            line += "INIT!!|";
                        else if (table[i, j] > MAX_CASES)
                            line += "██████|";
                        else if (table[i, j] < 10)
                            line += table[i, j] + "      |";
                        else if (table[i, j] < 100)
                            line += table[i, j] + "     |";
                        else if (table[i, j] < 1000)
                            line += table[i, j] + "    |";
                        else if (table[i, j] < 10000)
                            line += table[i, j] + "   |";
                        else if (table[i, j] < 100000)
                            line += table[i, j] + "  |";
                        else if (table[i, j] < 1000000)
                            line += table[i, j] + " |";
                        else
                            line += table[i, j] + "|";
                    }
                }
                Console.WriteLine(line);
                line = "";
            }
            Console.WriteLine("-------------------------------- " + Time + " ms");
        }

        void ConvertHTML()
        {

            var directory = Settings.Read("output", "HTML");
            var progress = 0;
            string back_color;
            if (Settings.Read("background", "HTML").Length > 7)
                back_color = "#ffffff";
            else
                back_color = Settings.Read("background", "HTML");
            Console.WriteLine("file name (without extention): ");
            string filename = Console.ReadLine();
            var Now = DateTime.Now;

            //affichage du tableau
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"" + directory + filename + ".html", true))
            {
                file.WriteLine("<style>");
                file.WriteLine("body {");
                file.WriteLine("font-family: \"Courier New\", Courier, monospace;");
                file.WriteLine("background-color:" + back_color + ";");
                file.WriteLine("}");
                file.WriteLine("</style>");

                file.WriteLine("<body>");
                file.WriteLine("<div style=\"text-align:center;\"><a href=\"./index.html\">Back to map list</a></div>");
                file.WriteLine("<h2>Pakiblip Randomizer level v2.2 </h2><br>");

                file.WriteLine(" (Tip: press ctrl + F and start searching INIT! word (his name can be I, IN, INI, INIT))<br>");
                file.WriteLine("player.x : " + pos_x + "<br>");
                file.WriteLine("player.y : " + pos_y + "<br><br>");
                file.WriteLine("Map size : " + MAX_X + "x" + MAX_Y + "<br>");
                file.WriteLine("Max Cases : " + MAX_CASES + "<br>");
                file.WriteLine("Cases to reach : " + NB_CASES + "<br><br>");
                file.WriteLine("Developed with Visual Studio in C# (.NET)<br>");
                file.WriteLine("By GaumKap<br><br>");
                var line = "";
                for (int j = 0; j < MAX_Y; j++)
                {
                    for (int i = 0; i < MAX_X; i++)
                    {
                        if (NB_CASES < 10)
                        {
                            if (table[i, j] == 0)
                                line += "█|";
                            else if (table[i, j] == MAX_CASES + 5)
                                line += "<b>I</b>|";
                            else if (table[i, j] > MAX_CASES)
                                line += "█|";
                            else
                                line += table[i, j] + "|";
                        }
                        else if (NB_CASES < 100)
                        {
                            if (table[i, j] == 0)
                                line += "██|";
                            else if (table[i, j] == MAX_CASES + 5)
                                line += "<b>IN</b>|";
                            else if (table[i, j] > MAX_CASES)
                                line += "██|";
                            else if (table[i, j] < 10)
                                line += table[i, j] + "&nbsp;|";
                            else
                                line += table[i, j] + "|";
                        }
                        else if (NB_CASES < 1000)
                        {
                            if (table[i, j] == 0)
                                line += "███|";
                            else if (table[i, j] == MAX_CASES + 5)
                                line += "<b>INI</b>|";
                            else if (table[i, j] > MAX_CASES)
                                line += "███|";
                            else if (table[i, j] < 10)
                                line += table[i, j] + "&nbsp;&nbsp;|";
                            else if (table[i, j] < 100)
                                line += table[i, j] + "&nbsp;|";
                            else
                                line += table[i, j] + "|";
                        }
                        else if (NB_CASES < 10000)
                        {
                            if (table[i, j] == 0)
                                line += "████|";
                            else if (table[i, j] == MAX_CASES + 5)
                                line += "<b>INIT</b>|";
                            else if (table[i, j] > MAX_CASES)
                                line += "████|";
                            else if (table[i, j] < 10)
                                line += table[i, j] + "&nbsp;&nbsp;&nbsp;|";
                            else if (table[i, j] < 100)
                                line += table[i, j] + "&nbsp;&nbsp;|";
                            else if (table[i, j] < 1000)
                                line += table[i, j] + "&nbsp;|";
                            else
                                line += table[i, j] + "|";
                        }
                        else
                        {
                            if (table[i, j] == 0)
                                line += "█████|";
                            else if (table[i, j] == MAX_CASES + 5)
                                line += "INIT!|";
                            else if (table[i, j] > MAX_CASES)
                                line += "█████|";
                            else if (table[i, j] < 10)
                                line += table[i, j] + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|";
                            else if (table[i, j] < 100)
                                line += table[i, j] + "&nbsp;&nbsp;&nbsp;&nbsp;|";
                            else if (table[i, j] < 1000)
                                line += table[i, j] + "&nbsp;&nbsp;&nbsp;|";
                            else if (table[i, j] < 10000)
                                line += table[i, j] + "&nbsp;&nbsp;|";
                            else if (table[i, j] < 100000)
                                line += table[i, j] + "&nbsp;|";
                            else
                                line += table[i, j] + "|";
                        }
                    }
                    file.WriteLine(line + "<br>");
                    line = "";
                    progress++;
                    Console.Write("\r{0}%   ", progress + "/" + MAX_Y);
                }
                file.WriteLine("<br><br>");
                file.WriteLine("Generated at : " + Now.ToString("g") + "<br>");
                file.WriteLine("GaumKap 2019 : <a href = \"http://gaumkap.blogspot.com/\" > http://gaumkap.blogspot.com/</a><br>");
                file.WriteLine("</body>");
            }

            using (System.IO.StreamWriter index =
            new System.IO.StreamWriter(@"" + directory + "index.html", true))
            { index.WriteLine("<a href=\"./" + filename + ".html\">" + filename + "</a> | " + Now.ToString("g") + "<br>"); }
            Console.Clear();
            Console.WriteLine("done.");
        }

        void TraceRoute()
        {
            var rem_cases = 0;
            var nb_road = 1;
            var x = pos_x; //lin
            var y = pos_y; //colon
            var hystory = new Hystory[NB_CASES + 2];
            hystory[0].x = pos_x;
            hystory[0].y = pos_y;
            hystory[0].nb = 0;
            while (rem_cases < NB_CASES)
            {
                var dir = aleatoire.Next(4);
                //Console.WriteLine(dir);
                /*0:left - 1:right - 2:up - 3:down*/
                if (dir == 0 && hystory[rem_cases].old_pos != "right" && (x - 1) >= 0 && table[x - 1, y] == 0)
                {
                    table[x - 1, y] = nb_road;
                    rem_cases++;
                    nb_road++;
                    x--;
                    hystory[rem_cases].x = x;
                    hystory[rem_cases].y = y;
                    //x--;
                    hystory[rem_cases].nb = rem_cases;
                    hystory[rem_cases].old_pos = "right";
                }
                else if (dir == 1 && hystory[rem_cases].old_pos != "left" && (x + 1) <= (MAX_X - 1) && table[x + 1, y] == 0)
                {
                    table[x + 1, y] = nb_road;
                    rem_cases++;
                    nb_road++;
                    x++;
                    hystory[rem_cases].x = x;
                    hystory[rem_cases].y = y;
                    hystory[rem_cases].nb = rem_cases;
                    hystory[rem_cases].old_pos = "left";
                    //x++;

                }
                else if (dir == 2 && hystory[rem_cases].old_pos != "down" && (y - 1) >= 0 && table[x, y - 1] == 0)
                {
                    table[x, y - 1] = nb_road;
                    rem_cases++;
                    nb_road++;
                    y--;
                    hystory[rem_cases].x = x;
                    hystory[rem_cases].y = y;
                    //y--;
                    hystory[rem_cases].nb = rem_cases;
                    hystory[rem_cases].old_pos = "down";
                }
                else if (dir == 3 && hystory[rem_cases].old_pos != "up" && (y + 1) <= (MAX_Y - 1) && table[x, y + 1] == 0)
                {
                    table[x, y + 1] = nb_road;
                    rem_cases++;
                    nb_road++;
                    y++;
                    hystory[rem_cases].x = x;
                    hystory[rem_cases].y = y;
                    //y++;
                    hystory[rem_cases].nb = rem_cases;
                    hystory[rem_cases].old_pos = "up";
                }
                else
                {
                    if (hystory[rem_cases].x == pos_x && hystory[rem_cases].y == pos_y)
                    {
                        TabToZero();
                        table[pos_x, pos_y] = 1;
                    }

                    if (hystory[rem_cases].nb == 0) { }
                    // Restart random position beacause is player position
                    else
                    {
                        //Console.WriteLine(dir + " imposible");
                        //if (rem_cases == 0) Console.WriteLine("hisorique : " + hystory[rem_cases]);
                        //else Console.WriteLine("Historique : " + hystory[rem_cases]);
                        //retest in all direction
                        if (hystory[rem_cases].old_pos != "right" && (x - 1) >= 0 && table[x - 1, y] == 0)
                        {
                            table[x - 1, y] = nb_road;
                            rem_cases++;
                            nb_road++;
                            x--;
                            hystory[rem_cases].x = x;
                            hystory[rem_cases].y = y;
                            //x--;
                            hystory[rem_cases].nb = rem_cases;
                            hystory[rem_cases].old_pos = "right";
                            //Console.WriteLine("0");
                        }
                        else if (hystory[rem_cases].old_pos != "left" && (x + 1) <= (MAX_X - 1) && table[x + 1, y] == 0)
                        {
                            table[x + 1, y] = nb_road;
                            rem_cases++;
                            nb_road++;
                            x++;
                            hystory[rem_cases].x = x;
                            hystory[rem_cases].y = y;
                            //x++;
                            hystory[rem_cases].nb = rem_cases;
                            hystory[rem_cases].old_pos = "left";
                            //Console.WriteLine("1");
                        }
                        else if (hystory[rem_cases].old_pos != "down" && (y - 1) >= 0 && table[x, y - 1] == 0)
                        {
                            table[x, y - 1] = nb_road;
                            rem_cases++;
                            nb_road++;
                            y--;
                            hystory[rem_cases].x = x;
                            hystory[rem_cases].y = y;
                            //y--;
                            hystory[rem_cases].nb = rem_cases;
                            hystory[rem_cases].old_pos = "down";
                            //Console.WriteLine("2");
                        }
                        else if (hystory[rem_cases].old_pos != "up" && (y + 1) <= (MAX_Y - 1) && table[x, y + 1] == 0)
                        {
                            table[x, y + 1] = nb_road;
                            rem_cases++;
                            nb_road++;
                            y++;
                            hystory[rem_cases].x = x;
                            hystory[rem_cases].y = y;
                            //y++;
                            hystory[rem_cases].nb = rem_cases;
                            hystory[rem_cases].old_pos = "up";
                            //Console.WriteLine("3");
                        }
                        else
                        {
                            //Console.WriteLine("back :(");
                            table[x, y] = MAX_CASES + 1;
                            if (rem_cases > 0) rem_cases--;
                            if (nb_road > 1) nb_road--;
                            x = hystory[rem_cases].x;
                            y = hystory[rem_cases].y;
                        }
                    }
                }

                //Drawtab();
                //System.Threading.Thread.Sleep(1);
                //Time += 1;
                Console.Write("\r{0}%   ", rem_cases + "/" + NB_CASES);
                //Console.Clear();
            }


        }

        void PlacePlayer(int var)
        {
            var test = 0;
            pos_x = 0;
            pos_y = 0;
            while (test < var)
            {
                if (pos_x == MAX_X)
                {
                    pos_y++;
                    pos_x = 0;
                }
                pos_x++;
                test++;
            }
            if (pos_x > 19) pos_x--;
            if (pos_y > 19) pos_y--;
        }
    }
}
