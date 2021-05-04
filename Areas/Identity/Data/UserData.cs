using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TodoListBreeze.Areas.Identity.Data
{
    public class Mission
    {
        [Required(ErrorMessage = "Task can use a good, short name.")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        [StringLength(25, ErrorMessage = "Task needs a title.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Good description will be useful for future reference.")]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        [StringLength(75, ErrorMessage = "Please fill in the form.")]
        public string Description { get; set; }
    }
    // Add profile data for application users by adding properties to the UserData class
    public class UserData : IdentityUser
    {
        public string UserTasks { get; set; }
        public string DisplayUserName { get; set; }
    }
}
