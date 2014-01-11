using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School
{
    interface ICommentable
    {
        //property to be implemented by child classes
        void AddComment(string comment);
        void ViewComments();
    }
}
