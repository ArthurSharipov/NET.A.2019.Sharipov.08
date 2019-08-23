using BookTask.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookTask.FindBook
{
    interface IFinder
    {
        Book FindBook();
    }
}
