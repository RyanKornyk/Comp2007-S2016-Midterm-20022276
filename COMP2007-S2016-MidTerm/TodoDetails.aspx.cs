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
                Todo updatedToDo = (from student in db.Todos
                                          where student.TodoID == todoID
                                          select Todo).FirstOrDefault();

                // map the student properties to the form controls
                if (updatedToDo != null)
                {

                }
            }
        }
    }
}