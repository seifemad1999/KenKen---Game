using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Timers;
using System.Threading;


namespace KenKen
{
    
    

    public partial class Form1 : Form
    {
        

        Dictionary<string, Button> map_index_btns = new Dictionary<string, Button> (49);
        Random rand = new Random();
        int random_x , plus_x;
        int random_y , plus_y;
        char chosenop;
        string operation;
        
        string reesult;
        Action[] functions_3;
        Action[] functions_4;
        Action[] functions_5;
        Action[] functions_6;
        Action[] functions_7;
        // int [,] mainarr = new int[5,5];

        char[] op = new char[4];
        int delay = 400;
        int xx;
        int generated;
        string time;
        string time_algorithim;
        bool flag = false;
        int size = 5;
        int time_in_number;
        int[][] board = new int[10][];
        int btn_result;

        Label[] lables = new Label[49];
        Button[] buttons = new Button[49];
        Button[] buttons_3 = new Button[9];
        Button[] buttons_4 = new Button[16];
        Button[] buttons_5 = new Button[25];
        Button[] buttons_6 = new Button[36];
        Button[] buttons_7 = new Button[49];

        int diff(int x=0, int y=0, int z=0)
        {
            int[] arr = new int[] { x, y, z };
            Array.Sort(arr);
            Array.Reverse(arr);
            return (arr[0] - arr[1] - arr[2]);
        }

        void swap(int[] num, int a, int b)
        {
            int temp = num[a];
            num[a] = num[b];
            num[b] = temp;
        }
        
        void shuffle(int[] num)
        {
            Random rnd = new Random();
            for (int x = 0; x < num.Length; x++)
                swap(num, x, rnd.Next(1,num.Length));
        }


        int[] createOrderedArray(int size, int startValue)
        {
            int[] num = new int[size];
            for (int x = 0; x < num.Length; x++)
                num[x] = x + startValue;
            return num;
        }

        bool compareArray(int[] num1, int[] num2)
        {
            if (num1.Length != num2.Length)
                return false;
            for (int x = 0; x < num1.Length; x++)
                if (num1[x] == num2[x])
                    return false;
            return true;
        }

        bool compare2DArray(int[] num1, int[][] num2, int start, int end)
        {
            for (int x = start; x < end; x++)
                if (!compareArray(num1, num2[x]))
                    return false;
            return true;
        }


        void Board_Generation()
        {
            /* Board Generation */
            board[0] = createOrderedArray(size, 1);
            shuffle(board[0]);
            for (int x = 1; x < size; x++)
            {
                board[x] = createOrderedArray(size, 1);
                do
                {
                    shuffle(board[x]);
                } while (!compare2DArray(board[x], board, 0, x));
            }
        }


        void append_labels ()
        {
            lables[0] = label1;
            lables[1] = label2;
            lables[2] = label3;
            lables[3] = label4;
            lables[4] = label5;
            lables[5] = label6;
            lables[6] = label7;
            lables[7] = label8;
            lables[8] = label9;
            lables[9] = label10;
            lables[10] = label11;
            lables[11] = label12;
            lables[12] = label13;
            lables[13] = label14;
            lables[14] = label15;
            lables[15] = label16;
            lables[16] = label17;
            lables[17] = label18;
            lables[18] = label19;
            lables[19] = label20;
            lables[20] = label21;
            lables[21] = label22;
            lables[22] = label23;
            lables[23] = label24;
            lables[24] = label25;
            lables[25] = label26;
            lables[26] = label27;
            lables[27] = label28;
            lables[28] = label29;
            lables[29] = label30;
            lables[30] = label31;
            lables[31] = label32;
            lables[32] = label33;
            lables[33] = label34;
            lables[34] = label35;
            lables[35] = label36;
            lables[36] = label37;
            lables[37] = label38;
            lables[38] = label39;
            lables[39] = label40;
            lables[40] = label41;
            lables[41] = label42;
            lables[42] = label43;
            lables[43] = label44;
            lables[44] = label45;
            lables[45] = label46;
            lables[46] = label47;
            lables[47] = label48;
            lables[48] = label49;
        }

        void append_buttons ()
        {
            buttons[0] = btn1;
            buttons[1] = btn2;
            buttons[2] = btn3;
            buttons[3] = btn4;
            buttons[4] = btn5;
            buttons[5] = btn6;
            buttons[6] = btn7;
            buttons[7] = btn8;
            buttons[8] = btn9;
            buttons[9] = btn10;
            buttons[10] = btn11;
            buttons[11] = btn12;
            buttons[12] = btn13;
            buttons[13] = btn14;
            buttons[14] = btn15;
            buttons[15] = btn16;
            buttons[16] = btn17;
            buttons[17] = btn18;
            buttons[18] = btn19;
            buttons[19] = btn20;
            buttons[20] = btn21;
            buttons[21] = btn22;
            buttons[22] = btn23;
            buttons[23] = btn24;
            buttons[24] = btn25;
            buttons[25] = btn26;
            buttons[26] = btn27;
            buttons[27] = btn28;
            buttons[28] = btn29;
            buttons[29] = btn30;
            buttons[30] = btn31;
            buttons[31] = btn32;
            buttons[32] = btn33;
            buttons[33] = btn34;
            buttons[34] = btn35;
            buttons[35] = btn36;
            buttons[36] = btn37;
            buttons[37] = btn38;
            buttons[38] = btn39;
            buttons[39] = btn40;
            buttons[40] = btn41;
            buttons[41] = btn42;
            buttons[42] = btn43;
            buttons[43] = btn44;
            buttons[44] = btn45;
            buttons[45] = btn46;
            buttons[46] = btn47;
            buttons[47] = btn48;
            buttons[48] = btn49;
        }

        void append_buttons_3()
        {
            buttons_3[0] = btn17;
            buttons_3[1] = btn18;
            buttons_3[2] = btn19;
            buttons_3[3] = btn24;
            buttons_3[4] = btn25;
            buttons_3[5] = btn26;
            buttons_3[6] = btn31;
            buttons_3[7] = btn32;
            buttons_3[8] = btn33;
        }

        void append_buttons_4()
        {
            buttons_4[0] = btn16;
            buttons_4[1] = btn17;
            buttons_4[2] = btn18;
            buttons_4[3] = btn19;
            buttons_4[4] = btn23;
            buttons_4[5] = btn24;
            buttons_4[6] = btn25;
            buttons_4[7] = btn26;
            buttons_4[8] = btn30;
            buttons_4[9] = btn31;
            buttons_4[10] = btn32;
            buttons_4[11] = btn33;
            buttons_4[12] = btn37;
            buttons_4[13] = btn38;
            buttons_4[14] = btn39;
            buttons_4[15] = btn40;
        }

        void append_buttons_5()
        {
            buttons_5[0] = btn9;
            buttons_5[1] = btn10;
            buttons_5[2] = btn11;
            buttons_5[3] = btn12;
            buttons_5[4] = btn13;
            buttons_5[5] = btn16;
            buttons_5[6] = btn17;
            buttons_5[7] = btn18;
            buttons_5[8] = btn19;
            buttons_5[9] = btn20;
            buttons_5[10] = btn23;
            buttons_5[11] = btn24;
            buttons_5[12] = btn25;
            buttons_5[13] = btn26;
            buttons_5[14] = btn27;
            buttons_5[15] = btn30;
            buttons_5[16] = btn31;
            buttons_5[17] = btn32;
            buttons_5[18] = btn33;
            buttons_5[19] = btn34;
            buttons_5[20] = btn37;
            buttons_5[21] = btn38;
            buttons_5[22] = btn39;
            buttons_5[23] = btn40;
            buttons_5[24] = btn41;
        }

        void append_buttons_6()
        {
            buttons_6[0] = btn9;
            buttons_6[1] = btn10;
            buttons_6[2] = btn11;
            buttons_6[3] = btn12;
            buttons_6[4] = btn13;
            buttons_6[5] = btn14;
            buttons_6[6] = btn16;
            buttons_6[7] = btn17;
            buttons_6[8] = btn18;
            buttons_6[9] = btn19;
            buttons_6[10] = btn20;
            buttons_6[11] = btn21;
            buttons_6[12] = btn23;
            buttons_6[13] = btn24;
            buttons_6[14] = btn25;
            buttons_6[15] = btn26;
            buttons_6[16] = btn27;
            buttons_6[17] = btn28;
            buttons_6[18] = btn30;
            buttons_6[19] = btn31;
            buttons_6[20] = btn32;
            buttons_6[21] = btn33;
            buttons_6[22] = btn34;
            buttons_6[23] = btn35;
            buttons_6[24] = btn37;
            buttons_6[25] = btn38;
            buttons_6[26] = btn39;
            buttons_6[27] = btn40;
            buttons_6[28] = btn41;
            buttons_6[29] = btn42;
            buttons_6[30] = btn44;
            buttons_6[31] = btn45;
            buttons_6[32] = btn46;
            buttons_6[33] = btn47;
            buttons_6[34] = btn48;
            buttons_6[35] = btn49;
        }

