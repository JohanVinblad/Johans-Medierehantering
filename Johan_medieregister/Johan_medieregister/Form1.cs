using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Johan_medieregister
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //media object
        public class Media
        {
            public string Type { get; set; }
            public string Title { get; set; }
            public string Creator { get; set; }
            public int Length { get; set; }
            public Media(string type,  string title, string creator, int length)
            {
                Type = type;
                Title = title;
                Creator = creator;
                Length = length;
            }
        }

        //media list
        List<Media> media_list = new List<Media>();

        //book/movie information
        string media_title, media_creator;
        int media_length = 0;

        //function to print media object
        public string ToString(Media media)
        {
            string media_info = "(" + media.Title + ", " + media.Creator + ", " + media.Length + ")";
            return media_info;
        }

        //function to check validity of input
        public bool InputChecker(string title, string creator, int length)
        {
            if ((title != null) && (creator != null) && (length > 0))
            {
                return true;
            } else
            {
                return false;
            }
        }

        //function to print list
        public string PrintList(string filter, List<Media> list)
        {
            string output = "";
            if (filter == "All")
            {
                for (int i = 0; i < media_list.Count; i++)
                {
                    output += " " + ToString(media_list[i]);
                }
            } else if (filter == "Book" || filter == "Movie")
            {
                for (int i = 0; i < media_list.Count; i++)
                {
                    if (media_list[i].Type == filter)
                    {
                        output += " " + ToString(media_list[i]);
                    }
                }
            }
            return output;
        }

        //function to flush all variables and textboxes
        public void Flush()
        {
            //clear variables
            media_title = "";
            media_creator = "";
            media_length = 0;
            //clear textboxes
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
        }


    /* BOOK TAB */
        //Button: "Lägg till bok"
        private void button4_Click(object sender, EventArgs e)
        {
            //check for valid input
            if (InputChecker(media_title, media_creator, media_length)) {
                //create book
                Media media_book = new Media("Book", media_title, media_creator, media_length);
                media_list.Add(media_book);
            } else
            {
                this.richTextBox1.Text = "Invalid Input";
            }
            Flush();
        }
        //Bok TextBox: "Titel" 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            media_title = textBox1.Text;
        }
        //Bok TextBox: "Författare"
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            media_creator = textBox2.Text;
        }
        //Bok TextBox: "Sidor" 
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                media_length = int.Parse(textBox3.Text);
            } catch (Exception ex)
            {

            }
        }

    /* MOVIE TAB*/
        //Button: "Lägg till film"
        private void button5_Click(object sender, EventArgs e)
        {
            //check for valid input
            if (InputChecker(media_title, media_creator, media_length))
            {
                //create book
                Media media_movie = new Media("Movie", media_title, media_creator, media_length);
                media_list.Add(media_movie);
            }
            else
            {
                this.richTextBox1.Text = "Invalid Input";
            }
            Flush();
        }
        //Film TextBox: "Titel"
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            media_title = textBox4.Text;
        }
        //Film TextBox: "Regissör"
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            media_creator = textBox5.Text;
        }
        //Film TextBox: "Spellängd"
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                media_length = int.Parse(textBox6.Text);
            }
            catch (Exception ex)
            {

            }
        }


    /* RADIO BUTTONS */
        //RadioButton: "ALLA"
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.richTextBox1.Text = PrintList("All", media_list);
        }
        //RadioButton: "BÖCKER"
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.richTextBox1.Text = PrintList("Book", media_list);
        }
        //RadioButton: "FILMER"
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.richTextBox1.Text = PrintList("Movie", media_list);
        }


        //Rich Text Box
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
