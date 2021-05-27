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

        //user input
        string title = "";
        string creator = "";
        int length = -1;

        //media list
        List<Media> media_list = new List<Media>();

        //media object
        public class Media
        {
            protected string Title;
            public virtual string ToString()
            {
                return "Ingen information.";
            }
        }

        public class Book : Media
        {
            public string Author;
            public int Pages;
            public Book(string title, string author, int pages)
            {
                Title = title;
                Author = author;
                Pages = pages;
            }

            public override string ToString()
            {
                string book_info = "(" + Title + ", " + Author + ", " + Pages + " sidor)";
                return book_info;
            }
        }

        public class Movie : Media
        {
            public string Director;
            public int Length;
            public Movie(string title, string director, int length)
            {
                Title = title;
                Director = director;
                Length = length;
            }

            public override string ToString()
            {
                string book_info = "(" + Title + ", " + Director + ", " + Length + " minuter)";
                return book_info;
            }
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
                    output += " " + media_list[i].ToString();
                }
            } else if (filter == "Book")
            {
                for (int i = 0; i < media_list.Count; i++)
                {
                    if (media_list[i] is Book)
                    {
                        output += " " + media_list[i].ToString();
                    }
                }
            }
            else if (filter == "Movie")
            {
                for (int i = 0; i < media_list.Count; i++)
                {
                    if (media_list[i] is Movie)
                    {
                        output += " " + media_list[i].ToString();
                    }
                }
            }
            return output;
        }

        //function to flush all variables and textboxes
        public void Flush()
        {
            //clear variables
            string title = "";
            string creator = "";
            int length = -1;
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
            if (InputChecker(title, creator, length)) {
                //create book
                media_list.Add(new Book(title, creator, length));
            } else
            {
                this.richTextBox1.Text = "Invalid Input";
            }
            Flush();
        }
        //Bok TextBox: "Titel" 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            title = textBox1.Text;
        }
        //Bok TextBox: "Författare"
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            creator = textBox2.Text;
        }
        //Bok TextBox: "Sidor" 
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                length = int.Parse(textBox3.Text);
            } catch (Exception ex)
            {

            }
        }

    /* MOVIE TAB*/
        //Button: "Lägg till film"
        private void button5_Click(object sender, EventArgs e)
        {
            //check for valid input
            if (InputChecker(title, creator, length))
            {
                //create book
                media_list.Add(new Movie(title, creator, length));
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
            title = textBox4.Text;
        }
        //Film TextBox: "Regissör"
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            creator = textBox5.Text;
        }
        //Film TextBox: "Spellängd"
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                length = int.Parse(textBox6.Text);
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
