using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    public class SelectDemoController : Controller
    {
        private List<ColorOption> _colorOptions = new List<ColorOption>
        {
            new ColorOption{Id = 1, Color = "Red"},
            new ColorOption{Id = 2, Color = "Orange"},
            new ColorOption{Id = 3, Color = "Green"},
            new ColorOption{Id = 4, Color = "Blue"},
            new ColorOption{Id = 5, Color = "Shiny Yellow"},
            new ColorOption{Id = 6, Color = "Purple Too"},
        };

        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Northwnd;Integrated Security=true;";

        public IActionResult Index()
        {
            return View(new SelectDemoIndexViewModel
            {
                Colors = _colorOptions
            });
        }

        [HttpPost]
        public IActionResult Post(int colorId)
        {
            return View(new SelectPostViewModel
            {
                Color = _colorOptions.FirstOrDefault(c => c.Id == colorId).Color
            });
        }

        public IActionResult EmployeeList()
        {
            NorthwindDb db = new NorthwindDb(_connectionString);
            return View(db.GetEmployees());
        }
    }


 /* Create an application to manage ToDoItems. Each ToDoItem has the following properties:
 * 
 * Title
 * DueDate
 * CompletedDate - nullable (DateTime? completedDate = reader.GetOrNull<DateTime?>("CompletedDate");)
 * CategoryId
 * 
 * Each ToDoItem should be associated with a category. A category looks like this:
 * 
 * Name
 *
 * Here are the pages the application should have:
 * 
 * On the home page, display a list of all Non Completed ToDoItems. Each row of the table
 * should display the Title, DueDate and Category Name of each item. On each row, there
 * should also be a button that says "Mark as completed". When this button is clicked,
 * this item should be marked as complete in the DB and the page should refresh (that item
 * should be gone from the list)
 * 
 * The next page to create is a page that displays a list of all completed items. Each row
 * should display the Title, CompletedDate and Category Name of each item.
 * 
 * The next page to create is a page that displays a list of Categories. Each category
 * should have the Name of the category as well as an edit button. When the edit button
 * is clicked, the user should be taken to a page that displays a textbox prefilled
 * with that category name and an update button. When update is clicked, the user
 * should get taken back to the categories list page. On top of this page, have a button
 * called "Add Category" that when clicked, takes the user to a page where they can add
 * new categories.
 * 
 * Finally, have a page where the user can add new ToDoItems. This page should have
 * a form that has textboxes for name and due date (use type="date"). There should also
 * be a drop down in this form that has all the categories from the database. When the 
 * user submits this form, they should be taken back to the home page.
 * 
 * Some bonus things to play with: 
 * 
 * On the home page, any row that has an item that is overdue should be highlighted in
 * red. (in bootstrap you can add the class of table-danger onto a tr to make it red)
 * 
 * On the categories page, the category name can be a link that takes you to a page
 * that shows you ToDoItems just for that category
 */
}
