using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements that are required to connect to DB
using COMP2007_S2016_MidTerm.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace COMP2007_S2016_MidTerm
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time get the data
            if (!IsPostBack)
            {
                // Get the To Do data
                this.GetTodo();
            }
        }
        /**
         * <summary>
         * This method gets the ToDo data from the DB
         * </summary>
         * 
         * @method GetToDo
         * @returns {void}
         */
        protected void GetTodo()
        {
            // populate teh form with existing data from the database
            int todoID = Convert.ToInt32(Request.QueryString["todoID"]);

            // connect to the EF DB
            using (TodoConnection db = new TodoConnection())
            {
                // populate a student object instance with the StudentID from the URL Parameter
                Todo updatedToDo = (from Todo in db.Todos
                                          where Todo.TodoID == todoID
                                          select Todo).FirstOrDefault();

                // map the to do properties to the form controls
                if (updatedToDo != null)
                {
                    NameTextBox.Text = updatedToDo.TodoName;
                    NotesTextBox.Text = updatedToDo.TodoNotes;
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to To do page
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (TodoConnection db = new TodoConnection())
            {
                // use the to do model to create a new to do object and
                // save a new record
                Todo newTodo = new Todo();

                int todoID = 0;

                if (Request.QueryString.Count > 0) // our URL has a todoID in it
                {
                    // get the id from the URL
                    todoID = Convert.ToInt32(Request.QueryString["todoID"]);

                    // get the current to do from EF DB
                    newTodo = (from Todo in db.Todos
                               where Todo.TodoID == todoID
                               select Todo).FirstOrDefault();
                }

                // add form data to the new to do record
                 newTodo.TodoName = NameTextBox.Text;
                 newTodo.TodoNotes = NotesTextBox.Text;

                // use LINQ to ADO.NET to add / insert new to do into the database

                if (todoID == 0)
                {
                    db.Todos.Add(newTodo);
                }


                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated to dos page
                Response.Redirect("~/ToDoList.aspx");
            }
        }
    }
}