        void append_buttons_7()
        {
            buttons_7[0] = btn1;
            buttons_7[1] = btn2;
            buttons_7[2] = btn3;
            buttons_7[3] = btn4;
            buttons_7[4] = btn5;
            buttons_7[5] = btn6;
            buttons_7[6] = btn7;
            buttons_7[7] = btn8;
            buttons_7[8] = btn9;
            buttons_7[9] = btn10;
            buttons_7[10] = btn11;
            buttons_7[11] = btn12;
            buttons_7[12] = btn13;
            buttons_7[13] = btn14;
            buttons_7[14] = btn15;
            buttons_7[15] = btn16;
            buttons_7[16] = btn17;
            buttons_7[17] = btn18;
            buttons_7[18] = btn19;
            buttons_7[19] = btn20;
            buttons_7[20] = btn21;
            buttons_7[21] = btn22;
            buttons_7[22] = btn23;
            buttons_7[23] = btn24;
            buttons_7[24] = btn25;
            buttons_7[25] = btn26;
            buttons_7[26] = btn27;
            buttons_7[27] = btn28;
            buttons_7[28] = btn29;
            buttons_7[29] = btn30;
            buttons_7[30] = btn31;
            buttons_7[31] = btn32;
            buttons_7[32] = btn33;
            buttons_7[33] = btn34;
            buttons_7[34] = btn35;
            buttons_7[35] = btn36;
            buttons_7[36] = btn37;
            buttons_7[37] = btn38;
            buttons_7[38] = btn39;
            buttons_7[39] = btn40;
            buttons_7[40] = btn41;
            buttons_7[41] = btn42;
            buttons_7[42] = btn43;
            buttons_7[43] = btn44;
            buttons_7[44] = btn45;
            buttons_7[45] = btn46;
            buttons_7[46] = btn47;
            buttons_7[47] = btn48;
            buttons_7[48] = btn49;

        }

        void disable_labels()
        {
            for(int i = 0; i < 49; i++)
            {
                lables[i].Visible = false;
            }
        }

        void disable_buttons()
        {
            for (int i = 0; i < 49; i++)
            {
                buttons[i].Hide();
            }
        }



        void First_Senario_3()
        {
            /* Write in File */
            String path = "in.txt";
            StreamWriter file = new StreamWriter(path);
            if(comboBox2.Text == "backtracking algorithm")
            {
                file.WriteLine("a1");
            }
            else if (comboBox2.Text == "forward checking algorithm")
            {
                file.WriteLine("a2");
            }
            else if (comboBox2.Text == "arc consistency algorithm")
            {
                file.WriteLine("a3");
            }
            
            file.WriteLine("3");
                

            btn17.BackColor = Color.LightPink;
            btn24.BackColor = Color.LightPink;
            file.WriteLine("0,0");
            file.WriteLine("1,0");
            btn_result = diff(board[0][0], board[1][0]);
              
            label17.Text = "-" + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine("-");
            
            btn18.BackColor = Color.LightGreen;
            btn19.BackColor = Color.LightGreen;
            file.WriteLine("0,1");
            file.WriteLine("0,2");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][2] + board[0][1];
                    break;

                case '-':
                    btn_result = diff(board[0][2], board[0][1]);
                    break;
                case '*':
                    btn_result = board[0][2] * board[0][1];
                    break;
            }
            operation = chosenop.ToString();
            reesult = btn_result.ToString();
            label18.Text = operation + reesult;
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn25.BackColor = Color.LightBlue;
            btn31.BackColor = Color.LightBlue;
            btn32.BackColor = Color.LightBlue;
            file.WriteLine("1,1");
            file.WriteLine("2,0");
            file.WriteLine("2,1");
     
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[2][0] + board[1][1] + board[2][1];
                    break;

