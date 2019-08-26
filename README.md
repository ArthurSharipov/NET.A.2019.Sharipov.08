# Day - 8
1. Develop the Book class (ISBN, author, title, publisher, year of publication,
number of pages, price), overriding the necessary class methods for it
Object For class objects, implement equivalence and order relations
(using appropriate interfaces). To perform basic operations with
a list of books that can be downloaded and, if necessary,
save to some storage BookListStorage develop class BookListService
(as a service for working with a collection of books) with AddBook functionality (add
a book, if there is no such book, otherwise throw an exception); Removebook
(delete the book, if there is one, otherwise throw an exception);
FindBookByTag (find a book by a given criterion); SortBooksByTag (sort
a list of books by a given criterion); delegates should not be used when implementing!
Demonstrate the operation of classes using the example of a console application.
Use as storage
- a binary file to work with which to use only the BinaryReader classes,
BinaryWriter. The repository may change / be added in the future.
2. Develop a type system to describe work with a bank account. condition
an account is determined by its number, data on the account holder (name, surname), amount
on the account and some bonus points that increase / decrease
each time when replenishing / debiting from the account, the values ​​are different for
replenishment and write-offs and calculated depending on some values
values ​​of the “value” of the balance sheet and the “cost” of replenishment. The value of "value"
balance and “value” of replenishment are integer values ​​and depend
from the gradation of the account, which may be, for example, Base, Gold, Platinum.
To work with the account, implement the following features:
- make a deposit to the account;
- execute debiting from the account;
- create a new account;
- close an account.
Account information is stored in a binary file.
Demonstrate the operation of classes using the example of a console application.
When designing types, consider the following expansion / modification options.
functionality

- adding new types of accounts;
- change / add sources of storage of information about accounts;
- change the logic for calculating bonus points.
