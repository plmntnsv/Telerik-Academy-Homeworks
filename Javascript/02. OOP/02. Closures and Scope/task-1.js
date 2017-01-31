/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and ISBN
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 *	Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
	var library = (function () {
		var books = [];
		var categories = [];

		function listBooks(category) {
			if (category !== undefined) {
				return books.filter(b => b.category === category.category);
			}
			return books;
		}

		function addBook(book) {
			if (book.title.length < 2 || book.title.length > 100 || book.category < 2 || book.category > 100) {
				throw "Book title or category out of range name length.";
			}
			if (book.author === "") {
				throw "Book author cannot be empty.";
			}
			if (book.isbn.length < 10 || book.isbn.length > 13) {
				throw "Book ISBN out of range.";
			}
			if (books.some(x => x.title === book.title)) {
				throw "Book with same title exists.";
			}
			if (books.some(x => x.isbn === book.isbn)) {
				throw "Book with same ISBN exists.";
			}
			if (books.every(b => b.category !== book.category)) {
				categories.push(book.category);
			}
			book.ID = books.length + 1;
			books.push(book);
			
			return book;
		}

		function listCategories() {
			return categories;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	}());
	return library;
}
// var book = {
// 	title: 'the good parts',
// 	isbn: '1234567890',
// 	author: 'Crockford',
// 	category: 'programming'
// };
// var book2 = {
// 	title: 'the good parts2',
// 	isbn: '12345678901',
// 	author: 'Crockford',
// 	category: 'programming'
// };

// var library = solve();
// library.books.add(book);
// library.books.add(book2);
// console.log(library.books.list({
// 	category: book.category + (Math.random() * 1000 + '')
// }));

// //console.log(library.books.list());
module.exports = solve;