                case '-':
                    btn_result = diff(board[2][0] , board[1][1] , board[2][1]);
                    break;
                case '*':
                    btn_result = board[2][0] * board[1][1] * board[2][1];
                    break;
            }
            label25.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn26.BackColor = Color.LightCoral;
            btn33.BackColor = Color.LightCoral;
            file.WriteLine("1,2");
            file.WriteLine("2,2");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][2] + board[2][2];
                    break;

                case '-':
                    btn_result = diff(board[1][2], board[2][2]);
                    break;
                case '*':
                    btn_result = board[1][2] * board[2][2];
                    break;
            }
            label26.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());
            file.Close();

            label17.Visible = true;
            label18.Visible = true;
            label25.Visible = true;
            label26.Visible = true;
        }

        void Second_Senario_3()
        {
            /* Write in File */
            String path = "in.txt";
            StreamWriter file = new StreamWriter(path);
            if (comboBox2.Text == "backtracking algorithm")
            {
                file.WriteLine("a1");
            }
            else if (comboBox2.Text == "forward checking algorithm")
            {
                file.WriteLine("a2");
            }
            else if (comboBox2.Text == "arc consistency algorithm")
            {
                file.WriteLine("a3");
            }
            file.WriteLine("3");

            btn17.BackColor = Color.LightBlue;
            btn24.BackColor = Color.LightBlue;
            btn18.BackColor = Color.LightBlue;
            file.WriteLine("0,0");
            file.WriteLine("0,1");
            file.WriteLine("1,0");
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][0] + board[0][1] + board[1][0];
                    break;

                case '-':
                    btn_result = diff(board[0][0] , board[0][1] , board[1][0]);
                    break;
                case '*':
                    btn_result = board[0][0] * board[0][1] * board[1][0];
                    break;
            }
            label17.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn25.BackColor = Color.LightPink;
            btn31.BackColor = Color.LightPink;
            btn32.BackColor = Color.LightPink;
            file.WriteLine("1,1");
            file.WriteLine("2,0");
            file.WriteLine("2,1");
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][1] + board[2][0] + board[2][1];
                    break;

                case '-':
                    btn_result = diff(board[1][1] , board[2][0] , board[2][1]);
                    break;
                case '*':
                    btn_result = board[1][1] * board[2][0] * board[2][1];
                    break;
            }
            label25.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn19.BackColor = Color.LightCoral;
            btn26.BackColor = Color.LightCoral;
            btn33.BackColor = Color.LightCoral;
            file.WriteLine("0,2");
            file.WriteLine("1,2");
            file.WriteLine("2,2");
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][2] + board[1][2] + board[2][2];
                    break;

                case '-':
                    btn_result = diff(board[0][2] , board[1][2] , board[2][2]);
                    break;
                case '*':
                    btn_result = board[0][2] * board[1][2] * board[2][2];
                    break;
            }
            label19.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());
            file.Close();
            label17.Visible = true;
            label19.Visible = true;
            label25.Visible = true;
        }

        void Third_Senario_3()
        {
            /* Write in File */
            String path = "in.txt";
            StreamWriter file = new StreamWriter(path);
            if (comboBox2.Text == "backtracking algorithm")
            {
                file.WriteLine("a1");
            }
            else if (comboBox2.Text == "forward checking algorithm")
            {
                file.WriteLine("a2");
            }
            else if (comboBox2.Text == "arc consistency algorithm")
            {
                file.WriteLine("a3");
            }
            file.WriteLine("3");

            btn17.BackColor = Color.LightBlue;
            btn24.BackColor = Color.LightBlue;
            btn25.BackColor = Color.LightBlue;
            file.WriteLine("0,0");
            file.WriteLine("1,0");
            file.WriteLine("1,1");
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][0] + board[1][0] + board[1][1];
                    break;

                case '-':
                    btn_result = diff(board[0][0] , board[1][0] , board[1][1]);
                    break;
                case '*':
                    btn_result = board[0][0] * board[1][0] * board[1][1];
                    break;
            }
            label17.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn26.BackColor = Color.LightGreen;
            btn33.BackColor = Color.LightGreen;
            file.WriteLine("1,2");
            file.WriteLine("2,2");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][2] + board[2][2] ;
                    break;

                case '-':
                    btn_result = diff(board[1][2] , board[2][2]);
                    break;
                case '*':
                    btn_result = board[1][2] * board[2][2];
                    break;
            }
            label26.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn31.BackColor = Color.LightPink;
            btn32.BackColor = Color.LightPink;
            file.WriteLine("2,0");
            file.WriteLine("2,1");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[2][0] + board[2][1] ;
                    break;

                case '-':
                    btn_result = diff(board[2][0] , board[2][1]);
                    break;
                case '*':
                    btn_result = board[2][0] * board[2][1];
                    break;
            }
            label31.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn18.BackColor = Color.LightCyan;
            file.WriteLine("0,1");
            label18.Text = board[0][1].ToString();
            file.WriteLine(board[0][1].ToString());
            file.WriteLine("#");

            btn19.BackColor = Color.Ivory;
            file.WriteLine("0,2");
            label19.Text = board[0][2].ToString();
            file.WriteLine(board[0][2].ToString());
            file.WriteLine("#");
            file.Close();

            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label26.Visible = true;
            label31.Visible = true;
        }

        void Fourth_Senario_3()
        {
            btn17.BackColor = Color.LightYellow;
            btn24.BackColor = Color.LightYellow;
            btn25.BackColor = Color.LightYellow;
            
            btn18.BackColor = Color.LightBlue;
            btn19.BackColor = Color.LightBlue;
            btn26.BackColor = Color.LightBlue;
            
            btn31.BackColor = Color.LightPink;
            btn32.BackColor = Color.LightPink;
            btn33.BackColor = Color.LightPink;
        }      // Not Done yet

        void Fifth_Senario_3()
        {
            btn17.BackColor = Color.LavenderBlush;
            btn24.BackColor = Color.LavenderBlush;
            btn25.BackColor = Color.LavenderBlush;

            btn31.BackColor = Color.LightSkyBlue;
            btn32.BackColor = Color.LightSkyBlue;

            btn26.BackColor = Color.LightCoral;
            btn33.BackColor = Color.LightCoral;

            btn18.BackColor = Color.LightPink;
            btn19.BackColor = Color.LightPink;
        }       // Not Done yet





        void First_Senario_4()
        {
            /* Write in File */
            String path = "in.txt";
            StreamWriter file = new StreamWriter(path);
            if (comboBox2.Text == "backtracking algorithm")
            {
                file.WriteLine("a1");
            }
            else if (comboBox2.Text == "forward checking algorithm")
            {
                file.WriteLine("a2");
            }
            else if (comboBox2.Text == "arc consistency algorithm")
            {
                file.WriteLine("a3");
            }
            file.WriteLine("4");

            btn16.BackColor = Color.LightBlue;
            btn23.BackColor = Color.LightBlue;
            file.WriteLine("0,0");
            file.WriteLine("1,0");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][0] + board[1][0];
                    break;

                case '-':
                    btn_result = diff(board[0][0], board[1][0]);
                    break;
                case '*':
                    btn_result = board[0][0] * board[1][0];
                    break;
            }
            label16.Text = chosenop.ToString() + btn_result.ToString(); 
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn30.BackColor = Color.LightSeaGreen;
            btn37.BackColor = Color.LightSeaGreen;
            file.WriteLine("2,0");
            file.WriteLine("3,0");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[2][0] + board[3][0];
                    break;

                case '-':
                    btn_result = diff(board[2][0], board[3][0]);
                    break;
                case '*':
                    btn_result = board[2][0] * board[3][0];
                    break;
            }
            label30.Text = chosenop.ToString() + btn_result.ToString(); 
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn17.BackColor = Color.LightGreen;
            btn18.BackColor = Color.LightGreen;
            file.WriteLine("0,1");
            file.WriteLine("0,2");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][1] + board[0][2];
                    break;

                case '-':
                    btn_result = diff(board[0][1], board[0][2]);
                    break;
                case '*':
                    btn_result = board[0][1] * board[0][2];
                    break;
            }
            label17.Text = chosenop.ToString() + btn_result.ToString(); 
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn19.BackColor = Color.LightPink;
            btn26.BackColor = Color.LightPink;
            file.WriteLine("0,3");
            file.WriteLine("1,3");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][3] + board[1][3];
                    break;

                case '-':
                    btn_result = diff(board[0][3], board[1][3]);
                    break;
                case '*':
                    btn_result = board[0][3] * board[1][3];
                    break;
            }
            label19.Text = chosenop.ToString() + btn_result.ToString(); 
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn24.BackColor = Color.LightSalmon;
            btn31.BackColor = Color.LightSalmon;
            file.WriteLine("1,1");
            file.WriteLine("2,1");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][1] + board[2][1];
                    break;

                case '-':
                    btn_result = diff(board[1][1], board[2][1]);
                    break;
                case '*':
                    btn_result = board[1][1] * board[2][1];
                    break;
            }
            label24.Text = chosenop.ToString() + btn_result.ToString(); 
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn25.BackColor = Color.LightCyan;
            btn32.BackColor = Color.LightCyan;
            file.WriteLine("1,2");
            file.WriteLine("2,2");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][2] + board[2][2];
                    break;

                case '-':
                    btn_result = diff(board[1][2], board[2][2]);
                    break;
                case '*':
                    btn_result = board[1][2] * board[2][2];
                    break;
            }
            label25.Text = chosenop.ToString() + btn_result.ToString(); 
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn38.BackColor = Color.LightYellow;
            btn39.BackColor = Color.LightYellow;
            file.WriteLine("3,1");
            file.WriteLine("3,2");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[3][1] + board[3][2];
                    break;

                case '-':
                    btn_result = diff(board[3][1], board[3][2]);
                    break;
                case '*':
                    btn_result = board[3][1] * board[3][2];
                    break;
            }
            label38.Text = chosenop.ToString() + btn_result.ToString(); 
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn33.BackColor = Color.LightCoral;
            btn40.BackColor = Color.LightCoral;
            file.WriteLine("2,3");
            file.WriteLine("3,3");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[2][3] + board[3][3];
                    break;

                case '-':
                    btn_result = diff(board[2][3], board[3][3]);
                    break;
                case '*':
                    btn_result = board[2][3] * board[3][3];
                    break;
            }
            label33.Text = chosenop.ToString() + btn_result.ToString(); 
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            file.Close();
            label16.Visible = true;
            label30.Visible = true;
            label17.Visible = true;
            label19.Visible = true;
            label24.Visible = true;
            label25.Visible = true;
            label38.Visible = true;
            label33.Visible = true;
        }

        void Second_Senario_4()
        {
            /* Write in File */
            String path = "in.txt";
            StreamWriter file = new StreamWriter(path);
            if (comboBox2.Text == "backtracking algorithm")
            {
                file.WriteLine("a1");
            }
            else if (comboBox2.Text == "forward checking algorithm")
            {
                file.WriteLine("a2");
            }
            else if (comboBox2.Text == "arc consistency algorithm")
            {
                file.WriteLine("a3");
            }
            file.WriteLine("4");

            btn24.BackColor = Color.LightSkyBlue;
            btn31.BackColor = Color.LightSkyBlue;
            file.WriteLine("1,1");
            file.WriteLine("2,1");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][1] + board[2][1];
                    break;

                case '-':
                    btn_result = diff(board[1][1], board[2][1]);
                    break;
                case '*':
                    btn_result = board[1][1] * board[2][1];
                    break;
            }
            label24.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn25.BackColor = Color.LightPink;
            btn32.BackColor = Color.LightPink;
            file.WriteLine("1,2");
            file.WriteLine("2,2");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][2] + board[2][2];
                    break;

                case '-':
                    btn_result = diff(board[1][2], board[2][2]);
                    break;
                case '*':
                    btn_result = board[1][2] * board[2][2];
                    break;
            }
            label25.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn33.BackColor = Color.LightGreen;
            btn40.BackColor = Color.LightGreen;
            file.WriteLine("2,3");
            file.WriteLine("3,3");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[2][3] + board[3][3];
                    break;

                case '-':
                    btn_result = diff(board[2][3], board[3][3]);
                    break;
                case '*':
                    btn_result = board[2][3] * board[3][3];
                    break;
            }
            label33.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn23.BackColor = Color.LightCoral;
            btn30.BackColor = Color.LightCoral;
            file.WriteLine("1,0");
            file.WriteLine("2,0");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][0] + board[2][0];
                    break;

                case '-':
                    btn_result = diff(board[1][0], board[2][0]);
                    break;
                case '*':
                    btn_result = board[1][0] * board[2][0];
                    break;
            }
            label23.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn16.BackColor = Color.LightCyan;
            btn17.BackColor = Color.LightCyan;
            file.WriteLine("0,0");
            file.WriteLine("0,1");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][0] + board[0][1];
                    break;

                case '-':
                    btn_result = diff(board[0][0], board[0][1]);
                    break;
                case '*':
                    btn_result = board[0][0] * board[0][1];
                    break;
            }
            label16.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn18.BackColor = Color.LightGoldenrodYellow;
            btn19.BackColor = Color.LightGoldenrodYellow;
            btn26.BackColor = Color.LightGoldenrodYellow;
            file.WriteLine("0,2");
            file.WriteLine("0,3");
            file.WriteLine("1,3");
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][2] + board[0][3] + board[1][3];
                    break;

                case '-':
                    btn_result = diff(board[0][2] , board[0][3] , board[1][3]);
                    break;
                case '*':
                    btn_result = board[0][2] * board[0][3] * board[1][3];
                    break;
            }
            label18.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn37.BackColor = Color.Magenta;
            btn38.BackColor = Color.Magenta;
            btn39.BackColor = Color.Magenta;
            file.WriteLine("3,0");
            file.WriteLine("3,1");
            file.WriteLine("3,2");
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[3][0] + board[3][1] + board[3][2];
                    break;

                case '-':
                    btn_result = diff(board[3][0] , board[3][1] , board[3][2]);
                    break;
                case '*':
                    btn_result = board[3][0] * board[3][1] * board[3][2];
                    break;
            }
            label37.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            file.Close();
            label16.Visible = true;
            label18.Visible = true;
            label23.Visible = true;
            label24.Visible = true;
            label25.Visible = true;
            label37.Visible = true;
            label33.Visible = true;

        }

        void Third_Senario_4()
        {
            /* Write in File */
            String path = "in.txt";
            StreamWriter file = new StreamWriter(path);
            if (comboBox2.Text == "backtracking algorithm")
            {
                file.WriteLine("a1");
            }
            else if (comboBox2.Text == "forward checking algorithm")
            {
                file.WriteLine("a2");
            }
            else if (comboBox2.Text == "arc consistency algorithm")
            {
                file.WriteLine("a3");
            }
            file.WriteLine("4");

            btn24.BackColor = Color.LightGoldenrodYellow;
            btn31.BackColor = Color.LightGoldenrodYellow;
            file.WriteLine("1,1");
            file.WriteLine("2,1");
            label24.Text = "*" + "12";
            file.WriteLine("12");
            file.WriteLine("*");

            btn16.BackColor = Color.LightGreen;
            btn17.BackColor = Color.LightGreen;
            file.WriteLine("0,0");
            file.WriteLine("0,1");
            label16.Text = "/" + "2";
            file.WriteLine("2");
            file.WriteLine("/");

            btn23.BackColor = Color.LightCyan;
            btn30.BackColor = Color.LightCyan;
            file.WriteLine("1,0");
            file.WriteLine("2,0");
            label23.Text = "/" + "2";
            file.WriteLine("2");
            file.WriteLine("/");

            btn32.BackColor = Color.LightCoral;
            btn39.BackColor = Color.LightCoral;
            file.WriteLine("2,2");
            file.WriteLine("3,2");
            label32.Text = "/" + "2";
            file.WriteLine("2");
            file.WriteLine("/");

            btn18.BackColor = Color.LightPink;
            btn19.BackColor = Color.LightPink;
            file.WriteLine("0,2");
            file.WriteLine("0,3");
            label18.Text = "-" + "2";
            file.WriteLine("2");
            file.WriteLine("-");

            btn25.BackColor = Color.LightSkyBlue;
            btn26.BackColor = Color.LightSkyBlue;
            file.WriteLine("1,2");
            file.WriteLine("1,3");
            label25.Text = "-" + "3";
            file.WriteLine("3");
            file.WriteLine("-");

            btn37.BackColor = Color.LightBlue;
            btn38.BackColor = Color.LightBlue;
            file.WriteLine("3,0");
            file.WriteLine("3,1");
            label37.Text = "-" + "2";
            file.WriteLine("2");
            file.WriteLine("-");

            btn33.BackColor = Color.LemonChiffon;
            btn40.BackColor = Color.LemonChiffon;
            file.WriteLine("2,3");
            file.WriteLine("3,3");
            label33.Text = "+" + "5";
            file.WriteLine("5");
            file.WriteLine("+");

            file.Close();
            label16.Visible = true;
            label18.Visible = true;
            label23.Visible = true;
            label24.Visible = true;
            label25.Visible = true;
            label37.Visible = true;
            label33.Visible = true;
            label32.Visible = true;
        }





        void First_Senario_5()
        {
            /* Write in File */
            String path = "in.txt";
            StreamWriter file = new StreamWriter(path);
            if (comboBox2.Text == "backtracking algorithm")
            {
                file.WriteLine("a1");
            }
            else if (comboBox2.Text == "forward checking algorithm")
            {
                file.WriteLine("a2");
            }
            else if (comboBox2.Text == "arc consistency algorithm")
            {
                file.WriteLine("a3");
            }
            file.WriteLine("5");


            btn17.BackColor = Color.MediumPurple;
            file.WriteLine("1,1");
            label17.Text = board[1][1].ToString();
            file.WriteLine(board[1][1].ToString());
            file.WriteLine("#");

            btn24.BackColor = Color.MediumVioletRed;
            file.WriteLine("2,1");
            label24.Text = board[2][1].ToString();
            file.WriteLine(board[2][1].ToString());
            file.WriteLine("#");


            btn9.BackColor = Color.LightCoral;
            btn10.BackColor = Color.LightCoral;
            btn11.BackColor = Color.LightCoral;
            file.WriteLine("0,0");
            file.WriteLine("0,1");
            file.WriteLine("0,2");
            
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][0] + board[0][1] + board[0][2];
                    break;

                case '-':
                    //btn_result = diff(board[0][0], board[1][0]);
                    break;
                case '*':
                    btn_result = board[0][0] * board[0][1] * board[0][2];
                    break;
            }
            label9.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn16.BackColor = Color.LightGreen;
            btn23.BackColor = Color.LightGreen;
            file.WriteLine("1,0");
            file.WriteLine("2,0");

            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][0] + board[2][0];
                    break;

                case '-':
                    btn_result = diff(board[1][0], board[2][0]);
                    break;
                case '*':
                    btn_result = board[1][0] * board[2][0];
                    break;
            }
            label16.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn18.BackColor = Color.LightPink;
            btn25.BackColor = Color.LightPink;
            btn32.BackColor = Color.LightPink;
            file.WriteLine("1,2");
            file.WriteLine("2,2");
            file.WriteLine("3,2");

            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][2] + board[2][2] + board[3][2];
                    break;

                case '-':
                    //btn_result = diff(board[0][0], board[1][0]);
                    break;
                case '*':
                    btn_result = board[1][2] * board[2][2] * board[3][2];
                    break;
            }
            label18.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn30.BackColor = Color.LightSalmon;
            btn31.BackColor = Color.LightSalmon;
            btn37.BackColor = Color.LightSalmon;
            btn38.BackColor = Color.LightSalmon;
            file.WriteLine("3,0");
            file.WriteLine("3,1");
            file.WriteLine("4,0");
            file.WriteLine("4,1");

            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[3][0] + board[3][1] + board[4][0] + board[4][1];
                    break;

                case '-':
                    // btn_result = diff(board[0][0], board[1][0]);
                    break;
                case '*':
                    btn_result = board[3][0] * board[3][1] * board[4][0] * board[4][1];
                    break;
            }
            label30.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn33.BackColor = Color.LightSkyBlue;
            btn39.BackColor = Color.LightSkyBlue;
            btn40.BackColor = Color.LightSkyBlue;
            file.WriteLine("3,3");
            file.WriteLine("4,3");
            file.WriteLine("4,2");
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[3][3] + board[4][3] + board[4][2];
                    break;

                case '-':
                    //btn_result = diff(board[0][0], board[1][0]);
                    break;
                case '*':
                    btn_result = board[3][3] * board[4][3] * board[4][2];
                    break;
            }
            label33.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn12.BackColor = Color.LavenderBlush;
            btn19.BackColor = Color.LavenderBlush;
            file.WriteLine("0,3");
            file.WriteLine("1,3");

            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][3] + board[1][3];
                    break;

                case '-':
                    btn_result = diff(board[0][3], board[1][3]);
                    break;
                case '*':
                    btn_result = board[0][3] * board[1][3];
                    break;
            }
            label12.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn13.BackColor = Color.LightCyan;
            btn20.BackColor = Color.LightCyan;
            file.WriteLine("0,4");
            file.WriteLine("1,4");

            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][4] + board[1][4];
                    break;

                case '-':
                    btn_result = diff(board[0][4], board[1][4]);
                    break;
                case '*':
                    btn_result = board[0][4] * board[1][4];
                    break;
            }
            label13.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn26.BackColor = Color.Magenta;
            btn27.BackColor = Color.Magenta;
            file.WriteLine("2,3");
            file.WriteLine("2,4");

            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[2][3] + board[2][4];
                    break;

                case '-':
                    btn_result = diff(board[2][3], board[2][4]);
                    break;
                case '*':
                    btn_result = board[2][3] * board[2][4];
                    break;
            }
            label26.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn34.BackColor = Color.Gold;
            btn41.BackColor = Color.Gold;
            file.WriteLine("3,4");
            file.WriteLine("4,4");

            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[3][4] + board[4][4];
                    break;

                case '-':
                    btn_result = diff(board[3][4], board[4][4]);
                    break;
                case '*':
                    btn_result = board[3][4] * board[4][4];
                    break;
            }
            label34.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            file.Close();

            label17.Visible = true;
            label24.Visible = true;
            label9.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label16.Visible = true;
            label18.Visible = true;
            label26.Visible = true;
            label30.Visible = true;
            label33.Visible = true;
            label34.Visible = true;
        }

        void Second_Senario_5()
        {
            /* Write in File */
            String path = "in.txt";
            StreamWriter file = new StreamWriter(path);
            if (comboBox2.Text == "backtracking algorithm")
            {
                file.WriteLine("a1");
            }
            else if (comboBox2.Text == "forward checking algorithm")
            {
                file.WriteLine("a2");
            }
            else if (comboBox2.Text == "arc consistency algorithm")
            {
                file.WriteLine("a3");
            }
            file.WriteLine("5");


            btn17.BackColor = Color.MediumPurple;
            file.WriteLine("1,1");
            label17.Text = board[1][1].ToString();
            file.WriteLine(board[1][1].ToString());
            file.WriteLine("#");

            btn26.BackColor = Color.Orange;
            file.WriteLine("2,3");
            label26.Text = board[2][3].ToString();
            file.WriteLine(board[2][3].ToString());
            file.WriteLine("#");

            btn41.BackColor = Color.Ivory;
            file.WriteLine("4,4");
            label41.Text = board[4][4].ToString();
            file.WriteLine(board[4][4].ToString());
            file.WriteLine("#");

            btn16.BackColor = Color.LightCoral;
            btn23.BackColor = Color.LightCoral;
            file.WriteLine("1,0");
            file.WriteLine("2,0");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][0] + board[2][0];
                    break;

                case '-':
                    btn_result = diff(board[1][0], board[2][0]);
                    break;
                case '*':
                    btn_result = board[1][0] * board[2][0];
                    break;
            }
            label16.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn30.BackColor = Color.LightBlue;
            btn37.BackColor = Color.LightBlue;
            file.WriteLine("3,0");
            file.WriteLine("4,0");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[3][0] + board[4][0];
                    break;

                case '-':
                    btn_result = diff(board[3][0], board[4][0]);
                    break;
                case '*':
                    btn_result = board[3][0] * board[4][0];
                    break;
            }
            label30.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn31.BackColor = Color.LightPink;
            btn38.BackColor = Color.LightPink;
            file.WriteLine("3,1");
            file.WriteLine("4,1");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[3][1] + board[4][1];
                    break;

                case '-':
                    btn_result = diff(board[3][1], board[4][1]);
                    break;
                case '*':
                    btn_result = board[3][1] * board[4][1];
                    break;
            }
            label31.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn9.BackColor = Color.LemonChiffon;
            btn10.BackColor = Color.LemonChiffon;
            file.WriteLine("0,0");
            file.WriteLine("0,1");

            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][0] + board[0][1];
                    break;

                case '-':
                    btn_result = diff(board[0][0], board[0][1]);
                    break;
                case '*':
                    btn_result = board[0][0] * board[0][1];
                    break;
            }
            label9.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn24.BackColor = Color.LightSkyBlue;
            btn25.BackColor = Color.LightSkyBlue;
            file.WriteLine("2,1");
            file.WriteLine("2,2");

            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[2][1] + board[2][2];
                    break;

                case '-':
                    btn_result = diff(board[2][1], board[2][2]);
                    break;
                case '*':
                    btn_result = board[2][1] * board[2][2];
                    break;
            }
            label24.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn27.BackColor = Color.Gold;
            btn34.BackColor = Color.Gold;
            file.WriteLine("2,4");
            file.WriteLine("3,4");

            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[2][4] + board[3][4];
                    break;

                case '-':
                    btn_result = diff(board[2][4], board[3][4]);
                    break;
                case '*':
                    btn_result = board[2][4] * board[3][4];
                    break;
            }
            label27.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn11.BackColor = Color.SandyBrown;
            btn18.BackColor = Color.SandyBrown;
            file.WriteLine("0,2");
            file.WriteLine("1,2");

            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][2] + board[1][2];
                    break;

                case '-':
                    btn_result = diff(board[0][2], board[1][2]);
                    break;
                case '*':
                    btn_result = board[0][2] * board[1][2];
                    break;
            }
            label11.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn12.BackColor = Color.MediumAquamarine;
            btn13.BackColor = Color.MediumAquamarine;
            btn19.BackColor = Color.MediumAquamarine;
            btn20.BackColor = Color.MediumAquamarine;
            file.WriteLine("0,3");
            file.WriteLine("0,4");
            file.WriteLine("1,3");
            file.WriteLine("1,4");
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][3] + board[0][4] + board[1][3] + board[1][4];
                    break;

                case '-':
                    //btn_result = diff(board[1][0], board[2][0]);
                    break;
                case '*':
                    btn_result = board[0][3] * board[0][4] * board[1][3] * board[1][4];
                    break;
            }
            label12.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn32.BackColor = Color.LightCyan;
            btn33.BackColor = Color.LightCyan;
            btn39.BackColor = Color.LightCyan;
            btn40.BackColor = Color.LightCyan;
            file.WriteLine("3,2");
            file.WriteLine("3,3");
            file.WriteLine("4,2");
            file.WriteLine("4,3");
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[3][2] + board[3][3] + board[4][2] + board[4][3];
                    break;

                case '-':
                    //btn_result = diff(board[1][0], board[2][0]);
                    break;
                case '*':
                    btn_result = board[3][2] * board[3][3] * board[4][2] * board[4][3];
                    break;
            }
            label32.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            file.Close();

            label9.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label24.Visible = true;
            label26.Visible = true;
            label27.Visible = true;
            label30.Visible = true;
            label31.Visible = true;
            label32.Visible = true;
            label41.Visible = true;
        }

        void Third_Senario_5()
        {
            /* Write in File */
            String path = "in.txt";
            StreamWriter file = new StreamWriter(path);
            if (comboBox2.Text == "backtracking algorithm")
            {
                file.WriteLine("a1");
            }
            else if (comboBox2.Text == "forward checking algorithm")
            {
                file.WriteLine("a2");
            }
            else if (comboBox2.Text == "arc consistency algorithm")
            {
                file.WriteLine("a3");
            }
            file.WriteLine("5");


            btn19.BackColor = Color.MediumTurquoise;
            file.WriteLine("1,3");
            label19.Text = board[1][3].ToString();
            file.WriteLine(board[1][3].ToString());
            file.WriteLine("#");

            btn30.BackColor = Color.MediumPurple;
            file.WriteLine("3,0");
            label30.Text = board[3][0].ToString();
            file.WriteLine(board[3][0].ToString());
            file.WriteLine("#");

            btn9.BackColor = Color.LightGreen;
            btn10.BackColor = Color.LightGreen;
            file.WriteLine("0,0");
            file.WriteLine("0,1");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][0] + board[0][1];
                    break;

                case '-':
                    btn_result = diff(board[0][0], board[0][1]);
                    break;
                case '*':
                    btn_result = board[0][0] * board[0][1];
                    break;
            }
            label9.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn13.BackColor = Color.LightCoral;
            btn20.BackColor = Color.LightCoral;
            file.WriteLine("0,4");
            file.WriteLine("1,4");

            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][4] + board[1][4];
                    break;

                case '-':
                    btn_result = diff(board[0][4], board[1][4]);
                    break;
                case '*':
                    btn_result = board[0][4] * board[1][4];
                    break;
            }
            label13.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn16.BackColor = Color.LightBlue;
            btn23.BackColor = Color.LightBlue;
            file.WriteLine("1,0");
            file.WriteLine("2,0");

            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][0] + board[2][0];
                    break;

                case '-':
                    btn_result = diff(board[1][0], board[2][0]);
                    break;
                case '*':
                    btn_result = board[1][0] * board[2][0];
                    break;
            }
            label16.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn11.BackColor = Color.LemonChiffon;
            btn12.BackColor = Color.LemonChiffon;
            file.WriteLine("0,2");
            file.WriteLine("0,3");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][2] + board[0][3];
                    break;

                case '-':
                    btn_result = diff(board[0][2] , board[0][3]);
                    break;
                case '*':
                    btn_result = board[0][2] * board[0][3];
                    break;
            }
            label11.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn17.BackColor = Color.LightPink;
            btn18.BackColor = Color.LightPink;
            file.WriteLine("1,1");
            file.WriteLine("1,2");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][1] + board[1][2];
                    break;

                case '-':
                    btn_result = diff(board[1][1], board[1][2]);
                    break;
                case '*':
                    btn_result = board[1][1] * board[1][2];
                    break;
            }
            label17.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn24.BackColor = Color.LightSkyBlue;
            btn31.BackColor = Color.LightSkyBlue;
            file.WriteLine("2,1");
            file.WriteLine("3,1");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[2][1] + board[3][1];
                    break;

                case '-':
                    btn_result = diff(board[2][1], board[3][1]);
                    break;
                case '*':
                    btn_result = board[2][1] * board[3][1];
                    break;
            }
            label24.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn25.BackColor = Color.LightYellow;
            btn32.BackColor = Color.LightYellow;
            file.WriteLine("2,2");
            file.WriteLine("3,2");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[2][2] + board[3][2];
                    break;

                case '-':
                    btn_result = diff(board[2][2], board[3][2]);
                    break;
                case '*':
                    btn_result = board[2][2] * board[3][2];
                    break;
            }
            label25.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn26.BackColor = Color.Gold;
            btn33.BackColor = Color.Gold;
            file.WriteLine("2,3");
            file.WriteLine("3,3");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[2][3] + board[3][3];
                    break;

                case '-':
                    btn_result = diff(board[2][3], board[3][3]);
                    break;
                case '*':
                    btn_result = board[2][3] * board[3][3];
                    break;
            }
            label26.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn37.BackColor = Color.LightCoral;
            btn38.BackColor = Color.LightCoral;
            file.WriteLine("4,0");
            file.WriteLine("4,1");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[4][0] + board[4][1];
                    break;

                case '-':
                    btn_result = diff(board[4][0], board[4][1]);
                    break;
                case '*':
                    btn_result = board[4][0] * board[4][1];
                    break;
            }
            label37.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn39.BackColor = Color.Orange;
            btn40.BackColor = Color.Orange;
            file.WriteLine("4,2");
            file.WriteLine("4,3");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[4][2] + board[4][3];
                    break;

                case '-':
                    btn_result = diff(board[4][2], board[4][3]);
                    break;
                case '*':
                    btn_result = board[4][2] * board[4][3];
                    break;
            }
            label39.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn27.BackColor = Color.LavenderBlush;
            btn34.BackColor = Color.LavenderBlush;
            btn41.BackColor = Color.LavenderBlush;
            file.WriteLine("2,4");
            file.WriteLine("3,4");
            file.WriteLine("4,4");
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[2][4] + board[3][4] + board[4][4];
                    break;

                case '-':
                   // btn_result = diff(board[0][2], board[0][3]);
                    break;
                case '*':
                    btn_result = board[2][4] * board[3][4] * board[4][4];
                    break;
            }
            label27.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            file.Close();

            label9.Visible = true;
            label11.Visible = true;
            label13.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label19.Visible = true;
            label24.Visible = true;
            label25.Visible = true;
            label26.Visible = true;
            label27.Visible = true;
            label30.Visible = true;
            label37.Visible = true;
            label39.Visible = true;
        }

        void Fourth_Senario_5()
        {
            
        }     // Not done yet






        void First_Senario_6()
        {
            /* Write in File */
            String path = "in.txt";
            StreamWriter file = new StreamWriter(path);
            if (comboBox2.Text == "backtracking algorithm")
            {
                file.WriteLine("a1");
            }
            else if (comboBox2.Text == "forward checking algorithm")
            {
                file.WriteLine("a2");
            }
            else if (comboBox2.Text == "arc consistency algorithm")
            {
                file.WriteLine("a3");
            }
            file.WriteLine("6");

            btn9.BackColor = Color.MediumPurple;
            file.WriteLine("0,0");
            label9.Text = "1";
            file.WriteLine("1");
            file.WriteLine("#");

            btn38.BackColor = Color.Maroon;
            file.WriteLine("4,1");
            label38.Text = "3";
            file.WriteLine("3");
            file.WriteLine("#");

            btn20.BackColor = Color.MediumOrchid;
            file.WriteLine("1,4");
            label20.Text = "5";
            file.WriteLine("5");
            file.WriteLine("#");

            btn10.BackColor = Color.LightBlue;
            btn11.BackColor = Color.LightBlue;
            file.WriteLine("0,1");
            file.WriteLine("0,2");
            label10.Text = "*" + "15";
            file.WriteLine("15");
            file.WriteLine("*");

            btn16.BackColor = Color.LightCoral;
            btn23.BackColor = Color.LightCoral;
            file.WriteLine("1,0");
            file.WriteLine("2,0");
            label16.Text = "-" + "1";
            file.WriteLine("1");
            file.WriteLine("-");

            btn18.BackColor = Color.LightPink;
            btn25.BackColor = Color.LightPink;
            file.WriteLine("1,2");
            file.WriteLine("2,2");
            label18.Text = "+" + "3";
            file.WriteLine("3");
            file.WriteLine("+");

            btn17.BackColor = Color.LightSalmon;
            btn24.BackColor = Color.LightSalmon;
            file.WriteLine("1,1");
            file.WriteLine("2,1");
            label17.Text = "-" + "2";
            file.WriteLine("2");
            file.WriteLine("-");

            btn30.BackColor = Color.LightGreen;
            btn31.BackColor = Color.LightGreen;
            btn37.BackColor = Color.LightGreen;
            file.WriteLine("3,0");
            file.WriteLine("3,1");
            file.WriteLine("4,0");
            label30.Text = "*" + "10";
            file.WriteLine("10");
            file.WriteLine("*");

            btn44.BackColor = Color.LightYellow;
            btn45.BackColor = Color.LightYellow;
            file.WriteLine("5,0");
            file.WriteLine("5,1");
            label44.Text = "-" + "4";
            file.WriteLine("4");
            file.WriteLine("-");

            btn12.BackColor = Color.LightGoldenrodYellow;
            btn13.BackColor = Color.LightGoldenrodYellow;
            btn19.BackColor = Color.LightGoldenrodYellow;
            file.WriteLine("0,3");
            file.WriteLine("0,4");
            file.WriteLine("1,3");
            label12.Text = "*" + "24";
            file.WriteLine("24");
            file.WriteLine("*");

            btn26.BackColor = Color.LightCyan;
            btn27.BackColor = Color.LightCyan;
            btn28.BackColor = Color.LightCyan;
            file.WriteLine("2,3");
            file.WriteLine("2,4");
            file.WriteLine("2,5");
            label26.Text = "+" + "10";
            file.WriteLine("10");
            file.WriteLine("+");

            btn34.BackColor = Color.LightCoral;
            btn40.BackColor = Color.LightCoral;
            btn41.BackColor = Color.LightCoral;
            file.WriteLine("3,4");
            file.WriteLine("4,3");
            file.WriteLine("4,4");
            label34.Text = "+" + "10";
            file.WriteLine("10");
            file.WriteLine("+");

            btn47.BackColor = Color.Gold;
            btn48.BackColor = Color.Gold;
            btn49.BackColor = Color.Gold;
            file.WriteLine("5,3");
            file.WriteLine("5,4");
            file.WriteLine("5,5");
            label47.Text = "+" + "8";
            file.WriteLine("8");
            file.WriteLine("+");

            btn14.BackColor = Color.Orange;
            btn21.BackColor = Color.Orange;
            file.WriteLine("0,5");
            file.WriteLine("1,5");
            label14.Text = "/" + "3";
            file.WriteLine("3");
            file.WriteLine("/");

            btn35.BackColor = Color.Lavender;
            btn42.BackColor = Color.Lavender;
            file.WriteLine("3,5");
            file.WriteLine("4,5");
            label35.Text = "+" + "9";
            file.WriteLine("9");
            file.WriteLine("+");

            btn32.BackColor = Color.Indigo;
            btn33.BackColor = Color.Indigo;
            file.WriteLine("3,2");
            file.WriteLine("3,3");
            label32.Text = "/" + "3";
            file.WriteLine("3");
            file.WriteLine("/");

            btn39.BackColor = Color.HotPink;
            btn46.BackColor = Color.HotPink;
            file.WriteLine("4,2");
            file.WriteLine("5,2");
            label39.Text = "-" + "1";
            file.WriteLine("1");
            file.WriteLine("-");

            file.Close();

            label9.Visible = true;
            label10.Visible = true;
            label12.Visible = true;
            label14.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label20.Visible = true;
            label26.Visible = true;
            label30.Visible = true;
            label32.Visible = true;
            label34.Visible = true;
            label35.Visible = true;
            label38.Visible = true;
            label39.Visible = true;
            label44.Visible = true;
            label47.Visible = true;
        }

        void Second_Senario_6()
        {
            /* Write in File */
            String path = "in.txt";
            StreamWriter file = new StreamWriter(path);
            if (comboBox2.Text == "backtracking algorithm")
            {
                file.WriteLine("a1");
            }
            else if (comboBox2.Text == "forward checking algorithm")
            {
                file.WriteLine("a2");
            }
            else if (comboBox2.Text == "arc consistency algorithm")
            {
                file.WriteLine("a3");
            }
            file.WriteLine("6");

            btn14.BackColor = Color.MediumPurple;
            file.WriteLine("0,5");
            label14.Text = board[0][5].ToString();
            file.WriteLine(board[0][5].ToString());
            file.WriteLine("#");

            btn35.BackColor = Color.MediumOrchid;
            file.WriteLine("3,5");
            label35.Text = board[3][5].ToString();
            file.WriteLine(board[3][5].ToString());
            file.WriteLine("#");

            btn48.BackColor = Color.MediumSpringGreen;
            file.WriteLine("5,4");
            label48.Text = board[5][4].ToString();
            file.WriteLine(board[5][4].ToString());
            file.WriteLine("#");

            btn49.BackColor = Color.MediumAquamarine;
            file.WriteLine("5,5");
            label49.Text = board[5][5].ToString();
            file.WriteLine(board[5][5].ToString());
            file.WriteLine("#");

            btn23.BackColor = Color.MediumVioletRed;
            file.WriteLine("2,0");
            label23.Text = board[2][0].ToString();
            file.WriteLine(board[2][0].ToString());
            file.WriteLine("#");

            btn12.BackColor = Color.LightCyan;
            btn13.BackColor = Color.LightCyan;
            file.WriteLine("0,3");
            file.WriteLine("0,4");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][3] + board[0][4];
                    break;

                case '-':
                    btn_result = diff(board[0][3], board[0][4]);
                    break;
                case '*':
                    btn_result = board[0][3] * board[0][4];
                    break;
            }
            label12.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn18.BackColor = Color.LightGoldenrodYellow;
            btn25.BackColor = Color.LightGoldenrodYellow;
            file.WriteLine("1,2");
            file.WriteLine("2,2");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][2] + board[2][2];
                    break;

                case '-':
                    btn_result = diff(board[1][2], board[2][2]);
                    break;
                case '*':
                    btn_result = board[1][2] * board[2][2];
                    break;
            }
            label18.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn19.BackColor = Color.LightGreen;
            btn26.BackColor = Color.LightGreen;
            file.WriteLine("1,3");
            file.WriteLine("2,3");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][3] + board[2][3];
                    break;

                case '-':
                    btn_result = diff(board[1][3], board[2][3]);
                    break;
                case '*':
                    btn_result = board[1][3] * board[2][3];
                    break;
            }
            label19.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn20.BackColor = Color.LightSalmon;
            btn27.BackColor = Color.LightSalmon;
            file.WriteLine("1,4");
            file.WriteLine("2,4");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][4] + board[2][4];
                    break;

                case '-':
                    btn_result = diff(board[1][4], board[2][4]);
                    break;
                case '*':
                    btn_result = board[1][4] * board[2][4];
                    break;
            }
            label20.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn21.BackColor = Color.LightSkyBlue;
            btn28.BackColor = Color.LightSkyBlue;
            file.WriteLine("1,5");
            file.WriteLine("2,5");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][5] + board[2][5];
                    break;

                case '-':
                    btn_result = diff(board[1][5], board[2][5]);
                    break;
                case '*':
                    btn_result = board[1][5] * board[2][5];
                    break;
            }
            label21.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn33.BackColor = Color.LightYellow;
            btn34.BackColor = Color.LightYellow;
            file.WriteLine("3,3");
            file.WriteLine("3,4");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[3][3] + board[3][4];
                    break;

                case '-':
                    btn_result = diff(board[3][3], board[3][4]);
                    break;
                case '*':
                    btn_result = board[3][3] * board[3][4];
                    break;
            }
            label33.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn30.BackColor = Color.Ivory;
            btn37.BackColor = Color.Ivory;
            file.WriteLine("3,0");
            file.WriteLine("4,0");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[3][0] + board[4][0];
                    break;

                case '-':
                    btn_result = diff(board[3][0], board[4][0]);
                    break;
                case '*':
                    btn_result = board[3][0] * board[4][0];
                    break;
            }
            label30.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn44.BackColor = Color.Lavender;
            btn45.BackColor = Color.Lavender;
            file.WriteLine("5,0");
            file.WriteLine("5,1");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[5][0] + board[5][1];
                    break;

                case '-':
                    btn_result = diff(board[5][0], board[5][1]);
                    break;
                case '*':
                    btn_result = board[5][0] * board[5][1];
                    break;
            }
            label44.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn39.BackColor = Color.Gold;
            btn46.BackColor = Color.Gold;
            file.WriteLine("4,2");
            file.WriteLine("5,2");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[4][2] + board[5][2];
                    break;

                case '-':
                    btn_result = diff(board[4][2], board[5][2]);
                    break;
                case '*':
                    btn_result = board[4][2] * board[5][2];
                    break;
            }
            label39.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn40.BackColor = Color.LightPink;
            btn47.BackColor = Color.LightPink;
            file.WriteLine("4,3");
            file.WriteLine("5,3");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[4][3] + board[5][3];
                    break;

                case '-':
                    btn_result = diff(board[4][3], board[5][3]);
                    break;
                case '*':
                    btn_result = board[4][3] * board[5][3];
                    break;
            }
            label40.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn41.BackColor = Color.LightBlue;
            btn42.BackColor = Color.LightBlue;
            file.WriteLine("4,4");
            file.WriteLine("5,4");
            chosenop = op[rand.Next(0, 3)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[4][4] + board[5][4];
                    break;

                case '-':
                    btn_result = diff(board[4][4], board[5][4]);
                    break;
                case '*':
                    btn_result = board[4][4] * board[5][4];
                    break;
            }
            label41.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn9.BackColor = Color.LightPink;
            btn10.BackColor = Color.LightPink;
            btn11.BackColor = Color.LightPink;
            file.WriteLine("0,0");
            file.WriteLine("0,1");
            file.WriteLine("0,2");
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[0][0] + board[0][1] + board[0][2];
                    break;

                case '-':
                    //btn_result = diff(board[0][0], board[1][0]);
                    break;
                case '*':
                    btn_result = board[0][0] * board[0][1] * board[0][2];
                    break;
            }
            label9.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn16.BackColor = Color.LightBlue;
            btn17.BackColor = Color.LightBlue;
            btn24.BackColor = Color.LightBlue;
            file.WriteLine("1,0");
            file.WriteLine("1,1");
            file.WriteLine("2,1");
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[1][0] + board[1][1] + board[2][1];
                    break;

                case '-':
                    //btn_result = diff(board[0][0], board[1][0]);
                    break;
                case '*':
                    btn_result = board[1][0] * board[1][1] * board[2][1];
                    break;
            }
            label16.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());

            btn31.BackColor = Color.LightCoral;
            btn32.BackColor = Color.LightCoral;
            btn38.BackColor = Color.LightCoral;
            file.WriteLine("3,1");
            file.WriteLine("3,2");
            file.WriteLine("4,1");
            chosenop = op[rand.Next(0, 2)];
            switch (chosenop)
            {

                case '+':
                    btn_result = board[3][1] + board[3][2] + board[4][1];
                    break;

                case '-':
                    //btn_result = diff(board[0][0], board[1][0]);
                    break;
                case '*':
                    btn_result = board[3][1] * board[3][2] * board[4][1];
                    break;
            }
            label31.Text = chosenop.ToString() + btn_result.ToString();
            file.WriteLine(btn_result.ToString());
            file.WriteLine(chosenop.ToString());


            file.Close();

            label9.Visible = true;
            label12.Visible = true;
            label14.Visible = true;
            label16.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            label23.Visible = true;
            label30.Visible = true;
            label31.Visible = true;
            label33.Visible = true;
            label35.Visible = true;
            label39.Visible = true;
            label40.Visible = true;
            label41.Visible = true;
            label44.Visible = true;
            label48.Visible = true;
            label49.Visible = true;

        }

        void Third_Senario_6()
        {





















        }

       


        void First_Senario_7()
        {
            /* Write in File */
            String path = "in.txt";
            StreamWriter file = new StreamWriter(path);
            if (comboBox2.Text == "backtracking algorithm")
            {
                file.WriteLine("a1");
            }
            else if (comboBox2.Text == "forward checking algorithm")
            {
                file.WriteLine("a2");
            }
            else if (comboBox2.Text == "arc consistency algorithm")
            {
                file.WriteLine("a3");
            }
            file.WriteLine("7");

            btn23.BackColor = Color.MediumOrchid;
            file.WriteLine("3,1");
            label23.Text = "4";
            file.WriteLine("4");
            file.WriteLine("#");

            btn31.BackColor = Color.MediumBlue;
            file.WriteLine("4,2");
            label31.Text = "4";
            file.WriteLine("4");
            file.WriteLine("#");

            btn15.BackColor = Color.MediumOrchid;
            file.WriteLine("2,0");
            label15.Text = "5";
            file.WriteLine("5");
            file.WriteLine("#");

            btn1.BackColor = Color.LightBlue;
            btn8.BackColor = Color.LightBlue;
            file.WriteLine("0,0");
            file.WriteLine("1,0");
            label1.Text = "/" + "2";
            file.WriteLine("2");
            file.WriteLine("/");

            btn2.BackColor = Color.LightPink;
            btn3.BackColor = Color.LightPink;
            file.WriteLine("0,1");
            file.WriteLine("0,2");
            label2.Text = "-" + "4";
            file.WriteLine("4");
            file.WriteLine("-");

            btn4.BackColor = Color.DodgerBlue;
            btn5.BackColor = Color.DodgerBlue;
            file.WriteLine("0,3");
            file.WriteLine("0,4");
            label4.Text = "-" + "4";
            file.WriteLine("4");
            file.WriteLine("-");

            btn9.BackColor = Color.LightSalmon;
            btn16.BackColor = Color.LightSalmon;
            file.WriteLine("1,1");
            file.WriteLine("2,1");
            label9.Text = "-" + "6";
            file.WriteLine("6");
            file.WriteLine("-");

            btn10.BackColor = Color.LightSkyBlue;
            btn11.BackColor = Color.LightSkyBlue;
            file.WriteLine("1,2");
            file.WriteLine("1,3");
            label10.Text = "+" + "11";
            file.WriteLine("11");
            file.WriteLine("+");

            btn17.BackColor = Color.Lime;
            btn24.BackColor = Color.Lime;
            file.WriteLine("2,2");
            file.WriteLine("3,2");
            label17.Text = "/" + "2";
            file.WriteLine("2");
            file.WriteLine("/");

            btn19.BackColor = Color.LightYellow;
            btn20.BackColor = Color.LightYellow;
            file.WriteLine("2,4");
            file.WriteLine("2,5");
            label19.Text = "-" + "2";
            file.WriteLine("2");
            file.WriteLine("-");

            btn22.BackColor = Color.LightCoral;
            btn29.BackColor = Color.LightCoral;
            file.WriteLine("3,0");
            file.WriteLine("4,0");
            label22.Text = "-" + "6";
            file.WriteLine("6");
            file.WriteLine("-");

            btn36.BackColor = Color.LightCyan;
            btn43.BackColor = Color.LightCyan;
            file.WriteLine("5,0");
            file.WriteLine("6,0");
            label36.Text = "/" + "2";
            file.WriteLine("2");
            file.WriteLine("/");

            btn26.BackColor = Color.LightGreen;
            btn33.BackColor = Color.LightGreen;
            file.WriteLine("3,4");
            file.WriteLine("4,4");
            label26.Text = "+" + "12";
            file.WriteLine("12");
            file.WriteLine("+");

            btn41.BackColor = Color.LightPink;
            btn48.BackColor = Color.LightPink;
            file.WriteLine("5,5");
            file.WriteLine("6,5");
            label41.Text = "-" + "6";
            file.WriteLine("6");
            file.WriteLine("-");

            btn7.BackColor = Color.LightCoral;
            btn14.BackColor = Color.LightCoral;
            btn21.BackColor = Color.LightCoral;
            file.WriteLine("0,6");
            file.WriteLine("1,6");
            file.WriteLine("2,6");
            label7.Text = "*" + "21";
            file.WriteLine("21");
            file.WriteLine("*");

            btn6.BackColor = Color.Gold;
            btn12.BackColor = Color.Gold;
            btn13.BackColor = Color.Gold;
            file.WriteLine("0,5");
            file.WriteLine("1,4");
            file.WriteLine("1,5");
            label6.Text = "+" + "10";
            file.WriteLine("10");
            file.WriteLine("+");

            btn18.BackColor = Color.LightBlue;
            btn25.BackColor = Color.LightBlue;
            btn32.BackColor = Color.LightBlue;
            file.WriteLine("2,3");
            file.WriteLine("3,3");
            file.WriteLine("4,3");
            label18.Text = "*" + "6";
            file.WriteLine("6");
            file.WriteLine("*");

            btn27.BackColor = Color.Lavender;
            btn28.BackColor = Color.Lavender;
            btn34.BackColor = Color.Lavender;
            file.WriteLine("3,5");
            file.WriteLine("3,6");
            file.WriteLine("4,5");
            label27.Text = "+" + "7";
            file.WriteLine("7");
            file.WriteLine("+");

            btn30.BackColor = Color.Indigo;
            btn37.BackColor = Color.Indigo;
            btn38.BackColor = Color.Indigo;
            file.WriteLine("4,1");
            file.WriteLine("5,1");
            file.WriteLine("5,2");
            label30.Text = "*" + "10";
            file.WriteLine("10");
            file.WriteLine("*");

            btn39.BackColor = Color.HotPink;
            btn40.BackColor = Color.HotPink;
            btn47.BackColor = Color.HotPink;
            file.WriteLine("5,3");
            file.WriteLine("5,4");
            file.WriteLine("6,4");
            label39.Text = "+" + "12";
            file.WriteLine("12");
            file.WriteLine("+");

            btn35.BackColor = Color.MediumVioletRed;
            btn42.BackColor = Color.MediumVioletRed;
            btn49.BackColor = Color.MediumVioletRed;
            file.WriteLine("4,6");
            file.WriteLine("5,6");
            file.WriteLine("6,6");
            label35.Text = "*" + "120";
            file.WriteLine("120");
            file.WriteLine("*");

            btn44.BackColor = Color.DodgerBlue;
            btn45.BackColor = Color.DodgerBlue;
            btn46.BackColor = Color.DodgerBlue;
            file.WriteLine("6,1");
            file.WriteLine("6,2");
            file.WriteLine("6,3");
            label44.Text = "*" + "105";
            file.WriteLine("105");
            file.WriteLine("*");

            file.Close();

            label1.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label15.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label22.Visible = true;
            label23.Visible = true;
            label26.Visible = true;
            label27.Visible = true;
            label30.Visible = true;
            label31.Visible = true;
            label35.Visible = true;
            label36.Visible = true;
            label39.Visible = true;
            label41.Visible = true;
            label44.Visible = true;
            
        }

        void Second_Senario_7()
        {

        }

        void Third_Senario_7()
        {

        }



        public Form1()
        {
            InitializeComponent();
            map_index_btns.Add("0,0", btn1);
            map_index_btns.Add("0,1", btn2);
            map_index_btns.Add("0,2", btn3);
            map_index_btns.Add("0,3", btn4);
            map_index_btns.Add("0,4", btn5);
            map_index_btns.Add("0,5", btn6);
            map_index_btns.Add("0,6", btn7);
            map_index_btns.Add("1,0", btn8);
            map_index_btns.Add("1,1", btn9);
            map_index_btns.Add("1,2", btn10);
            map_index_btns.Add("1,3", btn11);
            map_index_btns.Add("1,4", btn12);
            map_index_btns.Add("1,5", btn13);
            map_index_btns.Add("1,6", btn14);
            map_index_btns.Add("2,0", btn15);
            map_index_btns.Add("2,1", btn16);
            map_index_btns.Add("2,2", btn17);
            map_index_btns.Add("2,3", btn18);
            map_index_btns.Add("2,4", btn19);
            map_index_btns.Add("2,5", btn20);
            map_index_btns.Add("2,6", btn21);
            map_index_btns.Add("3,0", btn22);
            map_index_btns.Add("3,1", btn23);
            map_index_btns.Add("3,2", btn24);
            map_index_btns.Add("3,3", btn25);
            map_index_btns.Add("3,4", btn26);
            map_index_btns.Add("3,5", btn27);
            map_index_btns.Add("3,6", btn28);
            map_index_btns.Add("4,0", btn29);
            map_index_btns.Add("4,1", btn30);
            map_index_btns.Add("4,2", btn31);
            map_index_btns.Add("4,3", btn32);
            map_index_btns.Add("4,4", btn33);
            map_index_btns.Add("4,5", btn34);
            map_index_btns.Add("4,6", btn35);
            map_index_btns.Add("5,0", btn36);
            map_index_btns.Add("5,1", btn37);
            map_index_btns.Add("5,2", btn38);
            map_index_btns.Add("5,3", btn39);
            map_index_btns.Add("5,4", btn40);
            map_index_btns.Add("5,5", btn41);
            map_index_btns.Add("5,6", btn42);
            map_index_btns.Add("6,0", btn43);
            map_index_btns.Add("6,1", btn44);
            map_index_btns.Add("6,2", btn45);
            map_index_btns.Add("6,3", btn46);
            map_index_btns.Add("6,4", btn47);
            map_index_btns.Add("6,5", btn48);
            map_index_btns.Add("6,6", btn49);


            functions_3 = new Action[5];
            functions_3[0] = First_Senario_3;
            functions_3[1] = Second_Senario_3;
            functions_3[2] = Third_Senario_3;
            functions_3[3] = Fourth_Senario_3;
            functions_3[4] = Fifth_Senario_3;

            functions_4 = new Action[5];
            functions_4[0] = First_Senario_4;
            functions_4[1] = Second_Senario_4;
            functions_4[2] = Third_Senario_4;

            functions_5 = new Action[4];
            functions_5[0] = First_Senario_5;
            functions_5[1] = Second_Senario_5;
            functions_5[2] = Third_Senario_5;
            functions_5[3] = Fourth_Senario_5;

            functions_6 = new Action[5];
            functions_6[0] = First_Senario_6;
            functions_6[1] = Second_Senario_6;
            functions_6[2] = Third_Senario_6;

            functions_7 = new Action[3];
            functions_7[0] = First_Senario_7;
            functions_7[1] = Second_Senario_7;
            functions_7[2] = Third_Senario_7;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            append_labels();
            append_buttons();
            op[0] = '+';
            op[1] = '*';
            op[2] = '-';
            textBox1.Text = "1";
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {

        }

        private void btn24_Click(object sender, EventArgs e)
        {

        }

        private void btn23_Click(object sender, EventArgs e)
        {

        }

        private void btn22_Click(object sender, EventArgs e)
        {

        }

        private void btn21_Click(object sender, EventArgs e)
        {

        }

        private void btn20_Click(object sender, EventArgs e)
        {

        }

        private void btn19_Click(object sender, EventArgs e)
        {

        }

        private void btn18_Click(object sender, EventArgs e)
        {

        }

        private void btn17_Click(object sender, EventArgs e)
        {

        }

        private void btn16_Click(object sender, EventArgs e)
        {

        }

        private void btn15_Click(object sender, EventArgs e)
        {

        }

        private void btn14_Click(object sender, EventArgs e)
        {

        }

        private void btn13_Click(object sender, EventArgs e)
        {

        }

        private void btn12_Click(object sender, EventArgs e)
        {

        }

        private void btn5_Click(object sender, EventArgs e)
        {

        }

        private void btn11_Click(object sender, EventArgs e)
        {

        }

        private void btn10_Click(object sender, EventArgs e)
        {

        }

        private void btn9_Click(object sender, EventArgs e)
        {

        }

        private void btn8_Click(object sender, EventArgs e)
        {

        }

        private void btn7_Click(object sender, EventArgs e)
        {

        }

        private void btn6_Click(object sender, EventArgs e)
        {

        }

        private void btn4_Click(object sender, EventArgs e)
        {

        }

        private void btn3_Click(object sender, EventArgs e)
        {

        }

        private void btn25_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process.Start("keke.exe");

            if (comboBox1.Text == "3x3")
            {
                    
                        StreamReader sr = new StreamReader("out_num.txt");
                        string data;
                        for (int i = 0; i < 9; i++)
                        {
                            data = sr.ReadLine();
                            buttons_3[i].Text = data;
                        }
                        sr.Close();
                    
            }
            else if (comboBox1.Text == "4x4")
            {
                    
                        StreamReader sr = new StreamReader("out_num.txt");
                        string data;
                        for (int i = 0; i < 16; i++)
                        {
                            data = sr.ReadLine();
                            buttons_4[i].Text = data;
                        }
                        sr.Close();
                   
            }
            else if (comboBox1.Text == "5x5")
            {
                StreamReader sr = new StreamReader("out_num.txt");
                string data;
                for (int i = 0; i < 25; i++)
                {
                    data = sr.ReadLine();
                    buttons_5[i].Text = data;
                }
                sr.Close();
            }
            else if (comboBox1.Text == "6x6")
            {
                StreamReader sr = new StreamReader("out_num.txt");
                string data;
                for (int i = 0; i < 36; i++)
                {
                    data = sr.ReadLine();
                    buttons_6[i].Text = data;
                }
                sr.Close();
            }
            else if (comboBox1.Text == "7x7")
            {
                StreamReader sr = new StreamReader("out_num.txt");
                string data;
                for (int i = 0; i < 49; i++)
                {
                    data = sr.ReadLine();
                    buttons_7[i].Text = data;
                }
                sr.Close();
            }
                StreamReader output = new StreamReader("out.txt");
                StreamReader time_output = new StreamReader("out_time.txt");

                
                time_algorithim = time_output.ReadToEnd();

                time = output.ReadToEnd();
                xx = (int.Parse(time_algorithim) * int.Parse(textBox1.Text));

                Thread.Sleep(xx);
            
                output.Close();
            
            MessageBox.Show("Time for last board " + time + "Click Restart To get new puzzle");
            MessageBox.Show("Total time is " + xx.ToString() + " millisecond ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {

            disable_labels();
            disable_buttons();


            if (comboBox1.Text == "3x3")
            {
                size = 3;
                append_buttons_3();
                for (int i = 0; i < 9; i++)
                {
                    buttons_3[i].Text = "";
                }

                /* Generate Board */
                Board_Generation();

                /* Pick a Senario */
                functions_3[rand.Next(0, 3)]();

                for (int i = 0; i < 9; i++)
                {
                    buttons_3[i].Show();
                }

                Process.Start("keke.exe");

                StreamReader sr = new StreamReader("out_num.txt");
                string data;
                for (int i = 0; i < 9; i++)
                {
                    data = sr.ReadLine();
                    buttons_3[i].Text = "";
                }
                sr.Close();
            }
            else if (comboBox1.Text == "4x4")
            {
                size = 4;
                append_buttons_4();
                for (int i = 0; i < 16; i++)
                {
                    buttons_4[i].Text = "";
                }

                /* Generate Board */
                Board_Generation();

                /* Pick a Senario */
                functions_4[rand.Next(0, 3)]();

                for (int i = 0; i < 16; i++)
                {
                    buttons_4[i].Show();
                }
                Process.Start("keke.exe");

                StreamReader sr = new StreamReader("out_num.txt");
                string data;
                for (int i = 0; i < 16; i++)
                {
                    data = sr.ReadLine();
                    buttons_4[i].Text = "";
                }
                sr.Close();
            }
            else if (comboBox1.Text == "5x5")
            {
                size = 5;
                append_buttons_5();
                for (int i = 0; i < 25; i++)
                {
                    buttons_5[i].Text = "";
                }

                /* Generate Board */
                Board_Generation();

                /* Pick a Senario */
                functions_5[rand.Next(0, 2)]();

                for (int i = 0; i < 25; i++)
                {
                    buttons_5[i].Show();
                }


                Process.Start("keke.exe");

                StreamReader sr = new StreamReader("out_num.txt");
                string data;
                for (int i = 0; i < 25; i++)
                {
                    data = sr.ReadLine();
                    buttons_5[i].Text = "";
                }
                sr.Close();
            }
            else if (comboBox1.Text == "6x6")
            {
                size = 6;
                append_buttons_6();
                for (int i = 0; i < 36; i++)
                {
                    buttons_6[i].Text = "";
                }

                /* Generate Board */
                Board_Generation();

                /* Pick a Senario */
                functions_6[rand.Next(0, 1)]();

                for (int i = 0; i < 36; i++)
                {
                    buttons_6[i].Show();
                }


                Process.Start("keke.exe");

                StreamReader sr = new StreamReader("out_num.txt");
                string data;
                for (int i = 0; i < 36; i++)
                {
                    data = sr.ReadLine();
                    buttons_6[i].Text = "";
                }
                sr.Close();
            }
            else if (comboBox1.Text == "7x7")
            {
                size = 7;
                append_buttons_7();
                for (int i = 0; i < 49; i++)
                {
                    buttons_7[i].Text = "";
                }

                /* Generate Board */
                Board_Generation();

                /* Pick a Senario */
                functions_7[rand.Next(0, 1)]();

                for (int i = 0; i < 49; i++)
                {
                    buttons_7[i].Show();
                }


                Process.Start("keke.exe");

                StreamReader sr = new StreamReader("out_num.txt");
                string data;
                for (int i = 0; i < 49; i++)
                {
                    data = sr.ReadLine();
                    buttons_7[i].Text = "";
                }
                sr.Close();
            }
            MessageBox.Show("Generation Completed Please wait if any Console is running");
        
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }


    
}
